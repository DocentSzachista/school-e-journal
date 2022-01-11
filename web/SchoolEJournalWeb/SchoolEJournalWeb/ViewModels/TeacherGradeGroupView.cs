using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolEJournalWeb.Models;

namespace SchoolEJournalWeb.ViewModels
{
	public class TeacherGradeGroupView
	{
		public string GradeGroupName { get; set; }
		public int GradeGroupWeight { get; set; }
		public int GradeGroupId { get; set; }
		public Dictionary<User, Grade> Grades { get; set; }
		public int ClassId { get; set; }
		public string ClassName { get; set; }
		public string SubjectName { get; set; }
		public int SubjectId { get; set; }
	}
}
