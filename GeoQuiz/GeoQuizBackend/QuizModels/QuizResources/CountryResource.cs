using GeoQuiz.Models.QuizModels.Enums;

namespace GeoQuiz.Models.QuizModels.QuizResources
{
    public class CountryResource
    {
        public string Name { get; set; }
        public string ISO { get; set; }
        public Continent Continent { get; set; }
    }
}
