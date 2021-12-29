
namespace DamianRaczkowskiLab2PracDom.Forms
{
    partial class ChangePasswordForm
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
            this.changePasswordButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.changePasswordTextBox = new System.Windows.Forms.TextBox();
            this.loginTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // changePasswordButton
            // 
            this.changePasswordButton.Location = new System.Drawing.Point(60, 92);
            this.changePasswordButton.Name = "changePasswordButton";
            this.changePasswordButton.Size = new System.Drawing.Size(172, 23);
            this.changePasswordButton.TabIndex = 0;
            this.changePasswordButton.Text = "Zmień hasło";
            this.changePasswordButton.UseVisualStyleBackColor = true;
            this.changePasswordButton.Click += new System.EventHandler(this.changePasswordButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nowe hasło :";
            // 
            // changePasswordTextBox
            // 
            this.changePasswordTextBox.Location = new System.Drawing.Point(89, 44);
            this.changePasswordTextBox.Name = "changePasswordTextBox";
            this.changePasswordTextBox.Size = new System.Drawing.Size(143, 20);
            this.changePasswordTextBox.TabIndex = 2;
            // 
            // loginTextBox
            // 
            this.loginTextBox.Location = new System.Drawing.Point(89, 18);
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.Size = new System.Drawing.Size(143, 20);
            this.loginTextBox.TabIndex = 3;
            // 
            // ChangePasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 151);
            this.Controls.Add(this.loginTextBox);
            this.Controls.Add(this.changePasswordTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.changePasswordButton);
            this.Name = "ChangePasswordForm";
            this.Text = "Zmiana Hasła";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button changePasswordButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox changePasswordTextBox;
        private System.Windows.Forms.TextBox loginTextBox;
    }
}