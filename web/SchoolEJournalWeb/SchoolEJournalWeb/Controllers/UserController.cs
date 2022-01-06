using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolEJournalWeb.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
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
        [Authorize(AuthenticationSchemes = "myCookie")]
        public IActionResult Index()
        { 
            return View();
        }
        [Authorize(AuthenticationSchemes = "myCookie")]
        public IActionResult ChangePassword()
        {
            return View("~/Views/User/SharedResources/ChangePassword.cshtml");
        }
        [Authorize(AuthenticationSchemes = "myCookie")]
        public IActionResult EditData()
        {
            return View("~/Views/User/SharedResources/ChangeUserData.cshtml");
        }
    }
}
