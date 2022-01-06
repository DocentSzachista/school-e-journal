using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolEJournalWeb.Models
{
    public partial class Attendance
    {
        public int AttendanceId { get; set; }
        public int Attended { get; set; }
        public int StudentId { get; set; }
        public int LessonId { get; set; }

        public virtual Lesson Lesson { get; set; }
    }
}
