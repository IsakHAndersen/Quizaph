using Microsoft.Extensions.Configuration.UserSecrets;
using Models.Enums;

namespace QuizaphBackend.Models
{
    public class QuizResult
    {
        // Primary key for each attempt
        public int Id { get; set; }


        // Foreign key to user
        public User User { get; set; } = default!;
        public int UserId { get; set; } 

        // Quiz info
        public QuizType QuizType { get; set; }
        public QuizMode QuizMode { get; set; }

        // Attributes
        public bool IsCompleted { get; set; }
        public int Score { get; set; }
        public int MaxScore { get; set; }
        public TimeSpan? TimeTaken { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public QuizResult() { }

        public QuizResult(QuizType quizType, QuizMode quizMode, int userId, int score, TimeSpan? timeTaken)
        {
            QuizType = quizType;
            QuizMode = quizMode;
            UserId = userId;
            Score = score;
            MaxScore = StaticData.QuizMaxScores[QuizType];
            TimeTaken = timeTaken;
            CreatedAt = DateTime.UtcNow;
            IsQuizCompleted();
        }
         
        private void IsQuizCompleted() 
        {
            if (Score == MaxScore) 
            {
                IsCompleted = true;
            } 
            else 
            {
                IsCompleted = false;
            }
        }
    }

}
