using Models.Enums;

namespace QuizaphBackend.Models
{
    public class QuizCompletion
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public QuizType QuizType { get; set; }
        public QuizMode QuizMode { get; set; }
        public string FastestTime { get; set; }
    }
}
