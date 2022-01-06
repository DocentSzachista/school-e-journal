using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolEJournalWeb.Controllers
{
	public class CalendarController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult ShowCalendar()
		{
			return View("~/Views/User/SharedResources/CalendarView.cshtml");
		}

		public IActionResult ChangeDate()
		{
			return View();
		}
	}
}
