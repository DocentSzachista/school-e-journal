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
			ViewData["GradeData"] = GetGradeInfo();
			return View("~/Views/User/SharedResources/GradeView.cshtml");
		}

		public Dictionary<string, List<StudentGradeView>> GetGradeInfo()
		{
			Dictionary<string, List<StudentGradeView>> returnDict = new Dictionary<string, List<StudentGradeView>>();

			UserType userType = (UserType)int.Parse(HttpContext.User.Claims.ToList()[2].Value);
			int userId = int.Parse(HttpContext.User.Claims.ToList()[0].Value);

			switch(userType)
			{
				case UserType.Student:
					var query =
						from g in _context.Grades
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
					foreach(var element in query)
					{
						if (!returnDict.ContainsKey(element.SubjectName))
							returnDict.Add(element.SubjectName, new List<StudentGradeView>());

						returnDict[element.SubjectName].Add(element);
					}
					break;
			}
			return returnDict;
		}
	}
}
