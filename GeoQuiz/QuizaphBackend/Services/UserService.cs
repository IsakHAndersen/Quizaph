using CommmonModels.UserModels;
using GeoQuizBackend.EntityFramework;
using Microsoft.AspNetCore.Identity.UI.Services;
using QuizaphBackend.Services;
using System;
using System.Security.Cryptography;
using System.Text;

namespace QuizaphFrontend.Services
{
    public class UserService
    {
        private readonly IEmailSender _emailSender;
        private readonly IConfiguration _config;
        private readonly DBContext _context;
        public UserService(IEmailSender emailSender, IConfiguration config, DBContext dbContext)
        {
            _emailSender = emailSender;
            _config = config;
            _context = dbContext;
        }
        public async Task<User> RegisterUserInternal(string email, string password)
        {
            var salt = Convert.ToBase64String(RandomNumberGenerator.GetBytes(16));
            var hash = HashPassword(password, salt);

            var user = User.CreateLocalUser(email, hash, salt);
            user.EmailVerificationToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
            user.EmailVerified = false;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            var verifyUrl = $"{_config["FrontendBaseUrl"]}/verify-email?userId={user.Id}&token={Uri.EscapeDataString(user.EmailVerificationToken)}";
            await _emailSender.SendEmailAsync(user.Email!, "Verify your Quizaph account",
                $"Click <a href='{verifyUrl}'>here</a> to verify your email.");
            return user;
        }

        public async Task<User> RegisterUserExternal(string providerName, string providerId)
        {
            var user = User.CreateExternalUser(providerName, providerId);
             _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public bool ValidateUserCredentials(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            if (user == null) return false;
            return PasswordHasher.VerifyPassword(password, user.PasswordHash!, user.PasswordSalt!);
        }

        private string HashPassword(string password, string salt)
        {
            using var sha256 = SHA256.Create();
            var salted = Encoding.UTF8.GetBytes(password + salt);
            return Convert.ToBase64String(sha256.ComputeHash(salted));
        }

    }
}
