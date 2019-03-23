namespace Kommisionierung
{
    partial class Login_Form
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
            this.cobCompanies = new System.Windows.Forms.ComboBox();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.lbCompanySelect = new System.Windows.Forms.Label();
            this.lbUserName = new System.Windows.Forms.Label();
            this.lbPassword = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cobCompanies
            // 
            this.cobCompanies.FormattingEnabled = true;
            this.cobCompanies.Items.AddRange(new object[] {
            "TS_DFE_20181120"});
            this.cobCompanies.Location = new System.Drawing.Point(110, 51);
            this.cobCompanies.Name = "cobCompanies";
            this.cobCompanies.Size = new System.Drawing.Size(241, 21);
            this.cobCompanies.TabIndex = 0;
            this.cobCompanies.SelectedIndexChanged += new System.EventHandler(this.cobCompanies_SelectedIndexChanged);
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(110, 105);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(241, 20);
            this.tbUserName.TabIndex = 1;
            this.tbUserName.Text = "manager";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(110, 159);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '•';
            this.tbPassword.Size = new System.Drawing.Size(241, 20);
            this.tbPassword.TabIndex = 2;
            this.tbPassword.Text = "U1Iir23B";
            this.tbPassword.UseSystemPasswordChar = true;
            // 
            // lbCompanySelect
            // 
            this.lbCompanySelect.AutoSize = true;
            this.lbCompanySelect.Location = new System.Drawing.Point(24, 54);
            this.lbCompanySelect.Name = "lbCompanySelect";
            this.lbCompanySelect.Size = new System.Drawing.Size(35, 13);
            this.lbCompanySelect.TabIndex = 3;
            this.lbCompanySelect.Text = "Firma:";
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.Location = new System.Drawing.Point(24, 108);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(78, 13);
            this.lbUserName.TabIndex = 4;
            this.lbUserName.Text = "Benutzername:";
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Location = new System.Drawing.Point(24, 162);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(53, 13);
            this.lbPassword.TabIndex = 5;
            this.lbPassword.Text = "Passwort:";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(27, 202);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "Einloggen";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // Login_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 237);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lbPassword);
            this.Controls.Add(this.lbUserName);
            this.Controls.Add(this.lbCompanySelect);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbUserName);
            this.Controls.Add(this.cobCompanies);
            this.Name = "Login_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cobCompanies;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label lbCompanySelect;
        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.Button btnLogin;
    }
}