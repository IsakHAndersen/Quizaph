using CommonModels.Enums;
using CommonModels.QuizCreationModels.QuizManual;
using CommonModels.QuizCreationModels.QuizPrompt;
using CommonModels.QuizModels;

namespace QuizaphFrontend.Services
{
    public class HttpService
    {
        private readonly HttpClient _httpClient;

        public HttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;           
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

        public async Task<TriviaQuiz?> CreateTriviaQuiz(CreateTriviaQuiz createTriviaQuiz)
        {
            var response = await _httpClient.PostAsJsonAsync(
                "api/quizzes/create/trivia-quiz/manual", createTriviaQuiz
            );
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<TriviaQuiz>();
            }
            else { return null; }
        }

        public async Task<TriviaQuiz?> CreateTriviaQuizPrompt(CreateTriviaQuizPrompt createTriviaQuizPrompt)
        {
            var response = await _httpClient.PostAsJsonAsync(
                "api/QuizCreation/create-quiz",
                createTriviaQuizPrompt
            );
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<TriviaQuiz>();
            }
            else { return null; } 
        }
    }
}
