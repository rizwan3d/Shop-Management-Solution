namespace Shop_Management_Solution
{
    partial class ContractorVendorManagement
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Contractors");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Vendors");
            this.tvContractorsVendors = new System.Windows.Forms.TreeView();
            this.pnContractors = new System.Windows.Forms.Panel();
            this.pnVendors = new System.Windows.Forms.Panel();
            this.pnContractors.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvContractorsVendors
            // 
            this.tvContractorsVendors.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvContractorsVendors.Indent = 10;
            this.tvContractorsVendors.Location = new System.Drawing.Point(0, 0);
            this.tvContractorsVendors.Name = "tvContractorsVendors";
            treeNode1.Name = "ndContractors";
            treeNode1.Text = "Contractors";
            treeNode2.Name = "ndVendors";
            treeNode2.Text = "Vendors";
            this.tvContractorsVendors.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            this.tvContractorsVendors.ShowLines = false;
            this.tvContractorsVendors.Size = new System.Drawing.Size(85, 558);
            this.tvContractorsVendors.TabIndex = 0;
            this.tvContractorsVendors.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvContractorsVendors_AfterSelect);
            // 
            // pnContractors
            // 
            this.pnContractors.Controls.Add(this.pnVendors);
            this.pnContractors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnContractors.Location = new System.Drawing.Point(85, 0);
            this.pnContractors.Name = "pnContractors";
            this.pnContractors.Size = new System.Drawing.Size(907, 558);
            this.pnContractors.TabIndex = 1;
            this.pnContractors.Visible = false;
            // 
            // pnVendors
            // 
            this.pnVendors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnVendors.Location = new System.Drawing.Point(0, 0);
            this.pnVendors.Name = "pnVendors";
            this.pnVendors.Size = new System.Drawing.Size(907, 558);
            this.pnVendors.TabIndex = 2;
            this.pnVendors.Visible = false;
            // 
            // ContractorVendorManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 558);
            this.Controls.Add(this.pnContractors);
            this.Controls.Add(this.tvContractorsVendors);
            this.Name = "ContractorVendorManagement";
            this.Text = "Contractor and vendor management";
            this.Load += new System.EventHandler(this.ContractorVendorManagement_Load);
            this.pnContractors.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvContractorsVendors;
        private System.Windows.Forms.Panel pnContractors;
        private System.Windows.Forms.Panel pnVendors;
    }
}