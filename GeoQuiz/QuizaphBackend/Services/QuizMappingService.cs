using CommonModels.QuizCreationModels.QuizPrompt;
using CommonModels.QuizModels;
using System.Text.Json;

namespace QuizaphBackend.Services
{
    public interface IQuizMappingService
    {
        QuizDataset MapTriviaQuizJsonToDataset(string quizJson, CreateTriviaQuizPrompt prompt);
    }

    public class QuizMappingService : IQuizMappingService
    {
        public QuizDataset MapTriviaQuizJsonToDataset(string quizJson, CreateTriviaQuizPrompt prompt)
        {
            if (string.IsNullOrWhiteSpace(quizJson))
                return null!;

            try
            {
                var dataset = JsonSerializer.Deserialize<QuizDataset>(quizJson,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (dataset == null) return null;

                // Fill additional fields that come from the prompt or DB
                dataset.Quiz = new Quiz
                {
                    Title = prompt.Title,
                    QuizCategory = prompt.Category,
                    QuizType = prompt.QuizType,
                    MinPlayers = 1,
                    MaxPlayers = 4
                };

                // Set QuizId in each question (if needed)
                foreach (var question in dataset.Questions)
                {
                    question.QuizDataset = dataset;
                }

                return dataset;
            }
            catch
            {
                return null;
            }
        }
    }

}
