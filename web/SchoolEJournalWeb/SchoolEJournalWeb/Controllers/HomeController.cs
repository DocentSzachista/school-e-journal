using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolEJournalWeb.Encryption;
using SchoolEJournalWeb.Models;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


namespace SchoolEJournalWeb.Controllers
{
    public class HomeController : Controller
    {
        //        private readonly ILogger<HomeController> _logger;
        private readonly SchoolEJournalContext _context;
        public HomeController(SchoolEJournalContext context)
        {
            _context = context;
        }


        [Authorize(AuthenticationSchemes = "myCookie")]
        public IActionResult Index()
        {

            return View();
        }
    /*    [HttpPost]
        public IActionResult Index(LoginDatum loginData)
        {
            try
            {
                Console.WriteLine($" {loginData.Login} {loginData.Password}");
                var dataBaseData = _context.LoginData.SingleOrDefault(entity => entity.Login.Equals(loginData.Login));
                Console.WriteLine(dataBaseData.Password);
                if (PasswordChecker.VerifyPassword(loginData.Password, dataBaseData.Password))
                    return RedirectToAction("Index", "User");
                // TODO : add custom page for login fail
                else
                    return Unauthorized();
            }
            catch(Exception e)
            {
                // TODO: Same as in try block 
                return Unauthorized();
            }
        }*/
        [Authorize(AuthenticationSchemes = "myCookie")]
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
