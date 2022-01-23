using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ZakladOptyczny.Models;
using ZakladOptyczny.Models.Actors;
using ZakladOptyczny.Models.Utilities;
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

        public IActionResult Search()
        {
            string tempCookieValue = HttpContext.Request.Cookies["opticianpractice_current-user-email"];
            User us = _usersManager.GetMatchingUsersByEmail(tempCookieValue)[0];
            if (us is ZakladOptyczny.Models.Actors.Patient)
            {
                return Wizyty(us.UserId);
            }
            else
            {
                return View("search");
            }
        }
        [HttpPost]
        public IActionResult Szukaj(String pesel)
        {
            User us = _usersManager.GetUserByPesel(pesel);
            if (us == null)
                return Search();
            else
                return Wizyty(us.UserId);
        }

        public IActionResult Wizyty(int userID)
        {
            var apps = _appointmentsManager.GetUserAppointments(_usersManager.GetUserById(userID));
            ViewBag.Apps = apps;
            return View("visits");
        }
        public IActionResult Check(int appID)
        {
            string tempCookieValue = HttpContext.Request.Cookies["opticianpractice_current-user-email"];
            User us = _usersManager.GetMatchingUsersByEmail(tempCookieValue)[0];
            if (us is ZakladOptyczny.Models.Actors.Optician)
            {
                return OptInfo(appID);
            }
            else
            {
                return Info(appID);
            }

        }
        public IActionResult Info(int appID)
        {
            var app = _appointmentsManager.GetAppointmentById(appID);
            var name = app.User.Name + " " + app.User.Surname;
            ViewBag.App = app;
            ViewBag.UserName = name;
            return View("visitInfo");
        }

        public IActionResult OptInfo(int appID)
        {
            var app = _appointmentsManager.GetAppointmentById(appID);
            var name = app.User.Name + " " + app.User.Surname;
            ViewBag.App = app;
            ViewBag.UserName = name;
            return View("optInfo");
        }
        [HttpPost]
        public IActionResult Update(DateTime date, int id, string note, string presc, string isAtt, int appID)
        {

            bool isAttended;
            if (isAtt == "Tak")
                isAttended = true;
            else
                isAttended = false;
            Appointment temp = _appointmentsManager.GetAppointmentById(id);
            Appointment updated = new Appointment(id, presc, isAttended, note, date, temp.User);
            _appointmentsManager.UpdateAppointment(updated);
            return OptInfo(updated.AppointmentId);
        }
        public IActionResult Terminy(DateTime SearchDate)
        {
            var date = SearchDate.ToShortDateString();
            ViewData["date"] = date;
            return View("termins");
        }

        public IActionResult ProfileUpdate(string NewName, string NewSurname, string NewEmail, string NewPesel)
        {
            string tempCookieValue = HttpContext.Request.Cookies["opticianpractice_current-user-email"];
            
            User newUser, 
                oldUser = _usersManager.GetMatchingUsersByEmail(tempCookieValue)[0];

            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddMinutes(30);

            if (oldUser is ZakladOptyczny.Models.Actors.Patient)
            {
                newUser = new Patient("", "", "", "");
            }
            else if (oldUser is ZakladOptyczny.Models.Actors.Optician)
            {
                newUser = new Optician("", "", "", "");
            }
            else if (oldUser is ZakladOptyczny.Models.Actors.Receptionist)
            {
                newUser = new Receptionist("", "", "", "");
            }
            else
            {
                newUser = new Patient("","","","");
            }

            if (NewName != null)
            {
                oldUser.Name = NewName;
                Response.Cookies.Delete("opticianpractice_current-user-name");
                Response.Cookies.Append("opticianpractice_current-user-name", NewName, option);
            }
            if (NewSurname != null)
            {
                oldUser.Surname = NewSurname;
                Response.Cookies.Delete("opticianpractice_current-user-surname");
                Response.Cookies.Append("opticianpractice_current-user-surname", NewSurname, option);
            }
            if (NewEmail != null)
            {
                oldUser.Email = NewEmail;
                Response.Cookies.Delete("opticianpractice_current-user-email");
                Response.Cookies.Append("opticianpractice_current-user-email", NewEmail, option);
            }
            if (NewPesel != null)
            {
                oldUser.Pesel = NewPesel;
                Response.Cookies.Delete("opticianpractice_current-user-pesel");
                Response.Cookies.Append("opticianpractice_current-user-pesel", NewPesel, option);
            }

            _usersManager.UpdateUser(oldUser);
            return View("profile");
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
            User u1;

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
                u1 = _usersManager.AddUser(new Patient(claimsList[2].Value,
                    claimsList[3].Value,
                    "",
                    claimsList[4].Value));
            }
            else
            { 
                u1 = userCheckList[0];
            }
            
            CookieOptions option = new CookieOptions();

            option.Expires = DateTime.Now.AddMinutes(30);

            Response.Cookies.Append("opticianpractice_current-user-name",
                u1.Name, option);
            Response.Cookies.Append("opticianpractice_current-user-surname",
                u1.Surname, option);
            Response.Cookies.Append("opticianpractice_current-user-pesel",
                u1.Pesel, option);
            Response.Cookies.Append("opticianpractice_current-user-email",
                u1.Email, option);

            return RedirectToAction("StronaGlowna");
        }

        public async Task<IActionResult> GoogleLogout()
        {
            Response.Cookies.Delete("opticianpractice_current-user-name");
            Response.Cookies.Delete("opticianpractice_current-user-surname");
            Response.Cookies.Delete("opticianpractice_current-user-pesel");
            Response.Cookies.Delete("opticianpractice_current-user-email");

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