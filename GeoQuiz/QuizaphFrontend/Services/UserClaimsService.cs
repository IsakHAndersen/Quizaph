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

        public async Task<int?> GetUserIdAsync()
        {
            var authState = await _authStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            if (user.Identity?.IsAuthenticated ?? false)
            {
                var userIdString = user.FindFirst("sub")?.Value
                                   ?? user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (int.TryParse(userIdString, out int userId))
                    return userId;
            }

            return null;
        }

        public async Task<List<string>> GetUserRolesAsync()
        {
            var authState = await _authStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            if (user.Identity?.IsAuthenticated ?? false)
            {
                return user.FindAll(ClaimTypes.Role).Select(c => c.Value).ToList();
            }
            return new List<string>();
        }

        public async Task<bool> IsInRoleAsync(string role)
        {
            //var roles = await GetUserRolesAsync();
            var roles = new List<string> { "Admin" };   
            return roles.Contains(role);
        }
    }
}
