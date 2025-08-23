using GeoQuizBackend.EntityFramework;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;

namespace QuizaphBackend.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class HomeController : Controller
    {
        private readonly DBContext _context;
        public HomeController(DBContext context)
        {
            _context = context;
        }

        // GET: /home/quizzes
        [HttpGet("quizzes")]
        public IActionResult GetAllQuizzes()
        {
            var quizzes = _context.Quizes.ToList();
            return Ok(quizzes);
        }

        // GET: /home/quizzes/5
        [HttpGet("quizzes/{quizId}")]
        public IActionResult GetQuizById(int quizId)
        {
            var quiz = _context.Quizes.FirstOrDefault(q => q.Id == quizId);

            if (quiz == null)
                return NotFound();

            return Ok(quiz);
        }


    }
}
