using CommonModels.QuizCreationModels.QuizPrompt;
using CommonModels.QuizModels;
using Microsoft.SemanticKernel;
using System.ComponentModel;
using System.Reflection;
using System.Text.Json;

namespace QuizaphBackend.SKPlugins
{
    public class TriviaQuizPlugin
    {
        [KernelFunction("create_trivia_quiz")]
        [Description("Creates a trivia quiz in JSON format compatible with QuizDataset and QuizQuestion models.")]
        public static string CreateTriviaQuiz(CreateTriviaQuizPrompt prompt)
        {
            var quizSchema = GenerateSchema(typeof(QuizDataset));
            var promptJson = JsonSerializer.Serialize(prompt, new JsonSerializerOptions { WriteIndented = true });

            return $"""
            You are a professional quiz creator. Use the following quiz creation object as context:
            {promptJson}
            Generate a trivia quiz that conforms to the structure of this .NET model:

            {quizSchema}

            Rules:
            - Produce **only valid JSON** that matches this structure.
            - Each question must include a `Question`, `CorrectAnswers`, and `DifficultyLevel`.
            - The quiz `Name` should reflect the topic, and `Description` should summarize it.
            - Respect difficulty only when it logically applies.
            """;
        }

        private static string GenerateSchema(Type type)
        {
            var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var schema = props.ToDictionary(
                p => p.Name,
                p =>
                {
                    if (p.PropertyType.IsGenericType &&
                        p.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
                    {
                        var elementType = p.PropertyType.GetGenericArguments()[0];
                        return $"List<{elementType.Name}>";
                    }

                    return p.PropertyType.Name;
                });

            return JsonSerializer.Serialize(schema, new JsonSerializerOptions { WriteIndented = true });
        }
    }
}
