using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolEJournalWeb.Repository
{
    public class Lessons
    {
        public int LessonId { get; set; }
        public string Topic { get; set; }
        public DateTime StarTime { get; set; }
        public DateTime EndTime { get; set; }
        public int SubjectId { get; set; }
    }
}
