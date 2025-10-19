using CommonModels.QuizCreationModels.QuizPrompt;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using QuizaphBackend.SKPlugins;
using System.Text.Json;

namespace QuizaphBackend.Services
{
    public class SemanticKernelService
    {
        private readonly Kernel _kernel;
        private readonly IConfiguration _configuration;
        private readonly string _apiKey;
        private readonly string _modelId;

        public SemanticKernelService(IConfiguration configuration)
        {
            _configuration = configuration;

            _apiKey = _configuration["OpenAI:Api:Key"]
                ?? throw new ArgumentException("Missing OpenAI:Api:Key in configuration.");

            _modelId = _configuration["OpenAI:ModelId"]
                ?? throw new ArgumentException("Missing OpenAI:ModelId in configuration.");


            var builder = Kernel.CreateBuilder();
            builder.Services.AddLogging(services =>
                services.AddConsole().SetMinimumLevel(LogLevel.Information));
                builder.AddOpenAIChatCompletion(_modelId, _apiKey);
            builder.Plugins.AddFromType<TriviaQuizPlugin>("TriviaQuizPlugin");

            _kernel = builder.Build();
        }

        public async Task<string> CreateTriviaQuiz(CreateTriviaQuizPrompt createTriviaQuizPrompt)
        {
            if (!_kernel.Plugins.TryGetPlugin("TriviaQuizPlugin", out var plugin))
                throw new InvalidOperationException("TriviaQuizPlugin not registered in kernel.");

            var function = plugin["create_trivia_quiz"];

            var arguments = new KernelArguments
            {
                ["category"] = createTriviaQuizPrompt.Category.ToString(),
                ["title"] = createTriviaQuizPrompt.Title,
                ["numberOfQuestions"] = createTriviaQuizPrompt.NumberOfQuestions,
                ["difficulty"] = createTriviaQuizPrompt.Difficulty,
                ["instructions"] = createTriviaQuizPrompt.Instruction
            };

            var result = await _kernel.InvokeAsync(function, arguments);
            return result.GetValue<string>() ?? string.Empty;
        }
    }
}
