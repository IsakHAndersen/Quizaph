
using CommonModels.Enums;

namespace CommonModels.QuizModels
{
    public static class StaticData
    {
        public static Dictionary<QuizType, int> QuizMaxScores { get; set; } = new Dictionary<QuizType, int>
        {
            { QuizType.WorldCountriesQuiz, 100 },
            { QuizType.ImageQuiz, 80 },
            { QuizType.TextQuiz, 60 },
            { QuizType.MultipleChoiceQuiz, 50 },
            { QuizType.TrueFalseQuiz, 40 }
        };
    }
}
