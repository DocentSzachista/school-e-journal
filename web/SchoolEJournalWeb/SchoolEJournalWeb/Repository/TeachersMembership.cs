using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolEJournalWeb.Repository
{
    public class TeachersMembership
    {
        public int TeacherMembershipId { get; set; }
        public int TeacherId { get; set; }

        public int SubjectId { get; set; }
    }
}
