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
        UserIPAddress userIP;
        frmLogin FL;

        public frmAuthorize()
        {
            InitializeComponent();
        }

        private void frmAuthorize_Load(object sender, EventArgs e)
        {
            lblAuthorizeMsg.Text = "Enter the authorization PIN that was sent to your registered email address";
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtPin.Text == UserIPAddress.pin)
            {
                //userIP.Insert();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
