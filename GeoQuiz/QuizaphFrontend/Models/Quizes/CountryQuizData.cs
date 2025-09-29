using Models.Enums;
using QuizaphFrontend.Models.Interfaces;

namespace QuizaphFrontend.Models.Quizes
{
    public class CountryQuizData : IResetableQuiz
    {
        public List<Country> Countries { get; set; } = new List<Country>();

        public void ResetQuiz()
        {
            Countries.ForEach(a => a.Guessed = false);
        }
    }

    public class Country
    {
        public string CountryName { get; set; } = string.Empty;
        public Continent Continent { get; set; } = Continent.None;
        public List<string> ValidNames { get; set; } = new();
        public string Id { get; set; } = string.Empty;
        public bool Guessed { get; set; } = false;
    }
}
