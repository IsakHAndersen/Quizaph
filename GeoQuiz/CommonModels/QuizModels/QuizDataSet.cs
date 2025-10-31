using CommonModels.Enums;
using CommonModels.QuizCreationModels.QuizManual;

namespace CommonModels.QuizModels
{
    public class QuizDataset
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public List<QuizQuestion> Questions { get; set; } = new List<QuizQuestion>();
        public int MaxScore => Questions?.Count ?? 0;
        public QuizCategory QuizCategory { get; set; }
        public QuizType QuizType { get; set; }

        public QuizDataset()
        {
            
        }
        public QuizDataset(string title, QuizCategory quizCategory, QuizType quizType, List<QuizQuestion> quizQuestions)
        {
            Title = title;
            QuizCategory = quizCategory;
            QuizType = quizType;
            quizQuestions.ForEach(q =>
                {
                    q.QuizDataSetId = Id;
                    q.QuizDataset = this;
                }
            );
            Questions = quizQuestions;
        }

        public QuizDataset(CreateTriviaQuiz createTriviaQuiz)
        {
            QuizType = createTriviaQuiz.QuizType;
            QuizCategory = createTriviaQuiz.Category;
            Title = createTriviaQuiz.Title;
            createTriviaQuiz.Questions.ForEach(q =>
            {
                q.QuizDataSetId = Id;
                q.QuizDataset = this;
            }
            );
            Questions = createTriviaQuiz.Questions;
        }
    }
}
