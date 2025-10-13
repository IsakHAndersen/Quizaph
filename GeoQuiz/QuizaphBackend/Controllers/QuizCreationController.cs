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
        private readonly ISemanticKernelService _semanticKernelService;
        public QuizCreationController(DBContext context, ISemanticKernelService semanticKernelService)
        {
            _context = context;
            _semanticKernelService = semanticKernelService;
        }

        [HttpPost("create-trivia-quiz")]
        public async Task<IActionResult> CreateTriviaQuiz([FromBody] CreateTriviaQuiz createTriviaQuiz)
        {
            var quiz = new TriviaQuiz
            {
      
            };
            //// Convert manual structure to QuizQuestion entities
            //var correspondingQuizId = DictionariesStaticData.QuizTypeIdValuePairs[QuizType.TriviaQuiz];
            //foreach (var manualQuestion in triviaQuizStructure.Questions)
            //{
            //    var quizQuestion = new QuizQuestion
            //    {
            //        QuizId = triviaQuizStructure.QuizId,
            //        QuestionText = manualQuestion.QuestionText,
            //        Options = manualQuestion.Options,  // Assuming Options is a property
            //        CorrectAnswer = manualQuestion.CorrectAnswer
            //    };
            //    createdQuestions.Add(quizQuestion);
            //    _context.QuizQuestions.Add(quizQuestion);
            //}
            //await _context.SaveChangesAsync();
            return Ok(quiz);
        }

        [HttpPost("create-trivia-quiz-prompt")]
        public async Task<IActionResult> CreateTriviaQuiz([FromBody] CreateTriviaQuizPrompt request)
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
                        ["questionAmount"] = request.NumberOfQuestions,
                        ["instructions"] = request.AdditionalInstructions
                    }
                );

                var quiz = JsonSerializer.Deserialize<TriviaQuiz>(quizJson,
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
