using SchoolEJournalWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolEJournalWeb.Encryption
{
    public class LoginCookie
    {
        public bool SetUpCookie(double expireTime, User user)
        {
            
            return true;
        }
        public bool ExpireCookie(string cookieName)
        {

            return true;
        }
    }
}
