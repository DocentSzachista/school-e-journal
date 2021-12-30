
namespace DamianRaczkowskiLab2PracDom.Forms
{
	partial class SubjectCalendar
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.calendar = new System.Windows.Forms.MonthCalendar();
			this.label1 = new System.Windows.Forms.Label();
			this.subjectName = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// calendar
			// 
			this.calendar.Location = new System.Drawing.Point(18, 35);
			this.calendar.Name = "calendar";
			this.calendar.TabIndex = 0;
			this.calendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.calendar_DateChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(15, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(75, 17);
			this.label1.TabIndex = 1;
			this.label1.Text = "Przedmiot:";
			// 
			// subjectName
			// 
			this.subjectName.Location = new System.Drawing.Point(96, 6);
			this.subjectName.Name = "subjectName";
			this.subjectName.ReadOnly = true;
			this.subjectName.Size = new System.Drawing.Size(100, 22);
			this.subjectName.TabIndex = 2;
			// 
			// SubjectCalendar
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.subjectName);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.calendar);
			this.Name = "SubjectCalendar";
			this.Text = "SubjectCalendar";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MonthCalendar calendar;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox subjectName;
	}
}