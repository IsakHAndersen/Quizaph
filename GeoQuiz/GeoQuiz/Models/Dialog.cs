namespace QuizaphFrontend.Models
{
    public class Dialog
    {
        public string Title { get; set; }
        public List<string> DialogContent { get; set; }
    }

    public enum DialogType
    {
        Rules, Ranking, Information
    }
}
