using Microsoft.EntityFrameworkCore;
using SchoolEJournalWeb.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolEJournalWeb.Models
{
    public class SchoolEJournalDbContext:DbContext
    {
        public SchoolEJournalDbContext(DbContextOptions<SchoolEJournalDbContext> options)
        : base(options)
        {

        }
        public DbSet<Users> Users { get; set; }
        public DbSet<LoginData> LoginData { get; set; }
        public DbSet<Attendances> Attendances { get; set; }
        public DbSet<Subjects> Subjects  { get; set; }
        public DbSet<Lessons> Lessons { get; set; }
        public DbSet<Classes> Classes{ get; set; }
        public DbSet<Grades> Grades { get; set; }
        public DbSet<GradesGroups> GradesGroups { get; set; }
        public DbSet<TeachersMembership> TeachersMemberships { get; set; }

    }
}
