namespace QuizaphBackend.SKInstructions
{
    public class TriviaQuizPromptParameters
    {
        public string Instruction { get; set; } = string.Empty;
        public int NumberOfQuestions { get; set; }
        public int? DifficultyLevel { get; set; }
    }
}
