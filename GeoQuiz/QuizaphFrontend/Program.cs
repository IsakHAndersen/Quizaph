using CommonModels.UserModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components;
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
builder.Services.AddHttpContextAccessor();

builder.Configuration.AddUserSecrets<Program>();



builder.Services.AddHttpClient<BackendClient>(
    static client =>
    {
        client.BaseAddress = new("https+http://quizaphbackend");
    });

builder.Services.AddScoped(sp =>
{
    var nav = sp.GetRequiredService<NavigationManager>();
    return new HttpClient { BaseAddress = new Uri(nav.BaseUri) };
});


#pragma warning disable EXTEXP0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
builder.Services
    .AddHttpClient<OpenAIClient>(client =>
    {
        client.BaseAddress = new Uri("https+http://quizaphbackend");
    })
     .RemoveAllResilienceHandlers()
    // Add a custom pipeline (retry, timeout, circuit breaker)  
    .AddResilienceHandler("OpenAIHandler", builder =>
    {
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


// Authentication and Authorization 
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie("Cookies", options =>
    {
        options.Cookie.Name = ".AspNetCore.Identity.Application";
        options.Cookie.HttpOnly = true;
        options.Cookie.SameSite = SameSiteMode.None;
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
        options.Events.OnTicketReceived = async context =>
        {
            var googleId = context.Principal.FindFirstValue(ClaimTypes.NameIdentifier);
            var email = context.Principal.FindFirstValue(ClaimTypes.Email);
            var name = context.Principal.FindFirstValue(ClaimTypes.Name);
            var picture = context.Principal.FindFirst(claim => claim.Type == "picture")?.Value
                         ?? context.Request.Form["picture"]; // fallback
            if (string.IsNullOrEmpty(googleId) || string.IsNullOrEmpty(email))
            {
                context.Fail("Invalid Google identity.");
                return;
            }
            // Create a DI scope (critical!)
            using var scope = context.HttpContext.RequestServices.CreateScope();
            var services = scope.ServiceProvider;

            // Now resolve the FULL BackendClient with methods
            var backendClient = services.GetRequiredService<BackendClient>();
            var user = await backendClient.FindUserByLogin("Google", googleId);
            if (user == null)
            {
                var userDto = new CreateExternalUserDTO
                {
                    ExternalProviderName = "Google",
                    ExternalProviderId = googleId,
                    Email = email,
                    Name = name ?? "",
                };
                await backendClient.RegisterExternalProvider(userDto);
            };
        };
        options.Events.OnCreatingTicket = context =>
        {
            var picture = context.Identity?.FindFirst("picture")?.Value ??
                          context.User.GetProperty("picture").GetString();
            if (!string.IsNullOrEmpty(picture))
                context.Identity?.AddClaim(new Claim("picture", picture));

            context.Identity?.AddClaim(new Claim(ClaimTypes.Role, "User"));
            return Task.CompletedTask;
        };
    });
builder.Services.AddAuthorization();

// Mudblazor and FontAwesome icons
builder.Services.AddMudServices();

// Your app-specific services
builder.Services.AddScoped<CurrentQuizStateService>();
builder.Services.AddScoped<IAuthService, AuthService>();

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
