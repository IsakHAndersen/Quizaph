namespace QuizaphFrontend.Services
{
    public interface IHttpService
    {
        Task LoginAsync(string returnUrl = "/");
        Task LogoutAsync();
    }
}
