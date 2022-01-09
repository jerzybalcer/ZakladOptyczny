using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ZakladOptyczny.Models;
using ZakladOptyczny.Models.Utilities.Database.Appointments;
using ZakladOptyczny.Models.Utilities.Database.Users;

namespace ZakladOptyczny.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUsersManager _usersManager;
        private readonly IAppointmentManager _appointmentsManager;

        public HomeController(ILogger<HomeController> logger, IUsersManager usersManager, IAppointmentManager appointmentsManager)
        {
            _logger = logger;
            _usersManager = usersManager;
            _appointmentsManager = appointmentsManager;
        }

        public IActionResult Index()
        {
            return View("login");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult StronaGlowna()
        {
            return View("login");
        }

        public IActionResult Profil()
        {
            return View("profile");
        }

        public IActionResult Wizyty()
        {
            return View("visits");
        }

        public async Task GoogleLogin()
        {
            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme, new AuthenticationProperties()
            {
                RedirectUri = Url.Action("GoogleResponse")
            });
        }

        public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var claims = result.Principal.Identities
                .FirstOrDefault().Claims.Select(claim => new
                {
                    claim.Issuer,
                    claim.OriginalIssuer,
                    claim.Type,
                    claim.Value
                });
            //return Json(claims); <--  log in info in claims - empty txt html opens with this on
            return RedirectToAction("StronaGlowna");
        }

        public async Task<IActionResult> GoogleLogout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("StronaGlowna");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}