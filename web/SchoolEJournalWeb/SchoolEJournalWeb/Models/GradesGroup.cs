using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolEJournalWeb.Models
{
    public partial class GradesGroup
    {
        public GradesGroup()
        {
            Grades = new HashSet<Grade>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public int SubjectId { get; set; }

        public virtual Subject Subject { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
    }
}
