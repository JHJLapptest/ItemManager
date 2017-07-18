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
using System.Net;

namespace ItemManager
{
    public partial class frmLogin : Form
    {
        public static User user;
        Form1 F;
        frmRegister RegForm;
        ForgotPassword FGForm;
        UserIPAddress userIP;
        string a4;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            user = new User();
            userIP = new UserIPAddress();
            user = user.Login(txtLogin.Text.ToUpper(), txtPassword.Text);

            if (user != null && txtPassword.Text == user.Password)
            {
                F.User = user;
                F.Show();
                F.Activate();
                GetPublicIP();
                string pubIP = a4;
                if (pubIP == userIP.IPAddress && userIP.TrustedIP == true)
                {
                    this.Close();
                }

            }
            else if (user == null || (user != null && txtPassword.Text != user.Password))
            {
                MessageBox.Show("Invalid login. Check your credentials and try again.", "Login Error!", MessageBoxButtons.OK);
            }
        }
        private void btnForgotPassword_Click(object sender, EventArgs e)
        {
            user = new User();
            user = user.ForgotPassword(txtLogin.Text, txtLogin.Text);
            FGForm = new ForgotPassword();
            if (user != null)
            {
                FGForm.ShowDialog();
                //FGForm.Activate();
                
            }
            else
            {
                MessageBox.Show("Please enter a valid username or email.", "Error", MessageBoxButtons.OK);
            }
        }
        private void btnNewRegister_Click(object sender, EventArgs e)
        {
            RegForm = new frmRegister();
            RegForm.ShowDialog();
            //this.Hide();
            RegForm.Activate();

        }
        public static string GetPublicIP()
        {
            string url = "http://checkip.dyndns.org";
            System.Net.WebRequest req = System.Net.WebRequest.Create(url);
            System.Net.WebResponse resp = req.GetResponse();
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            string response = sr.ReadToEnd().Trim();
            string[] a = response.Split(':');
            string a2 = a[1].Substring(1);
            string[] a3 = a2.Split('<');
            string a4 = a3[0];
            return a4;
        }
        public frmLogin(Form1 frm)
        {
            InitializeComponent();
            F = frm;
        }
    }
}
