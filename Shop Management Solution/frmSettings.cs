using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Shop_Management_Solution.lib.util;

namespace Shop_Management_Solution
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string currencySymbol = txtCurrencySybmol.Text;
            string shopName = txtShopName.Text;
            try
            {
                if (String.IsNullOrEmpty(currencySymbol) || String.IsNullOrEmpty(currencySymbol))
                {
                    MessageBox.Show(this, "Fill in currency symbol", "Error: Settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (String.IsNullOrEmpty(shopName) || String.IsNullOrEmpty(shopName))
                {
                    MessageBox.Show(this, "Fill in Shop name", "Error: Settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    bool isInserted = ConfigurationDAL.UpdateConfigurationByName(ConfigurationDAL.CURRENCY, currencySymbol);
                    isInserted = ConfigurationDAL.UpdateConfigurationByName(ConfigurationDAL.SHOPNAME, shopName);

                    if (isInserted)
                    {
                        this.Close();
                        MessageBox.Show(this, "Settings updated successfully.", "Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(this, "Settings updation  failed.", "Error:Settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Error: Settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            txtCurrencySybmol.Text = ConfigurationDAL.GetCurrentCurrency();
            txtShopName.Text = ConfigurationDAL.GetShopName();
        }


    }
}
