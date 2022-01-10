using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolEJournalWeb.Models;
using SchoolEJournalWeb.Encryption;
using SchoolEJournalWeb.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;

namespace SchoolEJournalWeb.Controllers
{
	public class CalendarController : Controller
	{
		private readonly SchoolEJournalContext _context;
		private int id;
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
			UserType userType = (UserType)int.Parse(HttpContext.User.Claims.ToList()[2].Value);
			DateTime date = DateTime.Parse(selectedDate);
			IQueryable dataToSend = CreateCalendar(date, userType);
			AddToViewData(dataToSend, userType);


			ViewData["DisplayedDate"] = date.ToString("yyyy-MM-dd");
			ViewData["UserType"] = userType;
			
			return View("~/Views/User/SharedResources/CalendarView.cshtml");
		}

		public IQueryable CreateCalendar(DateTime date, UserType userType)
		{
			
			
			int userId = int.Parse(HttpContext.User.Claims.ToList()[0].Value);
			//List<string> returnList = new List<string>();
			// test section 
			switch (userType)
			{
				case UserType.Student:
                {
						List<StudentCalendarView> returnList = new List<StudentCalendarView>();

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
				
						return studentView;
					}

				case UserType.Teacher:
                {
					
						var teacherAttendanceView = (from t in _context.TeachersMemberships
										   join s in _context.Subjects on t.TeacherId equals userId
										   join l in _context.Lessons on s.SubjectId equals l.SubjectId
										   where  l.StartTime.Date == date.Date 
										   select  new TeacherCalendarView { 
											   Subject = s.SubjectName,
											   LessonId = l.LessonId,
											   Topic = l.Topic
										   }).Distinct();
					
						return teacherAttendanceView;
				}
				case UserType.Parent:
                {
						var parentAttendanceView = (from l in _context.DisplayLessons
													join u in _context.Users on l.ClassName equals u.Class.ClassName
													join a in _context.Attendances on u.UserId equals a.StudentId
													where u.ParentId == userId && l.StartTime.Date == date.Date
													orderby l.StartTime.TimeOfDay ascending
													select new StudentCalendarView
													{
														UserName = u.FirstName + " " + u.LastName,
														SubjectName = l.SubjectName,
														StartTime = l.StartTime.ToShortTimeString(),
														Topic = string.IsNullOrEmpty(l.Topic) ? "Brak Tematu" : l.Topic,
														EndTime = l.EndTime.ToShortTimeString(),
														Attended = ConvertAttendanceToString(a.Attended)
													}).Distinct();
						return parentAttendanceView;
                }
					
			}
			throw new Exception("NO datatype");
			
		}
		private void AddToViewData(IQueryable data, UserType userType)
        {
			switch(userType)
            {
				case UserType.Teacher:
                    {
						List<TeacherCalendarView> teacherCalendars = new List<TeacherCalendarView>();
                        foreach (var item in data)
                        {
							teacherCalendars.Add((TeacherCalendarView)item);
                        }
						ViewData["CalendarData"] = teacherCalendars;
						break;
                    }
				case UserType.Parent:
				case UserType.Student:
                {
						List<StudentCalendarView> teacherCalendars = new List<StudentCalendarView>();
						foreach (var item in data)
						{
							teacherCalendars.Add((StudentCalendarView)item);
						}
						ViewData["CalendarData"] = teacherCalendars;
						break;
				}
					
            }
        }

		public IActionResult AttendanceCheck(int LessonId)
        {
			this.id = LessonId;
			var lesson = (from x in _context.Lessons
						 where x.LessonId == LessonId
						 select x).FirstOrDefault();
			List<StudentAttendanceView> attendances = new List<StudentAttendanceView>();
			var teacherAttendanceView = (from l in _context.Lessons
										 join a in _context.Attendances on l.LessonId equals a.LessonId
										 join u in _context.Users on a.StudentId equals u.UserId
										 where l.LessonId == LessonId
										 select new StudentAttendanceView 
										 {
											Att = a.Attended,
											AttId = a.AttendanceId,
											UserName =  $"{u.FirstName} {u.LastName} "
										 
										 }).Distinct();
			foreach(var item in teacherAttendanceView)
            {
				attendances.Add(item);
            }
			UpdateLessonView dataToSend = new() ;
			dataToSend.attendances = attendances;
			dataToSend.Lesson = lesson;
				

			//ViewData["UpdateData"] = dataToSend ;	
			return View("~/Views/User/SharedResources/CheckAttendanceView.cshtml", dataToSend);
        }
		[HttpPost]
		public IActionResult AttendanceCheck(UpdateLessonView view)
        {

			Console.WriteLine($"{Request.Form["Topic"]} xDDD");
			var lesson = (from l in _context.Lessons
						  where l.LessonId == int.Parse(Request.Form["id"])
						  select l).FirstOrDefault();
			lesson.Topic = Request.Form["Topic"];
			var teacherAttendanceView = (from l in _context.Lessons
										 join a in _context.Attendances on l.LessonId equals a.LessonId
										 join u in _context.Users on a.StudentId equals u.UserId
										 where l.LessonId == int.Parse(Request.Form["id"])
										 select a).Distinct();
            foreach (var item in Request.Form.Keys)
            {
				Console.WriteLine(item);
            }
			
			
			foreach (var item in teacherAttendanceView)
			{
				string key = $"attendence-{item.AttendanceId}";
				item.Attended = int.Parse(Request.Form[key]);
			}
			_context.SaveChanges();
			return (ShowCalendar());
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
				case AttendedState.Justified:
					return "Usprawiedliwony";
				default:
					return "Niesprawdzona";
            }
        }



	}
}
