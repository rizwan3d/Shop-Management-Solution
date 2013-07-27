using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Shop_Management_Solution.lib.util;
using Shop_Management_Solution.lib.dal;
using Shop_Management_Solution.lib;

namespace Shop_Management_Solution
{
    public partial class frmAddUnit : Form
    {
        public frmAddUnit()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                UoM objUom = new UoM();
                objUom.Name = txtUnitName.Text.ToString();
                if (String.IsNullOrEmpty(objUom.Name))
                {
                    throw new Exception(" Unit name must not be empty ");
                }
                UoMDAL.addUoM(objUom);
                MessageBox.Show("Unit added successfully", "Add Unit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Add Unit", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
