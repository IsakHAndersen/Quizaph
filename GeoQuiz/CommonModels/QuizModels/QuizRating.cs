namespace QuizaphBackend.Models
{
    public class QuizRating
    {
        public int Id { get; set; }
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; } = default!;

        public int UserId { get; set; }
        public User User { get; set; } = default!;

        public int Stars { get; set; }
        public DateTime RatedAt { get; set; }
    }
}
