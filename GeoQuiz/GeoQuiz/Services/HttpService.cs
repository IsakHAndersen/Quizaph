using Microsoft.AspNetCore.Components;
using Models.Enums;
using QuizaphFrontend.Models;
using QuizaphFrontend.Models.Quizes;
using System.Net.Http;

namespace QuizaphFrontend.Services
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _httpClient;

        public HttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task LoginAsync(string returnUrl = "/")
        {
            var url = $"/account/login?returnUrl={Uri.EscapeDataString(returnUrl)}";
            // For login, usually you want to redirect the browser, not fetch
            //var absoluteUrl = new Uri(_httpClient.BaseAddress, url).ToString();
            //_navigationManager.NavigateTo(absoluteUrl, forceLoad: true);
        }

        public async Task LogoutAsync()
        {
            //await _httpClient.GetAsync("/account/logout");
        }
        public async Task<List<QuizCompletion>> GetUserCompletedQuizzes(int userId)
        {
            var response = await _httpClient.GetAsync($"api/users/{userId}/completed-quizzes");
            response.EnsureSuccessStatusCode();

            var quizzes = await response.Content.ReadFromJsonAsync<List<QuizCompletion>>();
            return quizzes ?? new List<QuizCompletion>();
        }

        public async Task<List<Quiz>> GetAllQuizzes()
        {
            var response = await _httpClient.GetAsync("api/quizzes");
            response.EnsureSuccessStatusCode();

            var quizzes = await response.Content.ReadFromJsonAsync<List<Quiz>>();
            return quizzes ?? new List<Quiz>();
        }
    }
}
