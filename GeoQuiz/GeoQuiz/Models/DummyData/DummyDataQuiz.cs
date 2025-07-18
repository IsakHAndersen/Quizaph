using CommonModels.Enums;
using QuizaphFrontend.Models;

public static class DummyDataQuiz
{

    public static async Task<List<QuizInfo>> GetAllQuizes()
    {
        await Task.Delay(100); // Simulate async operation
        return AllQuizzes;
    }

    public static List<QuizInfo> AllQuizzes = new List<QuizInfo>
    {
        new QuizInfo
        {
            Id = 1,
            Title = "Countries Of The World",
            Description = "Test your knowledge of global geography and recognize countries from maps and clues.",
            QuizCategory = QuizCategory.Geography,
            PlayersAvailable = (1, 4),
            QuizModes = new List<QuizModes> { QuizModes.Standard, QuizModes.Random, QuizModes.Alphabetical },
            Rules = new List<string>
            {
                "Rule 1: Identify the country from the given map or question.",
                "Rule 2: You have 30 seconds per question.",
                "Rule 3: No skipping questions."
            },
            ImagePath = "QuizImages/world_resized.jpg",
            QuizType = QuizType.WorldCountriesQuiz,
            QuizTypeId = 1
        },
        new QuizInfo
        {
            Id = 2,
            Title = "Famous Historical Figures",
            Description = "Guess the famous figure based on descriptions, quotes, or photos.",
            QuizCategory = QuizCategory.History,
            PlayersAvailable = (1, 2),
            QuizModes = new List<QuizModes> { QuizModes.Standard, QuizModes.Random },
            Rules = new List<string>
            {
                "Rule 1: Match the name to the description or image.",
                "Rule 2: You must answer before time runs out.",
                "Rule 3: Each correct answer earns points."
            },
            ImagePath = "QuizImages/historical_figures.jpg"
        },
        new QuizInfo
        {
            Id = 3,
            Title = "Car Brand Logos",
            Description = "Identify the brand from its logo — from common to obscure!",
            QuizCategory = QuizCategory.GeneralKnowledge,
            PlayersAvailable = (1, 4),
            QuizModes = new List<QuizModes> { QuizModes.Standard },
            Rules = new List<string>
            {
                "Rule 1: Choose the correct brand name for the logo shown.",
                "Rule 2: Each logo must be answered within 15 seconds.",
                "Rule 3: Hints reduce your score."
            },
            ImagePath = "QuizImages/car_logos.jpg"
        },
        new QuizInfo
        {
            Id = 4,
            Title = "Tech Terminology Quiz",
            Description = "How fluent are you in tech lingo? Match the terms with their definitions.",
            QuizCategory = QuizCategory.Technology,
            PlayersAvailable = (1, 3),
            QuizModes = new List<QuizModes> { QuizModes.Standard },
            Rules = new List<string>
            {
                "Rule 1: Select the correct definition for each tech term.",
                "Rule 2: No external help allowed.",
                "Rule 3: Time limit per round applies."
            },
            ImagePath = "QuizImages/tech_terms.jpg"
        }
    };

    public static QuizInfo QuizInfo => AllQuizzes.First();
}
