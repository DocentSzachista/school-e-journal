using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolEJournalWeb.Repository
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }

        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int UserType { get; set; }
        public int? ParentId { get; set; }
        public int? ClassId { get; set; }
    }
}
