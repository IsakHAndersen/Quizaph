using CommonModels.QuizCreationModels.QuizPrompt;
using CommonModels.QuizModels;

namespace QuizaphFrontend.Services
{
    public class OpenAIClient
    {
        private readonly HttpClient _httpClient;

        public OpenAIClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
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
