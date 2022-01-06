using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolEJournalWeb.Models
{
    public partial class Class
    {
        public Class()
        {
            Subjects = new HashSet<Subject>();
            Users = new HashSet<User>();
        }

        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public int? SupervisingTeacherId { get; set; }

        public virtual User SupervisingTeacher { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
