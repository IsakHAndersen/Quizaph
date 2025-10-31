using CommonModels.QuizModels;

namespace CommmonModels.UserModels
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime RegisteredAt { get; set; }
        public ICollection<QuizResult> QuizResults { get; set; } = new List<QuizResult>();
        public List<QuizRating> QuizRatings { get; set; } = new();
        public List<Quiz> Quizzes { get; set; } = new();
        public string? Email { get; set; } = string.Empty;
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

        public static User CreateLocalUser(string email, string passwordHash, string passwordSalt)
        {
            return new User
            {
                Email = email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                RegisteredAt = DateTime.UtcNow
            };
        }
        public static User CreateExternalUser(string providerName, string providerId)
        {
            return new User
            {
                ExternalProviderName = providerName,
                ExternalProviderId = providerId,
                RegisteredAt = DateTime.UtcNow
            };
        }
    }
}
