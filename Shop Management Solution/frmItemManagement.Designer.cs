namespace Shop_Management_Solution
{
    partial class frmItemManagement
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmItemManagement));
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblVendor = new System.Windows.Forms.Label();
            this.lblSalePrice = new System.Windows.Forms.Label();
            this.lblPurchasePrice = new System.Windows.Forms.Label();
            this.lblUoM = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.txtExpectedSalePrice = new System.Windows.Forms.TextBox();
            this.txtPurchasePrice = new System.Windows.Forms.TextBox();
            this.cbDeleted = new System.Windows.Forms.CheckBox();
            this.btClear = new System.Windows.Forms.Button();
            this.gbContractorDetails = new System.Windows.Forms.GroupBox();
            this.cmbUoM = new System.Windows.Forms.ComboBox();
            this.cmbVendor = new System.Windows.Forms.ComboBox();
            this.lbFilter = new System.Windows.Forms.Label();
            this.txtNameFilter = new System.Windows.Forms.TextBox();
            this.cbShowDeleted = new System.Windows.Forms.CheckBox();
            this.dgItem = new System.Windows.Forms.DataGridView();
            this.clID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clPurchasePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSalePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clUoMID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clVendorID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clVendor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clIsDeleted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btSaveItems = new System.Windows.Forms.Button();
            this.btnDeleteItem = new System.Windows.Forms.Button();
            this.btUpdateItem = new System.Windows.Forms.Button();
            this.btAddNewItem = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gbContractorDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(118, 24);
            this.txtName.MaxLength = 255;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(179, 20);
            this.txtName.TabIndex = 8;
            // 
            // lblVendor
            // 
            this.lblVendor.AutoSize = true;
            this.lblVendor.Location = new System.Drawing.Point(8, 87);
            this.lblVendor.Name = "lblVendor";
            this.lblVendor.Size = new System.Drawing.Size(44, 13);
            this.lblVendor.TabIndex = 2;
            this.lblVendor.Text = "Vendor:";
            // 
            // lblSalePrice
            // 
            this.lblSalePrice.AutoSize = true;
            this.lblSalePrice.Location = new System.Drawing.Point(6, 57);
            this.lblSalePrice.Name = "lblSalePrice";
            this.lblSalePrice.Size = new System.Drawing.Size(106, 13);
            this.lblSalePrice.TabIndex = 4;
            this.lblSalePrice.Text = "Expected Sale Price:";
            // 
            // lblPurchasePrice
            // 
            this.lblPurchasePrice.AutoSize = true;
            this.lblPurchasePrice.Location = new System.Drawing.Point(314, 27);
            this.lblPurchasePrice.Name = "lblPurchasePrice";
            this.lblPurchasePrice.Size = new System.Drawing.Size(81, 13);
            this.lblPurchasePrice.TabIndex = 3;
            this.lblPurchasePrice.Text = "Purchase price:";
            // 
            // lblUoM
            // 
            this.lblUoM.AutoSize = true;
            this.lblUoM.Location = new System.Drawing.Point(314, 57);
            this.lblUoM.Name = "lblUoM";
            this.lblUoM.Size = new System.Drawing.Size(108, 13);
            this.lblUoM.TabIndex = 1;
            this.lblUoM.Text = "Unit of Measurement:";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(6, 27);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(38, 13);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "Name:";
            // 
            // txtExpectedSalePrice
            // 
            this.txtExpectedSalePrice.Location = new System.Drawing.Point(118, 54);
            this.txtExpectedSalePrice.MaxLength = 255;
            this.txtExpectedSalePrice.Name = "txtExpectedSalePrice";
            this.txtExpectedSalePrice.Size = new System.Drawing.Size(179, 20);
            this.txtExpectedSalePrice.TabIndex = 9;
            this.txtExpectedSalePrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtExpectedSalePrice_KeyPress);
            // 
            // txtPurchasePrice
            // 
            this.txtPurchasePrice.Location = new System.Drawing.Point(428, 24);
            this.txtPurchasePrice.MaxLength = 30;
            this.txtPurchasePrice.Name = "txtPurchasePrice";
            this.txtPurchasePrice.Size = new System.Drawing.Size(178, 20);
            this.txtPurchasePrice.TabIndex = 15;
            this.txtPurchasePrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPurchasePrice_KeyPress);
            // 
            // cbDeleted
            // 
            this.cbDeleted.AutoSize = true;
            this.cbDeleted.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbDeleted.Location = new System.Drawing.Point(406, 110);
            this.cbDeleted.Name = "cbDeleted";
            this.cbDeleted.Size = new System.Drawing.Size(110, 17);
            this.cbDeleted.TabIndex = 18;
            this.cbDeleted.Text = "Is Deleted:           ";
            this.cbDeleted.UseVisualStyleBackColor = true;
            this.cbDeleted.Visible = false;
            // 
            // btClear
            // 
            this.btClear.Location = new System.Drawing.Point(531, 106);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(75, 23);
            this.btClear.TabIndex = 17;
            this.btClear.Text = "Reset";
            this.btClear.UseVisualStyleBackColor = false;
            this.btClear.Click += new System.EventHandler(this.btClear_Click);
            // 
            // gbContractorDetails
            // 
            this.gbContractorDetails.Controls.Add(this.cmbUoM);
            this.gbContractorDetails.Controls.Add(this.cmbVendor);
            this.gbContractorDetails.Controls.Add(this.btClear);
            this.gbContractorDetails.Controls.Add(this.cbDeleted);
            this.gbContractorDetails.Controls.Add(this.txtPurchasePrice);
            this.gbContractorDetails.Controls.Add(this.txtExpectedSalePrice);
            this.gbContractorDetails.Controls.Add(this.lbName);
            this.gbContractorDetails.Controls.Add(this.lblUoM);
            this.gbContractorDetails.Controls.Add(this.lblPurchasePrice);
            this.gbContractorDetails.Controls.Add(this.lblSalePrice);
            this.gbContractorDetails.Controls.Add(this.lblVendor);
            this.gbContractorDetails.Controls.Add(this.txtName);
            this.gbContractorDetails.Location = new System.Drawing.Point(58, 12);
            this.gbContractorDetails.Name = "gbContractorDetails";
            this.gbContractorDetails.Size = new System.Drawing.Size(619, 138);
            this.gbContractorDetails.TabIndex = 30;
            this.gbContractorDetails.TabStop = false;
            this.gbContractorDetails.Text = "Please specify item detail(s)";
            // 
            // cmbUoM
            // 
            this.cmbUoM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUoM.FormattingEnabled = true;
            this.cmbUoM.Location = new System.Drawing.Point(428, 57);
            this.cmbUoM.Name = "cmbUoM";
            this.cmbUoM.Size = new System.Drawing.Size(179, 21);
            this.cmbUoM.TabIndex = 20;
            // 
            // cmbVendor
            // 
            this.cmbVendor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVendor.FormattingEnabled = true;
            this.cmbVendor.Location = new System.Drawing.Point(118, 80);
            this.cmbVendor.Name = "cmbVendor";
            this.cmbVendor.Size = new System.Drawing.Size(179, 21);
            this.cmbVendor.TabIndex = 19;
            // 
            // lbFilter
            // 
            this.lbFilter.AutoSize = true;
            this.lbFilter.Location = new System.Drawing.Point(69, 159);
            this.lbFilter.Name = "lbFilter";
            this.lbFilter.Size = new System.Drawing.Size(72, 13);
            this.lbFilter.TabIndex = 34;
            this.lbFilter.Text = "Filter by name";
            // 
            // txtNameFilter
            // 
            this.txtNameFilter.Location = new System.Drawing.Point(147, 156);
            this.txtNameFilter.MaxLength = 30;
            this.txtNameFilter.Name = "txtNameFilter";
            this.txtNameFilter.Size = new System.Drawing.Size(208, 20);
            this.txtNameFilter.TabIndex = 32;
            this.txtNameFilter.TextChanged += new System.EventHandler(this.txtNameFilter_TextChanged);
            // 
            // cbShowDeleted
            // 
            this.cbShowDeleted.AutoSize = true;
            this.cbShowDeleted.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbShowDeleted.Location = new System.Drawing.Point(361, 159);
            this.cbShowDeleted.Name = "cbShowDeleted";
            this.cbShowDeleted.Size = new System.Drawing.Size(93, 17);
            this.cbShowDeleted.TabIndex = 35;
            this.cbShowDeleted.Text = "Show Deleted";
            this.cbShowDeleted.UseVisualStyleBackColor = false;
            this.cbShowDeleted.Visible = false;
            // 
            // dgItem
            // 
            this.dgItem.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LemonChiffon;
            this.dgItem.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clID,
            this.clName,
            this.clPurchasePrice,
            this.clSalePrice,
            this.clUoMID,
            this.clUnit,
            this.clVendorID,
            this.clVendor,
            this.clIsDeleted});
            this.dgItem.Location = new System.Drawing.Point(13, 220);
            this.dgItem.MultiSelect = false;
            this.dgItem.Name = "dgItem";
            this.dgItem.ReadOnly = true;
            this.dgItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgItem.Size = new System.Drawing.Size(673, 223);
            this.dgItem.TabIndex = 40;
            this.dgItem.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgItem_DataBindingComplete);
            // 
            // clID
            // 
            this.clID.DataPropertyName = "Type_ID";
            this.clID.HeaderText = "ID";
            this.clID.Name = "clID";
            this.clID.ReadOnly = true;
            this.clID.Visible = false;
            // 
            // clName
            // 
            this.clName.DataPropertyName = "ItemType_Name";
            this.clName.HeaderText = "Name";
            this.clName.Name = "clName";
            this.clName.ReadOnly = true;
            // 
            // clPurchasePrice
            // 
            this.clPurchasePrice.DataPropertyName = "Price";
            this.clPurchasePrice.HeaderText = "Purchase Price";
            this.clPurchasePrice.Name = "clPurchasePrice";
            this.clPurchasePrice.ReadOnly = true;
            this.clPurchasePrice.Width = 150;
            // 
            // clSalePrice
            // 
            this.clSalePrice.DataPropertyName = "Sale_Price";
            this.clSalePrice.FillWeight = 250F;
            this.clSalePrice.HeaderText = "Sale Price";
            this.clSalePrice.Name = "clSalePrice";
            this.clSalePrice.ReadOnly = true;
            // 
            // clUoMID
            // 
            this.clUoMID.DataPropertyName = "UoM_ID";
            this.clUoMID.HeaderText = "UoM ID";
            this.clUoMID.Name = "clUoMID";
            this.clUoMID.ReadOnly = true;
            this.clUoMID.Visible = false;
            // 
            // clUnit
            // 
            this.clUnit.DataPropertyName = "UoM_Name";
            this.clUnit.HeaderText = "Unit";
            this.clUnit.Name = "clUnit";
            this.clUnit.ReadOnly = true;
            // 
            // clVendorID
            // 
            this.clVendorID.DataPropertyName = "Vendor_ID";
            this.clVendorID.HeaderText = "Vendor ID";
            this.clVendorID.Name = "clVendorID";
            this.clVendorID.ReadOnly = true;
            this.clVendorID.Visible = false;
            // 
            // clVendor
            // 
            this.clVendor.DataPropertyName = "vendor_name";
            this.clVendor.HeaderText = "Vendor";
            this.clVendor.Name = "clVendor";
            this.clVendor.ReadOnly = true;
            // 
            // clIsDeleted
            // 
            this.clIsDeleted.DataPropertyName = "Is_Deleted";
            this.clIsDeleted.HeaderText = "IsDeleted";
            this.clIsDeleted.Name = "clIsDeleted";
            this.clIsDeleted.ReadOnly = true;
            this.clIsDeleted.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(589, 453);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(97, 23);
            this.btnCancel.TabIndex = 42;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btSaveItems
            // 
            this.btSaveItems.Location = new System.Drawing.Point(486, 453);
            this.btSaveItems.Name = "btSaveItems";
            this.btSaveItems.Size = new System.Drawing.Size(97, 23);
            this.btSaveItems.TabIndex = 41;
            this.btSaveItems.Text = "Save Changes";
            this.btSaveItems.UseVisualStyleBackColor = false;
            this.btSaveItems.Click += new System.EventHandler(this.btSaveItems_Click);
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.Enabled = false;
            this.btnDeleteItem.Location = new System.Drawing.Point(220, 191);
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteItem.TabIndex = 45;
            this.btnDeleteItem.Text = "Delete";
            this.btnDeleteItem.UseVisualStyleBackColor = false;
            this.btnDeleteItem.Click += new System.EventHandler(this.btnDeleteItem_Click);
            // 
            // btUpdateItem
            // 
            this.btUpdateItem.Enabled = false;
            this.btUpdateItem.Location = new System.Drawing.Point(139, 191);
            this.btUpdateItem.Name = "btUpdateItem";
            this.btUpdateItem.Size = new System.Drawing.Size(75, 23);
            this.btUpdateItem.TabIndex = 44;
            this.btUpdateItem.Text = "Update";
            this.btUpdateItem.UseVisualStyleBackColor = false;
            this.btUpdateItem.Click += new System.EventHandler(this.btUpdateItem_Click);
            // 
            // btAddNewItem
            // 
            this.btAddNewItem.Location = new System.Drawing.Point(58, 191);
            this.btAddNewItem.Name = "btAddNewItem";
            this.btAddNewItem.Size = new System.Drawing.Size(75, 23);
            this.btAddNewItem.TabIndex = 43;
            this.btAddNewItem.Text = "Add";
            this.btAddNewItem.UseVisualStyleBackColor = false;
            this.btAddNewItem.Click += new System.EventHandler(this.btAddNewItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Shop_Management_Solution.Properties.Resources.Misc_Box_icon1;
            this.pictureBox1.Location = new System.Drawing.Point(6, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(46, 51);
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
            // 
            // frmItemManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(694, 495);
            this.Controls.Add(this.btnDeleteItem);
            this.Controls.Add(this.btUpdateItem);
            this.Controls.Add(this.btAddNewItem);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btSaveItems);
            this.Controls.Add(this.dgItem);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cbShowDeleted);
            this.Controls.Add(this.txtNameFilter);
            this.Controls.Add(this.lbFilter);
            this.Controls.Add(this.gbContractorDetails);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmItemManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Item";
            this.Load += new System.EventHandler(this.frmItemManagement_Load);
            this.gbContractorDetails.ResumeLayout(false);
            this.gbContractorDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblVendor;
        private System.Windows.Forms.Label lblSalePrice;
        private System.Windows.Forms.Label lblPurchasePrice;
        private System.Windows.Forms.Label lblUoM;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TextBox txtExpectedSalePrice;
        private System.Windows.Forms.TextBox txtPurchasePrice;
        private System.Windows.Forms.CheckBox cbDeleted;
        private System.Windows.Forms.Button btClear;
        private System.Windows.Forms.GroupBox gbContractorDetails;
        private System.Windows.Forms.Label lbFilter;
        private System.Windows.Forms.TextBox txtNameFilter;
        private System.Windows.Forms.CheckBox cbShowDeleted;
        private System.Windows.Forms.DataGridView dgItem;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btSaveItems;
        private System.Windows.Forms.Button btnDeleteItem;
        private System.Windows.Forms.Button btUpdateItem;
        private System.Windows.Forms.Button btAddNewItem;
        private System.Windows.Forms.ComboBox cmbUoM;
        private System.Windows.Forms.ComboBox cmbVendor;
        private System.Windows.Forms.DataGridViewTextBoxColumn clID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clPurchasePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSalePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clUoMID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn clVendorID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clVendor;
        private System.Windows.Forms.DataGridViewTextBoxColumn clIsDeleted;

    }
}