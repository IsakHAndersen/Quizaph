using CommonModels.QuizCreationModels.BaseModels;
using QuizaphBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonModels.QuizCreationModels.QuizManual
{
    public class CreateTriviaQuiz : CreateQuizBaseClass
    {
        public List<QuizQuestion> Questions { get; set; } = new();
    }
}
