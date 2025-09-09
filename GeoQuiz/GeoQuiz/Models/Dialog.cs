namespace QuizaphFrontend.Models
{
    public class Dialog
    {
        public string Title { get; set; } = string.Empty;
        public List<string> DialogContent { get; set; } = new();
    }

    public enum DialogType
    {
        Rules, Ranking, Information
    }
}
