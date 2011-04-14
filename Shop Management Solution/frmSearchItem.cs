using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Shop_Management_Solution.lib.util;
using Shop_Management_Solution.lib;
using Shop_Management_Solution.lib.dal;

namespace Shop_Management_Solution
{
    public partial class frmSearchItem : Form
    {
        public frmSearchItem()
        {
            InitializeComponent();
        }

        private void frmSearchItem_Load(object sender, EventArgs e)
        {
            lblTotalProfit.Text = ConfigurationDAL.GetCurrentCurrency() + " 0.00";
            try
            {
                bool isExist = ShopDAL.isItemTypeExists();
                if (isExist)
                {
                    ShopDAL db = new ShopDAL();
                    DataSet ds = db.GetItemsType();
                    cmb_itemType.DataSource = ds.Tables[0];
                    cmb_itemType.DisplayMember = "Name";
                    cmb_itemType.ValueMember = "Type_ID";
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show(this, "Add atleast one item type", "Error:Search Item(s)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Error:Search Item(s)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            } 
            
            
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            try
            {
                String startDate = dpStartDate.Value.ToShortDateString();
                String endDate = dpEndDate.Value.ToShortDateString();
                long itemTypeId = long.Parse(cmb_itemType.SelectedValue.ToString());
                DataSet ds = ShopDAL.SearchTotalProfitDS(startDate, endDate, itemTypeId);
                //DebugUtil.displayDataSetContents(ds);
                long totalSoldQuantity = 0;
                long totalProfit = 0;

                lstViewSearch.Items.Clear();
                foreach (DataTable dt in ds.Tables)
                {
                    int rowIndex = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        string[] newRecord = new String[8];                    
                        int recordIndex = 0;
                        
                        foreach (DataColumn dc in dt.Columns)
                        {
                            if (recordIndex == 1)
                            {
                                newRecord[recordIndex] = row[dc].ToString();
                                totalSoldQuantity = totalSoldQuantity + long.Parse(row[dc].ToString());
                            }
                            else if (recordIndex == 2)
                            {
                                newRecord[recordIndex] = ConfigurationDAL.GetCurrentCurrency() + " " + row[dc].ToString();
                            }
                            else if (recordIndex == 3)
                            {
                                decimal soldPrice = decimal.Parse(row[dc].ToString());
                                soldPrice = decimal.Round(soldPrice, 2);
                                newRecord[recordIndex] = ConfigurationDAL.GetCurrentCurrency() + " " + soldPrice.ToString();
                            }
                            else if(recordIndex == 5)
                            {
                                decimal profit = decimal.Parse(row[dc].ToString());
                                profit = decimal.Round(profit, 2);
                                newRecord[recordIndex] = ConfigurationDAL.GetCurrentCurrency() + " " + profit.ToString();
                                totalProfit = totalProfit + long.Parse(profit.ToString());
                            }
                            else if (recordIndex == 6)
                            {
                                decimal totalSalePrice = decimal.Parse(row[dc].ToString());
                                totalSalePrice = decimal.Round(totalSalePrice, 2);
                                newRecord[recordIndex] = ConfigurationDAL.GetCurrentCurrency() + " " + totalSalePrice.ToString();
                               
                            }
                            else if (recordIndex == 7)
                            {
                                decimal totalPurchasePrice = decimal.Parse(row[dc].ToString());
                                totalPurchasePrice = decimal.Round(totalPurchasePrice, 2);
                                newRecord[recordIndex] = ConfigurationDAL.GetCurrentCurrency() + " " + totalPurchasePrice.ToString();
                            }
                            else
                            {
                                newRecord[recordIndex] = row[dc].ToString();
                            }
                            
                            recordIndex++;
                        }
                        rowIndex++;
                        lstViewSearch.Items.Add(rowIndex.ToString()).SubItems.AddRange(newRecord);
                      }
                }
                lblSoldQuantity.Text = totalSoldQuantity.ToString();
                lblTotalProfit.Text = ConfigurationDAL.GetCurrentCurrency() +" "+totalProfit.ToString();

                //lstViewSearch.DataBindings = ds;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            lstViewSearch.Items.Clear();
            lblSoldQuantity.Text = "0";
            lblTotalProfit.Text = ConfigurationDAL.GetCurrentCurrency() + " 0.00 ";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
