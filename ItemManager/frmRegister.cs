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
    public partial class frmRegister : Form
    {
        User user;
        string CQ1 = string.Empty;
        string CQ2 = string.Empty;
        string CQ3 = string.Empty;
        Guid CQ1G = Guid.Empty;
        Guid CQ2G = Guid.Empty;
        Guid CQ3G = Guid.Empty;
        SecurityQuestionsList Questions1;
        SecurityQuestionsList Questions2;
        SecurityQuestionsList Questions3;
        Form1 F;
        private BrokenRuleList _BrokenRules = new BrokenRuleList();

        public frmRegister()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            {
                user = new User();

                if (CQ1G != CQ2G || CQ1G != CQ3G || CQ2G != CQ3G)
                {
                    user = user.Register(txtEmail.Text.ToUpper(), txtUserName.Text.ToUpper(), txtFirstName.Text.ToUpper(), txtLastName.Text.ToUpper(), txtPassword2.Text,
                    CQ1G, CQ2G, CQ3G, txtAns1.Text.ToUpper(), txtAns2.Text.ToUpper(), txtAns3.Text.ToUpper());
                    if (user == null)
                    {

                        //do nothing
                    }
                    else if (user.BrokenRules.List.Count == 0)
                    {
                        this.Close();
                    }
                    else if (user.BrokenRules.List.Count >= 1)
                    {

                    }
                }
                else if (CQ1G == CQ2G || CQ1G == CQ3G || CQ2G == CQ3G)
                {
                    MessageBox.Show("Please ensure all security questions are different.", "Error!", MessageBoxButtons.OK);
                }
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

        private void frmRegister_Load(object sender, EventArgs e)
        {
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
