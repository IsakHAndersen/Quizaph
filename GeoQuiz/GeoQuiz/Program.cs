global using QuizaphBackend.Models;
global using Microsoft.AspNetCore.Authentication.Google;
using MudBlazor.Services;
using QuizaphFrontend.Components;
using QuizaphFrontend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Mudblazor and FontAwesome icons
builder.Services.AddMudServices();

// Your app-specific services
builder.Services.AddScoped<CurrentQuizStateService>();
builder.Services.AddScoped<UserClaimsService>();
builder.Services.AddScoped<AuthService>();

// Base HttpClient
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5274/") });

// HttpService that attaches JWT per request
builder.Services.AddScoped<HttpService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
app.Run();
