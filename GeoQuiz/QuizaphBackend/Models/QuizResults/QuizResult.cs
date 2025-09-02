using Microsoft.Extensions.Configuration.UserSecrets;
using Models.Enums;

namespace QuizaphBackend.Models.QuizResults
{
    public class QuizResult
    {
        // Composite primary key of quiztype quizmode and userId
        public QuizType QuizType { get; set; }
        public QuizMode QuizMode { get; set; }
        public int UserId { get; set; }


        // Used for EF to properly map relations
        public User User { get; set; }


        // Attributes
        public bool IsCompleted { get; set; }
        public int Score { get; set; }
        public int TotalQuestions { get; set; }
        public TimeSpan? TimeTaken { get; set; }

        public QuizResult()
        {
           
        }

        public QuizResult(QuizType quizType, QuizMode quizMode, int userId, int score, TimeSpan timeTaken)
        {
            QuizType = quizType;
            QuizMode = quizMode;
            UserId = userId;
            Score = score;
            TimeTaken = timeTaken;
        }

    }
}
