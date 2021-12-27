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
using Database.Enums;
namespace DamianRaczkowskiLab2PracDom
{
    public partial class FormMain : Form
    {
        private IDAO _usedDataObject;
        private Dictionary<DataType, Panel> userInteractivePanels;
        public FormMain()
        {
            this._usedDataObject = new Users();
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.userInteractivePanels = new Dictionary<DataType, Panel>();
            userInteractivePanels.Add(DataType.Uzytkownicy, this.panelUserData);
            userInteractivePanels.Add(DataType.Klasy, this.panelClassData);
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
               /* case DataType.Zajecia:
                    break;*/
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
            string[] data =  this.UpdateButtonSwitch(this._usedDataObject.GetDataType());
            if (data == null)
                return;
            this._usedDataObject.UpdateData(data, index);
            this.RefreshDataGrid();
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
            switch(dataType)
            {
                case DataType.Uzytkownicy:
                    string firstName = this.textBoxFirstName.Text;
                    string secondName = this.textBoxSecondName.Text;
                    string lastName = this.textBoxLastName.Text;
                    string phoneNumber = this.textBoxPhoneNumber.Text;
                    string email = this.textBoxEmail.Text;
                    string userType = this.comboBoxUserType.SelectedItem.ToString();
                    if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(userType))
                    {
                        MessageBox.Show("Nie uzupełniłeś wszystkich pól");
                        return;
                    }
                    string[] userData = { firstName, secondName, lastName, phoneNumber, email, userType };
                    this._usedDataObject.InsertData(userData);
                    break;
                /*case DataType.Zajecia:
                    MessageBox.Show("Nie uzupełniłeś wszystkich pól (Zajecia)");
                    break;*/
                case DataType.Klasy:
                    string className = this.textBoxClassName.Text;
                    if(string.IsNullOrEmpty(className) )
                    {
                        MessageBox.Show("Nie uzupełniłeś wszystkich wymaganych pól, nie stworzono ");
                        return;
                    }
                    string teacherId = "";
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
            switch (dataType)
            {
                case DataType.Uzytkownicy:
                    string[] userFieldsData = { this.textBoxFirstName.Text, this.textBoxSecondName.Text, this.textBoxLastName.Text, this.textBoxPhoneNumber.Text, this.textBoxEmail.Text, this.comboBoxUserType.SelectedItem.ToString() };
                    return userFieldsData;

                /*case DataType.Zajecia:
                    MessageBox.Show("Nie uzupełniłeś wszystkich pól (Zajecia)");
                    string[] subjectsFieldsData = null;
                    return subjectsFieldsData;*/
                case DataType.Klasy:
                    string className = this.textBoxClassName.Text;
                    string teacherId = "";
                    if (dataGridViewTeachers.SelectedRows.Count == 1)
                    {
                        DataGridViewRow row = dataGridViewTeachers.SelectedRows[0];
                        teacherId = row.Cells[0].Value.ToString();
                    }
                    string[] classData = { teacherId, className };
                    return classData;
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
                /*case DataType.Zajecia:
                    return new Subjects();*/
                case DataType.Klasy:
                    return new Classes();
                default:
                    return new Users();
            }
        }

    }
}
