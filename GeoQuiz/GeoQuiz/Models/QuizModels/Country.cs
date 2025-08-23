

using Models.Enums;

namespace QuizaphFrontend.Models.QuizModels
{
    public class Country
    {
        public string CountryName { get; set; } = string.Empty;
        public Continent Continent { get; set; } = Continent.None;
        public List<string> ValidNames { get; set; } = new();
        public string Id { get; set; } = string.Empty;
        public bool Guessed { get; set; } = false;
    }
}
