using GeoQuizBackend.EntityFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizaphBackend.Models;
using QuizaphBackend.Services;
using System.Text.Json;

namespace QuizaphBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizCreationController : ControllerBase
    {
        private readonly DBContext _context;
        private readonly ISemanticKernelService _semanticKernelService;
        public QuizCreationController(DBContext context, ISemanticKernelService semanticKernelService)
        {
            _context = context;
            _semanticKernelService = semanticKernelService;
        }

        [HttpPost("create-quiz")]
        public async Task<IActionResult> CreateQuiz([FromBody] TriviaQuizStructurePrompt request)
        {
            if (request == null)
                return BadRequest("Invalid request");

            try
            {
                var quizJson = await _semanticKernelService.CreateQuizAsync(
                    "QuizPromptFormats/TriviaQuizPrompt.json.txt",
                    new Dictionary<string, object>
                    {
                        ["quizType"] = request.QuizType.ToString(),
                        ["title"] = request.Title,
                        ["category"] = request.Category.ToString(),
                        ["difficulty"] = request.Difficulty,
                        ["questionAmount"] = request.QuestionAmount,
                        ["instructions"] = request.AdditionalInstructions
                    }
                );

                var quiz = JsonSerializer.Deserialize<TriviaQuizStructurePrompt>(quizJson,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (quiz == null)
                    return StatusCode(500, "Failed to parse quiz JSON");
                await _context.SaveChangesAsync();

                // Return to frontend
                return Ok(quiz);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Quiz generation failed: {ex.Message}");
            }
        }
    }
}
