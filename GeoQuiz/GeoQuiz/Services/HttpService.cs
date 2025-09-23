using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration.UserSecrets;
using Models.Enums;
using QuizaphFrontend.Models;
using QuizaphFrontend.Models.Quizes;
using System.Net.Http;

namespace QuizaphFrontend.Services
{
    public class HttpService
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

        public async Task<List<Quiz>> GetAllQuizzes()
        {
            var response = await _httpClient.GetAsync("api/quizzes");
            response.EnsureSuccessStatusCode();

            var quizzes = await response.Content.ReadFromJsonAsync<List<Quiz>>();
            return quizzes ?? new List<Quiz>();
        }

        public async Task<List<QuizResult>> GetAllUserQuizResults(int userId)
        {
            var response = await _httpClient.GetAsync($"api/quizzes/{userId}/quiz-results");
            response.EnsureSuccessStatusCode();

            var results = await response.Content.ReadFromJsonAsync<List<QuizResult>>();
            return results ?? new List<QuizResult>();
        }

        public async Task<List<QuizResult>> GetCompletedQuizzes(int userId)
        {
            var response = await _httpClient.GetAsync($"api/quizzes/{userId}/completed-quizzes");
            response.EnsureSuccessStatusCode();

            var completed = await response.Content.ReadFromJsonAsync<List<QuizResult>>();
            return completed ?? new List<QuizResult>();
        }

        public async Task<QuizResult?> GetBestUserQuizResultAsync(int userId, QuizType type, QuizMode mode)
        {
            var response = await _httpClient.GetAsync($"api/quizzes/{userId}/quiz-results/{type}/{mode}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return null;

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<QuizResult>();
        }
        public async Task<QuizStatistic?> GetQuizStatisticsAsync(QuizType type, QuizMode mode)
        {
            var response = await _httpClient.GetAsync($"api/quizzes/quiz-stats/{type}/{mode}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return null;

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<QuizStatistic>();
        }

        public async Task<List<QuizRule>?> GetQuizRules(int quizId)
        {
            var response = await _httpClient.GetAsync($"api/quizzes/quiz/{quizId}/rules");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return null;
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<QuizRule>>();
        }

        public async Task<List<QuizDataset>?> GetQuizDataSets(int quizId)
        {
            var response = await _httpClient.GetAsync($"api/quizzes/quiz/{quizId}/datasets");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return null;

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<QuizDataset>>();
        }

        public async Task<QuizDataset?> GetQuizDataSet(int quizId, int datasetId)
        {
            var response = await _httpClient.GetAsync($"api/quizzes/quiz/{quizId}/datasets/{datasetId}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return null;

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<QuizDataset>();
        }
        public async Task<List<QuizQuestion>?> GetQuizQuestions(int quizId, int datasetId)
        {
            var response = await _httpClient.GetAsync($"api/quizzes/quiz/{quizId}/datasets/{datasetId}/questions");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return null;

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<QuizQuestion>>();
        }
    }
}
