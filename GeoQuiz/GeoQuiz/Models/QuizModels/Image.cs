namespace QuizaphFrontend.Models.QuizModels
{
    public class Image
    {
        string ImageUrl { get; set; } = string.Empty;
        string Id { get; set; } = string.Empty;
        List<string> ValidNames { get; set; } = new();
        bool Guessed { get; set; } = false; 
    }
}
