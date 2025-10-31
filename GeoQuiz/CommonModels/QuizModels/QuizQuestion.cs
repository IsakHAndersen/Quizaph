using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonModels.QuizModels
{
    public class QuizQuestion
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid QuizDataSetId { get; set; }
        public QuizDataset QuizDataset { get; set; } = default!;
        [Required]
        public string Question { get; set; } = string.Empty;
        public List<string> CorrectAnswers { get; set; } = new();

        [NotMapped]
        public bool? IsGuessed { get; set; }
        public string? ImagePath { get; set; }
        public int? DifficultyLevel { get; set; } = 1; // 1 (easy) to 5 (hard)
    }
}
