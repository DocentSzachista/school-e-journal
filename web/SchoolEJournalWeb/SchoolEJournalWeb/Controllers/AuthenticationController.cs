using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SchoolEJournalWeb.Encryption;
using SchoolEJournalWeb.Models;
using SchoolEJournalWeb.ViewModels;
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
                Credentials credentials;

                if(ValidateUser(loginData, out credentials))
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, credentials.UserId.ToString()),
                        new Claim("Name", credentials.Name),
                        new Claim("UserType", credentials.UserType.ToString())
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

        private bool ValidateUser(LoginDatum loginData,  out Credentials dataBaseData)
        {
             dataBaseData = (from credentials in _context.LoginData
                                join user in _context.Users on credentials.UserId equals user.UserId
                                where credentials.Login.Equals(loginData.Login)
                                select new Credentials 
                                { 
                                    Password = credentials.Password, 
                                    Name = user.FirstName + " " + user.LastName, 
                                    UserType = user.UserType, 
                                    UserId = credentials.UserId }
                                ).FirstOrDefault();
               
            
           
            if (PasswordChecker.VerifyPassword(loginData.Password, dataBaseData.Password))
            {
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
