using SchoolEJournalWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolEJournalWeb.Controllers
{
    public class UserController
    {
        private readonly SchoolEJournalDbContext _context;
        public UserController(SchoolEJournalDbContext context)
        {
            _context = context;
        }

    }
}
