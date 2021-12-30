
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
            this.userDataLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // changePasswordButton
            // 
            this.changePasswordButton.Location = new System.Drawing.Point(38, 97);
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
            this.label1.Location = new System.Drawing.Point(14, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nowe hasło :";
            // 
            // changePasswordTextBox
            // 
            this.changePasswordTextBox.Location = new System.Drawing.Point(91, 61);
            this.changePasswordTextBox.Name = "changePasswordTextBox";
            this.changePasswordTextBox.Size = new System.Drawing.Size(143, 20);
            this.changePasswordTextBox.TabIndex = 2;
            this.changePasswordTextBox.UseSystemPasswordChar = true;
            // 
            // userData
            // 
            this.userDataLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.userDataLabel.Location = new System.Drawing.Point(12, 9);
            this.userDataLabel.Name = "userData";
            this.userDataLabel.Size = new System.Drawing.Size(243, 40);
            this.userDataLabel.TabIndex = 3;
            this.userDataLabel.Text = "Zmiana hasła dla administratora";
            this.userDataLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ChangePasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 132);
            this.Controls.Add(this.userDataLabel);
            this.Controls.Add(this.changePasswordTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.changePasswordButton);
            this.Name = "ChangePasswordForm";
            this.Text = "Zmiana Hasła";
            this.Load += new System.EventHandler(this.ChangePasswordForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button changePasswordButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox changePasswordTextBox;
        private System.Windows.Forms.Label userDataLabel;
    }
}