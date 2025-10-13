namespace QuizaphBackend.Models
{
    public class QuizDataset
    {
        public int Id { get; set; }
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; } = default!;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<QuizQuestion> Questions { get; set; } = new();
    }
}
