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
        public IActionResult ChangePassword()
        {
            
            return View("~/Views/User/SharedResources/ChangePassword.cshtml");
        }
        [Authorize(AuthenticationSchemes = "myCookie")]
        public IActionResult EditData()
        {
            var userId = HttpContext.User.Claims.ToList()[0].Value;
            var user = _context.Users.Where(user => user.UserId == int.Parse(userId)).FirstOrDefault();
            ViewBag.userId = userId;
            return View("~/Views/User/SharedResources/ChangeUserData.cshtml", user);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = "myCookie")]
        public IActionResult EditData(User providedUserData, int userId)
        {
            
            return View("~/Views/User/SharedResources/ChangeUserData.cshtml");
        }


    }
}
