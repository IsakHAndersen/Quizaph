using Models.Enums;

namespace QuizaphBackend.Models
{
    public class QuizCompletion
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int QuizTypeId { get; set; }
        public QuizModes QuizModes { get; set; }
        public string FastestTime { get; set; }
    }
}
