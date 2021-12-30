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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Logins logins = new Logins();
            
            if (logins.CheckPassword(textBoxLogin.Text, textBoxPassword.Text))
            {
                this.Hide();

                FormMain main = new FormMain(logins.GetCurrentLoggedUser());
                main.FormClosed += (a, b) =>
                {
                    DialogResult res = MessageBox.Show("Tak - Wyjście z aplikacji\nNie - wylogowanie", "Wyjście z aplikacji", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                        Application.Exit();
                    else if (res == DialogResult.No)
                        this.Show();
                };
                main.Show();
            }
            else   
                MessageBox.Show("Invalid login, password or user type");
            
            textBoxLogin.Text = "";
            textBoxPassword.Text = "";
        }
    }
}
