using CommonModels.Enums;

namespace CommonModels.QuizCreationModels.BaseModels
{
    public class CreateQuizBaseClass
    {
        public QuizType QuizType { get; set; }
        public QuizCategory Category { get; set; }
        public string Title { get; set; } = string.Empty;
    }
}
