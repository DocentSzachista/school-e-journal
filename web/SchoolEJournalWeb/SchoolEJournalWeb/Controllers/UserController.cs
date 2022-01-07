using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchoolEJournalWeb.Encryption;
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
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
        }
        [Authorize(AuthenticationSchemes = "myCookie")]
        public IActionResult ChangePassword()
        {
            
            return View("~/Views/User/SharedResources/ChangePassword.cshtml");
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = "myCookie")]
        public IActionResult ChangePassword(LoginDatum loginData)
        {
            LoginDatum dataToCHange = (from x in _context.LoginData
                                       where x.UserId == int.Parse(HttpContext.User.Claims.ToList()[0].Value)
                                       select x).FirstOrDefault();
            
            dataToCHange.Password = PasswordChecker.EncryptPassword(loginData.Password);
        
            _context.SaveChanges();
            return View("~/Views/User/SharedResources/ChangePassword.cshtml");
        }



        [Authorize(AuthenticationSchemes = "myCookie")]
        public IActionResult EditData()
        {
            var userId = HttpContext.User.Claims.ToList()[0].Value;
            var user = _context.Users.Where(user => user.UserId == int.Parse(userId)).FirstOrDefault();
            TempData["UserId"] = userId;
            TempData.Keep();
            return View("~/Views/User/SharedResources/ChangeUserData.cshtml", user);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = "myCookie")]
        public IActionResult EditData(User providedUserData)
        {
            User dataToChange = (from x in _context.Users
                                 where x.UserId == int.Parse(HttpContext.User.Claims.ToList()[0].Value)
                                 select x).FirstOrDefault();
            dataToChange.FirstName = providedUserData.FirstName;
            dataToChange.LastName = providedUserData.LastName;
            dataToChange.PhoneNumber= providedUserData.PhoneNumber;
            dataToChange.Email =  providedUserData.Email;
            dataToChange.SecondName = providedUserData.SecondName;
            _context.SaveChangesAsync();
            return View("~/Views/User/SharedResources/ChangeUserData.cshtml");
        }


    }
}
