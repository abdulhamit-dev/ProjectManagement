using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.UI.Services;
using System.Security.Claims;

namespace ProjectManagement.UI.Controllers
{
    public class AuthController : Controller
    {
        private readonly AuthService _authService;
        public AuthController(AuthService authService)
        {
            _authService = authService;
        }
        public async Task<IActionResult> Login()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var tokenResult = await _authService.GetToken(username, password);
            if (tokenResult.Token is not null)
            {
                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name,username),
                        new Claim("Token",tokenResult.Token),
                        new Claim("Expiration",tokenResult.Expiration)
                    };

                var zaman = Convert.ToDateTime(tokenResult.Expiration);
                var userIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(userIdentity), new AuthenticationProperties { ExpiresUtc = zaman.AddHours(1) });
                return Json(true);
            }
            else
                return Json(false);
        }
    }
}
