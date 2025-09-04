using GeoQuizBackend.EntityFramework;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using Models.Enums;
using QuizaphBackend.Models.QuizResults;
using System.Data.Entity;

namespace QuizaphBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuizzesController : ControllerBase
    {
        private readonly DBContext _context;
        public QuizzesController(DBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllQuizzes()
        {
            var quizzes = _context.Quizzes.ToList();
            return Ok(quizzes);
        }

        [HttpGet("{id}")]
        public IActionResult GetQuizById(int id)
        {
            var quiz = _context.Quizzes.FirstOrDefault(q => q.Id == id);
            if (quiz == null) return NotFound();
            return Ok(quiz);
        }

        [HttpGet("{userId}/quiz-results")]
        public async Task<ActionResult<IEnumerable<QuizResult>>> GetAllResults(int userId)
        {
            var results = await _context.QuizResults
                .Where(r => r.UserId == userId)
                .OrderByDescending(r => r.CreatedAt)
                .ToListAsync();

            return Ok(results);
        }

        [HttpGet("{userId}/completed-quizzes")]
        public async Task<ActionResult<IEnumerable<QuizResult>>> GetCompletedQuizzes(int userId)
        {
            var completed = await _context.QuizResults
                .Where(r => r.UserId == userId && r.IsCompleted)
                .GroupBy(r => new { r.QuizType, r.QuizMode })
                .Select(g => g.OrderByDescending(r => r.CreatedAt).FirstOrDefault())
                .ToListAsync();

            return Ok(completed);
        }

        [HttpGet("{userId}/quiz-results/{quizType}/{quizMode}")]
        public async Task<ActionResult<QuizResult?>> GetBestQuizResult(int userId, QuizType quizType, QuizMode quizMode)
        {
            var result = await _context.QuizResults
                .Where(r => r.UserId == userId && r.QuizType == quizType && r.QuizMode == quizMode)
                .OrderByDescending(r => r.Score)   // <-- best score first
                .ThenByDescending(r => r.CreatedAt) // tie-breaker: latest attempt
                .FirstOrDefaultAsync();

            if (result == null)
                return NotFound();

            return Ok(result);
        }

    }
}
