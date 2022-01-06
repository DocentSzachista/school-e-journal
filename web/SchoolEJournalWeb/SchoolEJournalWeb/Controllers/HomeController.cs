using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Index(LoginDatum loginData)
        {
            Console.WriteLine($" {loginData.Login} {loginData.Password}");
            var xD = _context.Users.Select(s => s.FirstName).ToList();

            return RedirectToAction("Index", "User");
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
