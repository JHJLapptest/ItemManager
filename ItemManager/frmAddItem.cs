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
    public partial class frmAddItem : Form
    {
        User user;
        Form1 F;
        ItemGroup IG;
        ItemGroupList IGList;
        ItemList icList;
        ItemList iwList;
        Item item;
        ItemGroup temp;
         


        public frmAddItem()
        {
            InitializeComponent();
        }

        private void btnItemAddItem_Click(object sender, EventArgs e)
        {
            user = Form1.user;
            item = new Item();
            IG = Form1.temp;
            icList = new ItemList();
            iwList = new ItemList();

            item.Name = txtItemName.Text;
            item.Type = txtItemType.Text;
            item.WishListStatus = chkItemWishlist.Checked;
            item.Quantity = int.Parse(txtItemQuantity.Text);
            item.Value = decimal.Parse(txtItemValue.Text);

            IG.ItemList.List.Add(item);
            user.ItemGroups.List.Add(IG);
            user.Save();
            F.Show();
            F.Activate();
            this.Close();

            //if (IG.Name == selectedNode.Text && selectedNode.Parent.Text == "Collections")
            //{
            //    icList.List.Clear();
            //    foreach (Item it in IG.ItemList.List)
            //    {
            //        if (it.WishListStatus == false)
            //        {
            //            icList.List.Add(it);
            //        }
            //        else
            //        {
            //            //Do Nothing
            //        }
            //    }
            //    dgvItemList.DataSource = icList.List;
            //}
            //else if (IG.Name == selectedNode.Text && selectedNode.Parent.Text == "Wishlist")
            //{
            //    iwList.List.Clear();
            //    foreach (Item it in IG.ItemList.List)
            //    {
            //        if (it.WishListStatus == true)
            //        {
            //            iwList.List.Add(it);
            //        }
            //        else
            //        {
            //            //Do Nothing
            //        }
            //    }
            //    dgvItemList.DataSource = iwList.List;
            //}
            #region Empty Text Boxes
            txtItemName.Text = string.Empty;
            txtItemType.Text = string.Empty;
            txtItemQuantity.Text = string.Empty;
            txtItemValue.Text = string.Empty;
            chkItemWishlist.Checked = false;
            #endregion
        }
        public frmAddItem(Form1 frm, ItemGroup IG)
        {
            InitializeComponent();
            F = frm;
            temp = IG;
            F.Hide();
            F.Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            F.ShowInTaskbar = true;
            F.Show();
            F.Activate();
            this.Close();
        }
    }
}
