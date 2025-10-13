using CommonModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonModels.QuizCreationModels.BaseModels
{
    public class CreateQuizBaseClass
    {
        public QuizType QuizType { get; set; }
        public QuizCategory Category { get; set; }
        public string Title { get; set; } = string.Empty;
    }
}
