using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ZakladOptyczny.Models;
using ZakladOptyczny.Models.Actors;
using ZakladOptyczny.Models.Utilities.Database.Appointments;
using ZakladOptyczny.Models.Utilities.Database.Users;
using System.Linq;


namespace ZakladOptyczny.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUsersManager _usersManager;
        private readonly IAppointmentManager _appointmentsManager;

        private User currentUser;

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
            ViewBag.User = currentUser;
            return View("login");
        }

        public IActionResult Profil()
        {
            ViewBag.User = currentUser;
            return View("profile");
        }

        public IActionResult Wizyty()
        {
            return View("visits");
        }

         public IActionResult Terminy(DateTime SearchDate)
        {
            var date = SearchDate.ToShortDateString();
            ViewData["date"] = date;
            return View("termins");
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

            var claimsList = claims.ToArray();

            var userCheckList = _usersManager.GetMatchingUsersByEmail(claimsList[4].Value);

            if (userCheckList.Count == 0)
            {

                currentUser = _usersManager.AddUser(new Patient(claimsList[2].Value,
                    claimsList[3].Value,
                    "",
                    claimsList[4].Value));
            }
            else
            { 
                currentUser = userCheckList[0];
            }

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