using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolEJournalWeb.Repository
{
    public class Classes
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public int SupervisingTeacherId { get; set; }
    }
}
