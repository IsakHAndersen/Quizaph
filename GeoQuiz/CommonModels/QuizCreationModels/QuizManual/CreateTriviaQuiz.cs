using CommonModels.QuizCreationModels.BaseModels;
using CommonModels.QuizModels;

namespace CommonModels.QuizCreationModels.QuizManual
{
    public class CreateTriviaQuiz : CreateQuizBaseClass
    {
        public List<QuizQuestion> Questions { get; set; } = new();
    }
}
