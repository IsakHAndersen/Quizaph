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

            var quizzes = new List<Quiz>
            {
                new Quiz(1, "World Countries Quiz", "Test your knowledge of world countries.", "/QuizImages/world_resized.jpg", 
                QuizCategory.Religion, 
                QuizType.WorldCountriesQuiz, 
                1, 
                4, 
                1634, 
                1, 
                QuizMode.Timed | QuizMode.RandomWithLives | QuizMode.Standard | QuizMode.TriviaExpansion
                ),
                new Quiz(1, "World Countries Quiz", "Test your knowledge of world countries.", "/QuizImages/world_resized.jpg",
                QuizCategory.Science,
                QuizType.WorldCountriesQuiz,
                1,
                4,
                5000,
                1,
                QuizMode.Timed | QuizMode.RandomWithLives | QuizMode.Standard | QuizMode.TriviaExpansion
                ),
                new Quiz(1, "World Countries Quiz", "Test your knowledge of world countries.", "/QuizImages/world_resized.jpg",
                QuizCategory.Geography,
                QuizType.WorldCountriesQuiz,
                1,
                4,
                1634,
                1,
                QuizMode.Timed | QuizMode.RandomWithLives | QuizMode.Standard | QuizMode.TriviaExpansion
                ),
                new Quiz(1, "World Countries Quiz", "Test your knowledge of world countries.", "/QuizImages/world_resized.jpg",
                QuizCategory.Geography,
                QuizType.WorldCountriesQuiz,
                1,
                4,
                1634,
                1,
                QuizMode.Timed | QuizMode.RandomWithLives | QuizMode.Standard | QuizMode.TriviaExpansion
                ),
                new Quiz(1, "World Countries Quiz", "Test your knowledge of world countries.", "/QuizImages/world_resized.jpg",
                QuizCategory.Geography,
                QuizType.WorldCountriesQuiz,
                1,
                5,
                2000,
                3,
                QuizMode.Timed | QuizMode.RandomWithLives | QuizMode.Standard | QuizMode.TriviaExpansion
                ),
                new Quiz(1, "World Countries Quiz", "Test your knowledge of world countries.", "/QuizImages/world_resized.jpg",
                QuizCategory.History,
                QuizType.MultipleChoiceQuiz,
                1,
                5,
                3000,
                2,
                QuizMode.Timed | QuizMode.RandomWithLives | QuizMode.Standard | QuizMode.TriviaExpansion
                ),
                new Quiz(1, "World Countries Quiz", "Test your knowledge of world countries.", "/QuizImages/world_resized.jpg",
                QuizCategory.GeneralKnowledge,
                QuizType.MultipleChoiceQuiz,
                1,
                4,
                1634,
                1,
                QuizMode.Timed | QuizMode.RandomWithLives | QuizMode.Standard | QuizMode.TriviaExpansion
                ),
            };

            var quizResults = new List<QuizResult>()
            {
                new QuizResult(QuizType.WorldCountriesQuiz, QuizMode.Standard, 1, 100, TimeSpan.FromMinutes(10)),
                new QuizResult(QuizType.WorldCountriesQuiz, QuizMode.Standard, 1, 90, TimeSpan.FromMinutes(12)),
                new QuizResult(QuizType.WorldCountriesQuiz, QuizMode.Standard, 1, 50, TimeSpan.FromMinutes(14)),
                new QuizResult(QuizType.WorldCountriesQuiz, QuizMode.Standard, 1, 50, TimeSpan.FromMinutes(15)),
                new QuizResult(QuizType.WorldCountriesQuiz, QuizMode.Standard, 1, 20, TimeSpan.FromMinutes(11)),
                new QuizResult(QuizType.WorldCountriesQuiz, QuizMode.Standard, 1, 12, TimeSpan.FromMinutes(13)),
                new QuizResult(QuizType.WorldCountriesQuiz, QuizMode.Standard, 1, 10, TimeSpan.FromMinutes(10)),
            };

            var quizRules = new List<QuizRule>
            {
                new QuizRule
                {
                    Id = 1,
                    QuizId = 1,
                    Rule = "Abbreviations dont count for many countries."
                },
                new QuizRule
                {
                    Id = 2,
                    QuizId = 1,
                    Rule = "Micro nations or small island nations are not included in this quiz"
                }
            };

            var users = new List<User>()
            {
                new User
                {
                    Id = 1,
                    RegisteredAt = DateTime.Now,
                    Email = "examplemail@gmail.com",
                    Name = "Isak",
                }
            };

            context.QuizResults.AddRange(quizResults);
            context.Users.AddRange(users);
            context.Quizzes.AddRange(quizzes);

            context.SaveChanges();
        }
    }
}
