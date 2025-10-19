using CommonModels.QuizCreationModels.QuizManual;

namespace CommonModels.QuizModels
{
    public class QuizDataset
    {
        public int Id { get; set; }
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; } = default!;
        public string Title { get; set; } = string.Empty;
        public List<QuizQuestion> Questions { get; set; } = new();
        public int MaxScore => Questions?.Count ?? 0;

        public QuizDataset()
        {
            
        }
        public QuizDataset(CreateTriviaQuiz createTriviaQuiz)
        {
            QuizId = QuizStaticData.QuizIdByQuizType[createTriviaQuiz.QuizType];
            Title = createTriviaQuiz.Title;
            Questions = createTriviaQuiz.Questions;
        }
    }
}
