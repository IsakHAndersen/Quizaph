using CommonModels.QuizCreationModels.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonModels.QuizCreationModels.QuizManual
{
    public class CreateTriviaQuiz : CreateQuizBaseClass
    {
        public List<TriviaQuizQuestion> Questions { get; set; } = new();
    }

    public class TriviaQuizQuestion
    {
        public string Question { get; set; } = "";
        public List<string> ValidAnswers { get; set; } = new();
    }
}
