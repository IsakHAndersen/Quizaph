using CommonModels.Enums;
using CommonModels.QuizCreationModels.QuizManual;
using CommonModels.QuizModels;
using CommonModels.UserModels;
using Grpc.Net.Client.Configuration;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using MudBlazor;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace QuizaphFrontend.Services
{
    public class BackendClient
    {
        private readonly HttpClient _httpClient;

        public BackendClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ActionResult> Login(LoginDTO loginRequest)
        {
            var response = await _httpClient.PostAsJsonAsync("api/users/login", loginRequest);
            response.EnsureSuccessStatusCode();
            return new OkResult();
        }
        public async Task<User?> GetUserByEmail(string email)
        {
            var response = await _httpClient
                .GetAsync($"/api/users/by-email?email={Uri.EscapeDataString(email)}");
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return null;
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<User>();
        }

        public async Task<User?> FindUserByLogin(string providerName, string providerId)
        {
            var response = await _httpClient.
                GetAsync($"api/users/by-login?providerName={providerName}&providerId={providerId}"
            );
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return null;
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<User>();
        }

        public async Task<ActionResult> Register(CreateUserDTO createUserDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/users/register", createUserDto);
            response.EnsureSuccessStatusCode();
            return new OkResult();
        }
        public async Task<HttpResponseMessage> RegisterExternalProvider(CreateExternalUserDTO user)
        {
            return await _httpClient.PostAsJsonAsync("api/users/register/external", user);
        }
        public async Task<HttpResponseMessage> ConfirmEmail(Guid userId, string token)
        {
            return await _httpClient.GetAsync(
                $"api/users/confirm-email?userId={userId}&token={Uri.EscapeDataString(token)}"
            );
        }

        public async Task<HttpResponseMessage> ResendVerificationEmail(string email)
        {
            return await _httpClient.PostAsJsonAsync("api/users/resend-verification", new { Email = email });
        }

        public async Task<List<Quiz>> GetAllQuizzes()
        {
            var response = await _httpClient.GetAsync("api/quizzes");
            response.EnsureSuccessStatusCode();

            var quizzes = await response.Content.ReadFromJsonAsync<List<Quiz>>();
            return quizzes ?? new List<Quiz>();
        }


        public async Task<HttpResponseMessage> CreateQuizResult(QuizResult quizResult)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/quizzes/quiz-result/create", quizResult);
            response.EnsureSuccessStatusCode();
            return response;
        }
        public async Task<List<QuizResult>> GetAllUserQuizResults(Guid userId)
        {
            var response = await _httpClient.GetAsync($"api/quizzes/{userId}/quiz-results");
            response.EnsureSuccessStatusCode();

            var results = await response.Content.ReadFromJsonAsync<List<QuizResult>>();
            return results ?? new List<QuizResult>();
        }

        public async Task<List<QuizResult>> GetCompletedQuizzes(Guid userId)
        {
            var response = await _httpClient.GetAsync($"api/quizzes/{userId}/completed-quizzes");
            response.EnsureSuccessStatusCode();

            var completed = await response.Content.ReadFromJsonAsync<List<QuizResult>>();
            return completed ?? new List<QuizResult>();
        }

        public async Task<QuizResult?> GetBestUserQuizResult(QuizType type, QuizMode mode)
        {
            var response = await _httpClient.GetAsync($"api/quizzes/quiz-results/{type}/{mode}/best");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return null;

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                throw new UnauthorizedAccessException("User not authenticated.");

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

        public async Task<List<QuizRule>?> GetQuizRules(Guid quizId)
        {
            var response = await _httpClient.GetAsync($"api/quizzes/quiz/{quizId}/rules");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return null;

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<QuizRule>>();
        }

        public async Task<List<QuizDataset>?> GetQuizDataSets(QuizType quizType)
        {
            var response = await _httpClient.GetAsync($"api/quizzes/quiz/{quizType}/datasets");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return null;

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<QuizDataset>>();
        }

        public async Task<QuizDataset?> GetQuizDataSet(QuizType quizType, Guid datasetId)
        {
            var response = await _httpClient.GetAsync($"api/quizzes/quiz/{quizType}/datasets/{datasetId}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return null;

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<QuizDataset>();
        }

        public async Task<List<QuizQuestion>?> GetQuizQuestions(QuizType quizType, Guid datasetId)
        {
            var response = await _httpClient.GetAsync(
                $"api/quizzes/quiz/{quizType}/datasets/{datasetId}/questions"
            );

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return null;

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<QuizQuestion>>();
        }

        public async Task<bool> CreateTriviaQuiz(CreateTriviaQuiz createTriviaQuiz)
        {
            var response = await _httpClient.PostAsJsonAsync(
                "api/quizcreation/create-trivia-quiz",
                createTriviaQuiz
            );
            return response.IsSuccessStatusCode;
        }
    }
}
