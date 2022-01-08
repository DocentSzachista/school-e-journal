using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolEJournalWeb.Encryption
{
    public enum AttendedState
    {
        [Display(Name ="Niesprawdzono")]
        NotChecked = 0,
        [Display(Name ="Obecny")]
        Present = 1,
        [Display(Name ="Spóźnony")]
        Late = 2,
        [Display(Name = "Nieobecny")]
        Absent = 3
    }
}
