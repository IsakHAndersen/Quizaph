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
                // Call SK to generate quiz JSON
                var quizJson = await _semanticKernelService.CreateQuizAsync(
                    "Prompts/TriviaQuizPrompt.txt",
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

                // Deserialize JSON into your model
                var quiz = JsonSerializer.Deserialize<TriviaQuizStructurePrompt>(quizJson,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (quiz == null)
                    return StatusCode(500, "Failed to parse quiz JSON");

                // (Optional) Save to DB if you want persistence
                // _context.TriviaQuizzes.Add(quiz);
                // await _context.SaveChangesAsync();

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
