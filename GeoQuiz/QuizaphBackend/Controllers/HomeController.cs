using CommonModels.Enums;
using CommonModels.QuizCreationModels.QuizManual;
using CommonModels.QuizCreationModels.QuizPrompt;
using GeoQuizBackend.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using QuizaphBackend.Models;
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

        #region Quizzes Endpoints
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
        #endregion 

        #region Quiz Result Endpoints
        [HttpGet("{userId}/quiz-results")]
        public IActionResult GetAllResults(int userId)
        {
            var results = _context.QuizResults
                .Where(r => r.UserId == userId)
                .OrderByDescending(r => r.CreatedAt)
                .ToList();
            return Ok(results);
        }

        [HttpGet("{userId}/completed-quizzes")]
        public IActionResult GetCompletedQuizzes(int userId)
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

        [HttpGet("{userId}/quiz-results/{quizType}/{quizMode}")]
        public IActionResult GetBestQuizResult(int userId, QuizType quizType, QuizMode quizMode)
        {
            var result = _context.QuizResults
                .Where(r => r.UserId == userId && r.QuizType == quizType && r.QuizMode == quizMode)
                .OrderByDescending(r => r.Score)   // <-- best score first
                .ThenByDescending(r => r.CreatedAt) // tie-breaker: latest attempt
                .FirstOrDefault();

            if (result == null)
                return NotFound();

            return Ok(result);
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
        public IActionResult GetQuizRules(int quizId)
        {
            var result = _context.QuizRules.Where(a => a.QuizId == quizId).ToList();
            if (result == null)
                return NotFound($"No quiz rules found for QuizId {quizId}.");
            return Ok(result);
        }
        #endregion

        #region Quiz Dataset Endpoints
        [HttpGet("quiz/{quizId}/datasets")]
        public IActionResult GetQuizDataSets(int quizId)
        {
            var datasets = _context.QuizDatasets
                .Where(ds => ds.QuizId == quizId)
                .ToList(); // returns the full entity objects

            if (!datasets.Any())
                return NotFound($"No datasets found for QuizId {quizId}.");

            return Ok(datasets);
        }

        [HttpGet("quiz/{quizId}/datasets/{datasetId}")]
        public IActionResult GetQuizDataSet(int quizId, int datasetId)
        {
            var dataset = _context.QuizDatasets
                .Include(ds => ds.Questions)
                .FirstOrDefault(ds => ds.QuizId == quizId && ds.Id == datasetId);

            if (dataset == null)
                return NotFound($"No dataset {datasetId} found for QuizId {quizId}.");

            return Ok(dataset);
        }

        [HttpGet("quiz/{quizId}/datasets/{datasetId}/questions")]
        public IActionResult GetQuizQuestions(int quizId, int datasetId)
        {
            var datasetExists = _context.QuizDatasets
                .Any(ds => ds.QuizId == quizId && ds.Id == datasetId);

            if (!datasetExists)
                return NotFound($"No dataset {datasetId} found for QuizId {quizId}.");
            var questions = _context.QuizQuestions
                .Where(q => q.QuizDataSetId == datasetId)
                .ToList();

            return Ok(questions);
        }
        #endregion

    }
}
