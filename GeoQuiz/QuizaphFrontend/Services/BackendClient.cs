using CommonModels.Enums;
using CommonModels.QuizCreationModels.QuizManual;
using CommonModels.QuizCreationModels.QuizPrompt;
using CommonModels.QuizModels;
using CommonModels.UserModels;

namespace QuizaphFrontend.Services
{
    public class BackendClient
    {
        private readonly HttpClient _httpClient;

        public BackendClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> RegisterUser(CreateUserDTO createUserDTO)
        {
            return await _httpClient.PostAsJsonAsync("api/users/register", createUserDTO);
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

        public async Task<QuizResult?> GetBestUserQuizResultAsync(Guid userId, QuizType type, QuizMode mode)
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

        public async Task<QuizDataset?> CreateTriviaQuizPrompt(CreateTriviaQuizPrompt createTriviaQuizPrompt)
        {
            var response = await _httpClient.PostAsJsonAsync(
                "api/quizcreation/create-trivia-quiz-prompt",
                createTriviaQuizPrompt
            );

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<QuizDataset>();

            return null;
        }
    }
}
