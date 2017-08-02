namespace ItemManager
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSearchAll = new System.Windows.Forms.Button();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.btnItemAddItem = new System.Windows.Forms.Button();
            this.btnItemSearch = new System.Windows.Forms.Button();
            this.txtItemSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.btnAddGroup = new System.Windows.Forms.Button();
            this.dgvItemList = new System.Windows.Forms.DataGridView();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemWishlist = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tvGroupList = new System.Windows.Forms.TreeView();
            this.menuStrip1.SuspendLayout();
            this.cmsMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemList)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1101, 33);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logOutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(69, 29);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(161, 30);
            this.logOutToolStripMenuItem.Text = "Log Out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(161, 30);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // cmsMenu
            // 
            this.cmsMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsEdit});
            this.cmsMenu.Name = "cmsMenu";
            this.cmsMenu.Size = new System.Drawing.Size(115, 34);
            // 
            // cmsEdit
            // 
            this.cmsEdit.Name = "cmsEdit";
            this.cmsEdit.Size = new System.Drawing.Size(114, 30);
            this.cmsEdit.Text = "Edit";
            this.cmsEdit.Click += new System.EventHandler(this.cmsEdit_Click);
            // 
            // btnSearchAll
            // 
            this.btnSearchAll.Location = new System.Drawing.Point(784, 204);
            this.btnSearchAll.Name = "btnSearchAll";
            this.btnSearchAll.Size = new System.Drawing.Size(179, 32);
            this.btnSearchAll.TabIndex = 43;
            this.btnSearchAll.Text = "Search All Groups";
            this.btnSearchAll.UseVisualStyleBackColor = true;
            this.btnSearchAll.Click += new System.EventHandler(this.btnSearchAll_Click);
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Location = new System.Drawing.Point(880, 637);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(209, 37);
            this.btnSaveChanges.TabIndex = 42;
            this.btnSaveChanges.Text = "Save Changes";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            // 
            // btnItemAddItem
            // 
            this.btnItemAddItem.Location = new System.Drawing.Point(18, 637);
            this.btnItemAddItem.Name = "btnItemAddItem";
            this.btnItemAddItem.Size = new System.Drawing.Size(209, 37);
            this.btnItemAddItem.TabIndex = 41;
            this.btnItemAddItem.Text = "Add Item";
            this.btnItemAddItem.UseVisualStyleBackColor = true;
            // 
            // btnItemSearch
            // 
            this.btnItemSearch.Location = new System.Drawing.Point(784, 169);
            this.btnItemSearch.Name = "btnItemSearch";
            this.btnItemSearch.Size = new System.Drawing.Size(179, 32);
            this.btnItemSearch.TabIndex = 40;
            this.btnItemSearch.Text = "Search Current Group";
            this.btnItemSearch.UseVisualStyleBackColor = true;
            // 
            // txtItemSearch
            // 
            this.txtItemSearch.Location = new System.Drawing.Point(537, 204);
            this.txtItemSearch.Name = "txtItemSearch";
            this.txtItemSearch.Size = new System.Drawing.Size(232, 26);
            this.txtItemSearch.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(568, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 20);
            this.label1.TabIndex = 38;
            this.label1.Text = "Search By Item Name:";
            // 
            // txtGroupName
            // 
            this.txtGroupName.Location = new System.Drawing.Point(18, 204);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(202, 26);
            this.txtGroupName.TabIndex = 37;
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.Location = new System.Drawing.Point(233, 201);
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(121, 32);
            this.btnAddGroup.TabIndex = 36;
            this.btnAddGroup.Text = "Add Group";
            this.btnAddGroup.UseVisualStyleBackColor = true;
            // 
            // dgvItemList
            // 
            this.dgvItemList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItemList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemName,
            this.ItemType,
            this.ItemQuantity,
            this.ItemValue,
            this.ItemWishlist});
            this.dgvItemList.Location = new System.Drawing.Point(233, 251);
            this.dgvItemList.Name = "dgvItemList";
            this.dgvItemList.ReadOnly = true;
            this.dgvItemList.RowTemplate.Height = 28;
            this.dgvItemList.Size = new System.Drawing.Size(856, 380);
            this.dgvItemList.TabIndex = 35;
            // 
            // ItemName
            // 
            this.ItemName.DataPropertyName = "Name";
            this.ItemName.HeaderText = "Name";
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            // 
            // ItemType
            // 
            this.ItemType.DataPropertyName = "Type";
            this.ItemType.HeaderText = "Type";
            this.ItemType.Name = "ItemType";
            this.ItemType.ReadOnly = true;
            // 
            // ItemQuantity
            // 
            this.ItemQuantity.DataPropertyName = "Quantity";
            this.ItemQuantity.HeaderText = "Quantity";
            this.ItemQuantity.Name = "ItemQuantity";
            this.ItemQuantity.ReadOnly = true;
            // 
            // ItemValue
            // 
            this.ItemValue.DataPropertyName = "Value";
            this.ItemValue.HeaderText = "Value";
            this.ItemValue.Name = "ItemValue";
            this.ItemValue.ReadOnly = true;
            // 
            // ItemWishlist
            // 
            this.ItemWishlist.DataPropertyName = "WishListStatus";
            this.ItemWishlist.HeaderText = "Wishlist";
            this.ItemWishlist.Name = "ItemWishlist";
            this.ItemWishlist.ReadOnly = true;
            // 
            // tvGroupList
            // 
            this.tvGroupList.HideSelection = false;
            this.tvGroupList.Location = new System.Drawing.Point(18, 251);
            this.tvGroupList.Name = "tvGroupList";
            this.tvGroupList.Size = new System.Drawing.Size(209, 380);
            this.tvGroupList.TabIndex = 34;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 684);
            this.Controls.Add(this.btnSearchAll);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.btnItemAddItem);
            this.Controls.Add(this.btnItemSearch);
            this.Controls.Add(this.txtItemSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtGroupName);
            this.Controls.Add(this.btnAddGroup);
            this.Controls.Add(this.dgvItemList);
            this.Controls.Add(this.tvGroupList);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.cmsMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsMenu;
        private System.Windows.Forms.ToolStripMenuItem cmsEdit;
        private System.Windows.Forms.Button btnSearchAll;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.Button btnItemAddItem;
        private System.Windows.Forms.Button btnItemSearch;
        private System.Windows.Forms.TextBox txtItemSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.Button btnAddGroup;
        private System.Windows.Forms.DataGridView dgvItemList;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemValue;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ItemWishlist;
        private System.Windows.Forms.TreeView tvGroupList;
    }
}

