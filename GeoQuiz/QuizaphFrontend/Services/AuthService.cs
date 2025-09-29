using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

public class AuthService
{
    private readonly HttpClient _httpClient;
    public string JwtToken { get; private set; } = "";

    public AuthService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public void SetToken(string token)
    {
        JwtToken = token;
        if (!string.IsNullOrEmpty(token))
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }
        else
        {
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }
    }

    public async Task LoginWithGoogleAsync(string idToken)
    {
        // Send Google ID token to backend to get your app JWT
        var response = await _httpClient.PostAsJsonAsync("api/auth/token-login", new { idToken });
        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadFromJsonAsync<LoginResult>();
        SetToken(result.Token);
    }

    private class LoginResult
    {
        public string Token { get; set; } = "";
    }
}
