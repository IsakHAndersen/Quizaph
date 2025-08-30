using GeoQuizBackend.EntityFramework;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("/api/users/{userId}/completed-quizzes")]
        public IActionResult GetCompletedQuizzesByUserId(int userId)
        {
            var completions = _context.QuizCompletions
                .Where(a => a.UserId == userId)
                .ToList();

            if (!completions.Any()) return NotFound();
            return Ok(completions);
        }

    }
}
