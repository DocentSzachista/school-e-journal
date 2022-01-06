using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolEJournalWeb.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolEJournalWeb.Controllers
{
    public class UserController : Controller
    {
        private readonly SchoolEJournalContext _context;
        public UserController(SchoolEJournalContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        { 
            return View();
        }
        public IActionResult ChangePassword()
        {
            return View("~/Views/User/SharedResources/ChangePassword.cshtml");
        }
        public IActionResult EditData()
        {
            return View("~/Views/User/SharedResources/ChangeUserData.cshtml");
        }
    }
}
