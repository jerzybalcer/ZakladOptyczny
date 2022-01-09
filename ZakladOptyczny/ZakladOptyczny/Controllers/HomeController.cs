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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}