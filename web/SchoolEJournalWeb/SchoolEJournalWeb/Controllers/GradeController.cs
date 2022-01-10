using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolEJournalWeb.Models;
using SchoolEJournalWeb.ViewModels;
using SchoolEJournalWeb.Encryption;

namespace SchoolEJournalWeb.Controllers
{
	public class GradeController : Controller
	{
		private readonly SchoolEJournalContext _context;

		public GradeController(SchoolEJournalContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult ShowGrades()
		{
			UserType userType = (UserType)int.Parse(HttpContext.User.Claims.ToList()[2].Value);
			ViewData["UserType"] = userType;
			switch(userType)
			{
				case UserType.Student:
					ViewData["GradeData"] = GetStudentGradeInfo();
					break;
				case UserType.Teacher:
					ViewData["GradeData"] = GetTeacherGradeInfo();
					break;
			}
			
			return View("~/Views/User/SharedResources/Grades/GradeView.cshtml");
		}

		private Dictionary<string, List<StudentGradeView>> GetStudentGradeInfo()
		{
			Dictionary<string, List<StudentGradeView>> returnDict = new Dictionary<string, List<StudentGradeView>>();

			int userId = int.Parse(HttpContext.User.Claims.ToList()[0].Value);

			var query = from g in _context.Grades
						where g.StudentId == userId
						select new StudentGradeView
						{
							UserId = userId,
							GradeId = g.GradeId,
							GradeGroupName = g.GradeGroup.Name,
							Value = g.Value,
							Weight = g.GradeGroup.Weight,
							SubjectName = g.GradeGroup.Subject.SubjectName
						};
			foreach (var element in query)
			{
				if (!returnDict.ContainsKey(element.SubjectName))
					returnDict.Add(element.SubjectName, new List<StudentGradeView>());

				returnDict[element.SubjectName].Add(element);
			}

			return returnDict;
		}

		private List<TeacherSubjectGradeView> GetTeacherGradeInfo()
		{
			List<TeacherSubjectGradeView> returnList = new List<TeacherSubjectGradeView>();

			int userId = int.Parse(HttpContext.User.Claims.ToList()[0].Value);

			var query = from tm in _context.TeachersMemberships
						where tm.TeacherId == userId && tm.SubjectId != null
						select new TeacherSubjectGradeView
						{
							SubjectId = (int)tm.SubjectId,
							SubjectName = tm.Subject.SubjectName,
							ClassName = tm.Subject.Class.ClassName,
						};

			returnList.AddRange(query);
			return returnList;
		}

		public IActionResult InspectSubject(int subjectId, string subjectName, string className)
		{
			ViewData["SubjectName"] = subjectName;
			ViewData["ClassName"] = className;
			ViewData["SubjectId"] = subjectId;

			ViewData["GradeGroups"] = GetGradeGroupViews(subjectId);

			return View("~/Views/User/SharedResources/Grades/SubjectGradesView.cshtml");
		}

		private List<TeacherGradeGroupView> GetGradeGroupViews(int subjectId)
		{
			List<TeacherGradeGroupView> returnList = new List<TeacherGradeGroupView>();

			var query = from gg in _context.GradesGroups
						where gg.SubjectId == subjectId
						select new TeacherGradeGroupView
						{
							GroupId = gg.Id,
							GroupName = gg.Name,
						};

			returnList.AddRange(query);
			return returnList;
		}

		public IActionResult CreateNewGradeGroup(int subjectId)
		{
			return View();
		}

		public IActionResult InspectGradeGroup(int groupId, string groupName)
		{
			GradesGroup group = (from gg in _context.GradesGroups
								where gg.Id == groupId
								select gg).First();

			ViewData["GroupName"] = groupName;

			return View();
		}
	}
}
