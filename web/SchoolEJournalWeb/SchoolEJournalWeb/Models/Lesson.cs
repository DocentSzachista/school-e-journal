using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolEJournalWeb.Models
{
    public partial class Lesson
    {
        public Lesson()
        {
            Attendances = new HashSet<Attendance>();
        }

        public int LessonId { get; set; }
        public string Topic { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int SubjectId { get; set; }

        public virtual Subject Subject { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}
