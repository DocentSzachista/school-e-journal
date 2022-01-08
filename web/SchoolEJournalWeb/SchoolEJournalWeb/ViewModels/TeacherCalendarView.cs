using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolEJournalWeb.ViewModels
{
    public class TeacherCalendarView
    {
        public string Topic { get; set; }
        public int LessonId { get; internal set; }
        public string Subject { get; set; }
    }
}
