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

namespace Shop_Management_Solution
{
    public partial class frmAddItemType : Form
    {
        public frmAddItemType()
        {
            InitializeComponent();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            String itemName = txtItemName.Text;
            String itemPrice = txtItemPrice.Text;
            try
            {
                if (String.IsNullOrEmpty(itemName) || String.IsNullOrEmpty(itemPrice))
                {
                    MessageBox.Show(this, "Fill in item name and price", "Error:Add Item Type", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    float price = float.Parse(itemPrice);
                    bool isInserted = ShopDAL.InsertNewItemType(itemName, price);
                    if (isInserted)
                    {
                        this.Close();
                        MessageBox.Show(this, "Itemtype inserted successfully.", "Add Item Type", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                     

                    }
                    else
                    {
                        MessageBox.Show(this, "Itemtype inserted failed.", "Error:Add Item Type", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Error:Add Item Type", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
