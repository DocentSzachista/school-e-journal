using SchoolEJournalWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolEJournalWeb.ViewModels
{
    public class UpdateLessonView
    {
        public Lesson Lesson { get; set; }
        public List<StudentAttendanceView> attendances { get; set; }
    }
    public class StudentAttendanceView
    {
        public string UserName { get; set; }
        public int AttId { get; set; }
        public int Att { get; set; }
    }
}
