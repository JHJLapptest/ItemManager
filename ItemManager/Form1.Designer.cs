﻿namespace ItemManager
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tvGroupList = new System.Windows.Forms.TreeView();
            this.gbItems = new System.Windows.Forms.GroupBox();
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
            this.menuStrip1.SuspendLayout();
            this.gbItems.SuspendLayout();
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
            this.menuStrip1.Size = new System.Drawing.Size(926, 33);
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
            // tvGroupList
            // 
            this.tvGroupList.HideSelection = false;
            this.tvGroupList.Location = new System.Drawing.Point(6, 89);
            this.tvGroupList.Name = "tvGroupList";
            this.tvGroupList.Size = new System.Drawing.Size(209, 380);
            this.tvGroupList.TabIndex = 19;
            // 
            // gbItems
            // 
            this.gbItems.Controls.Add(this.btnItemAddItem);
            this.gbItems.Controls.Add(this.btnItemSearch);
            this.gbItems.Controls.Add(this.txtItemSearch);
            this.gbItems.Controls.Add(this.label1);
            this.gbItems.Controls.Add(this.txtGroupName);
            this.gbItems.Controls.Add(this.btnAddGroup);
            this.gbItems.Controls.Add(this.dgvItemList);
            this.gbItems.Controls.Add(this.tvGroupList);
            this.gbItems.Location = new System.Drawing.Point(12, 36);
            this.gbItems.Name = "gbItems";
            this.gbItems.Size = new System.Drawing.Size(907, 550);
            this.gbItems.TabIndex = 20;
            this.gbItems.TabStop = false;
            this.gbItems.Text = "Items";
            // 
            // btnItemAddItem
            // 
            this.btnItemAddItem.Location = new System.Drawing.Point(6, 475);
            this.btnItemAddItem.Name = "btnItemAddItem";
            this.btnItemAddItem.Size = new System.Drawing.Size(209, 37);
            this.btnItemAddItem.TabIndex = 31;
            this.btnItemAddItem.Text = "Add Item";
            this.btnItemAddItem.UseVisualStyleBackColor = true;
            this.btnItemAddItem.Click += new System.EventHandler(this.btnItemAddItem_Click_1);
            // 
            // btnItemSearch
            // 
            this.btnItemSearch.Location = new System.Drawing.Point(773, 39);
            this.btnItemSearch.Name = "btnItemSearch";
            this.btnItemSearch.Size = new System.Drawing.Size(123, 27);
            this.btnItemSearch.TabIndex = 25;
            this.btnItemSearch.Text = "Search Items";
            this.btnItemSearch.UseVisualStyleBackColor = true;
            this.btnItemSearch.Click += new System.EventHandler(this.btnItemSearch_Click);
            // 
            // txtItemSearch
            // 
            this.txtItemSearch.Location = new System.Drawing.Point(535, 39);
            this.txtItemSearch.Name = "txtItemSearch";
            this.txtItemSearch.Size = new System.Drawing.Size(232, 26);
            this.txtItemSearch.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(361, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 20);
            this.label1.TabIndex = 23;
            this.label1.Text = "Search By Item Name:";
            // 
            // txtGroupName
            // 
            this.txtGroupName.Location = new System.Drawing.Point(6, 42);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(202, 26);
            this.txtGroupName.TabIndex = 22;
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.Location = new System.Drawing.Point(221, 39);
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(121, 32);
            this.btnAddGroup.TabIndex = 21;
            this.btnAddGroup.Text = "Add Group";
            this.btnAddGroup.UseVisualStyleBackColor = true;
            this.btnAddGroup.Click += new System.EventHandler(this.btnAddGroup_Click);
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
            this.dgvItemList.Location = new System.Drawing.Point(221, 89);
            this.dgvItemList.Name = "dgvItemList";
            this.dgvItemList.RowTemplate.Height = 28;
            this.dgvItemList.Size = new System.Drawing.Size(675, 423);
            this.dgvItemList.TabIndex = 20;
            // 
            // ItemName
            // 
            this.ItemName.DataPropertyName = "Name";
            this.ItemName.HeaderText = "Name";
            this.ItemName.Name = "ItemName";
            // 
            // ItemType
            // 
            this.ItemType.DataPropertyName = "Type";
            this.ItemType.HeaderText = "Type";
            this.ItemType.Name = "ItemType";
            // 
            // ItemQuantity
            // 
            this.ItemQuantity.DataPropertyName = "Quantity";
            this.ItemQuantity.HeaderText = "Quantity";
            this.ItemQuantity.Name = "ItemQuantity";
            // 
            // ItemValue
            // 
            this.ItemValue.DataPropertyName = "Value";
            this.ItemValue.HeaderText = "Value";
            this.ItemValue.Name = "ItemValue";
            // 
            // ItemWishlist
            // 
            this.ItemWishlist.DataPropertyName = "WishListStatus";
            this.ItemWishlist.HeaderText = "Wishlist";
            this.ItemWishlist.Name = "ItemWishlist";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 566);
            this.Controls.Add(this.gbItems);
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
            this.gbItems.ResumeLayout(false);
            this.gbItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TreeView tvGroupList;
        private System.Windows.Forms.GroupBox gbItems;
        private System.Windows.Forms.DataGridView dgvItemList;
        private System.Windows.Forms.Button btnAddGroup;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemValue;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ItemWishlist;
        private System.Windows.Forms.Button btnItemSearch;
        private System.Windows.Forms.TextBox txtItemSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnItemAddItem;
    }
}

