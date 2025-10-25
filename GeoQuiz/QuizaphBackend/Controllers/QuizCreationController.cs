using CommonModels.QuizCreationModels.QuizManual;
using CommonModels.QuizCreationModels.QuizPrompt;
using CommonModels.QuizModels;
using GeoQuizBackend.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using QuizaphBackend.Services;
using System.Text.Json;

namespace QuizaphBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizCreationController : ControllerBase
    {
        private readonly DBContext _context;
        private readonly SemanticKernelService _semanticKernelService;
        private readonly QuizMappingService _quizMappingService;
        public QuizCreationController(DBContext context, SemanticKernelService semanticKernelService, QuizMappingService quizMappingService)
        {
            _context = context;
            _semanticKernelService = semanticKernelService;
            _quizMappingService = quizMappingService;
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
                // Generate quiz JSON using Semantic Kernel and map into appropriate model, lastly save in db and return dataset.
                var quizJson = await _semanticKernelService.CreateTriviaQuiz(request);

                var quizDataset = _quizMappingService.MapTriviaQuizJsonToDataset(quizJson, request);

                if (quizDataset == null)
                    return StatusCode(500, "Failed to parse quiz JSON");

                _context.QuizDatasets.Add(quizDataset);
                await _context.SaveChangesAsync();
                return Ok(quizDataset);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Quiz generation failed: {ex.Message}");
            }
        }
    }
}
