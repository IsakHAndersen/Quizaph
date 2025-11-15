using CommonModels.UserModels;
using CommonModels.Enums;
using System.ComponentModel.DataAnnotations;

namespace CommonModels.QuizModels
{
    public class Quiz
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; } = default!;
        public int TimesTaken { get; set; } = 0;
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        public int? MinPlayers { get; set; }
        public int? MaxPlayers { get; set; }
        public List<QuizRule>? QuizRules { get; set; } = new();
        [Required]
        public string ImagePath { get; set; } = string.Empty;
        [Required]

        // Only set category for quiztypes that are not versatile eg. CountriesOfTheWorld
        public QuizCategory QuizCategory { get; set; } = QuizCategory.GeneralKnowledge;
        public List<QuizResult> QuizResults { get; set; } = new();
        public List<QuizRating> QuizRatings { get; set; } = new();
        public QuizMode QuizModes { get; set; } = QuizMode.None;
        public QuizType QuizType { get; set; }
        public int StarRating { get; set; }
        public List<QuizDataset> QuizDataSets { get; set; } = new();
        public Quiz()
        {
            
        }

        public Quiz(
        Guid userId,
        string title,
        string description,
        string imagePath,
        QuizCategory category,
        QuizType type,
        int? minPlayers,
        int? maxPlayers,
        int timesTaken,
        int starRating,
        QuizMode quizModes,
        List<QuizDataset> dataSets) 
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
            QuizDataSets = dataSets;
        }
    }

}
