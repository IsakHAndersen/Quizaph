using CommonModels.QuizCreationModels.QuizPrompt;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

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
            var modelConfig = configuration.GetSection($"OpenAICredentials");
            apiKey = modelConfig["apiKey"]!;
            modelId = modelConfig["modelId"]!;

            var builder = Kernel.CreateBuilder();

            // Standard OpenAI (not Azure)
            builder.AddOpenAIChatCompletion(modelId, apiKey!);

            _kernel = builder.Build();
        }

        public async Task CreateTriviaQuiz(CreateTriviaQuizPrompt createTriviaQuizPrompt)
        {

            var builder = Kernel.CreateBuilder();
            builder.Services.AddLogging(services => services.AddConsole().SetMinimumLevel(LogLevel.Trace));
            

            builder.AddOpenAIChatCompletion(modelOverride, apiKey);
            var kernelOverride = builder.Build();

            return await RunPromptAsync(kernelOverride, promptPath, args);
            return await RunPromptAsync(_kernel, promptPath, args);
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
    }

}
