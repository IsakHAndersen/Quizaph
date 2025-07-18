using Microsoft.AspNetCore.Components;
using QuizaphFrontend.Models;
using QuizaphFrontend.Models.Quizes;

namespace QuizaphFrontend.Services
{
    public class HttpService : IHttpService
    {

        public HttpService()
        {
        }

        public async Task LoginAsync(string returnUrl = "/")
        {
            var url = $"/account/login?returnUrl={Uri.EscapeDataString(returnUrl)}";
            // For login, usually you want to redirect the browser, not fetch
            //var absoluteUrl = new Uri(_httpClient.BaseAddress, url).ToString();
            //_navigationManager.NavigateTo(absoluteUrl, forceLoad: true);
        }

        public async Task LogoutAsync()
        {
            //await _httpClient.GetAsync("/account/logout");
        }

        //public async Task<CountryQuiz> GetCountryQuiz()
        //{
        //    var url = "";
        //    var response = await _httpClient.GetAsync(url);
        //    response.EnsureSuccessStatusCode();
        //    return new CountryQuiz();
        //}

        // Should be a query with parameters to filter quizzes
        public async Task<List<QuizInfo>> GetQuizInfos()
        {
            //var url = "";
            //var response = await _httpClient.GetAsync(url);
            //response.EnsureSuccessStatusCode();
            return await DummyDataQuiz.GetAllQuizes();
        }
    }
}
