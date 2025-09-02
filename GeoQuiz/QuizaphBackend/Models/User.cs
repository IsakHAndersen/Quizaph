using QuizaphBackend.Models.QuizResults;

namespace QuizaphBackend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<QuizResult> QuizResults { get; set; } = new List<QuizResult>();
        public DateTime DateRegistered { get; set; }
        
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string PasswordSalt { get; set; } = string.Empty;    
    }
}
