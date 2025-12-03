using CommonModels.UserModels;
using GeoQuizBackend.EntityFramework;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Security.Cryptography;
using System.Text;

namespace QuizaphBackend.Services
{
    public interface IUserService
    {
        Task<User> RegisterUserInternal(CreateUserDTO userDto);
        Task<User> RegisterUserExternal(CreateExternalUserDTO userDto);
        bool ValidateUserCredentials(User user, string password);
    }
    public class UserService : IUserService
    {
        private readonly IConfiguration _config;
        private readonly DBContext _context;
        public UserService(IConfiguration config, DBContext dbContext)
        {
            _config = config;
            _context = dbContext;
        }
        public async Task<User> RegisterUserInternal(CreateUserDTO userDto)
        {
            var salt = Convert.ToBase64String(RandomNumberGenerator.GetBytes(16));
            var hash = HashPassword(userDto.Password, salt);

            var user = new User
            {
                Email = userDto.Email,
                PasswordHash = hash,
                PasswordSalt = salt,
                Username = userDto.Username,
                RegisteredAt = DateTime.UtcNow,
                EmailVerificationToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                EmailVerified = false
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            var verifyUrl = $"{_config["FrontendBaseUrl"]}/verify-email?userId={user.Id}&token={Uri.EscapeDataString(user.EmailVerificationToken)}";
            //await _emailSender.SendEmailAsync(user.Email!, "Verify your Quizaph account",
            //    $"Click <a href='{verifyUrl}'>here</a> to verify your email.");
            return user;
        }

        public async Task<User> RegisterUserExternal(CreateExternalUserDTO userDto)
        {
            var user = new User
            {
                ExternalProviderName = userDto.ExternalProviderName,
                ExternalProviderId = userDto.ExternalProviderId,
                Email = userDto.Email,
                Username = userDto.Name,
                RegisteredAt = DateTime.UtcNow,
                EmailVerified = true,
            };
             _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public bool ValidateUserCredentials(User user, string password)
        {
            if (user == null) return false;
            return VerifyPassword(password, user.PasswordHash!, user.PasswordSalt!);
        }

        private static string HashPassword(string password, string salt)
        {
            using var sha256 = SHA256.Create();
            var saltedBytes = Encoding.UTF8.GetBytes(password + salt);
            return Convert.ToBase64String(sha256.ComputeHash(saltedBytes));
        }

        private static bool VerifyPassword(string password, string hash, string salt)
        {
            using var sha256 = SHA256.Create();
            var saltedBytes = Encoding.UTF8.GetBytes(password + salt);
            var computedHash = Convert.ToBase64String(sha256.ComputeHash(saltedBytes));
            return computedHash == hash;
        }
    }
}
