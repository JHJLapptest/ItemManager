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
        #region Private Members
        public static User user;
        
        Guid LoginToken = Guid.Empty;
        TreeNode tnIGList, tnIGList2, tnIGList3;
        Database DB;
        Item item;
        ItemList iList;
        ItemList icList = new ItemList();
        ItemList iwList = new ItemList();
        ItemList isList;
        ItemGroup IG;
        ItemGroupList IGList;
        SecurityQuestionsList SQList;
        public static ItemGroup temp;
        TreeNode selectedNode = new TreeNode();
        ForgotPassword FGForm;
        frmRegister RegForm;
        frmLogin FL;
        Form1 F;
        TreeNode tmp;
        #endregion

        public User User
        {
            set
            {
                user = value;
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
                    Show();
                    Activate();
                    ShowInTaskbar = true;
                    IG = new ItemGroup();
                    ItemGroupList Collections = user.ItemGroups;

                    foreach (ItemGroup IG in Collections.List)
                    {
                        TreeNode tmp = new TreeNode(IG.Name);
                        if (tmp.Text == IG.Name && IG.Deleted == false)
                        {
                            tmp.Tag = IG;

                            tnIGList.Nodes.Add(tmp.Text);
                            tnIGList2.Nodes.Add(tmp.Text);
                        }
                    }
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
            this.tvGroupList.NodeMouseClick += TvGroupList_NodeMouseClick;
            dgvItemList.AutoGenerateColumns = false;
            dgvItemList.CellMouseUp += DgvItemList_CellMouseUp;
            this.FormClosed += F_FormClosed;
            //dgvItemList.CellEndEdit += DgvItemList_CellEndEdit;
            tvGroupList.MouseUp += TvGroupList_MouseUp;
            //F.Size = new Size(344, 426);
        }

        private void F_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void TvGroupList_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                cmsMenu.Show(Cursor.Position);
                cmsEdit.Visible = false;
                cmsDeleteGroup.Visible = true;
                cmsDeleteItems.Visible = false;
            }
        }

        private void DgvItemList_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                cmsMenu.Show(Cursor.Position);
                cmsEdit.Visible = true;
                cmsDeleteGroup.Visible = false;
                cmsDeleteItems.Visible = true;
            }
        }

        private void TvGroupList_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            btnSaveChanges.Visible = false;
            ItemDeleted.Visible = false;
            dgvItemList.ReadOnly = true;
            IG = new ItemGroup();
            IGList = new ItemGroupList();
            iList = new ItemList();
            //ItemList icList = new ItemList();
            //ItemList iwList = new ItemList();
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
                    if (e.Node.Text == IG.Name && e.Node.Level == 1 && e.Node.Parent.Text == "Collections" && IG.Deleted == false)
                    {
                        temp = IG;
                        foreach (Item it in IG.ItemList.List)
                        {
                            if (it.WishListStatus == false && it.Deleted == false)
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
                    else if (e.Node.Text == IG.Name && e.Node.Level == 1 && e.Node.Parent.Text == "Wishlist" && IG.Deleted == false)
                    {
                        temp = IG;
                        foreach (Item it in IG.ItemList.List)
                        {
                            if (it.WishListStatus == true && it.Deleted == false)
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
                
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Hide();
            this.ShowInTaskbar = false;

            frmLogin FL = new frmLogin(this);
            FL.Show();
            FL.Activate();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void btnItemSearch_Click(object sender, EventArgs e)
        {
            isList = new ItemList();
            //iList.SearchByItemName(temp.ID, txtItemSearch.Text);
            try
            {
                if (temp.Name == selectedNode.Text && selectedNode.Parent.Text == "Collections")
                {
                    isList.List.Clear();
                    foreach (Item it in icList.List)
                    {
                        if (it.WishListStatus == false && (it.Name.Contains(txtItemSearch.Text.Trim())))
                        {
                            isList.List.Add(it);
                        }
                        else
                        {
                            //Do Nothing
                        }
                    }
                    dgvItemList.DataSource = isList.List;
                }
                else if (temp.Name == selectedNode.Text && selectedNode.Parent.Text == "Wishlist")
                {
                    isList.List.Clear();
                    foreach (Item it in iwList.List)
                    {
                        if (it.WishListStatus == true && (it.Name.Contains(txtItemSearch.Text.Trim())))
                        {
                            isList.List.Add(it);
                        }
                        else
                        {
                            //Do Nothing
                        }
                    }
                    dgvItemList.DataSource = isList.List;
                }
            }
            catch
            {
                //do nothing
            }
        }

        private void btnItemAddItem_Click_1(object sender, EventArgs e)
        {
            if(temp == null || selectedNode.Text == "Collections" || selectedNode.Text == "Wishlist")
            {
                MessageBox.Show("Please select a group that you would like to add an item to.", "Error!", MessageBoxButtons.OK);
            }
            else if (temp.UserID == user.ID && selectedNode.Text != "Collections" && selectedNode.Text != "Wishlist" 
                && selectedNode != null)
                {
                    //this.ShowInTaskbar = true;
                    //this.Show();
                    frmAddItem IF = new frmAddItem(this, IG);
                    IF.FormClosing += IF_FormClosing;
                    this.ShowInTaskbar = true;
                    this.Show();
                    IF.ShowDialog();
                }
            
        }

        private void cmsEdit_Click(object sender, EventArgs e)
        {
            btnSaveChanges.Visible = true;
            dgvItemList.ReadOnly = false;
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {

            IG = temp;
            user.ItemGroups.List.Add(IG);
            user.Save();
            ItemDeleted.Visible = false;
            ItemDeleted.ReadOnly = true;
            dgvItemList.ReadOnly = true;
            #region Refresh
            iwList = new ItemList();
            icList = new ItemList();
            iwList.List.Clear();
            icList.List.Clear();
            dgvItemList.DataSource = null;
            foreach (ItemGroup IG in IGList.List)
            {
                if (selectedNode.Text == IG.Name && selectedNode.Level == 1 && selectedNode.Parent.Text == "Collections" && IG.Deleted == false)
                {
                    temp = IG;
                    foreach (Item it in IG.ItemList.List)
                    {
                        if (it.WishListStatus == false && it.Deleted == false)
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
                else if (selectedNode.Text == IG.Name && selectedNode.Level == 1 && selectedNode.Parent.Text == "Wishlist" && IG.Deleted == false)
                {
                    temp = IG;
                    foreach (Item it in IG.ItemList.List)
                    {
                        if (it.WishListStatus == true && it.Deleted == false)
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
            #endregion
        }

        private void btnSearchAll_Click(object sender, EventArgs e)
        {
            isList = new ItemList();
            IGList = new ItemGroupList();
            isList.List.Clear();
            IGList.GetByUserID(user.ID);

            foreach (ItemGroup IG in IGList.List)
            {
                foreach (Item it in IG.ItemList.List)
                {
                    if (it.Name.Contains(txtItemSearch.Text.Trim()) && txtItemSearch.Text.Trim() != string.Empty)
                    {
                        //string colIG = IG.Name;
                        isList.List.Add(it);
                    }
                }
                
            }
            dgvItemList.DataSource = isList.List;
        }

        private void cmsDeleteGroup_Click(object sender, EventArgs e)
        {
            if (/*selectedNode.Text == IG.Name && */selectedNode.Level == 1 && selectedNode.Parent.Text == "Collections")
            {
                //selectedNode = new TreeNode();
                int index = tnIGList.Nodes.IndexOf(selectedNode);
                tnIGList.Nodes.Remove(selectedNode);
                tnIGList2.Nodes.RemoveAt(index);
                IG = temp;
                IG.Deleted = true;
                user.ItemGroups.List.Add(IG);
                user.Save();
            }
            if (/*selectedNode.Text == IG.Name && */selectedNode.Level == 1 && selectedNode.Parent.Text == "Wishlist")
            {
                int index = tnIGList2.Nodes.IndexOf(selectedNode);
                tnIGList2.Nodes.Remove(selectedNode);
                tnIGList.Nodes.RemoveAt(index);
                IG = temp;
                IG.Deleted = true;
                user.ItemGroups.List.Add(IG);
                user.Save();
            }
        }

        private void cmsDeleteItems_Click(object sender, EventArgs e)
        {
            dgvItemList.ReadOnly = false;
            ItemDeleted.Visible = true;
            btnSaveChanges.Visible = true;
            ItemDeleted.ReadOnly = false;
            ItemName.ReadOnly = true;
            ItemType.ReadOnly = true;
            ItemQuantity.ReadOnly = true;
            ItemValue.ReadOnly = true;
            ItemWishlist.ReadOnly = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void IF_FormClosing(object sender, FormClosingEventArgs e)
        {
            IG = temp;
            icList = new ItemList();
            iwList = new ItemList();
            if(selectedNode.Text == "Collections" || selectedNode.Text == "Wishlist")
            {
                //Do Nothing
            }
            else if (selectedNode.Parent.Text == "Collections")
            {
                foreach (Item it in IG.ItemList.List) //pick up here
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
            else if (selectedNode.Parent.Text == "Wishlist")
            {
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

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            if (txtGroupName.Text != string.Empty)
            {
                IG = new ItemGroup();
                IG.Name = txtGroupName.Text;
                user.ItemGroups.List.Add(IG);
            
                user.Save();
                tnIGList.Nodes.Add(new TreeNode(txtGroupName.Text));
                tnIGList2.Nodes.Add(new TreeNode(txtGroupName.Text));
                txtGroupName.Clear();
            }
            else
            {
                //do nothing
            }
        }
    }
}
