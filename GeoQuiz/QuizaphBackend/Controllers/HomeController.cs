using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;

namespace QuizaphBackend.Controllers
{
    [Route("home")]
    public class HomeController : Controller
    {
        [HttpGet("/RetrieveQuiz")]
        public IActionResult RetrieveQuiz(int quizId)
        {
            return null;
        }

    }
}
