using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace QuizaphFrontend.Services
{
    public class UserClaimsService
    {
        private readonly AuthenticationStateProvider _authStateProvider;

        public UserClaimsService(AuthenticationStateProvider authStateProvider)
        {
            _authStateProvider = authStateProvider;
        }

        public async Task<string?> GetUserIdAsync()
        {
            var authState = await _authStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            if (user.Identity?.IsAuthenticated ?? false)
            {
                return user.FindFirst("sub")?.Value
                    ?? user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            }

            return null;
        }
    }
}
