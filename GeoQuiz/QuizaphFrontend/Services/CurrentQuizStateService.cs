using CommonModels.Enums;
using CommonModels.QuizModels;

namespace QuizaphFrontend.Services
{
    public class CurrentQuizStateService
    {
        public Quiz CurrentQuizInfo { get; set; } = new();

        public event Func<Task>? OnResetRequested;
        public event Func<Task>? OnEndQuiz;
        public event Func<QuizMode, Task>? OnCurrentModeChanged;
        public event Func<QuizDataset, Task>? OnCurrentDatasetChanged;

        public async Task InvokeRequestReset()
        {
            if (OnResetRequested is not null)
            await OnResetRequested.Invoke();
        }
        public async Task InvokeShowEndScreen()
        {
            if (OnEndQuiz is not null)
                await OnEndQuiz.Invoke();
        }
        public async Task InvokeModeChanged(QuizMode mode)
        {
            if (OnCurrentModeChanged is not null)
            {
                await OnCurrentModeChanged.Invoke(mode);
            }
        }
        public async Task InvokeDatasetChanged(QuizDataset dataset)
        {
            if (OnCurrentDatasetChanged is not null)
            {
                await OnCurrentDatasetChanged.Invoke(dataset);
            }
        }
    }
}
