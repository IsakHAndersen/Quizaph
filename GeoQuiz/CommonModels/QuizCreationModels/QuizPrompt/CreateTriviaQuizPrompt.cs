using CommonModels.QuizCreationModels.BaseModels;

namespace CommonModels.QuizCreationModels.QuizPrompt
{
    public class CreateTriviaQuizPrompt : CreateQuizBaseClass
    {   
        public int NumberOfQuestions { get; set; } = 5;
        public string AdditionalInstructions { get; set; } = "";    
        public int Difficulty { get; set; } = 1; // 2 (easy) to 5 (hard)

    }
}
