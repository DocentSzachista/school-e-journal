﻿
namespace DamianRaczkowskiLab2PracDom
{
    partial class FormMain
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
            this.dataGridViewUsers = new System.Windows.Forms.DataGridView();
            this.comboBoxViewChanger = new System.Windows.Forms.ComboBox();
            this.panelUserData = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSecondName = new System.Windows.Forms.TextBox();
            this.comboBoxUserType = new System.Windows.Forms.ComboBox();
            this.textBoxParentEmail = new System.Windows.Forms.TextBox();
            this.textBoxPhoneNumber = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.textBoxFirstName = new System.Windows.Forms.TextBox();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.panelClassData = new System.Windows.Forms.Panel();
            this.labelTeacher = new System.Windows.Forms.Label();
            this.labelClassName = new System.Windows.Forms.Label();
            this.dataGridViewTeachers = new System.Windows.Forms.DataGridView();
            this.textBoxClassName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).BeginInit();
            this.panelUserData.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.panelClassData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTeachers)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewUsers
            // 
            this.dataGridViewUsers.AllowUserToAddRows = false;
            this.dataGridViewUsers.AllowUserToDeleteRows = false;
            this.dataGridViewUsers.AllowUserToResizeColumns = false;
            this.dataGridViewUsers.AllowUserToResizeRows = false;
            this.dataGridViewUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUsers.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewUsers.Name = "dataGridViewUsers";
            this.dataGridViewUsers.Size = new System.Drawing.Size(776, 267);
            this.dataGridViewUsers.TabIndex = 0;
            this.dataGridViewUsers.SelectionChanged += new System.EventHandler(this.dataGridViewUsers_SelectionChanged);
            // 
            // comboBoxViewChanger
            // 
            this.comboBoxViewChanger.FormattingEnabled = true;
            this.comboBoxViewChanger.Items.AddRange(new object[] {
            "Użytkownicy",
            "Klasy"});
            this.comboBoxViewChanger.Location = new System.Drawing.Point(667, 285);
            this.comboBoxViewChanger.Name = "comboBoxViewChanger";
            this.comboBoxViewChanger.Size = new System.Drawing.Size(121, 21);
            this.comboBoxViewChanger.TabIndex = 2;
            this.comboBoxViewChanger.SelectedIndexChanged += new System.EventHandler(this.comboBoxViewChanger_SelectedIndexChanged);
            // 
            // panelUserData
            // 
            this.panelUserData.Controls.Add(this.label6);
            this.panelUserData.Controls.Add(this.label5);
            this.panelUserData.Controls.Add(this.label4);
            this.panelUserData.Controls.Add(this.label3);
            this.panelUserData.Controls.Add(this.label2);
            this.panelUserData.Controls.Add(this.label1);
            this.panelUserData.Controls.Add(this.textBoxSecondName);
            this.panelUserData.Controls.Add(this.comboBoxUserType);
            this.panelUserData.Controls.Add(this.textBoxParentEmail);
            this.panelUserData.Controls.Add(this.textBoxPhoneNumber);
            this.panelUserData.Controls.Add(this.textBoxEmail);
            this.panelUserData.Controls.Add(this.textBoxLastName);
            this.panelUserData.Controls.Add(this.textBoxFirstName);
            this.panelUserData.Location = new System.Drawing.Point(12, 332);
            this.panelUserData.Name = "panelUserData";
            this.panelUserData.Size = new System.Drawing.Size(431, 215);
            this.panelUserData.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(3, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Typ użytkownika:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(3, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 32);
            this.label5.TabIndex = 11;
            this.label5.Text = "Adres email\r\n Rodzica";
            this.label5.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(3, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Numer telefonu:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(3, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Email:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(3, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Nazwisko:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(3, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Imie i-lub drugie imie:";
            // 
            // textBoxSecondName
            // 
            this.textBoxSecondName.Location = new System.Drawing.Point(238, 14);
            this.textBoxSecondName.Name = "textBoxSecondName";
            this.textBoxSecondName.Size = new System.Drawing.Size(90, 20);
            this.textBoxSecondName.TabIndex = 6;
            // 
            // comboBoxUserType
            // 
            this.comboBoxUserType.FormattingEnabled = true;
            this.comboBoxUserType.Items.AddRange(new object[] {
            "Uczen",
            "Rodzic",
            "Nauczyciel"});
            this.comboBoxUserType.Location = new System.Drawing.Point(142, 160);
            this.comboBoxUserType.Name = "comboBoxUserType";
            this.comboBoxUserType.Size = new System.Drawing.Size(185, 21);
            this.comboBoxUserType.TabIndex = 5;
            // 
            // textBoxParentEmail
            // 
            this.textBoxParentEmail.Location = new System.Drawing.Point(143, 118);
            this.textBoxParentEmail.Name = "textBoxParentEmail";
            this.textBoxParentEmail.Size = new System.Drawing.Size(185, 20);
            this.textBoxParentEmail.TabIndex = 4;
            this.textBoxParentEmail.Visible = false;
            // 
            // textBoxPhoneNumber
            // 
            this.textBoxPhoneNumber.Location = new System.Drawing.Point(143, 92);
            this.textBoxPhoneNumber.Name = "textBoxPhoneNumber";
            this.textBoxPhoneNumber.Size = new System.Drawing.Size(185, 20);
            this.textBoxPhoneNumber.TabIndex = 3;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(143, 66);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(185, 20);
            this.textBoxEmail.TabIndex = 2;
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Location = new System.Drawing.Point(142, 41);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(185, 20);
            this.textBoxLastName.TabIndex = 1;
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.Location = new System.Drawing.Point(142, 14);
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(90, 20);
            this.textBoxFirstName.TabIndex = 0;
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.buttonClear);
            this.panelButtons.Controls.Add(this.buttonDelete);
            this.panelButtons.Controls.Add(this.buttonUpdate);
            this.panelButtons.Controls.Add(this.buttonAdd);
            this.panelButtons.Location = new System.Drawing.Point(558, 332);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(182, 138);
            this.panelButtons.TabIndex = 4;
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(17, 101);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(148, 23);
            this.buttonClear.TabIndex = 3;
            this.buttonClear.Text = "Wyczyść";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(17, 71);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(148, 24);
            this.buttonDelete.TabIndex = 2;
            this.buttonDelete.Text = "Usuń";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(17, 41);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(148, 24);
            this.buttonUpdate.TabIndex = 1;
            this.buttonUpdate.Text = "Zmodyfikuj";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(17, 10);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(148, 24);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "Dodaj";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // panelClassData
            // 
            this.panelClassData.Controls.Add(this.labelTeacher);
            this.panelClassData.Controls.Add(this.labelClassName);
            this.panelClassData.Controls.Add(this.dataGridViewTeachers);
            this.panelClassData.Controls.Add(this.textBoxClassName);
            this.panelClassData.Location = new System.Drawing.Point(12, 332);
            this.panelClassData.Name = "panelClassData";
            this.panelClassData.Size = new System.Drawing.Size(524, 215);
            this.panelClassData.TabIndex = 5;
            this.panelClassData.Visible = false;
            // 
            // labelTeacher
            // 
            this.labelTeacher.AutoSize = true;
            this.labelTeacher.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelTeacher.Location = new System.Drawing.Point(270, 18);
            this.labelTeacher.Name = "labelTeacher";
            this.labelTeacher.Size = new System.Drawing.Size(234, 16);
            this.labelTeacher.TabIndex = 3;
            this.labelTeacher.Text = "Wybierz nauczyciela na wychowawcę:";
            // 
            // labelClassName
            // 
            this.labelClassName.AutoSize = true;
            this.labelClassName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelClassName.Location = new System.Drawing.Point(3, 19);
            this.labelClassName.Name = "labelClassName";
            this.labelClassName.Size = new System.Drawing.Size(90, 16);
            this.labelClassName.TabIndex = 2;
            this.labelClassName.Text = "Nazwa klasy :";
            // 
            // dataGridViewTeachers
            // 
            this.dataGridViewTeachers.AllowUserToAddRows = false;
            this.dataGridViewTeachers.AllowUserToDeleteRows = false;
            this.dataGridViewTeachers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTeachers.Location = new System.Drawing.Point(6, 44);
            this.dataGridViewTeachers.Name = "dataGridViewTeachers";
            this.dataGridViewTeachers.Size = new System.Drawing.Size(515, 171);
            this.dataGridViewTeachers.TabIndex = 1;
            // 
            // textBoxClassName
            // 
            this.textBoxClassName.Location = new System.Drawing.Point(99, 18);
            this.textBoxClassName.Name = "textBoxClassName";
            this.textBoxClassName.Size = new System.Drawing.Size(100, 20);
            this.textBoxClassName.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(803, 559);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.comboBoxViewChanger);
            this.Controls.Add(this.dataGridViewUsers);
            this.Controls.Add(this.panelClassData);
            this.Controls.Add(this.panelUserData);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "Panel Administratora";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).EndInit();
            this.panelUserData.ResumeLayout(false);
            this.panelUserData.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.panelClassData.ResumeLayout(false);
            this.panelClassData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTeachers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewUsers;
        private System.Windows.Forms.ComboBox comboBoxViewChanger;
        private System.Windows.Forms.Panel panelUserData;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSecondName;
        private System.Windows.Forms.ComboBox comboBoxUserType;
        private System.Windows.Forms.TextBox textBoxParentEmail;
        private System.Windows.Forms.TextBox textBoxPhoneNumber;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Panel panelClassData;
        private System.Windows.Forms.Label labelClassName;
        private System.Windows.Forms.DataGridView dataGridViewTeachers;
        private System.Windows.Forms.TextBox textBoxClassName;
        private System.Windows.Forms.Label labelTeacher;
    }
}

