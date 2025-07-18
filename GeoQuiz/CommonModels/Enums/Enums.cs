using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonModels.Enums
{
    public enum QuizCategory
    {
        Geography,
        History,
        Science,
        Literature,
        Art,
        Sports,
        Entertainment,
        Technology,
        GeneralKnowledge
    }

    public enum QuizModes
    {
        Alphabetical,
        Random,
        Standard,
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
