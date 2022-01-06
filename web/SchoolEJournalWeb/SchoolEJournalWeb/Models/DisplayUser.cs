using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolEJournalWeb.Models
{
    public partial class DisplayUser
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
