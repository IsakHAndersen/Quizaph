using Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizaphBackend.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = default!;
        public int TimesTaken { get; set; } = 0;
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        public int? MinPlayers { get; set; }
        public int? MaxPlayers { get; set; }
        public List<QuizRule> Rules { get; set; } = new();
        [Required]
        public string ImagePath { get; set; } = string.Empty;
        [Required]
        public QuizCategory QuizCategory { get; set; }
        public List<QuizResult> QuizResults { get; set; } = new();
        public List<QuizRating> QuizRatings { get; set; } = new();
        public QuizMode QuizModes { get; set; } = QuizMode.None;
        public QuizType QuizType { get; set; }
        public int StarRating { get; set; }
        public Quiz()
        {
            
        }

        public Quiz(
        int userId,
        string title,
        string description,
        string imagePath,
        QuizCategory category,
        QuizType type,
        int? minPlayers,
        int? maxPlayers,
        int timesTaken,
        int starRating,
        QuizMode quizModes) 
        {
            UserId = userId;
            Title = title;
            Description = description;
            ImagePath = imagePath;
            QuizCategory = category;
            QuizType = type;
            MinPlayers = minPlayers;
            MaxPlayers = maxPlayers;
            TimesTaken = timesTaken;
            StarRating = starRating;
            QuizModes = quizModes;
        }
    }

}
