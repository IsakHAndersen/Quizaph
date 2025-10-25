using MudBlazor.Services;
using QuizaphFrontend.Components;
using QuizaphFrontend.Services;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Configuration
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddControllers();


builder.Configuration.AddUserSecrets<Program>();

// Authentication and Authorization 
builder.Services.AddAuthentication("Cookies")
    .AddCookie("Cookies", options =>
    {
        options.Cookie.HttpOnly = true;
        options.Cookie.SameSite = SameSiteMode.Strict;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        options.LoginPath = "/auth/google-login";
        options.LogoutPath = "/auth/logout";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
        options.SlidingExpiration = true;
    })
    .AddGoogle("Google", options =>
    {
        options.ClientId = builder.Configuration["OAuth:Google:Id"] ?? throw new InvalidOperationException("Google ClientId not configured.");
        options.ClientSecret = builder.Configuration["OAuth:Google:Secret"] ?? throw new InvalidOperationException("Google ClientSecret not configured.");
        options.SaveTokens = true;
        options.Scope.Add("profile");
        options.Scope.Add("email");
        options.Events.OnCreatingTicket = ctx =>
        {
            string picuri = ctx.User.GetProperty("picture").GetString() ?? "";
            ctx.Identity?.AddClaim(new Claim("picture", picuri));
            return Task.CompletedTask;
        };
    });
builder.Services.AddAuthorization();

// Mudblazor and FontAwesome icons
builder.Services.AddMudServices();

// Your app-specific services
builder.Services.AddScoped<CurrentQuizStateService>();
builder.Services.AddScoped<UserClaimsService>();
//builder.Services.AddScoped<BackendClient>();

//builder.Services.AddScoped(sp =>
//{
//    var baseAddress = builder.Configuration["ServiceAdresses:QuizaphBackend"]
//                     ?? throw new InvalidOperationException("QuizaphBackend base address not configured.");
//    return new HttpClient { BaseAddress = new Uri(baseAddress) };
//});

builder.Services.AddHttpClient<BackendClient>(
    static client => client.BaseAddress = new("https+http://quizaphbackend"));

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseAntiforgery();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
app.Run();
