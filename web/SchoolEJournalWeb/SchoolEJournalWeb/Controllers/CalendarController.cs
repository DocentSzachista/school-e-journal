using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolEJournalWeb.Models;

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

			ViewData["DisplayedDate"] = date.ToString("yyyy-MM-dd");
			ViewData["CalendarData"] = CreateCalendar(date);
			return View("~/Views/User/SharedResources/CalendarView.cshtml");
		}

		public List<string> CreateCalendar(DateTime date)
		{
			int userId = int.Parse(HttpContext.User.Claims.ToList()[0].Value);
			List<string> returnList = new List<string>();

			var query =
				from l in _context.DisplayLessons
				join u in _context.Users
				on l.ClassName equals u.Class.ClassName
				where l.StartTime.Date == date.Date
				orderby l.StartTime.TimeOfDay ascending
				select $"{l.SubjectName} ({l.StartTime.ToShortTimeString()} - {l.EndTime.ToShortTimeString()}) Temat: {(string.IsNullOrEmpty(l.Topic) ? "Brak tematu" : l.Topic)}";

			foreach (string lessonText in query)

				returnList.Add(lessonText);

			return returnList;
		}
	}
}
