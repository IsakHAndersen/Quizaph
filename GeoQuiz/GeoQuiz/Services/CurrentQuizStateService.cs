using QuizaphFrontend.Models;

namespace QuizaphFrontend.Services
{
    public class CurrentQuizStateService
    {
        public QuizInfo? CurrentQuizInfo { get; set; }

        public event Action? OnResetRequested;
        public event Action? OnShowEndScreen;

        public void RequestReset()
        {
            OnResetRequested?.Invoke();
        }

        public void ShowEndScreen()
        {
            OnShowEndScreen?.Invoke();
        }
    }
}
