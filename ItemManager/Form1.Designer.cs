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
            this.btnSend = new System.Windows.Forms.Button();
            this.txtAnswerCheck = new System.Windows.Forms.TextBox();
            this.lblQuestionCheck = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbSecurityCheck.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(241, 45);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(166, 35);
            this.btnSubmit.TabIndex = 0;
            this.btnSubmit.Text = "Login";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(12, 49);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(209, 26);
            this.txtLogin.TabIndex = 1;
            this.txtLogin.Text = "Username/Email";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(12, 91);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(209, 26);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.Text = "Password";
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(348, 529);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(101, 36);
            this.btnRegister.TabIndex = 3;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(12, 213);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(412, 26);
            this.txtFirstName.TabIndex = 4;
            this.txtFirstName.Text = "First";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(460, 213);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(208, 26);
            this.txtLastName.TabIndex = 4;
            this.txtLastName.Text = "Last";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(13, 260);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(412, 26);
            this.txtUserName.TabIndex = 4;
            this.txtUserName.Text = "User";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(460, 260);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(208, 26);
            this.txtEmail.TabIndex = 4;
            this.txtEmail.Text = "Email";
            // 
            // txtPassword2
            // 
            this.txtPassword2.Location = new System.Drawing.Point(13, 306);
            this.txtPassword2.Name = "txtPassword2";
            this.txtPassword2.Size = new System.Drawing.Size(412, 26);
            this.txtPassword2.TabIndex = 4;
            this.txtPassword2.Text = "Password";
            // 
            // txtAns1
            // 
            this.txtAns1.Location = new System.Drawing.Point(460, 354);
            this.txtAns1.Name = "txtAns1";
            this.txtAns1.Size = new System.Drawing.Size(208, 26);
            this.txtAns1.TabIndex = 4;
            this.txtAns1.Text = "Ans1";
            // 
            // txtAns2
            // 
            this.txtAns2.Location = new System.Drawing.Point(460, 396);
            this.txtAns2.Name = "txtAns2";
            this.txtAns2.Size = new System.Drawing.Size(208, 26);
            this.txtAns2.TabIndex = 4;
            this.txtAns2.Text = "Ans2";
            // 
            // txtAns3
            // 
            this.txtAns3.Location = new System.Drawing.Point(460, 437);
            this.txtAns3.Name = "txtAns3";
            this.txtAns3.Size = new System.Drawing.Size(208, 26);
            this.txtAns3.TabIndex = 4;
            this.txtAns3.Text = "Ans3";
            // 
            // cmbQuestion1
            // 
            this.cmbQuestion1.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmbQuestion1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQuestion1.FormattingEnabled = true;
            this.cmbQuestion1.Location = new System.Drawing.Point(12, 354);
            this.cmbQuestion1.Name = "cmbQuestion1";
            this.cmbQuestion1.Size = new System.Drawing.Size(413, 28);
            this.cmbQuestion1.TabIndex = 5;
            // 
            // cmbQuestion2
            // 
            this.cmbQuestion2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQuestion2.FormattingEnabled = true;
            this.cmbQuestion2.Location = new System.Drawing.Point(13, 396);
            this.cmbQuestion2.Name = "cmbQuestion2";
            this.cmbQuestion2.Size = new System.Drawing.Size(413, 28);
            this.cmbQuestion2.TabIndex = 5;
            // 
            // cmbQuestion3
            // 
            this.cmbQuestion3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQuestion3.FormattingEnabled = true;
            this.cmbQuestion3.Location = new System.Drawing.Point(13, 437);
            this.cmbQuestion3.Name = "cmbQuestion3";
            this.cmbQuestion3.Size = new System.Drawing.Size(413, 28);
            this.cmbQuestion3.TabIndex = 5;
            // 
            // btnForgotPassword
            // 
            this.btnForgotPassword.Location = new System.Drawing.Point(244, 91);
            this.btnForgotPassword.Name = "btnForgotPassword";
            this.btnForgotPassword.Size = new System.Drawing.Size(163, 35);
            this.btnForgotPassword.TabIndex = 7;
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
            this.gbSecurityCheck.Location = new System.Drawing.Point(732, 133);
            this.gbSecurityCheck.Name = "gbSecurityCheck";
            this.gbSecurityCheck.Size = new System.Drawing.Size(342, 221);
            this.gbSecurityCheck.TabIndex = 8;
            this.gbSecurityCheck.TabStop = false;
            this.gbSecurityCheck.Visible = false;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(19, 166);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(99, 40);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtAnswerCheck
            // 
            this.txtAnswerCheck.Location = new System.Drawing.Point(19, 127);
            this.txtAnswerCheck.Name = "txtAnswerCheck";
            this.txtAnswerCheck.Size = new System.Drawing.Size(300, 26);
            this.txtAnswerCheck.TabIndex = 1;
            // 
            // lblQuestionCheck
            // 
            this.lblQuestionCheck.AutoSize = true;
            this.lblQuestionCheck.Location = new System.Drawing.Point(15, 60);
            this.lblQuestionCheck.Name = "lblQuestionCheck";
            this.lblQuestionCheck.Size = new System.Drawing.Size(0, 20);
            this.lblQuestionCheck.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(142, 166);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(98, 40);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 630);
            this.Controls.Add(this.gbSecurityCheck);
            this.Controls.Add(this.btnForgotPassword);
            this.Controls.Add(this.cmbQuestion3);
            this.Controls.Add(this.cmbQuestion2);
            this.Controls.Add(this.cmbQuestion1);
            this.Controls.Add(this.txtAns3);
            this.Controls.Add(this.txtAns2);
            this.Controls.Add(this.txtAns1);
            this.Controls.Add(this.txtPassword2);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.btnSubmit);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbSecurityCheck.ResumeLayout(false);
            this.gbSecurityCheck.PerformLayout();
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
    }
}

