using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DamianRaczkowskiLab2PracDom.Forms;
using Database;
using Database.Enums;
namespace DamianRaczkowskiLab2PracDom
{
    public partial class FormMain : Form
    {
        private IDAO _usedDataObject;
        private Dictionary<DataType, Panel> userInteractivePanels;
        private readonly int _currentUserId;
        public FormMain(int loggedUserId)
        {
            this._currentUserId = loggedUserId;
            this._usedDataObject = new Users();
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
         
            this.userInteractivePanels = new Dictionary<DataType, Panel>();
            userInteractivePanels.Add(DataType.Uzytkownicy, this.panelUserData);
            userInteractivePanels.Add(DataType.Klasy, this.panelClassData);
            userInteractivePanels.Add(DataType.Zajecia, this.subjectPanel);
            this.comboBoxViewChanger.DataSource = Enum.GetValues(typeof(DataType));
            this.comboBoxUserType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxViewChanger.DropDownStyle = ComboBoxStyle.DropDownList;
            this.RefreshDataGrid();
            
        }
        /// <summary>
        /// Przycisk Do dodawnia 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            this.AddButtonSwitch(this._usedDataObject.GetDataType());
            this.RefreshDataGrid();
            this.ClearTextBoxes(this._usedDataObject.GetDataType());

        }

        // Usuń wybrany rekord 
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (this.dataGridViewUsers.SelectedRows.Count > 1 || this.dataGridViewUsers.SelectedRows.Count == 0)
                return;
            int index = int.Parse(this.dataGridViewUsers.SelectedRows[0].Cells[0].Value.ToString());
            this._usedDataObject.DeleteData(index);
            this.RefreshDataGrid();
        }

        /// <summary>
        /// Przycisk służący do edycji konkretnego rekordu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (this.dataGridViewUsers.SelectedRows.Count > 1 || this.dataGridViewUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nie wybrano ");
                return;
            }
            DataGridViewRow row = dataGridViewUsers.SelectedRows[0];
            int index = int.Parse(row.Cells[0].Value.ToString());
            Console.WriteLine(index);
            string[] data = this.UpdateButtonSwitch(this._usedDataObject.GetDataType());
            if (data == null)
                return;
            this._usedDataObject.UpdateData(data, index);
            this.RefreshDataGrid();
        }



        /// <summary>
        /// Odśwież UserDataGrida i jeżeli panel od klas jest włączony to Jego też odśwież 
        /// </summary>
        private void RefreshDataGrid()
        {
            this.dataGridViewUsers.DataSource = this._usedDataObject.ReadData();
            if(this._usedDataObject.GetDataType() == DataType.Klasy)
            {
                Users user = new Users();
                this.dataGridViewTeachers.DataSource = user.GetSpecifiedUserData(UserType.Nauczyciel);
            }
            if(this._usedDataObject.GetDataType() == DataType.Zajecia)
            {
                Users user = new Users();
                this.teacherGridView.DataSource = user.GetSpecifiedUserData(UserType.Nauczyciel);
            }
            if(this._usedDataObject.GetDataType() == DataType.Uzytkownicy)
            {
                Users user = new Users();
                DataTable table = user.GetSpecifiedUserData(UserType.Rodzic);

                table.Columns.Add("Combined", typeof(string), "FirstName+' '+LastName");
                this.parentComboBox.DataSource = table;
                this.parentComboBox.DisplayMember =table.Columns[table.Columns.Count-1].ColumnName;
                this.parentComboBox.ValueMember = table.Columns[0].ColumnName;
                this.parentComboBox.SelectedItem = null;
                this.dataGridViewUsers.Columns[0].Visible = false;
            }
        }

        /// <summary>
        /// WYdarzenie obsługujące zmianę wybranego wiersza, wyświetla jego zawartość w przyporządkowanych textboxach
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dataGridViewUsers.SelectedRows.Count > 1 || this.dataGridViewUsers.SelectedRows.Count == 0)
                return;
            DataGridViewRow row = dataGridViewUsers.SelectedRows[0];
            ViewUsersSwitch(this._usedDataObject.GetDataType(), row);

        }


        /// <summary>
        /// Switch do funkcji Zmiany wyboru datagridViewUsers, która uzupełnia odpowiednie wartości w textboxach/datagridach w panelach
        /// </summary>
        /// <param name="dataType"> enum typu danych które są podłaczone do zmian </param>
        /// <param name="row"> Zaznaczony wiersz w dataGridViewUsers</param>
        private void ViewUsersSwitch(DataType dataType, DataGridViewRow row)
        {
            switch (dataType)
            {
                // Podmiana textboxów dla panelu Users
                case DataType.Uzytkownicy:
                    string firstName = row.Cells[1].Value.ToString();
                    string secondName = row.Cells[2].Value.ToString();
                    string lastName = row.Cells[3].Value.ToString();
                    string phoneNumber = row.Cells[4].Value.ToString();
                    string email = row.Cells[5].Value.ToString();
                    
                    this.textBoxFirstName.Text = firstName;
                    this.textBoxSecondName.Text = secondName;
                    this.textBoxLastName.Text = lastName;
                    this.textBoxPhoneNumber.Text = phoneNumber;
                    this.textBoxEmail.Text = email;
                    break;
                // podmiana textboxów dla panelu Classes
                case DataType.Klasy:
                    string className = row.Cells[4].Value.ToString();
                    this.textBoxClassName.Text = className;
                    int rowIndex = -1;
                    this.dataGridViewTeachers.ClearSelection();
                    foreach (DataGridViewRow teacherRow in this.dataGridViewTeachers.Rows)
                    {
                        if(!string.IsNullOrEmpty(teacherRow.Cells[3].Value.ToString()))
                        if (teacherRow.Cells[3].Value.ToString().Equals(row.Cells[3].Value.ToString()))
                        {
                            rowIndex = teacherRow.Index;
                            this.dataGridViewTeachers.Rows[rowIndex].Selected = true;
                            break;
                        }
                    }
                    break;

               case DataType.Zajecia:
                    string subjectName = row.Cells[1].Value.ToString();
                    this.subjectNameTextBox.Text = subjectName;
                    this.teacherGridView.ClearSelection();
                    foreach (DataGridViewRow teacherRow in this.teacherGridView.Rows)
                    {
                        if (!string.IsNullOrEmpty(teacherRow.Cells[3].Value.ToString()))
                            if (teacherRow.Cells[3].Value.ToString().Equals(row.Cells[4].Value.ToString()))
                            {
                                rowIndex = teacherRow.Index;
                                this.teacherGridView.Rows[rowIndex].Selected = true;
                                break;
                            }
                    }
                    break;

            }
        }

        /// <summary>
        /// Funkcja która czyści textboxy w zależności od aktywnego panelu
        /// </summary>
        /// <param name="dataType"> enum typu danych które są podłaczone do zmian </param>
        private void ClearTextBoxes(DataType dataType)
        {
            Panel panel;
            if (!this.userInteractivePanels.TryGetValue(dataType, out panel))
                return;
            foreach (Control control in panel.Controls)
                if (control is TextBox)
                    control.Text = "";

        }


        /// <summary>
        /// wydarzenie czyszczące przyciski 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClear_Click(object sender, EventArgs e)
        {
            this.ClearTextBoxes(this._usedDataObject.GetDataType());
        }

        private void comboBoxViewChanger_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (KeyValuePair<DataType, Panel> pair in this.userInteractivePanels)
            {
                Console.WriteLine(this.comboBoxViewChanger.SelectedItem.ToString());
                if (pair.Key.Equals(this.comboBoxViewChanger.SelectedItem))
                {
                    pair.Value.Visible = true;
                    this._usedDataObject = this.SwitchDAO((DataType)this.comboBoxViewChanger.SelectedItem);
                    this.RefreshDataGrid();
                }
                else
                {
                    pair.Value.Visible = false;
                }

            }
        }


        #region Funkcje rozróżniające z jakich pól dane pobierać w zależności od typu danych wybranych do modyfikacji 
        private void AddButtonSwitch(DataType dataType)
        {
            string teacherId = "";
            switch (dataType)
            {
                case DataType.Uzytkownicy:
                    string firstName = this.textBoxFirstName.Text;
                    string secondName = this.textBoxSecondName.Text;
                    string lastName = this.textBoxLastName.Text;
                    string phoneNumber = this.textBoxPhoneNumber.Text;
                    string email = this.textBoxEmail.Text;
                    if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(email)
                         || this.comboBoxUserType.SelectedIndex < 0)
                    {
                        MessageBox.Show("Nie uzupełniłeś wszystkich pól");
                        return;
                    }
                    string userType = this.comboBoxUserType.SelectedItem.ToString();
                    string[] userData;
                    if (this.parentComboBox.SelectedIndex != -1)
                    {
                        string parentIndex = this.parentComboBox.SelectedValue.ToString();
                        userData = new string[] { firstName, secondName, lastName, phoneNumber, email, userType, parentIndex };
                    }
                    else
                    {
                        userData = new string[] { firstName, secondName, lastName, phoneNumber, email, userType, null };
                    }
                    this._usedDataObject.InsertData(userData);
                    break;


                case DataType.Zajecia:
                    // MessageBox.Show("Nie uzupełniłeś wszystkich pól (Zajecia)");
                    string subjectName = this.subjectNameTextBox.Text;
                    DateTime dateStart = this.beginDateTimePicker.Value.Date;
                    DateTime endDay =    this.beginDateTimePicker.Value.Date;
                    DateTime endDate = this.endDateTimePicker.Value;
                    
                    TimeSpan startTime = this.startTime.Value.TimeOfDay;
                    TimeSpan endTime = this.endTime.Value.TimeOfDay;
                    bool generateDates = this.generateLessonsCheckbox.Checked;
                    
                    string classToBeAllocatedWith = this.classNameTextBox.Text;
                    dateStart = dateStart.Add(startTime);
                    endDay = dateStart.Add(endTime);
                    endDate = endDate.Add(startTime);
                    //string.IsNullOrEmpty(dateStart)
                    if (string.IsNullOrEmpty(subjectName) ||  string.IsNullOrEmpty(classToBeAllocatedWith) || this.teacherGridView.SelectedRows.Count < 1)
                    {
                        MessageBox.Show("Nie uzupełniłeś wszystkich pól");
                        return;
                    }
                    teacherId = this.teacherGridView.SelectedRows[0].Cells[0].Value.ToString();
                    string[] data;
                    if (generateDates)
                    {
                        //Console.WriteLine(dateStart.ToString());
                        //Console.WriteLine($"{subjectName}, {classToBeAllocatedWith}");
                        data = new string[] { teacherId, subjectName, classToBeAllocatedWith, dateStart.ToString("s"), endDay.ToString("s"), endDate.ToString("s") }; 
                    }
                    else
                    {
                        data = new string[] {teacherId, subjectName, classToBeAllocatedWith };
                        
                    }
                    this._usedDataObject.InsertData(data);
                    //string className = this.subjectNameTextBox.Text;
                    break;
                case DataType.Klasy:
                    string className = this.textBoxClassName.Text;
                    if(string.IsNullOrEmpty(className) )
                    {
                        MessageBox.Show("Nie uzupełniłeś wszystkich wymaganych pól, nie stworzono ");
                        return;
                    }
                    
                    if (dataGridViewTeachers.SelectedRows.Count == 1)
                    {
                        DataGridViewRow row = dataGridViewTeachers.SelectedRows[0];
                        teacherId = row.Cells[0].Value.ToString();
                    }
                    string[] classData = { teacherId, className };
                    this._usedDataObject.InsertData(classData);
                    break;
                default:
                    MessageBox.Show(" Nie zaimplementowano jeszcze ");
                    break;
            }
        }
        private  string[] UpdateButtonSwitch(DataType dataType)
        {
            string teacherId = "";
            switch (dataType)
            {
                case DataType.Uzytkownicy:
                    if (this.parentComboBox.SelectedIndex !=-1)
                        return new string[]{ this.textBoxFirstName.Text, this.textBoxSecondName.Text, this.textBoxLastName.Text, this.textBoxPhoneNumber.Text, 
                                             this.textBoxEmail.Text, this.comboBoxUserType.SelectedItem.ToString(), this.parentComboBox.SelectedValue.ToString()};
                    else
                        return new string[]{ this.textBoxFirstName.Text, this.textBoxSecondName.Text, this.textBoxLastName.Text, this.textBoxPhoneNumber.Text,
                                             this.textBoxEmail.Text, this.comboBoxUserType.SelectedItem.ToString() };

                case DataType.Klasy:
                    string className = this.textBoxClassName.Text;
                    
                    if (dataGridViewTeachers.SelectedRows.Count == 1)
                    {
                        DataGridViewRow row = dataGridViewTeachers.SelectedRows[0];
                        teacherId = row.Cells[0].Value.ToString();
                    }
                    string[] classData = { teacherId, className };
                    return classData;

                case DataType.Zajecia:
                    // MessageBox.Show("Nie uzupełniłeś wszystkich pól (Zajecia)");
                    string subjectName = this.subjectNameTextBox.Text;
                    DateTime dateStart = this.beginDateTimePicker.Value.Date;
                    DateTime endDay = this.beginDateTimePicker.Value.Date;
                    DateTime endDate = this.endDateTimePicker.Value;

                    TimeSpan startTime = this.startTime.Value.TimeOfDay;
                    TimeSpan endTime = this.endTime.Value.TimeOfDay;
                    bool generateDates = this.generateLessonsCheckbox.Checked;

                    string classToBeAllocatedWith = this.classNameTextBox.Text;
                    dateStart = dateStart.Add(startTime);
                    endDay = dateStart.Add(endTime);
                    endDate = endDate.Add(startTime);
                    //string.IsNullOrEmpty(dateStart)
                    if (string.IsNullOrEmpty(subjectName) || string.IsNullOrEmpty(classToBeAllocatedWith) || this.teacherGridView.SelectedRows.Count < 1)
                    {
                        MessageBox.Show("Nie uzupełniłeś wszystkich pól");
                        return null;
                    }
                    teacherId = this.teacherGridView.SelectedRows[0].Cells[0].Value.ToString();
                    string[] data;
                    if (generateDates)
                    {
                        //Console.WriteLine(dateStart.ToString());
                        Console.WriteLine($"{subjectName}, {classToBeAllocatedWith}");
                        data = new string[] { teacherId, subjectName, classToBeAllocatedWith, dateStart.ToString("s"), endDay.ToString("s"), endDate.ToString("s") };
                    }
                    else
                    {
                        data = new string[] { teacherId, subjectName, classToBeAllocatedWith };

                    }
                    return data;
                default:
                    return null;
            }
        }
        #endregion

        /// <summary>
        /// Funkcja podmieniająca zawartość pola _usedDataObject w zależności od wartości DataType pobranej wcześniej z comboboxa
        /// </summary>
        /// <param name="userType"></param>
        /// <returns></returns>
        private IDAO SwitchDAO (DataType userType)
        {
            switch(userType)
            {
                case DataType.Uzytkownicy:
                    return new Users();
                case DataType.Zajecia:
                    return new Subjects();
                case DataType.Klasy:
                    return new Classes();
                default:
                    return new Users();
            }
        }

        /// <summary>
        /// Na kliknięcie otwórz formularz by zmienić hasło administratora
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void zmieńHasłoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form changePWDForm = new ChangePasswordForm(_currentUserId);
            changePWDForm.ShowDialog();
        }
        /// <summary>
        /// Na kliknięcie otwórz formularz do zmiany hasła wybranego użytkownika
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void zmieńToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_usedDataObject.GetDataType() == DataType.Uzytkownicy && this.dataGridViewUsers.SelectedRows.Count == 1)
            {
                DataGridViewRow row = this.dataGridViewUsers.SelectedRows[0];
                int index = int.Parse(row.Cells[0].Value.ToString());
                string username = $"{row.Cells[1].Value.ToString()} { row.Cells[3].Value.ToString()} ";
                Console.WriteLine(index);
                ChangePasswordForm changePasswordForm = new ChangePasswordForm(index, username);
                changePasswordForm.ShowDialog();
            }
            else
                MessageBox.Show("Musisz wybrać dokładnie jednego użytkownika do zmiany hasła");
        }
    }
}
