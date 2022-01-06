using System;
using System.Collections.Generic;

#nullable disable

namespace SchoolEJournalWeb.Models
{
    public partial class User
    {
        public User()
        {
            Classes = new HashSet<Class>();
            InverseParent = new HashSet<User>();
            LoginData = new HashSet<LoginDatum>();
            TeachersMemberships = new HashSet<TeachersMembership>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int UserType { get; set; }
        public int? ParentId { get; set; }
        public int? ClassId { get; set; }

        public virtual Class Class { get; set; }
        public virtual User Parent { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<User> InverseParent { get; set; }
        public virtual ICollection<LoginDatum> LoginData { get; set; }
        public virtual ICollection<TeachersMembership> TeachersMemberships { get; set; }
    }
}
