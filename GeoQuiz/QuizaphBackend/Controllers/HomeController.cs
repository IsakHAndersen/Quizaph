using CommonModels.Enums;
using CommonModels.QuizModels;
using GeoQuizBackend.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

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

        #region Quizzes Endpoints
        [HttpGet]
        public IActionResult GetAllQuizzes()
        {
            var quizzes = _context.Quizzes.ToList();
            return Ok(quizzes);
        }

        [HttpGet("{id}")]
        public IActionResult GetQuizById(Guid id)
        {
            var quiz = _context.Quizzes.FirstOrDefault(q => q.Id == id);
            if (quiz == null) return NotFound();
            return Ok(quiz);
        }
        #endregion 
        #region Quiz Result Endpoints
        [HttpPost("quiz-result/create")]
        public IActionResult CreateQuizResult([FromBody] QuizResult quizResult)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                         ?? User.FindFirst("sub")?.Value;
            if (!Guid.TryParse(userId, out var userGuid))
                return Unauthorized();
            quizResult.UserId = userGuid;
            _context.QuizResults.Add(quizResult);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("{userId}/quiz-results")]
        public IActionResult GetAllResults(Guid userId)
        {
            var results = _context.QuizResults
                .Where(r => r.UserId == userId)
                .OrderByDescending(r => r.CreatedAt)
                .ToList();
            return Ok(results);
        }

        [HttpGet("quiz-results")]
        public IActionResult QuizResult()
        {
            var results = _context.QuizResults.AsNoTracking().ToList();
            return Ok(results); 
        }

        [HttpGet("users/{userId}/quiz-results")]
        public IActionResult GetUserQuizResults(Guid userId)
        {
            var results = _context.QuizResults.AsNoTracking()
                .Where(r => r.UserId == userId)
                .OrderByDescending(r => r.CreatedAt)
                .ToList();
            return Ok(results);
        }

        [HttpGet("{userId}/completed-quizzes")]
        public IActionResult GetCompletedQuizzes(Guid userId)
        {
            var completed =  _context.QuizResults
                .Where(r => r.UserId == userId && r.IsCompleted)
                .GroupBy(r => new { r.QuizType, r.QuizMode })
                .Select(g => g.OrderByDescending(r => r.CreatedAt).FirstOrDefault())
                .ToList();
            if (completed == null || !completed.Any())
            {
                return NotFound($"No completed quizzes found for user {userId}.");
            }
            return Ok(completed);
        }

        [HttpGet("quiz-results/{type}/{mode}/best")]
        [Authorize]
        public async Task<ActionResult<QuizResult>> GetBestUserQuizResult(QuizType type, QuizMode mode)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                         ?? User.FindFirst("sub")?.Value;

            if (!Guid.TryParse(userId, out var userGuid))
                return Unauthorized();

            var result = await _context.QuizResults
                .Where(a => a.UserId == userGuid)
                .Where(a => a.QuizType == type)
                .Where(a => a.QuizMode == mode)
                .OrderByDescending(a => a.Score)
                .FirstOrDefaultAsync();
            return result is null ? NotFound() : Ok(result);
        }

        [HttpGet("quiz-stats/{quizType}/{quizMode}")]
        public IActionResult GetQuizStatistics(QuizType quizType, QuizMode quizMode)
        {
            var stats = _context.QuizResults
                .Where(r => r.QuizType == quizType && r.QuizMode == quizMode)
                .GroupBy(r => 1)
                .Select(g => new QuizStatistic
                {
                    Attempts = g.Count(),
                    AverageScore = (int)Math.Round(g.Average(x => (double)x.Score)),
                    AverageScorePercent = Math.Round(
                        g.Average(x => (double)x.Score / x.MaxScore) * 100, 2
                    ),
                    AverageTime = TimeSpan.FromSeconds(
                        Math.Round(
                            g.Average(x => x.TimeTaken.HasValue ? x.TimeTaken.Value.TotalSeconds : 0),
                            0
                        )
),
                    QuizType = quizType,
                    QuizMode = quizMode
                })
                .FirstOrDefault();

            if (stats == null || stats.Attempts == 0)
                return NotFound("No results found for this quiz.");

            return Ok(stats);
        }
        #endregion

        #region Quiz Data Endpoints
        [HttpGet("data/{quizType}/{dataset}")]
        public IActionResult GetQuizData(QuizType quizType, string dataset)
        {
            return null!;
        }
        #endregion

        #region QuizRules Endpoints
        [HttpGet("quiz/{quizId}/rules")]
        public IActionResult GetQuizRules(Guid quizId)
        {
            var result = _context.QuizRules.Where(a => a.QuizId == quizId).ToList();
            if (result == null)
                return NotFound($"No quiz rules found for QuizId {quizId}.");
            return Ok(result);
        }
        #endregion

        #region Quiz Dataset Endpoints
        [HttpGet("quiz/{quiztype}/datasets")]
        public IActionResult GetQuizDataSets(QuizType quiztype)
        {
            var datasets = _context.QuizDatasets
                .Where(ds => ds.QuizType == quiztype)
                .ToList(); // returns the full entity objects

            if (!datasets.Any())
                return NotFound($"No datasets found for quiz type: {quiztype.ToString()}.");

            return Ok(datasets);
        }

        [HttpGet("quiz/{quiztype}/datasets/{datasetId}")]
        public IActionResult GetQuizDataSet(QuizType quiztype, Guid datasetId)
        {
            var dataset = _context.QuizDatasets
                .Include(ds => ds.Questions)
                .FirstOrDefault(ds => ds.QuizType == quiztype && ds.Id == datasetId);

            if (dataset == null)
                return NotFound($"No dataset {datasetId} found for quiz type: {quiztype}.");

            return Ok(dataset);
        }

        [HttpGet("quiz/{quiztype}/datasets/{datasetId}/questions")]
        public IActionResult GetQuizQuestions(QuizType quiztype, Guid datasetId)
        {
            var datasetExists = _context.QuizDatasets
                .Any(ds => ds.QuizType == quiztype && ds.Id == datasetId);

            if (!datasetExists)
                return NotFound($"No dataset {datasetId} found for quiz type: {quiztype}.");

            var questions = _context.QuizQuestions
                .Where(q => q.QuizDataSetId == datasetId)
                .ToList();

            return Ok(questions);
        }
        #endregion
    }
}
