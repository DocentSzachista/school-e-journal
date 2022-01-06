using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SchoolEJournalWeb.Encryption;
using SchoolEJournalWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SchoolEJournalWeb.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly SchoolEJournalContext _context;


        public AuthenticationController(SchoolEJournalContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginDatum loginData, string returnUrl = null)
        {
            if(ModelState.IsValid)
            {
                if(ValidateUser(loginData))
                {
                    var claims = new List<Claim>
                    {
                       // new Claim("user", loginData.UserId.ToString()),
                        new Claim("user", "1"),
                        new Claim("role", "member")
                    };
                    await HttpContext.SignInAsync(new ClaimsPrincipal(new ClaimsIdentity(claims, "Cookies", "user", "role" )));

                    if(returnUrl != null)
                    {
                        Redirect(returnUrl);
                    }
                    else
                    {
                        Redirect("/");
                    }

                }
                else
                {
                    ModelState.AddModelError("", "Invalid Login Credentials Provided");
                }
            }
            return View();
        }

        private bool ValidateUser(LoginDatum loginData)
        {
            var dataBaseData = _context.LoginData.SingleOrDefault(entity => entity.Login.Equals(loginData.Login));
            if (PasswordChecker.VerifyPassword(loginData.Password, dataBaseData.Password))
                return true;
            return false;
        }

        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync();
            return Redirect("/Authentication/login");
        }
    }
}
