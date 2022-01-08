using SchoolEJournalWeb.Encryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolEJournalWeb.ViewModels
{
    public class StudentCalendarView
    {
        public int UserId { get; set; }
        public string SubjectName { get; set; }
        public string UserName { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Attended { get; set; }

        public string Topic { get; set; }

        public override string ToString()
        {
            return $"{SubjectName}  Temat: {Topic}  ( {StartTime} - {EndTime} ) {Attended}";
        }

    }
}
