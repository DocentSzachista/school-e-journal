
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
			this.lessonSelect = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.startDate = new System.Windows.Forms.DateTimePicker();
			this.endDate = new System.Windows.Forms.DateTimePicker();
			this.topicText = new System.Windows.Forms.TextBox();
			this.addButton = new System.Windows.Forms.Button();
			this.modifyButton = new System.Windows.Forms.Button();
			this.removeButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.lessonSelect)).BeginInit();
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
			// lessonSelect
			// 
			this.lessonSelect.Location = new System.Drawing.Point(470, 11);
			this.lessonSelect.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.lessonSelect.Name = "lessonSelect";
			this.lessonSelect.Size = new System.Drawing.Size(120, 22);
			this.lessonSelect.TabIndex = 3;
			this.lessonSelect.ValueChanged += new System.EventHandler(this.lessonSelect_ValueChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(411, 13);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 17);
			this.label2.TabIndex = 4;
			this.label2.Text = "Lekcja:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(411, 52);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(52, 17);
			this.label3.TabIndex = 5;
			this.label3.Text = "Temat:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(413, 92);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(42, 17);
			this.label4.TabIndex = 6;
			this.label4.Text = "Start:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(413, 127);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(51, 17);
			this.label5.TabIndex = 7;
			this.label5.Text = "Koniec";
			// 
			// startDate
			// 
			this.startDate.Format = System.Windows.Forms.DateTimePickerFormat.Time;
			this.startDate.Location = new System.Drawing.Point(470, 87);
			this.startDate.Name = "startDate";
			this.startDate.Size = new System.Drawing.Size(200, 22);
			this.startDate.TabIndex = 9;
			// 
			// endDate
			// 
			this.endDate.Format = System.Windows.Forms.DateTimePickerFormat.Time;
			this.endDate.Location = new System.Drawing.Point(470, 122);
			this.endDate.Name = "endDate";
			this.endDate.Size = new System.Drawing.Size(200, 22);
			this.endDate.TabIndex = 10;
			// 
			// topicText
			// 
			this.topicText.Location = new System.Drawing.Point(469, 49);
			this.topicText.Name = "topicText";
			this.topicText.Size = new System.Drawing.Size(200, 22);
			this.topicText.TabIndex = 11;
			// 
			// addButton
			// 
			this.addButton.Location = new System.Drawing.Point(416, 172);
			this.addButton.Name = "addButton";
			this.addButton.Size = new System.Drawing.Size(254, 30);
			this.addButton.TabIndex = 12;
			this.addButton.Text = "Dodaj";
			this.addButton.UseVisualStyleBackColor = true;
			this.addButton.Click += new System.EventHandler(this.addButton_Click);
			// 
			// modifyButton
			// 
			this.modifyButton.Location = new System.Drawing.Point(414, 208);
			this.modifyButton.Name = "modifyButton";
			this.modifyButton.Size = new System.Drawing.Size(254, 30);
			this.modifyButton.TabIndex = 13;
			this.modifyButton.Text = "Zmodyfikuj";
			this.modifyButton.UseVisualStyleBackColor = true;
			this.modifyButton.Click += new System.EventHandler(this.modifyButton_Click);
			// 
			// removeButton
			// 
			this.removeButton.Location = new System.Drawing.Point(414, 244);
			this.removeButton.Name = "removeButton";
			this.removeButton.Size = new System.Drawing.Size(254, 30);
			this.removeButton.TabIndex = 14;
			this.removeButton.Text = "Usuń";
			this.removeButton.UseVisualStyleBackColor = true;
			this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
			// 
			// SubjectCalendar
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(687, 289);
			this.Controls.Add(this.removeButton);
			this.Controls.Add(this.modifyButton);
			this.Controls.Add(this.addButton);
			this.Controls.Add(this.topicText);
			this.Controls.Add(this.endDate);
			this.Controls.Add(this.startDate);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lessonSelect);
			this.Controls.Add(this.subjectName);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.calendar);
			this.MaximizeBox = false;
			this.Name = "SubjectCalendar";
			this.Text = "Kalendarz przedmiotu";
			((System.ComponentModel.ISupportInitialize)(this.lessonSelect)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MonthCalendar calendar;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox subjectName;
		private System.Windows.Forms.NumericUpDown lessonSelect;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.DateTimePicker startDate;
		private System.Windows.Forms.DateTimePicker endDate;
		private System.Windows.Forms.TextBox topicText;
		private System.Windows.Forms.Button addButton;
		private System.Windows.Forms.Button modifyButton;
		private System.Windows.Forms.Button removeButton;
	}
}