using CommonModels.Enums;
namespace QuizaphFrontend.Services
{
    public class HttpQuizDataService
    {
        private readonly HttpClient _httpClient;

        public HttpQuizDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<T> GetQuizData<T>(QuizType type, string dataset)
        {
            var response = await _httpClient.GetAsync($"api/quizzes/data/{type}/{dataset}");
            response.EnsureSuccessStatusCode();

            var quizzes = await response.Content.ReadFromJsonAsync<T>();
            return quizzes ?? default!;
        }
    }
}
