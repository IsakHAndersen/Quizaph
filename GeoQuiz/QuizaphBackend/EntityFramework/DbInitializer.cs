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

            // When new quiz is added these are needed: New QuizType for the type, an imagepath, rules, description and available modes.

            var quizes = new List<Quiz>
            {
                new Quiz
                {
                CreatorId = 1,
                Title = "World Countries Quiz",
                Description = "Test your knowledge of world countries.",
                TimesTaken = 1634,
                MaxPlayers = 1,
                MinPlayers = 1,
                Rules = new List<string> { "Abrevations dont count for many countries", "Completion is reached when all countries are guessed" },
                ImagePath = "/QuizImages.world_resized.jpg",
                QuizCategory = QuizCategory.Geography,
                QuizModes = new List<QuizModes> { QuizModes.Timed, QuizModes.RandomlySelected, QuizModes.Standard, QuizModes.TriviaExpansion},
                QuizType = QuizType.WorldCountriesQuiz,
                StarRating = 4,
                QuizTypeId = 1
                },
                new Quiz
                {
                CreatorId = 1,
                Title = "Europe Countries Quiz",
                Description = "Test your knowledge of european countries.",
                TimesTaken = 1634,
                MaxPlayers = 1,
                MinPlayers = 1,
                Rules = new List<string> { "Abrevations dont count for many countries", "Completion is reached when all countries are guessed" },
                ImagePath = "/images/capitals.png",
                QuizCategory = QuizCategory.Geography,
                QuizModes = new List<QuizModes> { QuizModes.Timed, QuizModes.RandomlySelected, QuizModes.Standard, QuizModes.TriviaExpansion},
                QuizType = QuizType.WorldCountriesQuiz,
                QuizTypeId = 1,
                StarRating = 4
                },
                new Quiz
                {
                CreatorId = 1,
                Title = "Europe Countries Quiz",
                Description = "Test your knowledge of european countries.",
                TimesTaken = 1634,
                MaxPlayers = 1,
                MinPlayers = 1,
                Rules = new List<string> { "Abrevations dont count for many countries", "Completion is reached when all countries are guessed" },
                ImagePath = "/images/capitals.png",
                QuizCategory = QuizCategory.Geography,
                QuizModes = new List<QuizModes> { QuizModes.Timed, QuizModes.RandomlySelected, QuizModes.Standard, QuizModes.TriviaExpansion},
                QuizType = QuizType.WorldCountriesQuiz,
                QuizTypeId = 1,
                StarRating = 4
                },
                new Quiz
                {
                CreatorId = 1,
                Title = "Europe Countries Quiz",
                Description = "Test your knowledge of european countries.",
                TimesTaken = 1634,
                MaxPlayers = 1,
                MinPlayers = 1,
                Rules = new List<string> { "Abrevations dont count for many countries", "Completion is reached when all countries are guessed" },
                ImagePath = "/images/capitals.png",
                QuizCategory = QuizCategory.Geography,
                QuizModes = new List<QuizModes> { QuizModes.Timed, QuizModes.RandomlySelected, QuizModes.Standard, QuizModes.TriviaExpansion},
                QuizType = QuizType.WorldCountriesQuiz,
                QuizTypeId = 1,
                StarRating = 4
                },
                new Quiz
                {
                CreatorId = 1,
                Title = "Europe Countries Quiz",
                Description = "Test your knowledge of european countries.",
                TimesTaken = 1634,
                MaxPlayers = 1,
                MinPlayers = 1,
                Rules = new List<string> { "Abrevations dont count for many countries", "Completion is reached when all countries are guessed" },
                ImagePath = "/images/capitals.png",
                QuizCategory = QuizCategory.Geography,
                QuizModes = new List<QuizModes> { QuizModes.Timed, QuizModes.RandomlySelected, QuizModes.Standard, QuizModes.TriviaExpansion},
                QuizType = QuizType.WorldCountriesQuiz,
                QuizTypeId = 1,
                StarRating = 4
                },
                new Quiz
                {
                CreatorId = 1,
                Title = "Europe Countries Quiz",
                Description = "Test your knowledge of european countries.",
                TimesTaken = 1634,
                MaxPlayers = 1,
                MinPlayers = 1,
                Rules = new List<string> { "Abrevations dont count for many countries", "Completion is reached when all countries are guessed" },
                ImagePath = "/images/capitals.png",
                QuizCategory = QuizCategory.Geography,
                QuizModes = new List<QuizModes> { QuizModes.Timed, QuizModes.RandomlySelected, QuizModes.Standard, QuizModes.TriviaExpansion},
                QuizType = QuizType.WorldCountriesQuiz,
                QuizTypeId = 1,
                StarRating = 4
                },
                new Quiz
                {
                CreatorId = 1,
                Title = "Europe Countries Quiz",
                Description = "Test your knowledge of european countries.",
                TimesTaken = 1634,
                MaxPlayers = 1,
                MinPlayers = 1,
                Rules = new List<string> { "Abrevations dont count for many countries", "Completion is reached when all countries are guessed" },
                ImagePath = "/images/capitals.png",
                QuizCategory = QuizCategory.Geography,
                QuizModes = new List<QuizModes> { QuizModes.Timed, QuizModes.RandomlySelected, QuizModes.Standard, QuizModes.TriviaExpansion},
                QuizType = QuizType.WorldCountriesQuiz,
                QuizTypeId = 1,
                StarRating = 4
                },
                new Quiz
                {
                CreatorId = 1,
                Title = "Europe Countries Quiz",
                Description = "Test your knowledge of european countries.",
                TimesTaken = 1634,
                MaxPlayers = 1,
                MinPlayers = 1,
                Rules = new List<string> { "Abrevations dont count for many countries", "Completion is reached when all countries are guessed" },
                ImagePath = "/images/capitals.png",
                QuizCategory = QuizCategory.Geography,
                QuizModes = new List<QuizModes> { QuizModes.Timed, QuizModes.RandomlySelected, QuizModes.Standard, QuizModes.TriviaExpansion},
                QuizType = QuizType.WorldCountriesQuiz,
                QuizTypeId = 1,
                StarRating = 4
                },
                new Quiz
                {
                CreatorId = 1,
                Title = "Europe Countries Quiz",
                Description = "Test your knowledge of european countries.",
                TimesTaken = 1634,
                MaxPlayers = 1,
                MinPlayers = 1,
                Rules = new List<string> { "Abrevations dont count for many countries", "Completion is reached when all countries are guessed" },
                ImagePath = "/images/capitals.png",
                QuizCategory = QuizCategory.Geography,
                QuizModes = new List<QuizModes> { QuizModes.Timed, QuizModes.RandomlySelected, QuizModes.Standard, QuizModes.TriviaExpansion},
                QuizType = QuizType.WorldCountriesQuiz,
                QuizTypeId = 1,
                StarRating = 4
                },
                new Quiz
                {
                CreatorId = 1,
                Title = "Europe Countries Quiz",
                Description = "Test your knowledge of european countries.",
                TimesTaken = 1634,
                MaxPlayers = 1,
                MinPlayers = 1,
                Rules = new List<string> { "Abrevations dont count for many countries", "Completion is reached when all countries are guessed" },
                ImagePath = "/images/capitals.png",
                QuizCategory = QuizCategory.Geography,
                QuizModes = new List<QuizModes> { QuizModes.Timed, QuizModes.RandomlySelected, QuizModes.Standard, QuizModes.TriviaExpansion},
                QuizType = QuizType.WorldCountriesQuiz,
                QuizTypeId = 1,
                StarRating = 4
                },
                new Quiz
                {
                CreatorId = 1,
                Title = "Europe Countries Quiz",
                Description = "Test your knowledge of european countries.",
                TimesTaken = 1634,
                MaxPlayers = 1,
                MinPlayers = 1,
                Rules = new List<string> { "Abrevations dont count for many countries", "Completion is reached when all countries are guessed" },
                ImagePath = "/images/capitals.png",
                QuizCategory = QuizCategory.Geography,
                QuizModes = new List<QuizModes> { QuizModes.Timed, QuizModes.RandomlySelected, QuizModes.Standard, QuizModes.TriviaExpansion},
                QuizType = QuizType.WorldCountriesQuiz,
                QuizTypeId = 1,
                StarRating = 4
                },
            };      

            context.Quizes.AddRange(quizes);
            context.SaveChanges();
        }
    }
}
