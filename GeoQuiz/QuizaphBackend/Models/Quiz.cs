using Microsoft.EntityFrameworkCore;
using Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizaphBackend.Models
{
    public class Quiz
    {

        public int CreatorId { get; set; }
        public User Creator { get; set; }
        [Key]
        public int Id { get; set; }
        public int TimesTaken { get; set; } = 0;
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public int? MinPlayers { get; set; }
        public int? MaxPlayers { get; set; }
        public List<string>? Rules { get; set; } = new();
        [Required]
        public string ImagePath { get; set; }
        [Required]
        public QuizCategory QuizCategory { get; set; }
    
        public List<QuizMode> QuizModes { get; set; } = new();
        public QuizType QuizType { get; set; }
        public int QuizTypeId { get; set; }
        public int StarRating { get; set; }
        public string CategoryColor { get; set; }


        public Quiz()
        {
            
        }

        public Quiz(
            int creatorId,
            string title,
            string description,
            string imagePath,
            QuizCategory quizCategory,
            QuizType quizType,
            int quizTypeId,
            int starRating,
            int timesTaken = 0,
            int? minPlayers = null,
            int? maxPlayers = null,
            List<string>? rules = null,
            List<QuizMode>? quizModes = null
        )
        {
            CreatorId = creatorId;
            Title = title;
            Description = description;
            ImagePath = imagePath;
            QuizCategory = quizCategory;
            QuizType = quizType;
            QuizTypeId = quizTypeId;
            StarRating = starRating;
            TimesTaken = timesTaken;
            MinPlayers = minPlayers;
            MaxPlayers = maxPlayers;
            Rules = rules ?? new List<string>();
            QuizModes = quizModes ?? new List<QuizMode> { QuizMode.Standard };
            CategoryColor = GetCategoryColor(quizCategory);
        }

        private string GetCategoryColor(QuizCategory category) => category switch
        {
            QuizCategory.Geography => "#1976D2",
            QuizCategory.Technology => "#6029e7",
            QuizCategory.History => "#8B5E3C",
            QuizCategory.Sports => "#4f9ff3",
            QuizCategory.GeneralKnowledge => "#6fcaaa",
            _ => throw new ArgumentException("Invalid quiz category", nameof(category))
        };
    } 
}
