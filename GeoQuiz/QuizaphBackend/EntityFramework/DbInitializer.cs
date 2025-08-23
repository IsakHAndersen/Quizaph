using GeoQuizBackend.EntityFramework;
using Models.Enums;
using QuizaphBackend.Models;

namespace QuizaphBackend.EntityFramework
{
    public static class DbInitializer
    {
        public static void Seed(DBContext context)
        {
            if (context.Quizes.Any())
                return; // DB already seeded

            var quiz1 = new Quiz
            {
                CreatorId = 1,
                Title = "World Capitals Quiz",
                Description = "Test your knowledge of world capitals.",
                TimesTaken = 0,
                MaxPlayers = 4,
                MinPlayers = 1,
                Rules = new List<string> { "No cheating", "Time limit: 60s" },
                ImagePath = "/images/capitals.png",
                QuizCategory = QuizCategory.Geography,
                QuizModes = new List<QuizModes> { QuizModes.Alphabetical, QuizModes.Random },
                QuizType = QuizType.WorldCountriesQuiz,
                QuizTypeId = 1
            };

            var quiz2 = new Quiz
            {
                CreatorId = 2,
                Title = "Math Challenge",
                Description = "Solve tricky math problems.",
                TimesTaken = 0,
                MinPlayers = 1,
                MaxPlayers = 2,
                Rules = new List<string> { "Use pen & paper only" },
                ImagePath = "/images/math.png",
                QuizCategory = QuizCategory.History,
                QuizModes = new List<QuizModes> { QuizModes.Standard },
                QuizType = QuizType.WorldCountriesQuiz,
                QuizTypeId = 2
            };

            var quiz3 = new Quiz
            {
                CreatorId = 2,
                Title = "Math Challenge",
                Description = "Solve tricky math problems.",
                TimesTaken = 0,
                MinPlayers = 1,
                MaxPlayers = 2,
                Rules = new List<string> { "Use pen & paper only" },
                ImagePath = "/images/math.png",
                QuizCategory = QuizCategory.Technology,
                QuizModes = new List<QuizModes> { QuizModes.Standard },
                QuizType = QuizType.WorldCountriesQuiz,
                QuizTypeId = 2
            };

            var quiz4 = new Quiz
            {
                CreatorId = 2,
                Title = "Math Challenge",
                Description = "Solve tricky math problems.",
                TimesTaken = 0,
                MinPlayers = 1,
                MaxPlayers = 2,
                Rules = new List<string> { "Use pen & paper only" },
                ImagePath = "/images/math.png",
                QuizCategory = QuizCategory.Technology,
                QuizModes = new List<QuizModes> { QuizModes.Standard },
                QuizType = QuizType.WorldCountriesQuiz,
                QuizTypeId = 2
            };

            var quiz5 = new Quiz
            {
                CreatorId = 2,
                Title = "Math Challenge",
                Description = "Solve tricky math problems.",
                TimesTaken = 0,
                MaxPlayers = 2,
                MinPlayers = 1,
                Rules = new List<string> { "Use pen & paper only" },
                ImagePath = "/images/math.png",
                QuizCategory = QuizCategory.History,
                QuizModes = new List<QuizModes> { QuizModes.Standard },
                QuizType = QuizType.WorldCountriesQuiz,
                QuizTypeId = 2
            };

            var quiz6 = new Quiz
            {
                CreatorId = 2,
                Title = "Math Challenge",
                Description = "Solve tricky math problems.",
                TimesTaken = 0,
                MaxPlayers = 2,
                MinPlayers = 1,
                Rules = new List<string> { "Use pen & paper only" },
                ImagePath = "/images/math.png",
                QuizCategory = QuizCategory.Geography,
                QuizModes = new List<QuizModes> { QuizModes.Standard },
                QuizType = QuizType.WorldCountriesQuiz,
                QuizTypeId = 2
            };

            context.Quizes.AddRange(quiz1, quiz2);
            context.SaveChanges();
        }
    }
}
