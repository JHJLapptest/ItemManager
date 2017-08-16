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
    public partial class frmAuthorize : Form
    {
        User user;
        UserIPAddress userIP;
        frmLogin FL;
        Form1 F;

        public frmAuthorize()
        {
            InitializeComponent();
        }

        private void frmAuthorize_Load(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtPin.Text == UserIPAddress.pin)
            { // need to add ip address first. After that, use a stored procedure to change the trusted ip bit to true.
                userIP = new UserIPAddress();
                userIP.UserID = frmLogin.user.ID;
                userIP.IPAddress = frmLogin.pubIP;
                //userIP.IPAddress = UserIPAddress
                userIP.TrustedIP = true;
                userIP.Save();
                
                this.Close();

                //F = new Form1();
                F.ShowInTaskbar = true;
                F.Show();
                F.Activate();
                F.User = frmLogin.user;
            }
            else if (txtPin.Text != UserIPAddress.pin)
            {
                userIP = new UserIPAddress();
                userIP.UserID = frmLogin.user.ID;
                userIP.IPAddress = frmLogin.pubIP;
                //userIP.TrustedIP = false;
                //userIP.Save();
                MessageBox.Show("Incorrect pin number.", "Error!", MessageBoxButtons.OK);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void btnResend_Click(object sender, EventArgs e)
        {
            UserIPAddress.pin = null;
            userIP = new UserIPAddress();
            userIP.UserID = frmLogin.user.ID;
            userIP.IPAddress = frmLogin.pubIP;
            userIP.ConfirmIP(frmLogin.user.Email);
            MessageBox.Show("Another pin has been sent to the account's email address. If an email has not been received in 5 minutes, click Resend PIN", "Notice!", MessageBoxButtons.OK);
        }
        public frmAuthorize(Form1 frm)
        {
            InitializeComponent();
            F = frm;
        }
    }
}
