using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolEJournalWeb.Models
{
    public partial class TeachersMembership
    {
        public int TeacherMembershipId { get; set; }
        public int? TeacherId { get; set; }
        public int? SubjectId { get; set; }

        public virtual Subject Subject { get; set; }
        public virtual User Teacher { get; set; }
    }
}
