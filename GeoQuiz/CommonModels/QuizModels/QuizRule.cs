namespace QuizaphBackend.Models
{
    public class QuizRule
    {
        public int Id { get; set; }
        public int QuizId { get; set; }
        public string Rule { get; set; } = string.Empty;

        public Quiz Quiz { get; set; } = null!;

        public QuizRule()
        {
            
        }
    }
}
