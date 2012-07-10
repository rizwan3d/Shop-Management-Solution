namespace Shop_Management_Solution
{
    partial class frmVendorManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVendorManagement));
            this.gbContractorDetails = new System.Windows.Forms.GroupBox();
            this.txtPostCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btClear = new System.Windows.Forms.Button();
            this.cbDeleted = new System.Windows.Forms.CheckBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtMobileNo = new System.Windows.Forms.TextBox();
            this.txtPhoneNo = new System.Windows.Forms.TextBox();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.lbName = new System.Windows.Forms.Label();
            this.lbEmail = new System.Windows.Forms.Label();
            this.lbMobile = new System.Windows.Forms.Label();
            this.lbLocation = new System.Windows.Forms.Label();
            this.lbPhone = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cbShowDeleted = new System.Windows.Forms.CheckBox();
            this.btUpdateVendor = new System.Windows.Forms.Button();
            this.btAddNewVendor = new System.Windows.Forms.Button();
            this.txtNameFilter = new System.Windows.Forms.TextBox();
            this.lbFilter = new System.Windows.Forms.Label();
            this.btSaveVendors = new System.Windows.Forms.Button();
            this.dgVendors = new System.Windows.Forms.DataGridView();
            this.clName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clMobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clPostCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clIsDeleted = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnDeleteVendor = new System.Windows.Forms.Button();
            this.gbContractorDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgVendors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbContractorDetails
            // 
            this.gbContractorDetails.Controls.Add(this.txtPostCode);
            this.gbContractorDetails.Controls.Add(this.label1);
            this.gbContractorDetails.Controls.Add(this.btClear);
            this.gbContractorDetails.Controls.Add(this.cbDeleted);
            this.gbContractorDetails.Controls.Add(this.txtEmail);
            this.gbContractorDetails.Controls.Add(this.txtMobileNo);
            this.gbContractorDetails.Controls.Add(this.txtPhoneNo);
            this.gbContractorDetails.Controls.Add(this.txtLocation);
            this.gbContractorDetails.Controls.Add(this.lbName);
            this.gbContractorDetails.Controls.Add(this.lbEmail);
            this.gbContractorDetails.Controls.Add(this.lbMobile);
            this.gbContractorDetails.Controls.Add(this.lbLocation);
            this.gbContractorDetails.Controls.Add(this.lbPhone);
            this.gbContractorDetails.Controls.Add(this.txtName);
            this.gbContractorDetails.Location = new System.Drawing.Point(63, 23);
            this.gbContractorDetails.Name = "gbContractorDetails";
            this.gbContractorDetails.Size = new System.Drawing.Size(628, 131);
            this.gbContractorDetails.TabIndex = 2;
            this.gbContractorDetails.TabStop = false;
            this.gbContractorDetails.Text = "Please specify contractor detail(s)";
            // 
            // txtPostCode
            // 
            this.txtPostCode.Location = new System.Drawing.Point(406, 84);
            this.txtPostCode.MaxLength = 100;
            this.txtPostCode.Name = "txtPostCode";
            this.txtPostCode.Size = new System.Drawing.Size(200, 20);
            this.txtPostCode.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(314, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Post Code:";
            // 
            // btClear
            // 
            this.btClear.Location = new System.Drawing.Point(531, 106);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(75, 23);
            this.btClear.TabIndex = 17;
            this.btClear.Text = "Reset";
            this.btClear.UseVisualStyleBackColor = true;
            this.btClear.Click += new System.EventHandler(this.btClear_Click);
            // 
            // cbDeleted
            // 
            this.cbDeleted.AutoSize = true;
            this.cbDeleted.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbDeleted.Location = new System.Drawing.Point(9, 106);
            this.cbDeleted.Name = "cbDeleted";
            this.cbDeleted.Size = new System.Drawing.Size(110, 17);
            this.cbDeleted.TabIndex = 18;
            this.cbDeleted.Text = "Is Deleted:           ";
            this.cbDeleted.UseVisualStyleBackColor = true;
            this.cbDeleted.Visible = false;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(406, 54);
            this.txtEmail.MaxLength = 100;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 20);
            this.txtEmail.TabIndex = 16;
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.Location = new System.Drawing.Point(406, 24);
            this.txtMobileNo.MaxLength = 30;
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Size = new System.Drawing.Size(200, 20);
            this.txtMobileNo.TabIndex = 15;
            // 
            // txtPhoneNo
            // 
            this.txtPhoneNo.Location = new System.Drawing.Point(89, 84);
            this.txtPhoneNo.MaxLength = 30;
            this.txtPhoneNo.Name = "txtPhoneNo";
            this.txtPhoneNo.Size = new System.Drawing.Size(208, 20);
            this.txtPhoneNo.TabIndex = 14;
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(89, 54);
            this.txtLocation.MaxLength = 255;
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(208, 20);
            this.txtLocation.TabIndex = 9;
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
            // lbEmail
            // 
            this.lbEmail.AutoSize = true;
            this.lbEmail.Location = new System.Drawing.Point(314, 57);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(38, 13);
            this.lbEmail.TabIndex = 1;
            this.lbEmail.Text = "E-mail:";
            // 
            // lbMobile
            // 
            this.lbMobile.AutoSize = true;
            this.lbMobile.Location = new System.Drawing.Point(314, 27);
            this.lbMobile.Name = "lbMobile";
            this.lbMobile.Size = new System.Drawing.Size(81, 13);
            this.lbMobile.TabIndex = 3;
            this.lbMobile.Text = "Mobile Number:";
            // 
            // lbLocation
            // 
            this.lbLocation.AutoSize = true;
            this.lbLocation.Location = new System.Drawing.Point(6, 57);
            this.lbLocation.Name = "lbLocation";
            this.lbLocation.Size = new System.Drawing.Size(51, 13);
            this.lbLocation.TabIndex = 4;
            this.lbLocation.Text = "Location:";
            // 
            // lbPhone
            // 
            this.lbPhone.AutoSize = true;
            this.lbPhone.Location = new System.Drawing.Point(8, 87);
            this.lbPhone.Name = "lbPhone";
            this.lbPhone.Size = new System.Drawing.Size(81, 13);
            this.lbPhone.TabIndex = 2;
            this.lbPhone.Text = "Phone Number:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(89, 24);
            this.txtName.MaxLength = 255;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(208, 20);
            this.txtName.TabIndex = 8;
            // 
            // cbShowDeleted
            // 
            this.cbShowDeleted.AutoSize = true;
            this.cbShowDeleted.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbShowDeleted.Location = new System.Drawing.Point(366, 160);
            this.cbShowDeleted.Name = "cbShowDeleted";
            this.cbShowDeleted.Size = new System.Drawing.Size(93, 17);
            this.cbShowDeleted.TabIndex = 23;
            this.cbShowDeleted.Text = "Show Deleted";
            this.cbShowDeleted.UseVisualStyleBackColor = true;
            this.cbShowDeleted.Visible = false;
            this.cbShowDeleted.CheckStateChanged += new System.EventHandler(this.cbShowDeleted_CheckStateChanged);
            // 
            // btUpdateVendor
            // 
            this.btUpdateVendor.Enabled = false;
            this.btUpdateVendor.Location = new System.Drawing.Point(144, 189);
            this.btUpdateVendor.Name = "btUpdateVendor";
            this.btUpdateVendor.Size = new System.Drawing.Size(75, 23);
            this.btUpdateVendor.TabIndex = 21;
            this.btUpdateVendor.Text = "Update";
            this.btUpdateVendor.UseVisualStyleBackColor = true;
            this.btUpdateVendor.Click += new System.EventHandler(this.btUpdateVendor_Click);
            // 
            // btAddNewVendor
            // 
            this.btAddNewVendor.Location = new System.Drawing.Point(63, 189);
            this.btAddNewVendor.Name = "btAddNewVendor";
            this.btAddNewVendor.Size = new System.Drawing.Size(75, 23);
            this.btAddNewVendor.TabIndex = 19;
            this.btAddNewVendor.Text = "Add";
            this.btAddNewVendor.UseVisualStyleBackColor = true;
            this.btAddNewVendor.Click += new System.EventHandler(this.btAddNewVendor_Click);
            // 
            // txtNameFilter
            // 
            this.txtNameFilter.Location = new System.Drawing.Point(152, 157);
            this.txtNameFilter.MaxLength = 30;
            this.txtNameFilter.Name = "txtNameFilter";
            this.txtNameFilter.Size = new System.Drawing.Size(208, 20);
            this.txtNameFilter.TabIndex = 20;
            this.txtNameFilter.TextChanged += new System.EventHandler(this.txtNameFilter_TextChanged);
            // 
            // lbFilter
            // 
            this.lbFilter.AutoSize = true;
            this.lbFilter.Location = new System.Drawing.Point(74, 160);
            this.lbFilter.Name = "lbFilter";
            this.lbFilter.Size = new System.Drawing.Size(72, 13);
            this.lbFilter.TabIndex = 22;
            this.lbFilter.Text = "Filter by name";
            // 
            // btSaveVendors
            // 
            this.btSaveVendors.Location = new System.Drawing.Point(491, 458);
            this.btSaveVendors.Name = "btSaveVendors";
            this.btSaveVendors.Size = new System.Drawing.Size(97, 23);
            this.btSaveVendors.TabIndex = 25;
            this.btSaveVendors.Text = "Save Changes";
            this.btSaveVendors.UseVisualStyleBackColor = true;
            this.btSaveVendors.Click += new System.EventHandler(this.btSaveVendors_Click);
            // 
            // dgVendors
            // 
            this.dgVendors.AllowUserToAddRows = false;
            this.dgVendors.AllowUserToResizeRows = false;
            this.dgVendors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgVendors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clName,
            this.clId,
            this.clEmail,
            this.clPhone,
            this.clMobile,
            this.clLocation,
            this.clPostCode,
            this.clIsDeleted});
            this.dgVendors.Location = new System.Drawing.Point(12, 218);
            this.dgVendors.Name = "dgVendors";
            this.dgVendors.ReadOnly = true;
            this.dgVendors.RowHeadersVisible = false;
            this.dgVendors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgVendors.Size = new System.Drawing.Size(679, 234);
            this.dgVendors.TabIndex = 24;
            this.dgVendors.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgVendors_CellDoubleClick);
            this.dgVendors.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgVendors_DataBindingComplete);
            // 
            // clName
            // 
            this.clName.DataPropertyName = "Name";
            this.clName.HeaderText = "Name";
            this.clName.MaxInputLength = 255;
            this.clName.Name = "clName";
            this.clName.ReadOnly = true;
            // 
            // clId
            // 
            this.clId.DataPropertyName = "ID";
            this.clId.HeaderText = "ID";
            this.clId.Name = "clId";
            this.clId.ReadOnly = true;
            this.clId.Visible = false;
            // 
            // clEmail
            // 
            this.clEmail.DataPropertyName = "E-mail";
            this.clEmail.HeaderText = "E-mail";
            this.clEmail.MaxInputLength = 100;
            this.clEmail.Name = "clEmail";
            this.clEmail.ReadOnly = true;
            // 
            // clPhone
            // 
            this.clPhone.DataPropertyName = "Phone";
            this.clPhone.HeaderText = "Phone";
            this.clPhone.MaxInputLength = 30;
            this.clPhone.Name = "clPhone";
            this.clPhone.ReadOnly = true;
            // 
            // clMobile
            // 
            this.clMobile.DataPropertyName = "Mobile";
            this.clMobile.HeaderText = "Mobile";
            this.clMobile.MaxInputLength = 30;
            this.clMobile.Name = "clMobile";
            this.clMobile.ReadOnly = true;
            // 
            // clLocation
            // 
            this.clLocation.DataPropertyName = "Location";
            this.clLocation.HeaderText = "Location";
            this.clLocation.MaxInputLength = 255;
            this.clLocation.Name = "clLocation";
            this.clLocation.ReadOnly = true;
            // 
            // clPostCode
            // 
            this.clPostCode.DataPropertyName = "PostCode";
            this.clPostCode.HeaderText = "Post Code";
            this.clPostCode.Name = "clPostCode";
            this.clPostCode.ReadOnly = true;
            this.clPostCode.Width = 90;
            // 
            // clIsDeleted
            // 
            this.clIsDeleted.DataPropertyName = "IsDeleted";
            this.clIsDeleted.FalseValue = "0";
            this.clIsDeleted.HeaderText = "Is Deleted?";
            this.clIsDeleted.IndeterminateValue = "0";
            this.clIsDeleted.Name = "clIsDeleted";
            this.clIsDeleted.ReadOnly = true;
            this.clIsDeleted.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clIsDeleted.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clIsDeleted.TrueValue = "1";
            this.clIsDeleted.Visible = false;
            this.clIsDeleted.Width = 80;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(594, 458);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(97, 23);
            this.btnCancel.TabIndex = 27;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Shop_Management_Solution.Properties.Resources.industry_icon;
            this.pictureBox1.Location = new System.Drawing.Point(11, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(46, 51);
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // btnDeleteVendor
            // 
            this.btnDeleteVendor.Enabled = false;
            this.btnDeleteVendor.Location = new System.Drawing.Point(225, 189);
            this.btnDeleteVendor.Name = "btnDeleteVendor";
            this.btnDeleteVendor.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteVendor.TabIndex = 29;
            this.btnDeleteVendor.Text = "Delete";
            this.btnDeleteVendor.UseVisualStyleBackColor = true;
            // 
            // frmVendorManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 487);
            this.Controls.Add(this.btnDeleteVendor);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btSaveVendors);
            this.Controls.Add(this.dgVendors);
            this.Controls.Add(this.cbShowDeleted);
            this.Controls.Add(this.btUpdateVendor);
            this.Controls.Add(this.btAddNewVendor);
            this.Controls.Add(this.txtNameFilter);
            this.Controls.Add(this.lbFilter);
            this.Controls.Add(this.gbContractorDetails);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVendorManagement";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Vendor";
            this.Load += new System.EventHandler(this.frmVendorManagement_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmVendorManagement_KeyDown);
            this.gbContractorDetails.ResumeLayout(false);
            this.gbContractorDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgVendors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbContractorDetails;
        private System.Windows.Forms.Button btClear;
        private System.Windows.Forms.CheckBox cbDeleted;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtMobileNo;
        private System.Windows.Forms.TextBox txtPhoneNo;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.Label lbMobile;
        private System.Windows.Forms.Label lbLocation;
        private System.Windows.Forms.Label lbPhone;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.CheckBox cbShowDeleted;
        private System.Windows.Forms.Button btUpdateVendor;
        private System.Windows.Forms.Button btAddNewVendor;
        private System.Windows.Forms.TextBox txtNameFilter;
        private System.Windows.Forms.Label lbFilter;
        private System.Windows.Forms.Button btSaveVendors;
        private System.Windows.Forms.DataGridView dgVendors;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn clPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn clMobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn clLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn clPostCode;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clIsDeleted;
        private System.Windows.Forms.Button btnDeleteVendor;
        private System.Windows.Forms.TextBox txtPostCode;
        private System.Windows.Forms.Label label1;
    }
}