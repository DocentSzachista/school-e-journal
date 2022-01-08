using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolEJournalWeb.ViewModels
{
    public class Credentials
    {
        public int UserId { get; set; }
        public int UserType { get; set; }

        public string Password { get; set; }
        
        public string Name { get; set; }
    }
}
