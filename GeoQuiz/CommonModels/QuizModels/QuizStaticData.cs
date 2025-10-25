
using CommonModels.Enums;
using System.Collections;

namespace CommonModels.QuizModels
{
    public static class QuizStaticData
    {
        public static readonly Dictionary<QuizType, int> QuizMaxScores = new()
        {
            { QuizType.WorldCountriesQuiz, 195 },
            { QuizType.TriviaQuiz, 0 }, // or dynamically set later
        };
        public static int GetMaxScore(QuizType quizType)
        {
            if (!QuizMaxScores.TryGetValue(quizType, out var maxScore))
            {
                throw new ArgumentException(
                    $"No max score is defined for quiz type '{quizType}'. " +
                    "Please add it to StaticData.QuizMaxScores if neccessary."
                );
            }

            return maxScore;
        }

        public static readonly Dictionary<QuizType, int> QuizIdByQuizType = new()
        {
            { QuizType.WorldCountriesQuiz, 1 },
            { QuizType.TriviaQuiz, 2 },
        };
    }

}
