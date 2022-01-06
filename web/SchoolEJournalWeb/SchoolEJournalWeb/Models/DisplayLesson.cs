using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolEJournalWeb.Models
{
    public partial class DisplayLesson
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Topic { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string ClassName { get; set; }
    }
}
