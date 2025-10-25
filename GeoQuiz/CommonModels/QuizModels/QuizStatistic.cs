using CommonModels.Enums;

namespace CommonModels.QuizModels
{
    public class QuizStatistic
    {
        public int Attempts { get; set; }
        public int AverageScore { get; set; }
        public double AverageScorePercent {  get; set; }
        public TimeSpan AverageTime { get; set; }
        public QuizType QuizType { get; set; }
        public QuizMode QuizMode { get; set; } 
    }
}
