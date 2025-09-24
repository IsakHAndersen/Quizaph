using System.ComponentModel.DataAnnotations;

namespace QuizaphBackend.Models
{
    public class QuizQuestion
    {
        public int Id { get; set; }
        public int QuizDataSetId { get; set; }
        public QuizDataset QuizDataset { get; set; } = default!;
        [Required]
        public string Question { get; set; } = string.Empty;
        public List<string> CorrectAnswers { get; set; } = new();
        public bool? IsGuessed { get; set; }
        public string? ImagePath { get; set; }
        public int? DifficultyLevel { get; set; } = 1; // 1 (easy) to 5 (hard)
    }
}
