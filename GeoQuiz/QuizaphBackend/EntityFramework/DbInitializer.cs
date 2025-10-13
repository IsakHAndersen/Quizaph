using CommmonModels.UserModels;
using CommonModels.Enums;
using CommonModels.QuizModels;
using GeoQuizBackend.EntityFramework;

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
                new Quiz
                {
                    UserId = 1,
                    Title = "World Countries Quiz",
                    Description = "Test your knowledge of world countries. Try various modes to test different areas or start with practice mode to get going.",
                    ImagePath = "/QuizImages/WorldCountriesQuizImage.jpg",
                    QuizCategory = QuizCategory.Geography,
                    QuizType = QuizType.WorldCountriesQuiz,
                    MinPlayers = 1,
                    MaxPlayers = 4,
                    TimesTaken = 1634,
                    StarRating = 1,
                    QuizModes = QuizMode.Timed | QuizMode.RandomWithLives | QuizMode.Standard | QuizMode.Practice
                },
                new Quiz
                {
                    UserId = 1,
                    Title = "Trivia Quiz",
                    Description = "Test your knowledge on various topics",
                    ImagePath = "/QuizImages/TriviaQuizImage.jpg",
                    QuizCategory = QuizCategory.GeneralKnowledge,
                    QuizType = QuizType.TriviaQuiz,
                    MinPlayers = 1,
                    MaxPlayers = 4,
                    TimesTaken = 5000,
                    StarRating = 1,
                    QuizModes = QuizMode.Standard,
                }
            };

            var quizDatasets = new List<QuizDataset>()
            {
                new QuizDataset
                {
                    Id = 1,
                    QuizId = 2,
                    Name = "World War 2 Trivia",
                    Description = "25 Questions based on World War 2.",
                },
                new QuizDataset
                {
                    Id = 2,
                    QuizId = 2,
                    Name = "Movies Trivia",
                    Description = "25 Questions based on Movies.",
                   
                },
                new QuizDataset
                {
                    Id = 3,
                    QuizId = 2,
                    Name = "Mythical Creatures Trivia",
                    Description = "25 Questions about dragons, unicorns, and legends from around the world.",
                },
            };

            var quizQuestions = new List<QuizQuestion>
            {
                new QuizQuestion
                {
                    Id = 6,
                    QuizDataSetId = 2,
                    Question = "Who directed the movie 'Jurassic Park' (1993)?",
                    CorrectAnswers = new List<string> { "Steven Spielberg" },
                    DifficultyLevel = 1
                },
                new QuizQuestion
                {
                    Id = 7,
                    QuizDataSetId = 2,
                    Question = "Which movie features the quote 'I'll be back'?",
                    CorrectAnswers = new List<string> { "The Terminator", "Terminator" },
                    DifficultyLevel = 1
                },
                new QuizQuestion
                {
                    Id = 8,
                    QuizDataSetId = 2,
                    Question = "Who played Jack Dawson in 'Titanic' (1997)?",
                    CorrectAnswers = new List<string> { "Leonardo DiCaprio" },
                    DifficultyLevel = 1
                },
                new QuizQuestion
                {
                    Id = 9,
                    QuizDataSetId = 2,
                    Question = "True or False: 'The Godfather' was released in 1972.",
                    CorrectAnswers = new List<string> { "True" },
                    DifficultyLevel = 2
                },
                new QuizQuestion
                {
                    Id = 10,
                    QuizDataSetId = 2,
                    Question = "Which movie won the Academy Award for Best Picture in 2020?",
                    CorrectAnswers = new List<string> { "Parasite" },
                    DifficultyLevel = 3
                },
                new QuizQuestion
                {
                    Id = 1,
                    QuizDataSetId = 1,
                    Question = "In which year did World War 2 begin?",
                    CorrectAnswers = new List<string> { "1939" },
                    DifficultyLevel = 1
                },
                new QuizQuestion
                {
                    Id = 2,
                    QuizDataSetId = 1,
                    Question = "Who was the Prime Minister of the United Kingdom for most of World War 2?",
                    CorrectAnswers = new List<string> { "Winston Churchill" },
                    DifficultyLevel = 2
                },
                new QuizQuestion
                {
                    Id = 3,
                    QuizDataSetId = 1,
                    Question = "Which country was invaded by Germany on September 1, 1939?",
                    CorrectAnswers = new List<string> { "Poland" },
                    DifficultyLevel = 2
                },
                new QuizQuestion
                {
                    Id = 4,
                    QuizDataSetId = 1,
                    Question = "True or False: The attack on Pearl Harbor brought the United States into World War 2.",
                    CorrectAnswers = new List<string> { "True" },
                    DifficultyLevel = 1
                },
                new QuizQuestion
                {
                    Id = 5,
                    QuizDataSetId = 1,
                    Question = "What was the codename for the Allied invasion of Normandy in 1944?",
                    CorrectAnswers = new List<string> { "Operation Overlord", "D-Day" },
                    DifficultyLevel = 3
                }   
            };

            var mythCreaturesQuizQuestions = new List<QuizQuestion>()
            {
                new QuizQuestion
                {
                    Id = 11,
                    QuizDataSetId = 3,
                    Question = "What mythical creature breathes fire and is often depicted guarding treasure?",
                    CorrectAnswers = new List<string> { "Dragon" },
                    DifficultyLevel = 1
                },
                new QuizQuestion
                {
                    Id = 12,
                    QuizDataSetId = 3,
                    Question = "What is the name of the horse with a single horn on its forehead?",
                    CorrectAnswers = new List<string> { "Unicorn" },
                    DifficultyLevel = 1
                },
                new QuizQuestion
                {
                    Id = 13,
                    QuizDataSetId = 3,
                    Question = "In Greek mythology, who was half man and half bull?",
                    CorrectAnswers = new List<string> { "Minotaur" },
                    DifficultyLevel = 2
                },
                new QuizQuestion
                {
                    Id = 14,
                    QuizDataSetId = 3,
                    Question = "What bird is said to rise from its own ashes after burning?",
                    CorrectAnswers = new List<string> { "Phoenix" },
                    DifficultyLevel = 2
                },
                new QuizQuestion
                {
                    Id = 15,
                    QuizDataSetId = 3,
                    Question = "What sea creature is known for luring sailors to their deaths with song?",
                    CorrectAnswers = new List<string> { "Siren", "Mermaid" },
                    DifficultyLevel = 3
                },
                new QuizQuestion
                {
                    Id = 16,
                    QuizDataSetId = 3,
                    Question = "Which Norse serpent encircles the world?",
                    CorrectAnswers = new List<string> { "Jormungandr", "Midgard Serpent" },
                    DifficultyLevel = 3
                },
                new QuizQuestion
                {
                    Id = 17,
                    QuizDataSetId = 3,
                    Question = "What creature from Japanese folklore is a mischievous shapeshifting fox?",
                    CorrectAnswers = new List<string> { "Kitsune" },
                    DifficultyLevel = 3
                },
                new QuizQuestion
                {
                    Id = 18,
                    QuizDataSetId = 3,
                    Question = "What Scottish lake is said to be home to a mysterious monster?",
                    CorrectAnswers = new List<string> { "Loch Ness Monster", "Nessie" },
                    DifficultyLevel = 2
                },
                new QuizQuestion
                {
                    Id = 19,
                    QuizDataSetId = 3,
                    Question = "In Slavic folklore, what house spirit is often mischievous and hairy?",
                    CorrectAnswers = new List<string> { "Domovoi" },
                    DifficultyLevel = 4
                },
                new QuizQuestion
                {
                    Id = 20,
                    QuizDataSetId = 3,
                    Question = "Which creature is part lion, part goat, and part serpent?",
                    CorrectAnswers = new List<string> { "Chimera" },
                    DifficultyLevel = 3
                },
                new QuizQuestion
                {
                    Id = 21,
                    QuizDataSetId = 3,
                    Question = "What is the name of the giant one-eyed creatures from Greek mythology?",
                    CorrectAnswers = new List<string> { "Cyclops", "Cyclopes" },
                    DifficultyLevel = 2
                },
                new QuizQuestion
                {
                    Id = 22,
                    QuizDataSetId = 3,
                    Question = "Which winged horse sprang from the blood of Medusa?",
                    CorrectAnswers = new List<string> { "Pegasus" },
                    DifficultyLevel = 2
                },
                new QuizQuestion
                {
                    Id = 23,
                    QuizDataSetId = 3,
                    Question = "What creature is said to suck the blood of goats in Latin American folklore?",
                    CorrectAnswers = new List<string> { "Chupacabra" },
                    DifficultyLevel = 2
                },
                new QuizQuestion
                {
                    Id = 24,
                    QuizDataSetId = 3,
                    Question = "Which mythological guardian has the body of a lion and the head of a human?",
                    CorrectAnswers = new List<string> { "Sphinx" },
                    DifficultyLevel = 2
                },
                new QuizQuestion
                {
                    Id = 25,
                    QuizDataSetId = 3,
                    Question = "What mythical creature is half eagle and half lion?",
                    CorrectAnswers = new List<string> { "Griffin", "Gryphon" },
                    DifficultyLevel = 2
                }
            };



            var quizResults = new List<QuizResult>
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
                    QuizId = 1,
                    Rule = "Abbreviations are not included for most countries."
                },
                new QuizRule
                {
                    QuizId = 1,
                    Rule = "Guess all the countries to complete the quiz and earn the corresponding badge."
                },
                new QuizRule
                {
                    QuizId = 1,
                    Rule = "Blue circles represent small countries or island nations."
                },
            };

            var users = new List<User>
            {
                new User
                {
                    Id = 1,
                    RegisteredAt = DateTime.Now,
                    Email = "examplemail@gmail.com",
                    Name = "Isak",
                }
            };

            context.QuizRules.AddRange(quizRules);
            context.QuizResults.AddRange(quizResults);
            context.Users.AddRange(users);
            context.Quizzes.AddRange(quizzes);
            context.QuizDatasets.AddRange(quizDatasets);
            context.QuizQuestions.AddRange(quizQuestions);
            context.QuizQuestions.AddRange(mythCreaturesQuizQuestions);
            context.SaveChanges();
        }
    }
}
