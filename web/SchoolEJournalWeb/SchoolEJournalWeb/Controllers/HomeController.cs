using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolEJournalWeb.Encryption;
using SchoolEJournalWeb.Models;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;

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
            var cookieData = HttpContext.User.Claims.ToList();
            Console.WriteLine(cookieData[0].Value);
            ViewBag.UserName = cookieData[1].Value;
            return View();
        }

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
