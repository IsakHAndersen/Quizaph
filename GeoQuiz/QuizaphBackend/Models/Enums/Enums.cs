using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Enums
{
    public enum QuizCategory
    {
        None,
        Geography,
        History,
        Science,
        Literature,
        Art,
        Sports,
        Entertainment,
        Technology,
        GeneralKnowledge,
        Mathematics,
        Language,
        Philosophy,
        Politics,
        Economics,
        Music,
        MoviesAndTV,
        Gaming,
        FoodAndDrink,
        Travel,
        Fashion,
        Mythology,
        Religion,
        Nature,
        Medicine,
        Astronomy,
        Business,
        Riddles,
        CurrentEvents
    }


    [Flags]
    public enum QuizMode
    {
        None = 0,
        Alphabetical = 1 << 0,    
        Random = 1 << 1,          
        Standard = 1 << 2,        
        Timed = 1 << 3,           
        TriviaExpansion = 1 << 4,
        RandomWithLives = 1 << 5
    }

    public enum Continent
    {
        Africa,
        Antarctica,
        Asia,
        Europe,
        NorthAmerica,
        Oceania,
        SouthAmerica,
        None
    }
    
    public enum QuizType
    {
        WorldCountriesQuiz,
        ImageQuiz,
        TextQuiz,
        MultipleChoiceQuiz,
        TrueFalseQuiz
    }
}
