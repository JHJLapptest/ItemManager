namespace ItemManager
{
    partial class ForgotPassword
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblQuestionCheck = new System.Windows.Forms.Label();
            this.txtAnswerCheck = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(234, 98);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(98, 40);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblQuestionCheck
            // 
            this.lblQuestionCheck.AutoSize = true;
            this.lblQuestionCheck.Location = new System.Drawing.Point(28, 19);
            this.lblQuestionCheck.Name = "lblQuestionCheck";
            this.lblQuestionCheck.Size = new System.Drawing.Size(0, 20);
            this.lblQuestionCheck.TabIndex = 19;
            // 
            // txtAnswerCheck
            // 
            this.txtAnswerCheck.Location = new System.Drawing.Point(32, 56);
            this.txtAnswerCheck.Name = "txtAnswerCheck";
            this.txtAnswerCheck.Size = new System.Drawing.Size(300, 26);
            this.txtAnswerCheck.TabIndex = 20;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(32, 98);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(99, 40);
            this.btnSend.TabIndex = 21;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click_1);
            // 
            // ForgotPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 171);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblQuestionCheck);
            this.Controls.Add(this.txtAnswerCheck);
            this.Controls.Add(this.btnSend);
            this.Name = "ForgotPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ForgotPassword";
            this.Load += new System.EventHandler(this.ForgotPassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblQuestionCheck;
        private System.Windows.Forms.TextBox txtAnswerCheck;
        private System.Windows.Forms.Button btnSend;
    }
}