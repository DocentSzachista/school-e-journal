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

		private Dictionary<Subject, List<TeacherGradeGroupView>> GetTeacherGradeInfo()
		{
			Dictionary<Subject, List<TeacherGradeGroupView>> returnDict = new Dictionary<Subject, List<TeacherGradeGroupView>>();

			int userId = int.Parse(HttpContext.User.Claims.ToList()[0].Value);

			var subjects = from tm in _context.TeachersMemberships
						   where tm.TeacherId == userId && tm.SubjectId != null
						   select tm.Subject;

			List<Subject> sub = new List<Subject>(subjects);

			foreach(var subject in sub)
			{
				if(subject.Class == null)
				{
					subject.Class = (from s in _context.Subjects
									 where s.SubjectId == subject.SubjectId
									 select s.Class).First();
				}

				var studentsQuery = from u in _context.Users
									where u.ClassId == subject.ClassId
									select u;

				List<User> students = new List<User>(studentsQuery);

				List<TeacherGradeGroupView> views = new List<TeacherGradeGroupView>();
				var gradeGroups = from gg in _context.GradesGroups
								  join s in _context.Subjects
								  on gg.SubjectId equals s.SubjectId
								  where gg.SubjectId == subject.SubjectId
								  select new TeacherGradeGroupView
								  {
									  ClassId = s.ClassId,
									  ClassName = s.Class.ClassName,
									  GradeGroupId = gg.Id,
									  GradeGroupName = gg.Name,
									  Grades = new Dictionary<User, Grade>(),
									  SubjectName = s.SubjectName,
									  GradeGroupWeight = gg.Weight
								  };

				views.AddRange(gradeGroups);

				foreach(var group in views)
				{
					foreach(var student in students)
					{
						var grade = (from g in _context.Grades
									 where g.StudentId == student.UserId && g.GradeGroupId == @group.GradeGroupId
									 select g).FirstOrDefault();

						group.Grades.Add(student, grade);
					}
				}

				if(views.Count > 0)
				{
					returnDict.Add(subject, views);
				}
			}

			return returnDict;
		}

		public IActionResult InspectGradeGroup(TeacherGradeGroupView gradeGroupView)
		{
			return View("~/Views/User/SharedResources/Grades/GradeGroupView.cshtml", gradeGroupView);
		}

		public IActionResult CreateNewGradeGroup(int subjectId)
		{
			return View("~/Views/User/SharedResources/Grades/NewGradeGroup.cshtml", new TeacherGradeGroupView() { SubjectId = subjectId});
		}

		public IActionResult DeleteGradeGroup(TeacherGradeGroupView gradeGroupView)
		{
			GradesGroup res = (from gg in _context.GradesGroups
							   where gg.Id == gradeGroupView.GradeGroupId
							   select gg).FirstOrDefault();
			if(res != null)
			{
				var query = from g in _context.Grades
							where g.GradeGroupId == res.Id
							select g;

				foreach (var grade in query)
					_context.Grades.Remove(grade);

				_context.GradesGroups.Remove(res);
				_context.SaveChanges();
			}
			return ShowGrades();
		}

		public IActionResult SaveGradeGroup(TeacherGradeGroupView gradeGroupView)
		{
			GradesGroup group = (from gg in _context.GradesGroups
								 where gg.Id == gradeGroupView.GradeGroupId
								 select gg).First();

			group.Name = gradeGroupView.GradeGroupName;
			group.Weight = gradeGroupView.GradeGroupWeight;
			//group.Grades.Clear();
			//foreach(var userGradePair in gradeGroupView.Grades)
				//group.Grades.Add(userGradePair.Value);

			_context.SaveChanges();
			return InspectGradeGroup(gradeGroupView);
		}
	
		public IActionResult AddNewGroup(TeacherGradeGroupView gradeGroupView)
		{
			_context.GradesGroups.Add(new GradesGroup
			{
				Name = gradeGroupView.GradeGroupName,
				Weight = gradeGroupView.GradeGroupWeight,
				SubjectId = gradeGroupView.SubjectId
			});

			_context.SaveChanges();

			return ShowGrades();
		}
	}
}
