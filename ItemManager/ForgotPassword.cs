using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessObjects;
using DatabaseHelper;

namespace ItemManager
{
    public partial class ForgotPassword : Form
    {
        User usert;
        ForgotPassword FGForm;
        frmLogin FL;
        Form1 F;
        public ForgotPassword()
        {
            InitializeComponent();
            
        }

        private void ForgotPassword_Load(object sender, EventArgs e)
        {
            //FGForm = new ForgotPassword();
            usert = frmLogin.user;
            this.lblQuestionCheck.Text = usert.Questions.List[0].QuestionText;
        }

        private void btnSend_Click_1(object sender, EventArgs e)
        {
            {
                try
                {
                    if (txtAnswerCheck.Text.ToUpper() == usert.Questions.List[0].Answer.ToUpper())
                    {
                        usert.SendEmailNowForgotPassword();
                        MessageBox.Show("If the answer is correct, an email has been sent to the email address on record.", "Notice", MessageBoxButtons.OK);
                        txtAnswerCheck.Clear();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("If the answer is correct, an email has been sent to the email address on record.", "Notice", MessageBoxButtons.OK);
                        txtAnswerCheck.Clear();
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
