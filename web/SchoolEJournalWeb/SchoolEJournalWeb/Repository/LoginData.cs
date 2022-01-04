using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolEJournalWeb.Repository
{
    public class LoginData
    {
        [Key]
        public int LoginDataId { get; set; }
        
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        public int UserId { get; set; }
    }
}
