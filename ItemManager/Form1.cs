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
    public partial class Form1 : Form
    {
        User user;
        SecurityQuestionsList Questions1;
        SecurityQuestionsList Questions2;
        SecurityQuestionsList Questions3;
        string CQ1 = string.Empty;
        string CQ2 = string.Empty;
        string CQ3 = string.Empty;
        Guid CQ1G = Guid.Empty;
        Guid CQ2G = Guid.Empty;
        Guid CQ3G = Guid.Empty;
        Guid LoginToken = Guid.Empty;
        TreeNode tnIGList, tnIGList2, tnIGList3;
        Database DB;
        Item item;
        ItemList iList;
        ItemList icList = new ItemList();
        ItemList iwList = new ItemList();
        ItemGroup IG;
        ItemGroupList IGList;
        SecurityQuestionsList SQList;
        ItemGroup temp = new ItemGroup();
        TreeNode selectedNode = new TreeNode();
        static Form1 F;

        public Form1()
        {
            InitializeComponent();
            this.tvGroupList.NodeMouseClick += TvGroupList_NodeMouseClick;
            dgvItemList.AutoGenerateColumns = false;
        }

        private void TvGroupList_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            IG = new ItemGroup();
            IGList = new ItemGroupList();
            iList = new ItemList();
            IGList.GetByUserID(user.ID);
            var hit = tvGroupList.HitTest(e.Location);
            if (hit.Location == TreeViewHitTestLocations.Label)
            {
                selectedNode = hit.Node;
                iwList.List.Clear();
                icList.List.Clear();
                dgvItemList.DataSource = null;
                foreach (ItemGroup IG in IGList.List)
                {
                    if (e.Node.Text == IG.Name && e.Node.Level == 1 && e.Node.Parent.Text == "Collections")
                    {
                        temp = IG;
                        foreach (Item it in IG.ItemList.List)
                        {
                            if (it.WishListStatus == false)
                            {
                                icList.List.Add(it);
                                dgvItemList.DataSource = icList.List;
                            }
                            else
                            {
                                //Do Nothing
                            }
                        }
                    }
                    else if (e.Node.Text == IG.Name && e.Node.Level == 1 && e.Node.Parent.Text == "Wishlist")
                    {
                        temp = IG;
                        foreach (Item it in IG.ItemList.List)
                        {
                            if (it.WishListStatus == true)
                            {
                                iwList.List.Add(it);
                                dgvItemList.DataSource = iwList.List;
                            }
                            else
                            {
                                //Do Nothing
                            }
                        }
                    }
                }
            }
            else
            {
                //Do Nothing.
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            user = new User();
            user = user.Login(txtLogin.Text, txtPassword.Text);
            if (user != null)
            {
                tnIGList = new TreeNode();
                tnIGList2 = new TreeNode();
                tnIGList3 = new TreeNode();
                IGList = new ItemGroupList();
                IGList.GetByUserID(user.ID);
                tvGroupList.Nodes.Add(tnIGList);
                tvGroupList.Nodes.Add(tnIGList2);
                tnIGList.Text = "Collections";
                tnIGList.Tag = IGList;
                tnIGList2.Text = "Wishlist";
                gbItems.Visible = true;
                IG = new ItemGroup();
                ItemGroupList Collections = (ItemGroupList)tnIGList.Tag;
                
                foreach (ItemGroup IG in Collections.List)
                {
                    TreeNode tmp = new TreeNode(IG.Name);
                    if (tmp.Text == IG.Name)
                    {
                        tmp.Tag = IG;

                        tnIGList.Nodes.Add(tmp.Text);
                        tnIGList2.Nodes.Add(tmp.Text);
                    }
                }
            }
            if (user == null)
            {
                MessageBox.Show("Invalid login. Check your credentials and try again.", "Login Error!", MessageBoxButtons.OK);
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
            gbItems.Visible = false;
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

        private void btnItemAddItem_Click(object sender, EventArgs e)
        {
            item = new Item();
            IG = temp;
            
            item.Name = txtItemName.Text;
            item.Type = txtItemType.Text;
            item.WishListStatus = chkItemWishlist.Checked;
            item.Quantity = int.Parse(txtItemQuantity.Text);
            item.Value = decimal.Parse(txtItemValue.Text);
            
            IG.ItemList.List.Add(item);
            user.ItemGroups.List.Add(IG);
            user.Save();

            if (IG.Name == selectedNode.Text && selectedNode.Parent.Text == "Collections")
            {
                icList.List.Clear();
                foreach (Item it in IG.ItemList.List)
                {
                    if (it.WishListStatus == false)
                    {
                        icList.List.Add(it);
                        dgvItemList.DataSource = icList.List;
                    }
                    else
                    {
                        //Do Nothing
                    }
                }
            }
            else if (IG.Name == selectedNode.Text && selectedNode.Parent.Text == "Wishlist")
            {
                iwList.List.Clear();
                foreach (Item it in IG.ItemList.List)
                {
                    if (it.WishListStatus == true)
                    {
                        iwList.List.Add(it);
                        dgvItemList.DataSource = iwList.List;
                    }
                    else
                    {
                        //Do Nothing
                    }
                }
            }
            #region Empty Text Boxes
            txtItemName.Text = string.Empty;
            txtItemType.Text = string.Empty;
            txtItemQuantity.Text = string.Empty;
            txtItemValue.Text = string.Empty;
            chkItemWishlist.Checked = false;
            #endregion
        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            IG = new ItemGroup();
            IG.Name = txtGroupName.Text;
            user.ItemGroups.List.Add(IG);
            
            user.Save();
            tnIGList.Nodes.Add(new TreeNode(txtGroupName.Text));
            tnIGList2.Nodes.Add(new TreeNode(txtGroupName.Text));
        }
    }
}
