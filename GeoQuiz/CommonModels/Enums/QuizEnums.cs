
namespace CommonModels.Enums
{
    public enum QuizCategory
    {
        None,
        Geography,
        History,
        Science,
        Literature,
        Art,
        Sports,
        Entertainment,
        Technology,
        GeneralKnowledge,
        Mathematics,
        Language,
        Philosophy,
        Politics,
        Economics,
        Music,
        MoviesAndTV,
        Gaming,
        FoodAndDrink,
        Travel,
        Fashion,
        Mythology,
        Religion,
        Nature,
        Medicine,
        Astronomy,
        Business,
        Riddles,
        CurrentEvents
    }


    [Flags]
    public enum QuizMode
    {
        None = 0,
        Standard = 1 << 0,
        Alphabetical = 1 << 1,
        Practice = 1 << 2,
        Random = 1 << 3,
        Timed = 1 << 4,
        TriviaExpansion = 1 << 5,
        RandomWithLives = 1 << 6,

    }

    public enum Continent
    {
        Africa,
        Antarctica,
        Asia,
        Europe,
        NorthAmerica,
        Oceania,
        SouthAmerica,
        None
    }

    public enum QuizType
    {
        WorldCountriesQuiz,
        TriviaQuiz,
        ImageQuiz,
        TextQuiz,
        MultipleChoiceQuiz,
        TrueFalseQuiz
    }
}
