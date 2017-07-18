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
        ItemList isList = new ItemList();
        ItemGroup IG;
        ItemGroupList IGList;
        SecurityQuestionsList SQList;
        ItemGroup temp = new ItemGroup();
        TreeNode selectedNode = new TreeNode();
        ForgotPassword FGForm;
        frmRegister RegForm;
        frmLogin FL;
        Form1 F;
        #endregion

        public Form1()
        {
            InitializeComponent();
            this.tvGroupList.NodeMouseClick += TvGroupList_NodeMouseClick;
            dgvItemList.AutoGenerateColumns = false;
            //F.Size = new Size(344, 426);
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

            //iList.SearchByItemName(temp.ID, txtItemSearch.Text);
            isList.List.Clear();
            if (temp.Name == selectedNode.Text && selectedNode.Parent.Text == "Collections")
            {
                foreach (Item it in icList.List)
                {
                    if (it.WishListStatus == false && (it.Name.Contains(txtItemSearch.Text)))
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
                foreach (Item it in iwList.List)
                {
                    if (it.WishListStatus == true && (it.Name.Contains(txtItemSearch.Text)))
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
                    }
                    else
                    {
                        //Do Nothing
                    }
                }
                dgvItemList.DataSource = icList.List;
            }
            else if (IG.Name == selectedNode.Text && selectedNode.Parent.Text == "Wishlist")
            {
                iwList.List.Clear();
                foreach (Item it in IG.ItemList.List)
                {
                    if (it.WishListStatus == true)
                    {
                        iwList.List.Add(it);
                    }
                    else
                    {
                        //Do Nothing
                    }
                }
                dgvItemList.DataSource = iwList.List;
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
