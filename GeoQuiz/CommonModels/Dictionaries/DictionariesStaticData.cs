using CommonModels.Enums;


namespace QuizaphBackend.Models.Dictionaries
{
    public static class DictionariesStaticData
    {
        public static Dictionary<QuizType, int> QuizTypeIdValuePairs = new Dictionary<QuizType, int>
        {
            { QuizType.WorldCountriesQuiz, 1 },
            { QuizType.TriviaQuiz, 2 },
        };
    }
}
