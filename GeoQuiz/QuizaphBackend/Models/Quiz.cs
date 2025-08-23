using Models.Enums;

namespace QuizaphBackend.Models
{
    public class Quiz
    {
        public int CreatorId { get; set; } // Foreign key to User
        public int Id { get; set; }
        public int TimesTaken { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? MinPlayers { get; set; }
        public int? MaxPlayers { get; set; }
        public List<string> Rules { get; set; } = new();
        public string ImagePath { get; set; }
        public QuizCategory QuizCategory { get; set; }
        public List<QuizModes> QuizModes { get; set; } = new();
        public QuizType? QuizType { get; set; }
        public int QuizTypeId { get; set; }
    }
}
