using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolEJournalWeb.Encryption
{
    // wrapper class for checking password 
    public static class PasswordChecker
    {
        public static string EncryptPassword(string pwd)
        {
            return BCrypt.Net.BCrypt.HashPassword(pwd);
        }
        public static bool VerifyPassword(string providedPassword, string databasePasswordHash)
        {
            return BCrypt.Net.BCrypt.Verify(providedPassword, databasePasswordHash);
        }

    }
}
