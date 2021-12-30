using Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DamianRaczkowskiLab2PracDom.Forms
{
    public partial class ChangePasswordForm : Form
    {
        private readonly int _userIdForPasswordChange;
        private readonly string username;
        public ChangePasswordForm(int currentUserId)
        {
            this.username = "Zmiana hasła dla administratora";
            _userIdForPasswordChange = currentUserId;
            InitializeComponent();
        }
        public ChangePasswordForm(int currentUserId, string username)
        {
            _userIdForPasswordChange = currentUserId;
            this.username = username;
            InitializeComponent();
            
        }
        private void changePasswordButton_Click(object sender, EventArgs e)
        {
            
            string newPWD = this.changePasswordTextBox.Text;
            Logins login = new Logins();
            
            login.UpdateData(new[] {newPWD }, _userIdForPasswordChange);
            MessageBox.Show("Pomyślnie zmieniono hasło", "Zmiana hasła");
            this.Close();
        }

        private void ChangePasswordForm_Load(object sender, EventArgs e)
        {
            this.userDataLabel.Text = $"Zmiana hasła dla {username}";
        }
    }
}
