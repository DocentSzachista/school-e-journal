using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolEJournalWeb.Repository
{
    public class Grades
    {
        public int GradeId { get; set; }
        public int Value { get; set; }
        public int StudentId { get; set; }
        public int GradeGroupId { get; set; }
    }
}
