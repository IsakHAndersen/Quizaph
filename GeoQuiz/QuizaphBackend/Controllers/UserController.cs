using CommonModels.UserModels;
using GeoQuizBackend.EntityFramework;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizaphBackend.Services;
using System.Security.Claims;

namespace QuizaphBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DBContext _context;
        private readonly IUserService _userService;

        public UsersController(DBContext _dbContext, IUserService userService)
        {
            _context = _dbContext;
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDto)
        {
            var user = await _context.Users.Where(a => a.Email == loginDto.Email).FirstOrDefaultAsync();
            if (user == null)
                return Unauthorized(new { message = "Invalid credentials" });
            var isSuccess = _userService.ValidateUserCredentials(user, loginDto.Password);
            if (!isSuccess)
                return Unauthorized(new { message = "Invalid credentials" });

            // Build claims for the authentication cookie
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(ClaimTypes.Email, user.Email),
                new(ClaimTypes.Role, "User"),
                new(ClaimTypes.Name, user.Username ?? user.Email)
            };

            var identity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme
            );

            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal,
                new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddDays(7)
                });
            return Ok();
        }

        [HttpGet("login-info")]
        public async Task<ActionResult<User>> GetLoginInfo(string email)
        {
            var user = await _context.Users
                .Where(u => u.Email == email)
                .FirstOrDefaultAsync();

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpGet("by-login")]
        public async Task<ActionResult<User>> FindUserByLogin(string providerName, string providerId)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.ExternalProviderName == providerName && u.ExternalProviderId == providerId);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpPost("register/external")]
        public async Task<ActionResult<User>> RegisterExternalProvider([FromBody] CreateExternalUserDTO userDto)
        {
            // Optional: Check if user already exists
            var existing = await _context.Users
                .FirstOrDefaultAsync(u => u.ExternalProviderName == userDto.ExternalProviderName && u.ExternalProviderId == userDto.ExternalProviderId);

            if (existing != null)
                return Conflict("User already exists");

            var user = await _userService.RegisterUserExternal(userDto);
            return Ok();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] string email, [FromForm] string password, [FromForm] string username)
        {
            var existing = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (existing != null)
                return Conflict("User already exists");
            var user = await _userService.RegisterUserInternal(new CreateUserDTO(email, password, username));
            if (user == null)
                return BadRequest("Could not create user");
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, "User"),
                new Claim(ClaimTypes.Name, user.Username ?? user.Email)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal,
                new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddDays(7)
                });
            // Frontend redirect
            return Redirect("/"); 
        }



        [HttpGet("{id:guid}")]
        public async Task<ActionResult<User>> GetUser(Guid id)
        {
            var user = await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            var users = await _context.Users.AsNoTracking().ToListAsync();
            return Ok(users);
        }
    }
}
