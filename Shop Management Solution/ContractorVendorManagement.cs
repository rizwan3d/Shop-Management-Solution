using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Shop_Management_Solution
{
    public partial class ContractorVendorManagement : Form
    {
        public ContractorVendorManagement()
        {
            InitializeComponent();            
        }

        private void ContractorVendorManagement_Load(object sender, EventArgs e)
        {
            pnVendors.Visible = false;
            frmContractorManagement contractorMngmt = new frmContractorManagement();
            contractorMngmt.TopLevel = false;
            pnContractors.Controls.Add(contractorMngmt);
            contractorMngmt.Show();
            contractorMngmt.Dock = DockStyle.Top;
            contractorMngmt.BringToFront();
        }

        private void tvContractorsVendors_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "Contractors")
            {
                pnContractors.Visible = true;
                pnVendors.Visible = false;
            }

            if (e.Node.Text == "Vendors")
            {
                pnContractors.Visible = false;
                pnVendors.Visible = true;
            }
        }
    }
}
