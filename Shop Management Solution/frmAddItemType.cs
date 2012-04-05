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
            String itemSalePrice = txtExpectedSalePrice.Text;

            try
            {
                if (String.IsNullOrEmpty(itemName) || String.IsNullOrEmpty(itemPrice) || String.IsNullOrEmpty(itemSalePrice))
                {
                    MessageBox.Show(this, "Fill in item name and price", "Error:Add Item Type", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    float price = NumberUtils.SafeParse(itemPrice ); // float.Parse(itemPrice);
                    float saleprice = NumberUtils.SafeParse(itemSalePrice); //float.Parse(itemSalePrice);

                    ItemType item = new ItemType();
                    item.ItemName = itemName;
                    item.Price = price;
                    item.SalePrice = saleprice;

                    bool isInserted = ShopDAL.InsertNewItemType( item );
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

        private void txtItemPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Code to Ensure that only numberic value with 
            if (!char.IsControl(e.KeyChar)
                 && !char.IsDigit(e.KeyChar)
                 && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtExpectedSalePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Code to Ensure that only numberic value with 
            if (!char.IsControl(e.KeyChar)
                 && !char.IsDigit(e.KeyChar)
                 && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

    }
}
