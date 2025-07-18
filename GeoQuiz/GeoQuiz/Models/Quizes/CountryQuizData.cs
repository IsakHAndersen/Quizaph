using CommonModels.Enums;
using QuizaphFrontend.Models.QuizModels;

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
}
