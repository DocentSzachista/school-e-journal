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

        public ChangePasswordForm()
        {
            InitializeComponent();
        }

        private void changePasswordButton_Click(object sender, EventArgs e)
        {
            string userLogin = this.loginTextBox.Text;
            string newPWD = this.changePasswordTextBox.Text;
            Logins login = new Logins();
            
            login.UpdateData(new[] {userLogin ,newPWD }, -1);

        }
    }
}
