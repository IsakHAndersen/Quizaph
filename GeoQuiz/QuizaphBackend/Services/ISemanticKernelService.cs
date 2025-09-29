namespace QuizaphBackend.Services
{
    public interface ISemanticKernelService
    {
        public Task<string> CreateQuizAsync(string promptPath, Dictionary<string, object> args, string? modelOverride = null);
    }
}
