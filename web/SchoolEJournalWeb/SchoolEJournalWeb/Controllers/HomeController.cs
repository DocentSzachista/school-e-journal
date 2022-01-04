using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolEJournalWeb.Models;
using SchoolEJournalWeb.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolEJournalWeb.Controllers
{
    public class HomeController : Controller
    {
        //        private readonly ILogger<HomeController> _logger;
        private readonly SchoolEJournalDbContext _context;
        public HomeController(SchoolEJournalDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Index(LoginData loginData)
        {
            Console.WriteLine($" {loginData.Login} {loginData.Password}");
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
