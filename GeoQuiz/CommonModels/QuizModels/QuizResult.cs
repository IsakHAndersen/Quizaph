using CommmonModels.UserModels;
using CommonModels.Enums;
using System.ComponentModel.DataAnnotations;

namespace CommonModels.QuizModels
{
    public class QuizResult
    {
        // Primary key for each attempt
        public Guid Id { get; set; }


        // Foreign key to user
        public User User { get; set; } = default!;
        public Guid UserId { get; set; } 

        // Quiz info
        public QuizType QuizType { get; set; }
        public QuizMode QuizMode { get; set; }
        public bool IsCompleted { get; set; }
        public int Score { get; set; }
        public int MaxScore { get; set; }
        public TimeSpan? TimeTaken { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public QuizResult() { }

        public QuizResult(QuizType quizType, QuizMode quizMode, Guid userId, int score, TimeSpan? timeTaken, int maxScore)
        {
            QuizType = quizType;
            QuizMode = quizMode;
            UserId = userId;
            Score = score;
            TimeTaken = timeTaken;
            CreatedAt = DateTime.UtcNow;
            MaxScore = maxScore;
            IsCompleted = IsQuizCompleted();
        }
         
        private bool IsQuizCompleted() 
        {
            if (Score == MaxScore) 
            {
                return true;
            }
            return false;
        }
    }

}
