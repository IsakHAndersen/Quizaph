using GeoQuiz.Models.QuizModels.Enums;
using static GeoQuiz.Models.QuizModels.QuizStructures.NameThingThatStartsWithX;

namespace GeoQuiz
{
    public interface IRepositoryService
    {
        List<string> GetCategories(QuizType type);
        List<string> GetCategoryItems(string category, QuizType type);
    }

    public class RepositoryService : IRepositoryService
    {
        public RepositoryService() { }
        public List<string> GetCategories(QuizType type)
        {
            return new List<string>();
        }
        public List<string> GetCategoryItems(string category, QuizType type)
        {
            return new List<string>();
        }
    }
}
