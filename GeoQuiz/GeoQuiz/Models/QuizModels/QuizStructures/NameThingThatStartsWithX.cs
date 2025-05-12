using GeoQuiz.Models.QuizModels.Enums;
using GeoQuiz.Models.QuizModels.Interfaces;

namespace GeoQuiz.Models.QuizModels.QuizStructures
{
    public class NameThingThatStartsWithX: IMultiplayerInterface
    {
        private readonly IRepositoryService repositoryService;
        public QuizType QuizType { get; set; } = QuizType.NameThingThatStartWithX;
        List<(string category, string alphabet)> Categories { get; set; } = new();
        public char CurrentLetter { get; set; }
        private string CurrentCategory { get; set; }
        public bool AllowSameCategoryDifferentRule { get; set; }
        public Dictionary<int, List<string>> CorrectGuesses { get; set; } = new();
        public List<string> CategoryItems { get; set; } = new();

        public NameThingThatStartsWithX(IRepositoryService repositoryService)
        {
            this.repositoryService = repositoryService;
        }

        public NameThingThatStartsWithX(List<int> playerIds)
        {
            playerIds.ForEach(a => CorrectGuesses.Add(a, new List<string>()));
            FillCategories();
        }

        private void FillCategories()
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            List<string> categories = repositoryService.GetCategories(QuizType);
            categories.ForEach(a => Categories.Add((a, alphabet)));
        }

        public void NewRound()
        {
            // Shuffle Category
            var random = new Random();
            Categories.Where(a => a.category == CurrentCategory).First().alphabet.Replace(CurrentLetter, Convert.ToChar(""));
            if (!AllowSameCategoryDifferentRule)
            {
                Categories.Remove(Categories.Where(a => a.category == CurrentCategory).First());
            }
            var randomlySelected = random.Next(Categories.Count);
            CurrentCategory = Categories[randomlySelected].category;
            CategoryItems = repositoryService.GetCategoryItems(CurrentCategory, QuizType);

            // Shuffle letter
            var availableAlphabet = Categories.Where(a => a.category == CurrentCategory).First().alphabet.ToCharArray();
            CurrentLetter = availableAlphabet[random.Next(availableAlphabet.Count())];
        }

        public bool Guess(string guess, int playerId)
        {
            if (CategoryItems.Contains(guess)) 
            {
                if (CorrectGuesses.TryGetValue(playerId, out var correctGuesses))
                {
                    if (correctGuesses.Contains(guess))
                    {
                        return false;
                    }
                }
                CorrectGuesses[playerId].Add(guess);
                return true;
            }
            return false;
        }
    }

   
}
