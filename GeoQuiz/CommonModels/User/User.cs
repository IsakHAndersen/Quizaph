namespace QuizaphBackend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime RegisteredAt { get; set; }
        public ICollection<QuizResult> QuizResults { get; set; } = new List<QuizResult>();
        public List<QuizRating> QuizRatings { get; set; } = new();
        public List<Quiz> Quizzes { get; set; } = new();
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string PasswordSalt { get; set; } = string.Empty;    
    }
}
