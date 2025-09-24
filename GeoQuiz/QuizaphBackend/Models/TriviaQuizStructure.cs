using Models.Enums;

namespace QuizaphBackend.Models
{
    public class TriviaQuizStructureManual : QuizBaseClass
    {
        public List<Question> Questions { get; set; } = new();
        public string Title { get; set; } = string.Empty;
    }

    public class TriviaQuizStructurePrompt : QuizBaseClass
    {
        public string Title { get; set; } = string.Empty;
        public int Difficulty { get; set; } 
        public string AdditionalInstructions { get; set; } = string.Empty;
        public int QuestionAmount { get; set; }
    }
    public class QuizBaseClass
    {
        public QuizType QuizType { get; set; }
        public QuizCategory Category { get; set; }
    }


    public class Question
    {
        public string Text { get; set; } = "";
        public List<string> Answers { get; set; } = new();
    }
}
