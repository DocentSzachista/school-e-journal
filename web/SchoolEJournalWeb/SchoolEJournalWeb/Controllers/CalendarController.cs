using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolEJournalWeb.Models;
using SchoolEJournalWeb.Encryption;
using SchoolEJournalWeb.ViewModels;

namespace SchoolEJournalWeb.Controllers
{
	public class CalendarController : Controller
	{
		private readonly SchoolEJournalContext _context;

		public CalendarController(SchoolEJournalContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult ShowCalendar()
		{
			return ChangeDate(DateTime.Now.ToString("yyyy-MM-dd"));
		}

		[HttpPost]
		public IActionResult ChangeDate(string selectedDate)
		{
			DateTime date = DateTime.Parse(selectedDate);
			List<StudentCalendarView> listToParse = CreateCalendar(date);
			ViewData["DisplayedDate"] = date.ToString("yyyy-MM-dd");
			ViewData["CalendarData"] = listToParse;
			return View("~/Views/User/SharedResources/CalendarView.cshtml");
		}

		public List<StudentCalendarView> CreateCalendar(DateTime date)
		{
			
			UserType userType = (UserType)int.Parse(HttpContext.User.Claims.ToList()[2].Value);
			int userId = int.Parse(HttpContext.User.Claims.ToList()[0].Value);
			//List<string> returnList = new List<string>();
			List<StudentCalendarView> returnList = new List<StudentCalendarView>();
			// test section 
			switch (userType)
			{
				case UserType.Student:
                {
						var studentView = (from l in _context.DisplayLessons
														   join u in _context.Users on l.ClassName equals u.Class.ClassName 
														   join a in _context.Attendances on new { X1 = u.UserId, X2 = l.LessonId }  equals new { X1 = a.StudentId, X2 = a.LessonId }
														   where l.StartTime.Date == date.Date  && u.UserId == userId
														   orderby l.StartTime.TimeOfDay ascending
														   select new StudentCalendarView {
															   UserName = u.FirstName +" "+u.LastName, 
															   SubjectName = l.SubjectName,
															   StartTime = l.StartTime.ToShortTimeString(),
															   Topic = string.IsNullOrEmpty(l.Topic) ? "Brak Tematu" : l.Topic,
															   EndTime = l.EndTime.ToShortTimeString(),
															   Attended = ConvertAttendanceToString(a.Attended)
														   });
						foreach( StudentCalendarView lesson in studentView)
                        {
							returnList.Add(lesson);
                        }
                }
					break;
					/*
				default:
				{
						var query =
							from l in _context.DisplayLessons
							join u in _context.Users
							on l.ClassName equals u.Class.ClassName
							where l.StartTime.Date == date.Date
							orderby l.StartTime.TimeOfDay ascending
							select $"{l.SubjectName} ({l.StartTime.ToShortTimeString()} - {l.EndTime.ToShortTimeString()}) Temat: {(string.IsNullOrEmpty(l.Topic) ? "Brak tematu" : l.Topic)}";


						foreach (string lessonText in query)

							returnList.Add(lessonText);
				}
					break;
					*/
			}
			return returnList;
		}
		private static string ConvertAttendanceToString(int attendanceType)
        {
			AttendedState state = (AttendedState)attendanceType;
			switch(state)
            {
				case AttendedState.NotChecked:
					return "Niesprawdzona";
				case AttendedState.Absent:
					return "Nieobecny";
				case AttendedState.Present:
					return "Obecny";
				case AttendedState.Late:
					return "Spóźnony";
				default:
					return "Niesprawdzona";
            }
        }



	}
}
