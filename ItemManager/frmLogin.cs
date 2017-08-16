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
        frmAuthorize FA;
        string a4;
        public static string pubIP;
        bool result;
        //public static string pin;

        public frmLogin()
        {
            InitializeComponent();
            this.FormClosing += FrmLogin_FormClosing;
        }

        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            user = new User();
            userIP = new UserIPAddress();
            userIP.GetPublicIP();//use to pass values
            pubIP = userIP.IPAddress;
            user = user.Login(txtLogin.Text.ToUpper(), txtPassword.Text);
            if (userIP.IPAddress == string.Empty || userIP.IPAddress == null)
            {
                MessageBox.Show("No internet access. Please check your connection settings and try again.", "Login Error!", MessageBoxButtons.OK);
                this.Activate();
            }
            
            

            else if (user == null || (user != null && txtPassword.Text != user.Password))
            {
                MessageBox.Show("Invalid login. Check your credentials and try again.", "Login Error!", MessageBoxButtons.OK);
            }
            
            else if (user != null && txtPassword.Text == user.Password)
            {

                //if userip = null, create if statement to run frmAuthorize 7/26
                userIP.UserID = user.ID;
                userIP = userIP.SearchIP();
                if (userIP.TrustedIP == true)
                {
                    this.Hide();
                    ShowInTaskbar = false;
                    F.User = user;
                }
                else if (userIP.TrustedIP == false)
                {
                    this.Hide();
                    FA = new frmAuthorize(F);
                    userIP.ConfirmIP(user.Email);
                    FA.Show();
                    FA.Activate();
                }
                //F.ShowInTaskbar = true;
                //F.Show();
                //F.Activate();
            }
            
        }
        private void btnForgotPassword_Click(object sender, EventArgs e)
        {
            user = new User();
            user = user.ForgotPassword(txtLogin.Text, txtLogin.Text);
            FGForm = new ForgotPassword();
            userIP = new UserIPAddress();
            userIP.GetPublicIP();//use to pass values
            pubIP = userIP.IPAddress;
            if (userIP.IPAddress == string.Empty || userIP.IPAddress == null)
            {
                MessageBox.Show("No internet access. Please check your connection settings and try again.", "Login Error!", MessageBoxButtons.OK);
                this.Activate();
            }
            else if (user != null)
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
            userIP = new UserIPAddress();
            userIP.GetPublicIP();//use to pass values
            pubIP = userIP.IPAddress;
            //userIP.UserID = user.ID;
            if (userIP.IPAddress == string.Empty || userIP.IPAddress == null)
            {
                MessageBox.Show("No internet access. Please check your connection settings and try again.", "Login Error!", MessageBoxButtons.OK);
                this.Activate();
            }
            else
            {
                RegForm = new frmRegister();
                RegForm.ShowDialog();
                //this.Hide();
                //RegForm.Activate();
            }
        }
        public frmLogin(Form1 frm)
        {
            InitializeComponent();
            F = frm;
            F.Hide();
            F.Visible = false;
            this.FormClosing += FrmLogin_FormClosing;
        }
    }
}
