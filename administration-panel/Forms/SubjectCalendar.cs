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
		private struct DisplayedLesson
		{
			public string topic;
			public DateTime startDate;
			public DateTime endDate;
			public int id;
		}

		private int subjectId;
		private Lessons lessons;
		private DataTable data;
		private List<DisplayedLesson> displayedLessons;

		public SubjectCalendar(int subjectId)
		{
			InitializeComponent();

			this.subjectId = subjectId;

			lessons = new Lessons();
			displayedLessons = new List<DisplayedLesson>();

			FetchData();

			if (data.Rows.Count == 0)
			{
				MessageBox.Show("Brak lekcji dla wybranego przedmiotu");
				Close();
			}
			else
				subjectName.Text = data.Rows[0]["SubjectName"].ToString();
		}

		private void FetchData()
		{
			ClearLessonDisplay();
			data = lessons.GetSubjectLessons(subjectId);

			ClearLessonDisplay();
			PopulateCalendar();
		}

		private void PopulateCalendar()
		{
			calendar.RemoveAllBoldedDates();

			foreach(DataRow row in data.Rows)
			{
				calendar.AddBoldedDate(DateTime.Parse(row["StartTime"].ToString()));
			}

			calendar.UpdateBoldedDates();
		}

		private void ClearLessonDisplay()
		{
			lessonSelect.Maximum = 0;
			lessonSelect.Value = 0;
			topicText.Text = "";
			startDate.Value = DateTime.Now;
			endDate.Value = DateTime.Now;
		}

		private void UpdateDisplayLessons()
		{
			lessonSelect.Maximum = Math.Max(0, displayedLessons.Count - 1);
			lessonSelect.Value = 0;
			if (displayedLessons.Count != 0)
			{
				topicText.Text = displayedLessons[0].topic;
				startDate.Value = displayedLessons[0].startDate;
				endDate.Value = displayedLessons[0].endDate;
			}
			else
			{
				startDate.Value = calendar.SelectionStart;
				endDate.Value = calendar.SelectionStart;
			}
		}

		private void calendar_DateChanged(object sender, DateRangeEventArgs e)
		{
			ClearLessonDisplay();
			displayedLessons.Clear();

			foreach(DateTime date in calendar.BoldedDates)
			{
				if(DateTime.Compare(date.Date, e.Start.Date) == 0)
				{
					foreach(DataRow row in data.Select($"StartTime = '{date}'"))
					{
						DisplayedLesson lesson = new DisplayedLesson();
						lesson.startDate = DateTime.Parse(row["StartTime"].ToString());
						lesson.endDate = DateTime.Parse(row["EndTime"].ToString());
						lesson.topic = row["Topic"].ToString();
						lesson.id = int.Parse(row["LessonId"].ToString());

						displayedLessons.Add(lesson);
					}
				}
			}
			UpdateDisplayLessons();
		}

		private void lessonSelect_ValueChanged(object sender, EventArgs e)
		{
			int index = (int)lessonSelect.Value;
			if (index >= 0 || index < displayedLessons.Count)
			{
				topicText.Text = displayedLessons[index].topic;
				startDate.Value = displayedLessons[index].startDate;
				endDate.Value = displayedLessons[index].endDate;
			}
		}

		private void addButton_Click(object sender, EventArgs e)
		{
			lessons.InsertData(new string[] { topicText.Text, startDate.Value.ToString("s"), endDate.Value.ToString("s"), subjectId.ToString() });
			FetchData();
		}

		private void modifyButton_Click(object sender, EventArgs e)
		{
			int index = (int)lessonSelect.Value;
			if (index >= 0 || index < displayedLessons.Count)
			{
				lessons.UpdateData(new string[] { topicText.Text, startDate.Value.ToString("s"), endDate.Value.ToString("s"), subjectId.ToString() }, displayedLessons[index].id);
				FetchData();
			}
		}

		private void removeButton_Click(object sender, EventArgs e)
		{
			int index = (int)lessonSelect.Value;
			if (index >= 0 || index < displayedLessons.Count)
			{
				lessons.DeleteData(displayedLessons[index].id);
				FetchData();
			}
		}
	}
}
