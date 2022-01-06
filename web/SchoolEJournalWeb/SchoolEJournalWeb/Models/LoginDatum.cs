using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolEJournalWeb.Models
{
    public partial class LoginDatum
    {
        public int LoginDataId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
