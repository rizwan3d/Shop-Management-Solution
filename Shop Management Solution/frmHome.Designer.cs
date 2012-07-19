namespace Shop_Management_Solution
{
    partial class frmHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHome));
            this.pnlStoreName = new System.Windows.Forms.Panel();
            this.pnlTotalLbl = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.pnlTotalVal = new System.Windows.Forms.Panel();
            this.pnlTotalLbl.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlStoreName
            // 
            this.pnlStoreName.BackColor = System.Drawing.Color.LemonChiffon;
            this.pnlStoreName.Location = new System.Drawing.Point(13, 13);
            this.pnlStoreName.Name = "pnlStoreName";
            this.pnlStoreName.Size = new System.Drawing.Size(323, 99);
            this.pnlStoreName.TabIndex = 0;
            // 
            // pnlTotalLbl
            // 
            this.pnlTotalLbl.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.pnlTotalLbl.Controls.Add(this.lblTotal);
            this.pnlTotalLbl.Location = new System.Drawing.Point(342, 13);
            this.pnlTotalLbl.Name = "pnlTotalLbl";
            this.pnlTotalLbl.Size = new System.Drawing.Size(200, 100);
            this.pnlTotalLbl.TabIndex = 1;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Times New Roman", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(17, 13);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(180, 73);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "Total:";
            // 
            // pnlTotalVal
            // 
            this.pnlTotalVal.BackColor = System.Drawing.Color.LightGreen;
            this.pnlTotalVal.Location = new System.Drawing.Point(548, 12);
            this.pnlTotalVal.Name = "pnlTotalVal";
            this.pnlTotalVal.Size = new System.Drawing.Size(200, 100);
            this.pnlTotalVal.TabIndex = 2;
            // 
            // frmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 487);
            this.Controls.Add(this.pnlTotalVal);
            this.Controls.Add(this.pnlTotalLbl);
            this.Controls.Add(this.pnlStoreName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmHome";
            this.Text = "Shop Management Solution";
            this.pnlTotalLbl.ResumeLayout(false);
            this.pnlTotalLbl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlStoreName;
        private System.Windows.Forms.Panel pnlTotalLbl;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Panel pnlTotalVal;
    }
}