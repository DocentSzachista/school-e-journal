using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Database;

namespace DamianRaczkowskiLab2PracDom.Forms
{
	public partial class SubjectCalendar : Form
	{
		private int subjectId;
		private Lessons lessons;
		private DataTable data;

		public SubjectCalendar(int subjectId)
		{
			InitializeComponent();

			this.subjectId = subjectId;

			lessons = new Lessons();
			data = lessons.GetSubjectLessons(subjectId);
			if(data.Rows.Count == 0)
			{
				MessageBox.Show("Brak lekcji dla wybranego przedmiotu");
				Close();
			}
			else
			{
				subjectName.Text = data.Rows[0]["SubjectName"].ToString();
				PopulateCalendar();
			}
		}

		private void PopulateCalendar()
		{
			calendar.RemoveAllBoldedDates();

			foreach(DataRow row in data.Rows)
			{
				calendar.AddBoldedDate(DateTime.Parse(row["StartTime"].ToString()));
			}
		}

		private void calendar_DateChanged(object sender, DateRangeEventArgs e)
		{
			foreach(DateTime date in calendar.BoldedDates)
			{
				if(DateTime.Compare(date.Date, e.Start.Date) == 0)
				{
					
				}
			}
		}
	}
}
