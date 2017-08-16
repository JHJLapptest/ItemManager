namespace ItemManager
{
    partial class frmAddItem
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
            this.txtItemValue = new System.Windows.Forms.TextBox();
            this.chkItemWishlist = new System.Windows.Forms.CheckBox();
            this.txtItemQuantity = new System.Windows.Forms.TextBox();
            this.txtItemType = new System.Windows.Forms.TextBox();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.btnItemAddItem = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtItemValue
            // 
            this.txtItemValue.Location = new System.Drawing.Point(3, 76);
            this.txtItemValue.Name = "txtItemValue";
            this.txtItemValue.Size = new System.Drawing.Size(142, 26);
            this.txtItemValue.TabIndex = 35;
            this.txtItemValue.Text = "Value";
            // 
            // chkItemWishlist
            // 
            this.chkItemWishlist.AutoSize = true;
            this.chkItemWishlist.Location = new System.Drawing.Point(3, 108);
            this.chkItemWishlist.Name = "chkItemWishlist";
            this.chkItemWishlist.Size = new System.Drawing.Size(98, 24);
            this.chkItemWishlist.TabIndex = 34;
            this.chkItemWishlist.Text = "Wishlist?";
            this.chkItemWishlist.UseVisualStyleBackColor = true;
            // 
            // txtItemQuantity
            // 
            this.txtItemQuantity.Location = new System.Drawing.Point(3, 44);
            this.txtItemQuantity.Name = "txtItemQuantity";
            this.txtItemQuantity.Size = new System.Drawing.Size(142, 26);
            this.txtItemQuantity.TabIndex = 33;
            this.txtItemQuantity.Text = "Quantity";
            // 
            // txtItemType
            // 
            this.txtItemType.Location = new System.Drawing.Point(151, 12);
            this.txtItemType.Multiline = true;
            this.txtItemType.Name = "txtItemType";
            this.txtItemType.Size = new System.Drawing.Size(333, 120);
            this.txtItemType.TabIndex = 32;
            this.txtItemType.Text = "Type";
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(3, 12);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(142, 26);
            this.txtItemName.TabIndex = 31;
            this.txtItemName.Text = "Name";
            // 
            // btnItemAddItem
            // 
            this.btnItemAddItem.BackColor = System.Drawing.Color.ForestGreen;
            this.btnItemAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnItemAddItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItemAddItem.Location = new System.Drawing.Point(3, 138);
            this.btnItemAddItem.Name = "btnItemAddItem";
            this.btnItemAddItem.Size = new System.Drawing.Size(108, 36);
            this.btnItemAddItem.TabIndex = 30;
            this.btnItemAddItem.Text = "Add Item";
            this.btnItemAddItem.UseVisualStyleBackColor = false;
            this.btnItemAddItem.Click += new System.EventHandler(this.btnItemAddItem_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Firebrick;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(117, 138);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(108, 36);
            this.btnCancel.TabIndex = 36;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmAddItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 191);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtItemValue);
            this.Controls.Add(this.chkItemWishlist);
            this.Controls.Add(this.txtItemQuantity);
            this.Controls.Add(this.txtItemType);
            this.Controls.Add(this.txtItemName);
            this.Controls.Add(this.btnItemAddItem);
            this.Name = "frmAddItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmAddItem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtItemValue;
        private System.Windows.Forms.CheckBox chkItemWishlist;
        private System.Windows.Forms.TextBox txtItemQuantity;
        private System.Windows.Forms.TextBox txtItemType;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Button btnItemAddItem;
        private System.Windows.Forms.Button btnCancel;
    }
}