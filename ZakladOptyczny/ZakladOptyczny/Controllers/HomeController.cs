using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ZakladOptyczny.Models;
using ZakladOptyczny.Models.Utilities.Database;

namespace ZakladOptyczny.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DatabaseContext _databaseContext;

        public HomeController(ILogger<HomeController> logger, DatabaseContext databaseContext)
        {
            _logger = logger;
            _databaseContext = databaseContext;
        }

        public IActionResult Index()
        {
            var db = new DatabaseManager(_databaseContext);
            //var users = db.GetUsers();
            //db.AddTestUser();

            return View("profile");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}