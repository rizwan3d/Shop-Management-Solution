﻿namespace Shop_Management_Solution
{
    partial class frmContractorManagement
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
            this.lbName = new System.Windows.Forms.Label();
            this.lbEmail = new System.Windows.Forms.Label();
            this.lbPhone = new System.Windows.Forms.Label();
            this.lbMobile = new System.Windows.Forms.Label();
            this.lbAddrLine1 = new System.Windows.Forms.Label();
            this.lbAddrLine2 = new System.Windows.Forms.Label();
            this.lbPostCode = new System.Windows.Forms.Label();
            this.lbCountry = new System.Windows.Forms.Label();
            this.gbContractorDetails = new System.Windows.Forms.GroupBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.lbCity = new System.Windows.Forms.Label();
            this.btClear = new System.Windows.Forms.Button();
            this.cbDeleted = new System.Windows.Forms.CheckBox();
            this.combCountries = new System.Windows.Forms.ComboBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtMobileNo = new System.Windows.Forms.TextBox();
            this.txtPhoneNo = new System.Windows.Forms.TextBox();
            this.txtPostCode = new System.Windows.Forms.TextBox();
            this.txtAddrLine2 = new System.Windows.Forms.TextBox();
            this.txtAddrLine1 = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btAddNewContractor = new System.Windows.Forms.Button();
            this.lbFilter = new System.Windows.Forms.Label();
            this.txtNameFilter = new System.Windows.Forms.TextBox();
            this.dgContractors = new System.Windows.Forms.DataGridView();
            this.btUpdateContractor = new System.Windows.Forms.Button();
            this.btSaveContractors = new System.Windows.Forms.Button();
            this.clName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clMobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clAddressLine1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clAddressLine2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clPostCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clCountry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clCountryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clCity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clIsDeleted = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cbShowDeleted = new System.Windows.Forms.CheckBox();
            this.gbContractorDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgContractors)).BeginInit();
            this.SuspendLayout();
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(6, 27);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(35, 13);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "Name";
            // 
            // lbEmail
            // 
            this.lbEmail.AutoSize = true;
            this.lbEmail.Location = new System.Drawing.Point(300, 87);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(35, 13);
            this.lbEmail.TabIndex = 1;
            this.lbEmail.Text = "E-mail";
            // 
            // lbPhone
            // 
            this.lbPhone.AutoSize = true;
            this.lbPhone.Location = new System.Drawing.Point(300, 27);
            this.lbPhone.Name = "lbPhone";
            this.lbPhone.Size = new System.Drawing.Size(78, 13);
            this.lbPhone.TabIndex = 2;
            this.lbPhone.Text = "Phone Number";
            // 
            // lbMobile
            // 
            this.lbMobile.AutoSize = true;
            this.lbMobile.Location = new System.Drawing.Point(300, 57);
            this.lbMobile.Name = "lbMobile";
            this.lbMobile.Size = new System.Drawing.Size(78, 13);
            this.lbMobile.TabIndex = 3;
            this.lbMobile.Text = "Mobile Number";
            // 
            // lbAddrLine1
            // 
            this.lbAddrLine1.AutoSize = true;
            this.lbAddrLine1.Location = new System.Drawing.Point(6, 57);
            this.lbAddrLine1.Name = "lbAddrLine1";
            this.lbAddrLine1.Size = new System.Drawing.Size(72, 13);
            this.lbAddrLine1.TabIndex = 4;
            this.lbAddrLine1.Text = "Addres Line 1";
            // 
            // lbAddrLine2
            // 
            this.lbAddrLine2.AutoSize = true;
            this.lbAddrLine2.Location = new System.Drawing.Point(6, 87);
            this.lbAddrLine2.Name = "lbAddrLine2";
            this.lbAddrLine2.Size = new System.Drawing.Size(72, 13);
            this.lbAddrLine2.TabIndex = 5;
            this.lbAddrLine2.Text = "Addres Line 2";
            // 
            // lbPostCode
            // 
            this.lbPostCode.AutoSize = true;
            this.lbPostCode.Location = new System.Drawing.Point(6, 117);
            this.lbPostCode.Name = "lbPostCode";
            this.lbPostCode.Size = new System.Drawing.Size(56, 13);
            this.lbPostCode.TabIndex = 6;
            this.lbPostCode.Text = "Post Code";
            // 
            // lbCountry
            // 
            this.lbCountry.AutoSize = true;
            this.lbCountry.Location = new System.Drawing.Point(6, 177);
            this.lbCountry.Name = "lbCountry";
            this.lbCountry.Size = new System.Drawing.Size(43, 13);
            this.lbCountry.TabIndex = 7;
            this.lbCountry.Text = "Country";
            // 
            // gbContractorDetails
            // 
            this.gbContractorDetails.Controls.Add(this.txtCity);
            this.gbContractorDetails.Controls.Add(this.lbCity);
            this.gbContractorDetails.Controls.Add(this.btClear);
            this.gbContractorDetails.Controls.Add(this.cbDeleted);
            this.gbContractorDetails.Controls.Add(this.combCountries);
            this.gbContractorDetails.Controls.Add(this.txtEmail);
            this.gbContractorDetails.Controls.Add(this.txtMobileNo);
            this.gbContractorDetails.Controls.Add(this.txtPhoneNo);
            this.gbContractorDetails.Controls.Add(this.txtPostCode);
            this.gbContractorDetails.Controls.Add(this.txtAddrLine2);
            this.gbContractorDetails.Controls.Add(this.txtAddrLine1);
            this.gbContractorDetails.Controls.Add(this.lbName);
            this.gbContractorDetails.Controls.Add(this.lbCountry);
            this.gbContractorDetails.Controls.Add(this.lbEmail);
            this.gbContractorDetails.Controls.Add(this.lbMobile);
            this.gbContractorDetails.Controls.Add(this.lbAddrLine1);
            this.gbContractorDetails.Controls.Add(this.lbPhone);
            this.gbContractorDetails.Controls.Add(this.lbPostCode);
            this.gbContractorDetails.Controls.Add(this.lbAddrLine2);
            this.gbContractorDetails.Controls.Add(this.txtName);
            this.gbContractorDetails.Enabled = false;
            this.gbContractorDetails.Location = new System.Drawing.Point(12, 12);
            this.gbContractorDetails.Name = "gbContractorDetails";
            this.gbContractorDetails.Size = new System.Drawing.Size(545, 202);
            this.gbContractorDetails.TabIndex = 1;
            this.gbContractorDetails.TabStop = false;
            this.gbContractorDetails.Text = "Contractor details";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(77, 144);
            this.txtCity.MaxLength = 100;
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(146, 20);
            this.txtCity.TabIndex = 12;
            // 
            // lbCity
            // 
            this.lbCity.AutoSize = true;
            this.lbCity.Location = new System.Drawing.Point(6, 147);
            this.lbCity.Name = "lbCity";
            this.lbCity.Size = new System.Drawing.Size(56, 13);
            this.lbCity.TabIndex = 19;
            this.lbCity.Text = "City/Town";
            // 
            // btClear
            // 
            this.btClear.Location = new System.Drawing.Point(453, 168);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(75, 23);
            this.btClear.TabIndex = 17;
            this.btClear.Text = "Clear";
            this.btClear.UseVisualStyleBackColor = true;
            this.btClear.Click += new System.EventHandler(this.btClearContractor_Click);
            // 
            // cbDeleted
            // 
            this.cbDeleted.AutoSize = true;
            this.cbDeleted.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbDeleted.Location = new System.Drawing.Point(299, 116);
            this.cbDeleted.Name = "cbDeleted";
            this.cbDeleted.Size = new System.Drawing.Size(101, 17);
            this.cbDeleted.TabIndex = 18;
            this.cbDeleted.Text = "Is Deleted         ";
            this.cbDeleted.UseVisualStyleBackColor = true;
            // 
            // combCountries
            // 
            this.combCountries.DisplayMember = "CountryName";
            this.combCountries.FormattingEnabled = true;
            this.combCountries.Location = new System.Drawing.Point(77, 174);
            this.combCountries.Name = "combCountries";
            this.combCountries.Size = new System.Drawing.Size(121, 21);
            this.combCountries.TabIndex = 13;
            this.combCountries.ValueMember = "ID";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(382, 84);
            this.txtEmail.MaxLength = 100;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(146, 20);
            this.txtEmail.TabIndex = 16;
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.Location = new System.Drawing.Point(382, 54);
            this.txtMobileNo.MaxLength = 30;
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Size = new System.Drawing.Size(146, 20);
            this.txtMobileNo.TabIndex = 15;
            // 
            // txtPhoneNo
            // 
            this.txtPhoneNo.Location = new System.Drawing.Point(382, 24);
            this.txtPhoneNo.MaxLength = 30;
            this.txtPhoneNo.Name = "txtPhoneNo";
            this.txtPhoneNo.Size = new System.Drawing.Size(146, 20);
            this.txtPhoneNo.TabIndex = 14;
            // 
            // txtPostCode
            // 
            this.txtPostCode.Location = new System.Drawing.Point(77, 114);
            this.txtPostCode.MaxLength = 30;
            this.txtPostCode.Name = "txtPostCode";
            this.txtPostCode.Size = new System.Drawing.Size(100, 20);
            this.txtPostCode.TabIndex = 11;
            // 
            // txtAddrLine2
            // 
            this.txtAddrLine2.Location = new System.Drawing.Point(77, 84);
            this.txtAddrLine2.MaxLength = 255;
            this.txtAddrLine2.Name = "txtAddrLine2";
            this.txtAddrLine2.Size = new System.Drawing.Size(208, 20);
            this.txtAddrLine2.TabIndex = 10;
            // 
            // txtAddrLine1
            // 
            this.txtAddrLine1.Location = new System.Drawing.Point(77, 54);
            this.txtAddrLine1.MaxLength = 255;
            this.txtAddrLine1.Name = "txtAddrLine1";
            this.txtAddrLine1.Size = new System.Drawing.Size(208, 20);
            this.txtAddrLine1.TabIndex = 9;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(77, 24);
            this.txtName.MaxLength = 255;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(208, 20);
            this.txtName.TabIndex = 8;
            // 
            // btAddNewContractor
            // 
            this.btAddNewContractor.Location = new System.Drawing.Point(394, 231);
            this.btAddNewContractor.Name = "btAddNewContractor";
            this.btAddNewContractor.Size = new System.Drawing.Size(75, 23);
            this.btAddNewContractor.TabIndex = 2;
            this.btAddNewContractor.Text = "Add New";
            this.btAddNewContractor.UseVisualStyleBackColor = true;
            this.btAddNewContractor.Click += new System.EventHandler(this.btAddNew_Click);
            // 
            // lbFilter
            // 
            this.lbFilter.AutoSize = true;
            this.lbFilter.Location = new System.Drawing.Point(82, 268);
            this.lbFilter.Name = "lbFilter";
            this.lbFilter.Size = new System.Drawing.Size(72, 13);
            this.lbFilter.TabIndex = 9;
            this.lbFilter.Text = "Filter by name";
            // 
            // txtNameFilter
            // 
            this.txtNameFilter.Location = new System.Drawing.Point(160, 265);
            this.txtNameFilter.MaxLength = 30;
            this.txtNameFilter.Name = "txtNameFilter";
            this.txtNameFilter.Size = new System.Drawing.Size(146, 20);
            this.txtNameFilter.TabIndex = 4;
            this.txtNameFilter.TextChanged += new System.EventHandler(this.txtNameFilter_TextChanged);
            // 
            // dgContractors
            // 
            this.dgContractors.AllowUserToAddRows = false;
            this.dgContractors.AllowUserToResizeRows = false;
            this.dgContractors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgContractors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clName,
            this.clId,
            this.clEmail,
            this.clPhone,
            this.clMobile,
            this.clAddressLine1,
            this.clAddressLine2,
            this.clPostCode,
            this.clCountry,
            this.clCountryName,
            this.clCity,
            this.clIsDeleted});
            this.dgContractors.Location = new System.Drawing.Point(0, 291);
            this.dgContractors.Name = "dgContractors";
            this.dgContractors.ReadOnly = true;
            this.dgContractors.RowHeadersVisible = false;
            this.dgContractors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgContractors.Size = new System.Drawing.Size(964, 234);
            this.dgContractors.TabIndex = 15;
            this.dgContractors.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgContractors_CellDoubleClick);
            // 
            // btUpdateContractor
            // 
            this.btUpdateContractor.Enabled = false;
            this.btUpdateContractor.Location = new System.Drawing.Point(475, 231);
            this.btUpdateContractor.Name = "btUpdateContractor";
            this.btUpdateContractor.Size = new System.Drawing.Size(75, 23);
            this.btUpdateContractor.TabIndex = 4;
            this.btUpdateContractor.Text = "Update";
            this.btUpdateContractor.UseVisualStyleBackColor = true;
            this.btUpdateContractor.Click += new System.EventHandler(this.btUpdateContractor_Click);
            // 
            // btSaveContractors
            // 
            this.btSaveContractors.Location = new System.Drawing.Point(552, 531);
            this.btSaveContractors.Name = "btSaveContractors";
            this.btSaveContractors.Size = new System.Drawing.Size(97, 23);
            this.btSaveContractors.TabIndex = 17;
            this.btSaveContractors.Text = "Save Changes";
            this.btSaveContractors.UseVisualStyleBackColor = true;
            this.btSaveContractors.Click += new System.EventHandler(this.btSaveContractors_Click);
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
            // clAddressLine1
            // 
            this.clAddressLine1.DataPropertyName = "AddressLine1";
            this.clAddressLine1.HeaderText = "Address line 1";
            this.clAddressLine1.MaxInputLength = 255;
            this.clAddressLine1.Name = "clAddressLine1";
            this.clAddressLine1.ReadOnly = true;
            // 
            // clAddressLine2
            // 
            this.clAddressLine2.DataPropertyName = "AddressLine2";
            this.clAddressLine2.HeaderText = "Address line 2";
            this.clAddressLine2.MaxInputLength = 255;
            this.clAddressLine2.Name = "clAddressLine2";
            this.clAddressLine2.ReadOnly = true;
            // 
            // clPostCode
            // 
            this.clPostCode.DataPropertyName = "PostCode";
            this.clPostCode.HeaderText = "Post code";
            this.clPostCode.MaxInputLength = 30;
            this.clPostCode.Name = "clPostCode";
            this.clPostCode.ReadOnly = true;
            // 
            // clCountry
            // 
            this.clCountry.DataPropertyName = "Country";
            this.clCountry.HeaderText = "Country";
            this.clCountry.Name = "clCountry";
            this.clCountry.ReadOnly = true;
            this.clCountry.Visible = false;
            // 
            // clCountryName
            // 
            this.clCountryName.DataPropertyName = "CountryName";
            this.clCountryName.HeaderText = "Country";
            this.clCountryName.Name = "clCountryName";
            this.clCountryName.ReadOnly = true;
            // 
            // clCity
            // 
            this.clCity.DataPropertyName = "City";
            this.clCity.HeaderText = "City";
            this.clCity.Name = "clCity";
            this.clCity.ReadOnly = true;
            // 
            // clIsDeleted
            // 
            this.clIsDeleted.DataPropertyName = "IsDeleted";
            this.clIsDeleted.FalseValue = "0";
            this.clIsDeleted.HeaderText = "Is deleted";
            this.clIsDeleted.IndeterminateValue = "0";
            this.clIsDeleted.Name = "clIsDeleted";
            this.clIsDeleted.ReadOnly = true;
            this.clIsDeleted.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clIsDeleted.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clIsDeleted.TrueValue = "1";
            // 
            // cbShowDeleted
            // 
            this.cbShowDeleted.AutoSize = true;
            this.cbShowDeleted.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbShowDeleted.Location = new System.Drawing.Point(370, 268);
            this.cbShowDeleted.Name = "cbShowDeleted";
            this.cbShowDeleted.Size = new System.Drawing.Size(93, 17);
            this.cbShowDeleted.TabIndex = 18;
            this.cbShowDeleted.Text = "Show Deleted";
            this.cbShowDeleted.UseVisualStyleBackColor = true;
            // 
            // frmContractorManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 558);
            this.Controls.Add(this.cbShowDeleted);
            this.Controls.Add(this.btSaveContractors);
            this.Controls.Add(this.btUpdateContractor);
            this.Controls.Add(this.btAddNewContractor);
            this.Controls.Add(this.dgContractors);
            this.Controls.Add(this.txtNameFilter);
            this.Controls.Add(this.lbFilter);
            this.Controls.Add(this.gbContractorDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmContractorManagement";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.ContractorManagement_Load);
            this.gbContractorDetails.ResumeLayout(false);
            this.gbContractorDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgContractors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.Label lbPhone;
        private System.Windows.Forms.Label lbMobile;
        private System.Windows.Forms.Label lbAddrLine1;
        private System.Windows.Forms.Label lbAddrLine2;
        private System.Windows.Forms.Label lbPostCode;
        private System.Windows.Forms.Label lbCountry;
        private System.Windows.Forms.GroupBox gbContractorDetails;
        private System.Windows.Forms.TextBox txtPostCode;
        private System.Windows.Forms.TextBox txtAddrLine2;
        private System.Windows.Forms.TextBox txtAddrLine1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtMobileNo;
        private System.Windows.Forms.TextBox txtPhoneNo;
        private System.Windows.Forms.ComboBox combCountries;
        private System.Windows.Forms.Label lbFilter;
        private System.Windows.Forms.TextBox txtNameFilter;
        private System.Windows.Forms.DataGridView dgContractors;
        private System.Windows.Forms.Button btAddNewContractor;
        private System.Windows.Forms.CheckBox cbDeleted;
        private System.Windows.Forms.Button btUpdateContractor;
        private System.Windows.Forms.Button btClear;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label lbCity;
        private System.Windows.Forms.Button btSaveContractors;
        private System.Windows.Forms.DataGridViewTextBoxColumn clName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn clPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn clMobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn clAddressLine1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clAddressLine2;
        private System.Windows.Forms.DataGridViewTextBoxColumn clPostCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clCountry;
        private System.Windows.Forms.DataGridViewTextBoxColumn clCountryName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clCity;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clIsDeleted;
        private System.Windows.Forms.CheckBox cbShowDeleted;
    }
}