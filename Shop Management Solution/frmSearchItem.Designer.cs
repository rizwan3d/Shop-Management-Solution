namespace Shop_Management_Solution
{
    partial class frmSearchItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchItem));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmb_itemType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.lstViewSearch = new System.Windows.Forms.ListView();
            this.colItemIndex = new System.Windows.Forms.ColumnHeader();
            this.colItem = new System.Windows.Forms.ColumnHeader();
            this.colQuantity = new System.Windows.Forms.ColumnHeader();
            this.colPurchasePrice = new System.Windows.Forms.ColumnHeader();
            this.colSoldPrice = new System.Windows.Forms.ColumnHeader();
            this.colRemainingQuantity = new System.Windows.Forms.ColumnHeader();
            this.colProfit = new System.Windows.Forms.ColumnHeader();
            this.colTotalSalePrice = new System.Windows.Forms.ColumnHeader();
            this.colTotalPurchasePrice = new System.Windows.Forms.ColumnHeader();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSoldQuantity = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTotalProfit = new System.Windows.Forms.Label();
            this.btn_search = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Clear);
            this.groupBox1.Controls.Add(this.btn_search);
            this.groupBox1.Controls.Add(this.cmb_itemType);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dpEndDate);
            this.groupBox1.Controls.Add(this.dpStartDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(75, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(374, 110);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Item(s)";
            // 
            // cmb_itemType
            // 
            this.cmb_itemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_itemType.FormattingEnabled = true;
            this.cmb_itemType.Location = new System.Drawing.Point(114, 46);
            this.cmb_itemType.Name = "cmb_itemType";
            this.cmb_itemType.Size = new System.Drawing.Size(252, 21);
            this.cmb_itemType.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Item Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(243, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "To";
            // 
            // dpEndDate
            // 
            this.dpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpEndDate.Location = new System.Drawing.Point(269, 19);
            this.dpEndDate.Name = "dpEndDate";
            this.dpEndDate.Size = new System.Drawing.Size(98, 20);
            this.dpEndDate.TabIndex = 2;
            // 
            // dpStartDate
            // 
            this.dpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpStartDate.Location = new System.Drawing.Point(110, 18);
            this.dpStartDate.Name = "dpStartDate";
            this.dpStartDate.Size = new System.Drawing.Size(98, 20);
            this.dpStartDate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "From";
            // 
            // lstViewSearch
            // 
            this.lstViewSearch.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colItemIndex,
            this.colItem,
            this.colQuantity,
            this.colPurchasePrice,
            this.colSoldPrice,
            this.colRemainingQuantity,
            this.colProfit,
            this.colTotalSalePrice,
            this.colTotalPurchasePrice});
            this.lstViewSearch.Location = new System.Drawing.Point(12, 144);
            this.lstViewSearch.Name = "lstViewSearch";
            this.lstViewSearch.Size = new System.Drawing.Size(961, 180);
            this.lstViewSearch.TabIndex = 2;
            this.lstViewSearch.UseCompatibleStateImageBehavior = false;
            this.lstViewSearch.View = System.Windows.Forms.View.Details;
            // 
            // colItemIndex
            // 
            this.colItemIndex.Text = "S.No.";
            // 
            // colItem
            // 
            this.colItem.Text = "Item";
            this.colItem.Width = 138;
            // 
            // colQuantity
            // 
            this.colQuantity.Text = "Sold Quantity";
            this.colQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colQuantity.Width = 85;
            // 
            // colPurchasePrice
            // 
            this.colPurchasePrice.Text = "Purchase Price / Piece";
            this.colPurchasePrice.Width = 141;
            // 
            // colSoldPrice
            // 
            this.colSoldPrice.Text = "Sold Price / Piece";
            this.colSoldPrice.Width = 125;
            // 
            // colRemainingQuantity
            // 
            this.colRemainingQuantity.Text = "Remaining Quantity";
            this.colRemainingQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colRemainingQuantity.Width = 115;
            // 
            // colProfit
            // 
            this.colProfit.Text = "Profit";
            this.colProfit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // colTotalSalePrice
            // 
            this.colTotalSalePrice.Text = "Total Sale Price";
            this.colTotalSalePrice.Width = 95;
            // 
            // colTotalPurchasePrice
            // 
            this.colTotalPurchasePrice.Text = "Total Purchase Price";
            this.colTotalPurchasePrice.Width = 117;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Sienna;
            this.label4.Location = new System.Drawing.Point(27, 333);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Total Sold Quantity";
            // 
            // lblSoldQuantity
            // 
            this.lblSoldQuantity.AutoSize = true;
            this.lblSoldQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoldQuantity.ForeColor = System.Drawing.Color.Sienna;
            this.lblSoldQuantity.Location = new System.Drawing.Point(167, 333);
            this.lblSoldQuantity.Name = "lblSoldQuantity";
            this.lblSoldQuantity.Size = new System.Drawing.Size(15, 15);
            this.lblSoldQuantity.TabIndex = 5;
            this.lblSoldQuantity.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.SeaGreen;
            this.label5.Location = new System.Drawing.Point(277, 333);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "Total Profit";
            // 
            // lblTotalProfit
            // 
            this.lblTotalProfit.AutoSize = true;
            this.lblTotalProfit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalProfit.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblTotalProfit.Location = new System.Drawing.Point(354, 333);
            this.lblTotalProfit.Name = "lblTotalProfit";
            this.lblTotalProfit.Size = new System.Drawing.Size(0, 15);
            this.lblTotalProfit.TabIndex = 7;
            // 
            // btn_search
            // 
            this.btn_search.BackgroundImage = global::Shop_Management_Solution.Properties.Resources.bg_blue;
            this.btn_search.Image = global::Shop_Management_Solution.Properties.Resources.search_icon;
            this.btn_search.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_search.Location = new System.Drawing.Point(211, 73);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 29);
            this.btn_search.TabIndex = 6;
            this.btn_search.Text = "Search";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = global::Shop_Management_Solution.Properties.Resources.bg_blue;
            this.btnClose.Location = new System.Drawing.Point(898, 330);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btn_Clear
            // 
            this.btn_Clear.BackgroundImage = global::Shop_Management_Solution.Properties.Resources.bg_blue;
            this.btn_Clear.Image = global::Shop_Management_Solution.Properties.Resources.Synchronize_icon;
            this.btn_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Clear.Location = new System.Drawing.Point(292, 73);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(75, 29);
            this.btn_Clear.TabIndex = 7;
            this.btn_Clear.Text = "Clear";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(57, 51);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // frmSearchItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(979, 360);
            this.Controls.Add(this.lblTotalProfit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblSoldQuantity);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lstViewSearch);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmSearchItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Search Item(s)";
            this.Load += new System.EventHandler(this.frmSearchItem_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmb_itemType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dpEndDate;
        private System.Windows.Forms.DateTimePicker dpStartDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.ListView lstViewSearch;
        private System.Windows.Forms.ColumnHeader colItem;
        private System.Windows.Forms.ColumnHeader colQuantity;
        private System.Windows.Forms.ColumnHeader colPurchasePrice;
        private System.Windows.Forms.ColumnHeader colSoldPrice;
        private System.Windows.Forms.ColumnHeader colRemainingQuantity;
        private System.Windows.Forms.ColumnHeader colProfit;
        private System.Windows.Forms.ColumnHeader colItemIndex;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ColumnHeader colTotalSalePrice;
        private System.Windows.Forms.ColumnHeader colTotalPurchasePrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSoldQuantity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTotalProfit;
    }
}