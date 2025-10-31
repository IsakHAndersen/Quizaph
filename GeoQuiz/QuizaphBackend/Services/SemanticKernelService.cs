using CommonModels.QuizCreationModels.QuizPrompt;
using Microsoft.Extensions.AI;
using Microsoft.SemanticKernel;
using QuizaphBackend.SKInstructions;
using System.Text.Json;

public class SemanticKernelService
{
    private readonly Kernel _kernel;
    private readonly IChatClient _chatClient;

    public SemanticKernelService(IConfiguration configuration)
    {
        var apiKey = configuration["OpenAI:Api:Key"]
            ?? throw new ArgumentException("Missing OpenAI:Api:Key in configuration.");
        var modelId = configuration["OpenAI:ModelId"]
            ?? throw new ArgumentException("Missing OpenAI:ModelId in configuration.");

        // Initialize Kernel with OpenAI Chat Client
        _kernel = Kernel.CreateBuilder()
            .AddOpenAIChatClient(modelId, apiKey)
            .Build();

        // Retrieve the IChatClient service
        _chatClient = _kernel.GetRequiredService<IChatClient>();
    }

    public async Task<string> CreateTriviaQuiz(TriviaQuizPromptParameters promptParameters)
    {
        if (promptParameters == null) throw new ArgumentNullException(nameof(promptParameters));

        // Generate JSON schema for QuizDataset
        var quizSchema = GenerateSchema(typeof(CommonModels.QuizModels.QuizQuestion));

        // Build the prompt for the LLM
        var promptText = $"""
            You are a professional quiz creator. Use the following quiz creation object as context to create a new trivia quiz:
            {JsonSerializer.Serialize(promptParameters, new JsonSerializerOptions { WriteIndented = true })}

            Generate an array of questions that follow this .NET model:
            {quizSchema} but only fill in the Difficulty, Question, and CorrectAnswers fields for each question.

            Rules:
            - Produce only valid JSON
            - Prefer more correct answers for each question, example: "What is the river that flows through egypt". Possible answers should not only be nile river, but also just nile. Or if there are very similar ways to spell a answer, example portugese or portuguese
            - Leave the parameters not related to your generation alone. (e.g., Id, QuizId, Title, QuizType and QuizCategory)
            - DifficultyLevel must match the difficulty specified, and generate the number of questions as specified, unless logically impossible
            - Each question must include Question, CorrectAnswers, DifficultyLevel
            - Do not hallucinate properties, only use those defined in the model
            - DifficultyLevel must be an integer from 1 (easy) to 5 (hard)
            - A question may have more than one correct answer if it makes sense
            - Generate the number of questions specified in the prompt, unless the topic logically limits the possible questions (e.g., 'Name the solar system planets')
            - CorrectAnswers must be an array of strings; do not translate answers into other languages 
            """;

        // Call the LLM to generate the quiz JSON
        var response = await _chatClient.GetResponseAsync(new[] { new ChatMessage(ChatRole.User, promptText) });
        return response.Text;
    }

    private static string GenerateSchema(Type type)
    {
        var props = type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
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