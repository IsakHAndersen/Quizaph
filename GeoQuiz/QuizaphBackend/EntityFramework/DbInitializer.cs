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

            var userId = Guid.NewGuid();
            var quiz1Id = Guid.NewGuid();
            var quiz2Id = Guid.NewGuid();

            var quizzes = new List<Quiz>
            {
                new Quiz
                {
                    Id = quiz1Id,
                    UserId = userId,
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
                    Id = quiz2Id,
                    UserId = userId,
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

            var quizDataset1Id = Guid.NewGuid();
            var quizDataset2Id = Guid.NewGuid();
            var quizDataset3Id = Guid.NewGuid();

            var quizDatasets = new List<QuizDataset>
            {
                new QuizDataset
                {
                    Id = quizDataset1Id,
                    QuizType = QuizType.TriviaQuiz,
                    Title = "World War 2 Trivia",
                },
                new QuizDataset
                {
                    Id = quizDataset2Id,
                    QuizType = QuizType.TriviaQuiz,
                    Title = "Movies Trivia",
                },
                new QuizDataset
                {
                    Id = quizDataset3Id,
                    QuizType = QuizType.TriviaQuiz,
                    Title = "Mythical Creatures Trivia",
                },
            };

            var quizQuestions = new List<QuizQuestion>
            {
                new QuizQuestion
                {
                    Id = Guid.NewGuid(),
                    QuizDataSetId = quizDataset2Id,
                    Question = "Who directed the movie 'Jurassic Park' (1993)?",
                    CorrectAnswers = new List<string> { "Steven Spielberg" },
                    DifficultyLevel = 1
                },
                new QuizQuestion
                {
                    Id = Guid.NewGuid(),
                    QuizDataSetId = quizDataset2Id,
                    Question = "Which movie features the quote 'I'll be back'?",
                    CorrectAnswers = new List<string> { "The Terminator", "Terminator" },
                    DifficultyLevel = 1
                },
                new QuizQuestion
                {
                    Id = Guid.NewGuid(),
                    QuizDataSetId = quizDataset2Id,
                    Question = "Who played Jack Dawson in 'Titanic' (1997)?",
                    CorrectAnswers = new List<string> { "Leonardo DiCaprio" },
                    DifficultyLevel = 1
                },
                new QuizQuestion
                {
                    Id = Guid.NewGuid(),
                    QuizDataSetId = quizDataset2Id,
                    Question = "True or False: 'The Godfather' was released in 1972.",
                    CorrectAnswers = new List<string> { "True" },
                    DifficultyLevel = 2
                },
                new QuizQuestion
                {
                    Id = Guid.NewGuid(),
                    QuizDataSetId = quizDataset2Id,
                    Question = "Which movie won the Academy Award for Best Picture in 2020?",
                    CorrectAnswers = new List<string> { "Parasite" },
                    DifficultyLevel = 3
                },
                new QuizQuestion
                {
                    Id = Guid.NewGuid(),
                    QuizDataSetId = quizDataset1Id,
                    Question = "In which year did World War 2 begin?",
                    CorrectAnswers = new List<string> { "1939" },
                    DifficultyLevel = 1
                },
                new QuizQuestion
                {
                    Id = Guid.NewGuid(),
                    QuizDataSetId = quizDataset1Id,
                    Question = "Who was the Prime Minister of the United Kingdom for most of World War 2?",
                    CorrectAnswers = new List<string> { "Winston Churchill" },
                    DifficultyLevel = 2
                },
                new QuizQuestion
                {
                    Id = Guid.NewGuid(),
                    QuizDataSetId = quizDataset1Id,
                    Question = "Which country was invaded by Germany on September 1, 1939?",
                    CorrectAnswers = new List<string> { "Poland" },
                    DifficultyLevel = 2
                },
                new QuizQuestion
                {
                    Id = Guid.NewGuid(),
                    QuizDataSetId = quizDataset1Id,
                    Question = "True or False: The attack on Pearl Harbor brought the United States into World War 2.",
                    CorrectAnswers = new List<string> { "True" },
                    DifficultyLevel = 1
                },
                new QuizQuestion
                {
                    Id = Guid.NewGuid(),
                    QuizDataSetId = quizDataset1Id,
                    Question = "What was the codename for the Allied invasion of Normandy in 1944?",
                    CorrectAnswers = new List<string> { "Operation Overlord", "D-Day" },
                    DifficultyLevel = 3
                }
            };

            var mythCreaturesQuizQuestions = new List<QuizQuestion>
            {
                new QuizQuestion
                {
                    Id = Guid.NewGuid(),
                    QuizDataSetId = quizDataset3Id,
                    Question = "What mythical creature breathes fire and is often depicted guarding treasure?",
                    CorrectAnswers = new List<string> { "Dragon" },
                    DifficultyLevel = 1
                },
                new QuizQuestion
                {
                    Id = Guid.NewGuid(),
                    QuizDataSetId = quizDataset3Id,
                    Question = "What is the name of the horse with a single horn on its forehead?",
                    CorrectAnswers = new List<string> { "Unicorn" },
                    DifficultyLevel = 1
                },
                new QuizQuestion
                {
                    Id = Guid.NewGuid(),
                    QuizDataSetId = quizDataset3Id,
                    Question = "In Greek mythology, who was half man and half bull?",
                    CorrectAnswers = new List<string> { "Minotaur" },
                    DifficultyLevel = 2
                },
                new QuizQuestion
                {
                    Id = Guid.NewGuid(),
                    QuizDataSetId = quizDataset3Id,
                    Question = "What bird is said to rise from its own ashes after burning?",
                    CorrectAnswers = new List<string> { "Phoenix" },
                    DifficultyLevel = 2
                },
                new QuizQuestion
                {
                    Id = Guid.NewGuid(),
                    QuizDataSetId = quizDataset3Id,
                    Question = "What sea creature is known for luring sailors to their deaths with song?",
                    CorrectAnswers = new List<string> { "Siren", "Mermaid" },
                    DifficultyLevel = 3
                },
                new QuizQuestion
                {
                    Id = Guid.NewGuid(),
                    QuizDataSetId = quizDataset3Id,
                    Question = "Which Norse serpent encircles the world?",
                    CorrectAnswers = new List<string> { "Jormungandr", "Midgard Serpent" },
                    DifficultyLevel = 3
                },
                new QuizQuestion
                {
                    Id = Guid.NewGuid(),
                    QuizDataSetId = quizDataset3Id,
                    Question = "What creature from Japanese folklore is a mischievous shapeshifting fox?",
                    CorrectAnswers = new List<string> { "Kitsune" },
                    DifficultyLevel = 3
                },
                new QuizQuestion
                {
                    Id = Guid.NewGuid(),
                    QuizDataSetId = quizDataset3Id,
                    Question = "What Scottish lake is said to be home to a mysterious monster?",
                    CorrectAnswers = new List<string> { "Loch Ness Monster", "Nessie" },
                    DifficultyLevel = 2
                },
                new QuizQuestion
                {
                    Id = Guid.NewGuid(),
                    QuizDataSetId = quizDataset3Id,
                    Question = "In Slavic folklore, what house spirit is often mischievous and hairy?",
                    CorrectAnswers = new List<string> { "Domovoi" },
                    DifficultyLevel = 4
                },
                new QuizQuestion
                {
                    Id = Guid.NewGuid(),
                    QuizDataSetId = quizDataset3Id,
                    Question = "Which creature is part lion, part goat, and part serpent?",
                    CorrectAnswers = new List<string> { "Chimera" },
                    DifficultyLevel = 3
                },
                new QuizQuestion
                {
                    Id = Guid.NewGuid(),
                    QuizDataSetId = quizDataset3Id,
                    Question = "What is the name of the giant one-eyed creatures from Greek mythology?",
                    CorrectAnswers = new List<string> { "Cyclops", "Cyclopes" },
                    DifficultyLevel = 2
                },
                new QuizQuestion
                {
                    Id = Guid.NewGuid(),
                    QuizDataSetId = quizDataset3Id,
                    Question = "Which winged horse sprang from the blood of Medusa?",
                    CorrectAnswers = new List<string> { "Pegasus" },
                    DifficultyLevel = 2
                },
                new QuizQuestion
                {
                    Id = Guid.NewGuid(),
                    QuizDataSetId = quizDataset3Id,
                    Question = "What creature is said to suck the blood of goats in Latin American folklore?",
                    CorrectAnswers = new List<string> { "Chupacabra" },
                    DifficultyLevel = 2
                },
                new QuizQuestion
                {
                    Id = Guid.NewGuid(),
                    QuizDataSetId = quizDataset3Id,
                    Question = "Which mythological guardian has the body of a lion and the head of a human?",
                    CorrectAnswers = new List<string> { "Sphinx" },
                    DifficultyLevel = 2
                },
                new QuizQuestion
                {
                    Id = Guid.NewGuid(),
                    QuizDataSetId = quizDataset3Id,
                    Question = "What mythical creature is half eagle and half lion?",
                    CorrectAnswers = new List<string> { "Griffin", "Gryphon" },
                    DifficultyLevel = 2
                }
            };

            var quizResults = new List<QuizResult>
            {
                new QuizResult(QuizType.WorldCountriesQuiz, QuizMode.Standard, userId, 100, TimeSpan.FromMinutes(10), 198),
                new QuizResult(QuizType.WorldCountriesQuiz, QuizMode.Standard, userId, 90, TimeSpan.FromMinutes(12), 198),
                new QuizResult(QuizType.WorldCountriesQuiz, QuizMode.Standard, userId, 50, TimeSpan.FromMinutes(14), 198),
                new QuizResult(QuizType.WorldCountriesQuiz, QuizMode.Standard, userId, 50, TimeSpan.FromMinutes(15), 198),
                new QuizResult(QuizType.WorldCountriesQuiz, QuizMode.Standard, userId, 20, TimeSpan.FromMinutes(11), 198),
                new QuizResult(QuizType.WorldCountriesQuiz, QuizMode.Standard, userId, 12, TimeSpan.FromMinutes(13), 198),
                new QuizResult(QuizType.WorldCountriesQuiz, QuizMode.Standard, userId, 10, TimeSpan.FromMinutes(10), 198)
            };

            var quizRules = new List<QuizRule>
            {
                new QuizRule
                {
                    Id = Guid.NewGuid(),
                    QuizId = quiz1Id,
                    Rule = "Abbreviations are not included for most countries."
                },
                new QuizRule
                {
                    Id = Guid.NewGuid(),
                    QuizId = quiz1Id,
                    Rule = "Guess all the countries to complete the quiz and earn the corresponding badge."
                },
                new QuizRule
                {
                    Id = Guid.NewGuid(),
                    QuizId = quiz1Id,
                    Rule = "Blue circles represent small countries or island nations."
                },
            };

            var users = new List<User>
            {
                new User
                {
                    Id = userId,
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
