using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace QuizaphFrontend.Services
{
    public interface IAuthService
    {
        Task<Guid?> GetUserIdAsync();
        Task<List<string>> GetUserRolesAsync();
        Task<bool> IsInRoleAsync(string role);
    }
    public class AuthService : IAuthService
    {
        private readonly AuthenticationStateProvider _authStateProvider;
        public AuthService(AuthenticationStateProvider authenticationStateProvider)
        {
            _authStateProvider = authenticationStateProvider;
        }

        public async Task<Guid?> GetUserIdAsync()
        {
            var authState = await _authStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;
            if (user.Identity?.IsAuthenticated ?? false)
            {
                // Try to extract the user ID from claims (JWT sub or standard NameIdentifier)
                var userIdString = user.FindFirst("sub")?.Value
                                   ?? user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (Guid.TryParse(userIdString, out Guid userId))
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
                return user.FindAll(ClaimTypes.Role)
                           .Select(c => c.Value)
                           .ToList();
            }
            return new List<string>();
        }

        public async Task<bool> IsInRoleAsync(string role)
        {
            var roles = await GetUserRolesAsync();
            return roles.Contains(role);
        }
    }
}
