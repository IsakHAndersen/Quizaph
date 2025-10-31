using CommonModels.QuizCreationModels.QuizManual;
using CommonModels.QuizCreationModels.QuizPrompt;
using CommonModels.QuizModels;
using GeoQuizBackend.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using QuizaphBackend.Services;
using QuizaphBackend.SKInstructions;
using System.Text.Json;

namespace QuizaphBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizCreationController : ControllerBase
    {
        private readonly DBContext _context;
        private readonly SemanticKernelService _semanticKernelService;
        public QuizCreationController(DBContext context, SemanticKernelService semanticKernelService)
        {
            _context = context;
            _semanticKernelService = semanticKernelService;
        }

        [HttpPost("create-trivia-quiz")]
        public async Task<IActionResult> CreateTriviaQuiz([FromBody] CreateTriviaQuiz createTriviaQuiz)
        {
            var quizDataset = new QuizDataset(createTriviaQuiz);
            await _context.QuizDatasets.AddAsync(quizDataset);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("create-trivia-quiz-prompt")]
        public async Task<IActionResult> CreateTriviaQuiz([FromBody] CreateTriviaQuizPrompt request)
        {
            if (request == null)
                return BadRequest("Invalid request");
            try
            {
                var instructions = new TriviaQuizPromptParameters
                {
                    Instruction = request.Instruction,
                    NumberOfQuestions = request.NumberOfQuestions,
                    DifficultyLevel = request.Difficulty
                };
                // Generate questions using Semantic Kernel
                var quizJson = await _semanticKernelService.CreateTriviaQuiz(instructions);

                var quizQuestions = JsonSerializer.Deserialize<List<QuizQuestion>>(quizJson, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                // Create quiz dataset and save to database
                var dataset = new QuizDataset(request.Title, request.Category, request.QuizType, quizQuestions ?? new List<QuizQuestion>());

                _context.QuizDatasets.Add(dataset);
                await _context.SaveChangesAsync();
                return Ok(dataset);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Quiz generation failed: {ex.Message}");
            }
        }

    }
}
