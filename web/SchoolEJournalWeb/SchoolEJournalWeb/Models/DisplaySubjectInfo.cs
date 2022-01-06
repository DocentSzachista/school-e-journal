using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolEJournalWeb.Models
{
    public partial class DisplaySubjectInfo
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
