using Models.Enums;
using QuizaphFrontend.Models;

namespace QuizaphFrontend.Services
{
    public class CurrentQuizStateService
    {
        public Quiz CurrentQuizInfo { get; set; } = new();

        public event Func<Task>? OnResetRequested;
        public event Func<Task>? OnShowEndScreen;
        public event Func<QuizMode, Task>? OnCurrentModeChanged;

        public async Task InvokeRequestReset()
        {
            if (OnResetRequested is not null)
            await OnResetRequested.Invoke();
        }

        public async Task InvokeShowEndScreen()
        {
            if (OnShowEndScreen is not null)
                await OnShowEndScreen.Invoke();
        }

        public async Task InvokeModeChanged(QuizMode mode)
        {
            if (OnCurrentModeChanged is not null)
            {
                await OnCurrentModeChanged.Invoke(mode);
            }
        }
    }
}
