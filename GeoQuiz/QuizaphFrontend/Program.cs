using Microsoft.Extensions.Http.Resilience;
using MudBlazor.Services;
using Polly;
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
            string id = ctx.Principal.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";
            string email = ctx.Principal.FindFirstValue(ClaimTypes.Email) ?? "";
            string picture = ctx.User.GetProperty("picture").GetString() ?? "";

            ctx.Identity?.AddClaim(new Claim("picture", picture));
            ctx.Identity?.AddClaim(new Claim("AppUserId", id));

            // All logged-in users automatically get "Membership"
            ctx.Identity?.AddClaim(new Claim(ClaimTypes.Role, "Membership"));
            return Task.CompletedTask;
        };
    });
builder.Services.AddAuthorization();

// Mudblazor and FontAwesome icons
builder.Services.AddMudServices();

// Your app-specific services
builder.Services.AddScoped<CurrentQuizStateService>();
builder.Services.AddScoped<UserClaimsService>();

builder.Services.AddHttpClient<BackendClient>(
    static client =>
    {
        client.BaseAddress = new("https+http://quizaphbackend");
    });

#pragma warning disable EXTEXP0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
builder.Services
    .AddHttpClient<OpenAIClient>(client =>
    {
        client.BaseAddress = new Uri("https+http://quizaphbackend");
        client.Timeout = Timeout.InfiniteTimeSpan; // Disable HttpClient's own timeout
    })
     .RemoveAllResilienceHandlers()
    // Add a custom pipeline 1. Max Retries 2. Request Timeout Limit 3. Circuit breaker options
    .AddResilienceHandler("OpenAIHandler", builder =>
    {
        builder.AddRetry(new HttpRetryStrategyOptions
        {
            MaxRetryAttempts = 2
        });
        builder.AddTimeout(new HttpTimeoutStrategyOptions
        {
            Timeout = TimeSpan.FromMinutes(2)
        });
        builder.AddCircuitBreaker(new HttpCircuitBreakerStrategyOptions
        {
            MinimumThroughput = 5,
            SamplingDuration = TimeSpan.FromMinutes(5),
            FailureRatio = 0.9
        });
    });
#pragma warning restore EXTEXP0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.


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
