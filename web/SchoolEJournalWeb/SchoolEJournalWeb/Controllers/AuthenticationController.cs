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
            //Console.WriteLine(loginData.Password);
            if(ModelState.IsValid)
            {
                if(ValidateUser(loginData))
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, loginData.UserId.ToString()),
                        new Claim("role", "member")
                    };
                    var indentity = new ClaimsIdentity(claims, "myCookie");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(indentity);
                    await HttpContext.SignInAsync(claimsPrincipal);

                    if(returnUrl != null)
                    {
                        return RedirectToPage(returnUrl);
                    }
                    else
                    {
                        return RedirectToPage("/Home/Index");
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
            var dataBaseData = _context.LoginData.Single(entity => entity.Login.Equals(loginData.Login));
            
           
            if (PasswordChecker.VerifyPassword(loginData.Password, dataBaseData.Password))
            {
                loginData.UserId = dataBaseData.UserId;
                return true;
            }
                return false;
        }

        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync();
            return Redirect("/Authentication/login");
        }
    }
}
