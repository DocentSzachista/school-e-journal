using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolEJournalWeb.Repository
{
    public class Attendances
    {
        [Key]
        public int AttendanceId { get; set; }
        [Required]
        public int Attended { get; set; }
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int LessonId { get; set; }
    }
}
