using CommonModels.UserModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;
using static QuizaphFrontend.Components.Pages.SignUp;

namespace QuizaphFrontend
{
    [Route("/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        // Trigger Google login
        [HttpGet("google-login")]
        public async Task<ActionResult> Google()
        {
            var props = new Microsoft.AspNetCore.Authentication.AuthenticationProperties
            {
                RedirectUri = "/"
            };
            return Challenge(props, GoogleDefaults.AuthenticationScheme);
        }

        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }

        //[HttpPost("register")]
        //public async Task<IActionResult> Register(RegisterModel model)
        //{
        //    // ... create user ...

        //    // Log the user in immediately after registration
        //    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
        //        new ClaimsPrincipal(claimsIdentity));

        //    return Redirect("/");
        //}
    }
}
