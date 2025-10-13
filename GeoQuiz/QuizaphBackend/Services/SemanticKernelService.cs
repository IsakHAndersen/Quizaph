using CommonModels.QuizCreationModels.QuizPrompt;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using System.ComponentModel;

namespace QuizaphBackend.Services
{

    public class SemanticKernelService : ISemanticKernelService
    {
        private readonly Kernel _kernel;
        private readonly IConfiguration _configuration;

        private string apiKey;
        private string modelId;


        public SemanticKernelService(IConfiguration configuration)
        {
            _configuration = configuration;

            // Retrieve configuration values
            var modelConfig = _configuration.GetSection($"OpenAICredentials");
            apiKey = modelConfig["apiKey"]!;
            modelId = modelConfig["modelId"]!;

            var builder = Kernel.CreateBuilder();
            builder.Services.AddLogging(services => services.AddConsole().SetMinimumLevel(LogLevel.Trace));
            builder.AddOpenAIChatCompletion(modelId, apiKey!);
            var history = new ChatHistory();
            _kernel = builder.Build();
            OpenAIPromptExecutionSettings openAIPromptExecutionSettings = new()
            {
                FunctionChoiceBehavior = FunctionChoiceBehavior.Auto()
            };
        }

        public async Task CreateTriviaQuiz(CreateTriviaQuizPrompt createTriviaQuizPrompt)
        {
           
           
           
        }

        private static async Task<string> RunPromptAsync(Kernel kernel, string promptPath, Dictionary<string, object> args)
        {
            var prompt = File.ReadAllText(promptPath);
            var func = kernel.CreateFunctionFromPrompt(prompt);
            var result = await kernel.InvokeAsync(func, new KernelArguments(args));
            return result.ToString();
        }

        public Task<string> CreateQuizAsync(string promptPath, Dictionary<string, object> args, string? modelOverride = null)
        {
            throw new NotImplementedException();
        }

        public class TriviaQuizPlugin
        {
            [KernelFunction("create_trivia_quiz")]
            [Description("Creates a trivia quiz from a given topic and difficulty.")]
            public static string CreateQuiz(CreateTriviaQuizPrompt createTriviaQuizPrompt)
                => $"Generate a {createTriviaQuizPrompt.Difficulty} level quiz about {createTriviaQuizPrompt.Category}.";
        }
    }

}
