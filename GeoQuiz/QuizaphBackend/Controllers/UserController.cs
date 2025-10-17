using CommmonModels.UserModels;
using CommonModels.UserModels;
using GeoQuizBackend.EntityFramework;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using QuizaphBackend.Services;
using System.Security.Claims;

namespace QuizaphBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly DBContext _context;
        private readonly IConfiguration _configuration;

        public UsersController(UserService userService, DBContext _dbContext, IConfiguration configuration)
        {
            _userService = userService;
            _context = _dbContext;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateUserDTO dto)
        {
            if (dto == null)
                return BadRequest("Invalid user data.");

            if (string.IsNullOrWhiteSpace(dto.Email) && string.IsNullOrWhiteSpace(dto.ExternalProviderName))
                return BadRequest("Missing required registration information.");

            try
            {
                User user;

                if (!string.IsNullOrEmpty(dto.ExternalProviderName))
                {
                    // External login (Google, etc.)
                    user = await _userService.RegisterUserExternal(dto.ExternalProviderName!, dto.ExternalProviderId!);
                }
                else
                {
                    user = await _userService.RegisterUserInternal(dto.Email!, dto.Password!);
                }
                return Ok(new
                {
                    user.Id,
                    user.Email,
                    user.ExternalProviderName,
                    user.EmailVerified
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Registration failed: {ex.Message}");
            }
        }

        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(int userId, string token)
        {
            var user = await _context.Users.FindAsync(userId);

            if (user == null || user.EmailVerificationToken != token)
                return BadRequest("Invalid or expired verification link.");

            user.EmailVerified = true;
            user.EmailVerificationToken = null;
            await _context.SaveChangesAsync();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name ?? ""),
                new Claim(ClaimTypes.Email, user.Email ?? "")
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

            // Redirect to frontend home page
            return Redirect(_configuration["FrontendBaseUrl"]!);
        }

    }

}
