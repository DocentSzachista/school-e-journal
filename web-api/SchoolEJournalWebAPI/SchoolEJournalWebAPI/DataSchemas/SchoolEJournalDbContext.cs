using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolEJournalWebAPI.DataSchemas
{
    public class SchoolEJournalDbContext : DbContext
    {
       public SchoolEJournalDbContext(DbContextOptions<SchoolEJournalDbContext> options)
            : base(options)
       {

       }
        public DbSet<Users> Users { get; set;}
    }
}
