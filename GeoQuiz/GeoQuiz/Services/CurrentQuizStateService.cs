using Models.Enums;
using QuizaphBackend.Models.QuizResults;
using QuizaphFrontend.Models;

namespace QuizaphFrontend.Services
{
    public class CurrentQuizStateService
    {
        public Quiz CurrentQuizInfo { get; set; } = new();

        public event Action? OnResetRequested;
        public event Func<Task>? OnShowEndScreen;
        public event Action<QuizMode>? OnCurrentModeChanged;

        public void InvokeRequestReset()
        {
            OnResetRequested?.Invoke();
        }

        public async Task InvokeShowEndScreen()
        {
            if (OnShowEndScreen is not null)
                await OnShowEndScreen.Invoke();
        }

        public void InvokeModeChanged(QuizMode mode)
        {
            OnCurrentModeChanged?.Invoke(mode);
        }
    }
}
