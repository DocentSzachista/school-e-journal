using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolEJournalWeb.Models
{
    public partial class Grade
    {
        public int GradeId { get; set; }
        public int Value { get; set; }
        public int StudentId { get; set; }
        public int GradeGroupId { get; set; }

        public virtual GradesGroup GradeGroup { get; set; }
    }
}
