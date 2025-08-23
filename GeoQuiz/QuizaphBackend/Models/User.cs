namespace QuizaphBackend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<QuizCompletion> QuizCompletions { get; set; } = new List<QuizCompletion>();
        public DateTime DateRegistrered { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
    }
}
