using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolEJournalWeb.ViewModels
{
	public class StudentGradeView
	{
		public int UserId { get; set; }
		public int GradeId { get; set; }
		public int Value { get; set; }
		public int Weight { get; set; }
		public string GradeGroupName { get; set; }
		public string SubjectName { get; set; }
	}
}
