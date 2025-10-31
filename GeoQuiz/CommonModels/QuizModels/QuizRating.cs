
using CommmonModels.UserModels;

namespace CommonModels.QuizModels
{
    public class QuizRating
    {
        public Guid Id { get; set; }
        public Guid QuizId { get; set; }
        public Quiz Quiz { get; set; } = default!;

        public Guid UserId { get; set; }
        public User User { get; set; } = default!;

        public int Stars { get; set; }
        public DateTime RatedAt { get; set; }
    }
}
