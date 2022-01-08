using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolEJournalWeb.ViewModels
{
    public class TeacherCalendarView
    {
        public string UserName { get; set; }
        public int Attended { get; set; }
        public int LessonId { get; internal set; }
        public int StudentId { get; internal set; }
    }
}
