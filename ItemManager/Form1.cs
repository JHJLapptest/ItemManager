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

namespace ItemManager
{
    public partial class Form1 : Form
    {
        User user = new User();
        SecurityQuestionsList Questions1;
        SecurityQuestionsList Questions2;
        SecurityQuestionsList Questions3;
        string CQ1 = string.Empty;
        string CQ2 = string.Empty;
        string CQ3 = string.Empty;
        Guid CQ1G = Guid.Empty;
        Guid CQ2G = Guid.Empty;
        Guid CQ3G = Guid.Empty;
        static Form1 F;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            user = user.Login(txtLogin.Text, txtPassword.Text);
            if (user != null)
            {
                
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (CQ1G != CQ2G || CQ1G != CQ3G || CQ2G != CQ3G)
            {
                user = user.Register(txtEmail.Text, txtUserName.Text, txtFirstName.Text, txtLastName.Text, txtPassword2.Text,
                CQ1G, CQ2G, CQ3G, txtAns1.Text, txtAns2.Text, txtAns3.Text);
            }
            if (CQ1G == CQ2G || CQ1G == CQ3G || CQ2G == CQ3G)
            {
                MessageBox.Show("Please ensure all security questions are different.", "Error!", MessageBoxButtons.OK);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            gbLoginForgotPassword.Visible = true;
            gbRegister.Visible = false;
            gbSecurityCheck.Visible = false;  
            //this.Size = new Size(346, 425);
            

            //F.Width = 346;
            //F.Height = 425;

        }
        private void btnForgotPassword_Click(object sender, EventArgs e)
        {
            user = new User();
            user = user.ForgotPassword(txtLogin.Text, txtLogin.Text);
            if (user != null)
            {
                this.gbSecurityCheck.Visible = true;
                this.lblQuestionCheck.Text = user.Questions.List[0].QuestionText;

            }
        }

        private void btnNewRegister_Click(object sender, EventArgs e)
        {
            gbLoginForgotPassword.Visible = false;
            gbRegister.Visible = true;
            gbSecurityCheck.Visible = false;
            //F.Width = 691;
            //F.Height = 399;

            Questions1 = new SecurityQuestionsList();
            Questions2 = new SecurityQuestionsList();
            Questions3 = new SecurityQuestionsList();

            Questions1 = Questions1.GetAll();

            cmbQuestion1.ValueMember = "ID";
            cmbQuestion1.DisplayMember = "Question";
            cmbQuestion1.DataSource = Questions1.List;

            CQ1 = cmbQuestion1.SelectedValue.ToString();
            CQ1G = Guid.Parse(CQ1);
            cmbQuestion1.SelectedIndexChanged += CmbQuestion1_SelectedIndexChanged;

            Questions2 = Questions2.GetAll();
            cmbQuestion2.ValueMember = "ID";
            cmbQuestion2.DisplayMember = "Question";
            cmbQuestion2.DataSource = Questions2.List;

            CQ2 = cmbQuestion2.SelectedValue.ToString();
            CQ2G = Guid.Parse(CQ2);
            cmbQuestion2.SelectedIndexChanged += CmbQuestion2_SelectedIndexChanged;

            Questions3 = Questions3.GetAll();
            cmbQuestion3.ValueMember = "ID";
            cmbQuestion3.DisplayMember = "Question";
            cmbQuestion3.DataSource = Questions3.List;

            CQ3 = cmbQuestion3.SelectedValue.ToString();
            CQ3G = Guid.Parse(CQ3);
            cmbQuestion3.SelectedIndexChanged += CmbQuestion3_SelectedIndexChanged;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAnswerCheck.Text.ToUpper() == user.Questions.List[0].Answer.ToUpper())
                {
                    user.SendEmailNowForgotPassword();
                    MessageBox.Show("If the answer is correct, an email has been sent to the email address on record.", "Notice", MessageBoxButtons.OK);
                    txtAnswerCheck.Clear();
                    this.gbSecurityCheck.Visible = false;
                }
                else
                {
                    MessageBox.Show("If the answer is correct, an email has been sent to the email address on record.", "Notice", MessageBoxButtons.OK);
                    txtAnswerCheck.Clear();
                    this.gbSecurityCheck.Visible = false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void CmbQuestion1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbQuestion1.DataSource = Questions1.List;
            CQ1 = cmbQuestion1.SelectedValue.ToString();
            CQ1G = Guid.Parse(CQ1);
        }
        private void CmbQuestion2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbQuestion1.DataSource = Questions2.List;
            CQ2 = cmbQuestion2.SelectedValue.ToString();
            CQ2G = Guid.Parse(CQ2);
        }
        private void CmbQuestion3_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbQuestion1.DataSource = Questions3.List;
            CQ3 = cmbQuestion3.SelectedValue.ToString();
            CQ3G = Guid.Parse(CQ3);
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
