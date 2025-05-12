using GeoQuiz.Models.QuizModels.Enums;

namespace GeoQuiz.Models.QuizModels.QuizStructures
{
    public class NameSpecificThing
    {
        public ResourceType Resourcetype { get; set; }
        Dictionary<string, (string value, int resourceId)> QuizKeyValuePairs = new Dictionary<string, (string value, int resourceId)>();
        public NameSpecificThing()
        {

        }

        public bool Guess(string key, string guess)
        {
            if (QuizKeyValuePairs.TryGetValue(key, out var value))
            {
                if (guess == value.value)
                {
                    return true;
                }
            }
            return false;
        }


    }
}
