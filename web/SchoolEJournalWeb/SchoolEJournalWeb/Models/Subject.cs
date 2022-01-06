using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolEJournalWeb.Models
{
    public partial class Subject
    {
        public Subject()
        {
            GradesGroups = new HashSet<GradesGroup>();
            Lessons = new HashSet<Lesson>();
            TeachersMemberships = new HashSet<TeachersMembership>();
        }

        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int ClassId { get; set; }

        public virtual Class Class { get; set; }
        public virtual ICollection<GradesGroup> GradesGroups { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
        public virtual ICollection<TeachersMembership> TeachersMemberships { get; set; }
    }
}
