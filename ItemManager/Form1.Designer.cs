namespace ItemManager
{
    partial class Form1
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
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPassword2 = new System.Windows.Forms.TextBox();
            this.txtAns1 = new System.Windows.Forms.TextBox();
            this.txtAns2 = new System.Windows.Forms.TextBox();
            this.txtAns3 = new System.Windows.Forms.TextBox();
            this.cmbQuestion1 = new System.Windows.Forms.ComboBox();
            this.cmbQuestion2 = new System.Windows.Forms.ComboBox();
            this.cmbQuestion3 = new System.Windows.Forms.ComboBox();
            this.btnForgotPassword = new System.Windows.Forms.Button();
            this.gbSecurityCheck = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblQuestionCheck = new System.Windows.Forms.Label();
            this.txtAnswerCheck = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.gbRegister = new System.Windows.Forms.GroupBox();
            this.gbLoginForgotPassword = new System.Windows.Forms.GroupBox();
            this.btnNewRegister = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbSecurityCheck.SuspendLayout();
            this.gbRegister.SuspendLayout();
            this.gbLoginForgotPassword.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(46, 136);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(166, 35);
            this.btnSubmit.TabIndex = 1;
            this.btnSubmit.Text = "Login";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(24, 44);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(209, 26);
            this.txtLogin.TabIndex = 0;
            this.txtLogin.Text = "Username/Email";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(24, 86);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(209, 26);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.Text = "Password";
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(294, 324);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(101, 36);
            this.btnRegister.TabIndex = 15;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(15, 35);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(412, 26);
            this.txtFirstName.TabIndex = 4;
            this.txtFirstName.Text = "First";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(463, 35);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(208, 26);
            this.txtLastName.TabIndex = 5;
            this.txtLastName.Text = "Last";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(16, 82);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(412, 26);
            this.txtUserName.TabIndex = 6;
            this.txtUserName.Text = "User";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(463, 82);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(208, 26);
            this.txtEmail.TabIndex = 7;
            this.txtEmail.Text = "Email";
            // 
            // txtPassword2
            // 
            this.txtPassword2.Location = new System.Drawing.Point(16, 128);
            this.txtPassword2.Name = "txtPassword2";
            this.txtPassword2.Size = new System.Drawing.Size(412, 26);
            this.txtPassword2.TabIndex = 8;
            this.txtPassword2.Text = "Password";
            // 
            // txtAns1
            // 
            this.txtAns1.Location = new System.Drawing.Point(463, 176);
            this.txtAns1.Name = "txtAns1";
            this.txtAns1.Size = new System.Drawing.Size(208, 26);
            this.txtAns1.TabIndex = 10;
            this.txtAns1.Text = "Ans1";
            // 
            // txtAns2
            // 
            this.txtAns2.Location = new System.Drawing.Point(463, 218);
            this.txtAns2.Name = "txtAns2";
            this.txtAns2.Size = new System.Drawing.Size(208, 26);
            this.txtAns2.TabIndex = 12;
            this.txtAns2.Text = "Ans2";
            // 
            // txtAns3
            // 
            this.txtAns3.Location = new System.Drawing.Point(463, 259);
            this.txtAns3.Name = "txtAns3";
            this.txtAns3.Size = new System.Drawing.Size(208, 26);
            this.txtAns3.TabIndex = 14;
            this.txtAns3.Text = "Ans3";
            // 
            // cmbQuestion1
            // 
            this.cmbQuestion1.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmbQuestion1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQuestion1.FormattingEnabled = true;
            this.cmbQuestion1.Location = new System.Drawing.Point(15, 176);
            this.cmbQuestion1.Name = "cmbQuestion1";
            this.cmbQuestion1.Size = new System.Drawing.Size(413, 28);
            this.cmbQuestion1.TabIndex = 9;
            // 
            // cmbQuestion2
            // 
            this.cmbQuestion2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQuestion2.FormattingEnabled = true;
            this.cmbQuestion2.Location = new System.Drawing.Point(16, 218);
            this.cmbQuestion2.Name = "cmbQuestion2";
            this.cmbQuestion2.Size = new System.Drawing.Size(413, 28);
            this.cmbQuestion2.TabIndex = 11;
            // 
            // cmbQuestion3
            // 
            this.cmbQuestion3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQuestion3.FormattingEnabled = true;
            this.cmbQuestion3.Location = new System.Drawing.Point(16, 259);
            this.cmbQuestion3.Name = "cmbQuestion3";
            this.cmbQuestion3.Size = new System.Drawing.Size(413, 28);
            this.cmbQuestion3.TabIndex = 13;
            // 
            // btnForgotPassword
            // 
            this.btnForgotPassword.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnForgotPassword.Location = new System.Drawing.Point(46, 189);
            this.btnForgotPassword.Name = "btnForgotPassword";
            this.btnForgotPassword.Size = new System.Drawing.Size(166, 35);
            this.btnForgotPassword.TabIndex = 3;
            this.btnForgotPassword.Text = "Forgot Password";
            this.btnForgotPassword.UseVisualStyleBackColor = true;
            this.btnForgotPassword.Click += new System.EventHandler(this.btnForgotPassword_Click);
            // 
            // gbSecurityCheck
            // 
            this.gbSecurityCheck.Controls.Add(this.btnCancel);
            this.gbSecurityCheck.Controls.Add(this.lblQuestionCheck);
            this.gbSecurityCheck.Controls.Add(this.txtAnswerCheck);
            this.gbSecurityCheck.Controls.Add(this.btnSend);
            this.gbSecurityCheck.Location = new System.Drawing.Point(149, 416);
            this.gbSecurityCheck.Name = "gbSecurityCheck";
            this.gbSecurityCheck.Size = new System.Drawing.Size(342, 152);
            this.gbSecurityCheck.TabIndex = 8;
            this.gbSecurityCheck.TabStop = false;
            this.gbSecurityCheck.Text = "Forgot Password?";
            this.gbSecurityCheck.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(221, 106);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(98, 40);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblQuestionCheck
            // 
            this.lblQuestionCheck.AutoSize = true;
            this.lblQuestionCheck.Location = new System.Drawing.Point(15, 41);
            this.lblQuestionCheck.Name = "lblQuestionCheck";
            this.lblQuestionCheck.Size = new System.Drawing.Size(0, 20);
            this.lblQuestionCheck.TabIndex = 2;
            // 
            // txtAnswerCheck
            // 
            this.txtAnswerCheck.Location = new System.Drawing.Point(19, 64);
            this.txtAnswerCheck.Name = "txtAnswerCheck";
            this.txtAnswerCheck.Size = new System.Drawing.Size(300, 26);
            this.txtAnswerCheck.TabIndex = 16;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(19, 106);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(99, 40);
            this.btnSend.TabIndex = 17;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // gbRegister
            // 
            this.gbRegister.Controls.Add(this.txtFirstName);
            this.gbRegister.Controls.Add(this.txtLastName);
            this.gbRegister.Controls.Add(this.txtUserName);
            this.gbRegister.Controls.Add(this.txtEmail);
            this.gbRegister.Controls.Add(this.txtPassword2);
            this.gbRegister.Controls.Add(this.cmbQuestion1);
            this.gbRegister.Controls.Add(this.txtAns1);
            this.gbRegister.Controls.Add(this.cmbQuestion2);
            this.gbRegister.Controls.Add(this.txtAns2);
            this.gbRegister.Controls.Add(this.cmbQuestion3);
            this.gbRegister.Controls.Add(this.txtAns3);
            this.gbRegister.Controls.Add(this.btnRegister);
            this.gbRegister.Location = new System.Drawing.Point(536, 45);
            this.gbRegister.Name = "gbRegister";
            this.gbRegister.Size = new System.Drawing.Size(691, 399);
            this.gbRegister.TabIndex = 16;
            this.gbRegister.TabStop = false;
            this.gbRegister.Text = "Register";
            // 
            // gbLoginForgotPassword
            // 
            this.gbLoginForgotPassword.AutoSize = true;
            this.gbLoginForgotPassword.Controls.Add(this.btnNewRegister);
            this.gbLoginForgotPassword.Controls.Add(this.txtLogin);
            this.gbLoginForgotPassword.Controls.Add(this.btnSubmit);
            this.gbLoginForgotPassword.Controls.Add(this.txtPassword);
            this.gbLoginForgotPassword.Controls.Add(this.btnForgotPassword);
            this.gbLoginForgotPassword.Location = new System.Drawing.Point(34, 65);
            this.gbLoginForgotPassword.Name = "gbLoginForgotPassword";
            this.gbLoginForgotPassword.Size = new System.Drawing.Size(257, 303);
            this.gbLoginForgotPassword.TabIndex = 17;
            this.gbLoginForgotPassword.TabStop = false;
            this.gbLoginForgotPassword.Text = "Login/Forgot Password";
            // 
            // btnNewRegister
            // 
            this.btnNewRegister.Location = new System.Drawing.Point(46, 239);
            this.btnNewRegister.Name = "btnNewRegister";
            this.btnNewRegister.Size = new System.Drawing.Size(166, 35);
            this.btnNewRegister.TabIndex = 4;
            this.btnNewRegister.Text = "Register";
            this.btnNewRegister.UseVisualStyleBackColor = true;
            this.btnNewRegister.Click += new System.EventHandler(this.btnNewRegister_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1263, 33);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logOutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(69, 29);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
            this.logOutToolStripMenuItem.Text = "Log Out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1263, 629);
            this.Controls.Add(this.gbLoginForgotPassword);
            this.Controls.Add(this.gbRegister);
            this.Controls.Add(this.gbSecurityCheck);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbSecurityCheck.ResumeLayout(false);
            this.gbSecurityCheck.PerformLayout();
            this.gbRegister.ResumeLayout(false);
            this.gbRegister.PerformLayout();
            this.gbLoginForgotPassword.ResumeLayout(false);
            this.gbLoginForgotPassword.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassword2;
        private System.Windows.Forms.TextBox txtAns1;
        private System.Windows.Forms.TextBox txtAns2;
        private System.Windows.Forms.TextBox txtAns3;
        private System.Windows.Forms.ComboBox cmbQuestion1;
        private System.Windows.Forms.ComboBox cmbQuestion2;
        private System.Windows.Forms.ComboBox cmbQuestion3;
        private System.Windows.Forms.Button btnForgotPassword;
        private System.Windows.Forms.GroupBox gbSecurityCheck;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblQuestionCheck;
        private System.Windows.Forms.TextBox txtAnswerCheck;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.GroupBox gbRegister;
        private System.Windows.Forms.GroupBox gbLoginForgotPassword;
        private System.Windows.Forms.Button btnNewRegister;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

