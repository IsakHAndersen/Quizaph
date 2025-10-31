namespace CommonModels.QuizModels
{
    public class QuizRule
    {
        public Guid Id { get; set; }
        public Guid QuizId { get; set; }
        public string Rule { get; set; } = string.Empty;

        public Quiz Quiz { get; set; } = null!;

        public QuizRule()
        {
            
        }
    }
}
