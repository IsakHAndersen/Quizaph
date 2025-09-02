using GeoQuizBackend.EntityFramework;
using Models.Enums;
using QuizaphBackend.Models;

namespace QuizaphBackend.EntityFramework
{
    public static class DbInitializer
    {
        public static void Seed(DBContext context)
        {
            if (context.Quizzes.Any())
                return; // DB already seeded

            // When new quiz is added these are needed: New QuizType for the type, an imagepath, rules, description and available modes.

            var quizzes = new List<Quiz>
            {
                new Quiz(1, "World Countries Quiz", "Test your knowledge of world countries.", "/QuizImages/world_resized.jpg", 
                QuizCategory.Geography, 
                QuizType.WorldCountriesQuiz, 
                1, 
                4, 
                1634, 
                1, 
                1, 
                new List<string> { "Abbreviations don't count for many countries", "Completion is reached when all countries are guessed" }, 
                new List<QuizMode> { QuizMode.Timed, QuizMode.RandomlySelected, QuizMode.Standard, QuizMode.TriviaExpansion }),
                new Quiz(1, "World Countries Quiz", "Test your knowledge of world countries.", "/QuizImages/world_resized.jpg",
                QuizCategory.Geography,
                QuizType.WorldCountriesQuiz,
                1,
                4,
                1634,
                1,
                1,
                new List<string> { "Abbreviations don't count for many countries", "Completion is reached when all countries are guessed" },
                new List<QuizMode> { QuizMode.Timed, QuizMode.RandomlySelected, QuizMode.Standard, QuizMode.TriviaExpansion }),
                new Quiz(1, "World Countries Quiz", "Test your knowledge of world countries.", "/QuizImages/world_resized.jpg",
                QuizCategory.Geography,
                QuizType.WorldCountriesQuiz,
                1,
                4,
                1634,
                1,
                1,
                new List<string> { "Abbreviations don't count for many countries", "Completion is reached when all countries are guessed" },
                new List<QuizMode> { QuizMode.Timed, QuizMode.RandomlySelected, QuizMode.Standard, QuizMode.TriviaExpansion }),
                new Quiz(1, "World Countries Quiz", "Test your knowledge of world countries.", "/QuizImages/world_resized.jpg",
                QuizCategory.Geography,
                QuizType.WorldCountriesQuiz,
                1,
                4,
                1634,
                1,
                1,
                new List<string> { "Abbreviations don't count for many countries", "Completion is reached when all countries are guessed" },
                new List<QuizMode> { QuizMode.Timed, QuizMode.RandomlySelected, QuizMode.Standard, QuizMode.TriviaExpansion }),
                new Quiz(1, "World Countries Quiz", "Test your knowledge of world countries.", "/QuizImages/world_resized.jpg",
                QuizCategory.Geography,
                QuizType.WorldCountriesQuiz,
                1,
                4,
                1634,
                1,
                1,
                new List<string> { "Abbreviations don't count for many countries", "Completion is reached when all countries are guessed" },
                new List<QuizMode> { QuizMode.Timed, QuizMode.RandomlySelected, QuizMode.Standard, QuizMode.TriviaExpansion }),
                new Quiz(1, "World Countries Quiz", "Test your knowledge of world countries.", "/QuizImages/world_resized.jpg",
                QuizCategory.Geography,
                QuizType.WorldCountriesQuiz,
                1,
                4,
                1634,
                1,
                1,
                new List<string> { "Abbreviations don't count for many countries", "Completion is reached when all countries are guessed" },
                new List<QuizMode> { QuizMode.Timed, QuizMode.RandomlySelected, QuizMode.Standard, QuizMode.TriviaExpansion }),
                new Quiz(1, "World Countries Quiz", "Test your knowledge of world countries.", "/QuizImages/world_resized.jpg",
                QuizCategory.Geography,
                QuizType.WorldCountriesQuiz,
                1,
                4,
                1634,
                1,
                1,
                new List<string> { "Abbreviations don't count for many countries", "Completion is reached when all countries are guessed" },
                new List<QuizMode> { QuizMode.Timed, QuizMode.RandomlySelected, QuizMode.Standard, QuizMode.TriviaExpansion }),
                new Quiz(1, "World Countries Quiz", "Test your knowledge of world countries.", "/QuizImages/world_resized.jpg",
                QuizCategory.Geography,
                QuizType.WorldCountriesQuiz,
                1,
                4,
                1634,
                1,
                1,
                new List<string> { "Abbreviations don't count for many countries", "Completion is reached when all countries are guessed" },
                new List<QuizMode> { QuizMode.Timed, QuizMode.RandomlySelected, QuizMode.Standard, QuizMode.TriviaExpansion }),
                new Quiz(1, "World Countries Quiz", "Test your knowledge of world countries.", "/QuizImages/world_resized.jpg",
                QuizCategory.Geography,
                QuizType.WorldCountriesQuiz,
                1,
                4,
                1634,
                1,
                1,
                new List<string> { "Abbreviations don't count for many countries", "Completion is reached when all countries are guessed" },
                new List<QuizMode> { QuizMode.Timed, QuizMode.RandomlySelected, QuizMode.Standard, QuizMode.TriviaExpansion }),
                new Quiz(1, "World Countries Quiz", "Test your knowledge of world countries.", "/QuizImages/world_resized.jpg",
                QuizCategory.Geography,
                QuizType.WorldCountriesQuiz,
                1,
                4,
                1634,
                1,
                1,
                new List<string> { "Abbreviations don't count for many countries", "Completion is reached when all countries are guessed" },
                new List<QuizMode> { QuizMode.Timed, QuizMode.RandomlySelected, QuizMode.Standard, QuizMode.TriviaExpansion }),
                new Quiz(1, "World Countries Quiz", "Test your knowledge of world countries.", "/QuizImages/world_resized.jpg",
                QuizCategory.Geography,
                QuizType.WorldCountriesQuiz,
                1,
                4,
                5000,
                1,
                1,
                new List<string> { "Abbreviations don't count for many countries", "Completion is reached when all countries are guessed" },
                new List<QuizMode> { QuizMode.Timed, QuizMode.RandomlySelected, QuizMode.Standard, QuizMode.TriviaExpansion }),
                new Quiz(1, "World Countries Quiz", "Test your knowledge of world countries.", "/QuizImages/world_resized.jpg",
                QuizCategory.Geography,
                QuizType.WorldCountriesQuiz,
                1,
                4,
                1634,
                1,
                1,
                new List<string> { "Abbreviations don't count for many countries", "Completion is reached when all countries are guessed" },
                new List<QuizMode> { QuizMode.Timed, QuizMode.RandomlySelected, QuizMode.Standard, QuizMode.TriviaExpansion }),
                new Quiz(1, "World Countries Quiz", "Test your knowledge of world countries.", "/QuizImages/world_resized.jpg",
                QuizCategory.Geography,
                QuizType.WorldCountriesQuiz,
                1,
                4,
                1634,
                1,
                1,
                new List<string> { "Abbreviations don't count for many countries", "Completion is reached when all countries are guessed" },
                new List<QuizMode> { QuizMode.Timed, QuizMode.RandomlySelected, QuizMode.Standard, QuizMode.TriviaExpansion }),
                new Quiz(1, "World Countries Quiz", "Test your knowledge of world countries.", "/QuizImages/world_resized.jpg",
                QuizCategory.Geography,
                QuizType.WorldCountriesQuiz,
                1,
                5,
                2000,
                3,
                4,
                new List<string> { "Abbreviations don't count for many countries", "Completion is reached when all countries are guessed" },
                new List<QuizMode> { QuizMode.Timed, QuizMode.RandomlySelected, QuizMode.Standard, QuizMode.TriviaExpansion }),
                new Quiz(1, "World Countries Quiz", "Test your knowledge of world countries.", "/QuizImages/world_resized.jpg",
                QuizCategory.History,
                QuizType.MultipleChoiceQuiz,
                1,
                5,
                3000,
                2,
                4,
                new List<string> { "Abbreviations don't count for many countries", "Completion is reached when all countries are guessed" },
                new List<QuizMode> { QuizMode.Timed, QuizMode.RandomlySelected, QuizMode.Standard, QuizMode.TriviaExpansion }),
                new Quiz(1, "World Countries Quiz", "Test your knowledge of world countries.", "/QuizImages/world_resized.jpg",
                QuizCategory.GeneralKnowledge,
                QuizType.MultipleChoiceQuiz,
                1,
                4,
                1634,
                1,
                1,
                new List<string> { "Abbreviations don't count for many countries", "Completion is reached when all countries are guessed" },
                new List<QuizMode> { QuizMode.Timed, QuizMode.RandomlySelected, QuizMode.Standard, QuizMode.TriviaExpansion }),
            };

            var quizCompletions = new List<QuizCompletion>()
            {
                new QuizCompletion
                {
                    FastestTime = "10:01",
                    Id = 1,
                    QuizMode = QuizMode.Standard,
                    QuizType = QuizType.MultipleChoiceQuiz,
                    UserId = 1,
                }
            };


            var users = new List<User>()
            {
                new User
                {
                    Id = 1,
                    DateRegistered = DateTime.Now,
                    Email = "examplemail@gmail.com",
                    Name = "Isak",
                }
            };

            context.QuizCompletions.AddRange(quizCompletions);
            context.Users.AddRange(users);
            context.Quizzes.AddRange(quizzes);

            context.SaveChanges();
        }
    }
}
