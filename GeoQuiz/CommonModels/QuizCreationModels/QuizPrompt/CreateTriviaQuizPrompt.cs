using CommonModels.QuizCreationModels.BaseModels;
using System.ComponentModel.DataAnnotations;

namespace CommonModels.QuizCreationModels.QuizPrompt
{
    public class CreateTriviaQuizPrompt : CreateQuizBaseClass
    {   
        public int NumberOfQuestions { get; set; } = 5;
        public string Instruction { get; set; } = "";

        [Range(1, 5, ErrorMessage = "Difficulty must be between 1 and 5.")]
        public int? Difficulty { get; set; } = 1;

    }
}
