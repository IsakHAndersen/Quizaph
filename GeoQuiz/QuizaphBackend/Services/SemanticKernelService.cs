using Microsoft.SemanticKernel;

namespace QuizaphBackend.Services
{

    public class SemanticKernelService : ISemanticKernelService
    {
        private readonly Kernel _kernel;
        private readonly IConfiguration _configuration;
        private readonly string _defaultModel;

        public SemanticKernelService(IConfiguration configuration)
        {
            _configuration = configuration;
            _defaultModel = configuration["OpenAI:defaultModel"] ?? "gpt-3.5-turbo";

            var modelConfig = configuration.GetSection($"OpenAI:models:{_defaultModel}");

            var apiKey = modelConfig["apiKey"];
            var modelId = _defaultModel;
            var endpoint = modelConfig["endpoint"];

            var builder = Kernel.CreateBuilder();

            // Standard OpenAI (not Azure)
            builder.AddOpenAIChatCompletion(modelId, apiKey);

            _kernel = builder.Build();
        }

        public async Task<string> CreateQuizAsync(string promptPath, Dictionary<string, object> args, string? modelOverride = null)
        {
            if (!string.IsNullOrEmpty(modelOverride) && modelOverride != _defaultModel)
            {
                var modelConfig = _configuration.GetSection($"OpenAI:models:{modelOverride}");
                var apiKey = modelConfig["apiKey"];
                var endpoint = modelConfig["endpoint"];

                var builder = Kernel.CreateBuilder();
                builder.AddOpenAIChatCompletion(modelOverride, apiKey);
                var kernelOverride = builder.Build();

                return await RunPromptAsync(kernelOverride, promptPath, args);
            }

            return await RunPromptAsync(_kernel, promptPath, args);
        }

        private static async Task<string> RunPromptAsync(Kernel kernel, string promptPath, Dictionary<string, object> args)
        {
            var prompt = File.ReadAllText(promptPath);
            var func = kernel.CreateFunctionFromPrompt(prompt);

            var result = await kernel.InvokeAsync(func, new KernelArguments(args));

            return result.ToString();
        }
    }

}
