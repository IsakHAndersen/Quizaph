using CommonModels.QuizModels;

namespace CommonModels.UserModels
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Username { get; set; } = string.Empty;
        public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;
        public ICollection<QuizResult> QuizResults { get; set; } = new List<QuizResult>();
        public List<QuizRating> QuizRatings { get; set; } = new();
        public List<Quiz> Quizzes { get; set; } = new();
        public string Email { get; set; } = string.Empty;
        public string? PasswordHash { get; set; } = string.Empty;
        public string? PasswordSalt { get; set; } = string.Empty;

        // Email verification
        public bool EmailVerified { get; set; } = false;
        public string? EmailVerificationToken { get; set; }

        // Eternal provider name and id
        public string? ExternalProviderName { get; set; }
        public string? ExternalProviderId { get; set; }

        public User()
        {
            
        }
    }
}
