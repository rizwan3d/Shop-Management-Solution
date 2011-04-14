﻿using System;
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
    public partial class frmBuyItem : Form
    {
        public frmBuyItem()
        {
            InitializeComponent();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void onLoadBuy(object sender, EventArgs e)
        {
            try
            {
                bool isExist = ShopDAL.isItemTypeExists();
                if (isExist)
                {
                    ShopDAL db = new ShopDAL();
                    DataSet ds = db.GetItemsType();
                    cmbItemType.DataSource = ds.Tables[0];
                    cmbItemType.DisplayMember = "Name";
                    cmbItemType.ValueMember = "Type_ID";
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show(this, "Add atleast one item type to add purchase", "Error:Add new stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Error:Add New Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            String dateofPurchase = txtDateofPurchase.Text;
            long itemQuantity = long.Parse(txtQuantity.Value.ToString()) ;
            long itemTypeId = long.Parse(cmbItemType.SelectedValue.ToString());
            //MessageBox.Show(" Value for DB = " + dateofPurchase + " " + itemQuantity +" "+ itemTypeId);
            try
            {
                if (String.IsNullOrEmpty(dateofPurchase) || itemQuantity < 1)
                {
                    MessageBox.Show(this, "Fill in date of purchase and quantity", "Error: Add new stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    bool isInserted = ShopDAL.AddPurchasedItem(dateofPurchase, itemTypeId, itemQuantity);
                    if (isInserted)
                    {
                        this.Close();
                        MessageBox.Show(this, "New stock inserted successfully.", "Add new stock", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(this, "New stock insertion failed.", "Error:Add new stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Error:Add new stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
