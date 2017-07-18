namespace ItemManager
{
    partial class frmRegister
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
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPassword2 = new System.Windows.Forms.TextBox();
            this.cmbQuestion1 = new System.Windows.Forms.ComboBox();
            this.txtAns1 = new System.Windows.Forms.TextBox();
            this.cmbQuestion2 = new System.Windows.Forms.ComboBox();
            this.txtAns2 = new System.Windows.Forms.TextBox();
            this.cmbQuestion3 = new System.Windows.Forms.ComboBox();
            this.txtAns3 = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(12, 12);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(412, 26);
            this.txtFirstName.TabIndex = 16;
            this.txtFirstName.Text = "First";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(460, 12);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(208, 26);
            this.txtLastName.TabIndex = 17;
            this.txtLastName.Text = "Last";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(13, 59);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(412, 26);
            this.txtUserName.TabIndex = 18;
            this.txtUserName.Text = "User";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(460, 59);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(208, 26);
            this.txtEmail.TabIndex = 19;
            this.txtEmail.Text = "Email";
            // 
            // txtPassword2
            // 
            this.txtPassword2.Location = new System.Drawing.Point(13, 105);
            this.txtPassword2.Name = "txtPassword2";
            this.txtPassword2.Size = new System.Drawing.Size(412, 26);
            this.txtPassword2.TabIndex = 20;
            this.txtPassword2.Text = "Password";
            // 
            // cmbQuestion1
            // 
            this.cmbQuestion1.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmbQuestion1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQuestion1.FormattingEnabled = true;
            this.cmbQuestion1.Location = new System.Drawing.Point(12, 153);
            this.cmbQuestion1.Name = "cmbQuestion1";
            this.cmbQuestion1.Size = new System.Drawing.Size(413, 28);
            this.cmbQuestion1.TabIndex = 21;
            // 
            // txtAns1
            // 
            this.txtAns1.Location = new System.Drawing.Point(460, 153);
            this.txtAns1.Name = "txtAns1";
            this.txtAns1.Size = new System.Drawing.Size(208, 26);
            this.txtAns1.TabIndex = 22;
            this.txtAns1.Text = "Ans1";
            // 
            // cmbQuestion2
            // 
            this.cmbQuestion2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQuestion2.FormattingEnabled = true;
            this.cmbQuestion2.Location = new System.Drawing.Point(13, 195);
            this.cmbQuestion2.Name = "cmbQuestion2";
            this.cmbQuestion2.Size = new System.Drawing.Size(413, 28);
            this.cmbQuestion2.TabIndex = 23;
            // 
            // txtAns2
            // 
            this.txtAns2.Location = new System.Drawing.Point(460, 195);
            this.txtAns2.Name = "txtAns2";
            this.txtAns2.Size = new System.Drawing.Size(208, 26);
            this.txtAns2.TabIndex = 24;
            this.txtAns2.Text = "Ans2";
            // 
            // cmbQuestion3
            // 
            this.cmbQuestion3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQuestion3.FormattingEnabled = true;
            this.cmbQuestion3.Location = new System.Drawing.Point(13, 236);
            this.cmbQuestion3.Name = "cmbQuestion3";
            this.cmbQuestion3.Size = new System.Drawing.Size(413, 28);
            this.cmbQuestion3.TabIndex = 25;
            // 
            // txtAns3
            // 
            this.txtAns3.Location = new System.Drawing.Point(460, 236);
            this.txtAns3.Name = "txtAns3";
            this.txtAns3.Size = new System.Drawing.Size(208, 26);
            this.txtAns3.TabIndex = 26;
            this.txtAns3.Text = "Ans3";
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(291, 301);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(101, 36);
            this.btnRegister.TabIndex = 27;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(487, 301);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(93, 36);
            this.btnCancel.TabIndex = 28;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 349);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtPassword2);
            this.Controls.Add(this.cmbQuestion1);
            this.Controls.Add(this.txtAns1);
            this.Controls.Add(this.cmbQuestion2);
            this.Controls.Add(this.txtAns2);
            this.Controls.Add(this.cmbQuestion3);
            this.Controls.Add(this.txtAns3);
            this.Controls.Add(this.btnRegister);
            this.Name = "frmRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRegister";
            this.Load += new System.EventHandler(this.frmRegister_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassword2;
        private System.Windows.Forms.ComboBox cmbQuestion1;
        private System.Windows.Forms.TextBox txtAns1;
        private System.Windows.Forms.ComboBox cmbQuestion2;
        private System.Windows.Forms.TextBox txtAns2;
        private System.Windows.Forms.ComboBox cmbQuestion3;
        private System.Windows.Forms.TextBox txtAns3;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnCancel;
    }
}