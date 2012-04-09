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
    public partial class frmSearchSales : Form
    {
        public frmSearchSales()
        {
            InitializeComponent();
        }

        private int currentPage;
        private int totalPages;
        private const int recordsPerPage = 5;
        private int totalRecords;

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
            setupGridColumns();
            setupColumnsWidth();            
            
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            setSummaryData();
            performSearch(0, recordsPerPage);
            if (totalRecords > recordsPerPage)
            {
                btNext.Enabled = true;
                btPrev.Enabled = false;
                totalPages = totalRecords / recordsPerPage;
                if ((totalRecords % recordsPerPage) > 0)
                    totalPages++;
                currentPage = 1;
                lbPageInfo.Text = "Page 1 of " + totalPages;
            }
            else
            {
                currentPage = 1;
                totalPages = 1;
                btNext.Enabled = false;
                btPrev.Enabled = false;
                lbPageInfo.Text = "Page 1 of 1";
            }
            lbPageInfo.Visible = true;
            
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            dgSearchResults.Rows.Clear();
            dgSearchResults.Columns.Clear();
            setupGridColumns();
            setupColumnsWidth();
            lblSoldQuantity.Text = "0";
            lblTotalProfit.Text = ConfigurationDAL.GetCurrentCurrency() + " 0.00 ";
            btPrev.Enabled = false;
            btNext.Enabled = false;
            lbPageInfo.Visible = false;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void setupGridColumns()
        {
            dgSearchResults.Columns.Clear();

            dgSearchResults.Columns.Add("dcNo", "S.No.");
            dgSearchResults.Columns.Add("dcItemType", "Item Type");
            dgSearchResults.Columns.Add("dcSoldQuantity", "Sold Quantity");
            dgSearchResults.Columns[2].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgSearchResults.Columns.Add("dcPurchasePrice", "Purchase Price/Piece");
            dgSearchResults.Columns.Add("dcSoldPrice", "Sold Price/Piece");
            dgSearchResults.Columns.Add("dcRemQuantity", "Remaining Quantity");
            dgSearchResults.Columns[5].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgSearchResults.Columns.Add("dcProfit", "Profit");
            dgSearchResults.Columns[6].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgSearchResults.Columns.Add("dcTotSalePrice", "Total Sale Price");
            dgSearchResults.Columns.Add("dcTotPurchasePrice", "Total Purchase Price");
        }

        private void setupColumnsWidth()
        {
            dgSearchResults.Columns[0].Width = 50;
            dgSearchResults.Columns[1].Width = 130;
            dgSearchResults.Columns[2].Width = 95;
            dgSearchResults.Columns[3].Width = 135;
            dgSearchResults.Columns[4].Width = 115;
            dgSearchResults.Columns[5].Width = 125;
            dgSearchResults.Columns[6].Width = 60;
            dgSearchResults.Columns[7].Width = 110;
            dgSearchResults.Columns[8].Width = 130;
            
        }

        private void dgSearchResults_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {           
        }

        private void dgSearchResults_Click(object sender, EventArgs e)
        {
            //dgSearchResults.ClearSelection();
        }

        private void performSearch(int startRecordNo, int noOfRecords)
        {            
            try
            {
                String startDate = dpStartDate.Value.ToShortDateString();
                String endDate = dpEndDate.Value.ToShortDateString();
                long itemTypeId = long.Parse(cmb_itemType.SelectedValue.ToString());
                DataTable resultTable = ShopDAL.SearchTotalProfitDS(startDate, endDate, itemTypeId, startRecordNo, noOfRecords).Tables[0];
                String[] dataFromTable;
                //DebugUtil.displayDataSetContents(ds);

                dgSearchResults.Columns.Clear();
                dgSearchResults.Columns.Add("dcNo", "S.No.");
                setupGridColumns();
                setupColumnsWidth();

                int i = startRecordNo+1;                    
                foreach (DataRow dr in resultTable.Rows)
                {
                    dataFromTable = new String[] { 
                        i.ToString(), 
                        dr[0].ToString(), 
                        dr[1].ToString(), 
                        ConfigurationDAL.GetCurrentCurrency() + " " + decimal.Round(decimal.Parse(dr[2].ToString()), 2).ToString(), 
                        ConfigurationDAL.GetCurrentCurrency() + " " + decimal.Round(decimal.Parse(dr[3].ToString()), 2).ToString(),
                        dr[4].ToString(), 
                        ConfigurationDAL.GetCurrentCurrency() + " " + decimal.Round(decimal.Parse(dr[5].ToString()), 2).ToString(), 
                        ConfigurationDAL.GetCurrentCurrency() + " " + decimal.Round(decimal.Parse(dr[6].ToString()), 2).ToString(), 
                        ConfigurationDAL.GetCurrentCurrency() + " " + decimal.Round(decimal.Parse(dr[7].ToString()), 2).ToString() 
                        };
                    
                    dgSearchResults.Rows.Add(dataFromTable);                    
                    i++;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dgSearchResults.ClearSelection();
        }

        private void btPrev_Click(object sender, EventArgs e)
        {            
            currentPage--;            

            if (currentPage == 1)
            {
                btPrev.Enabled = false;
                performSearch(0, recordsPerPage);
            }
            else
                performSearch(((currentPage - 1) * recordsPerPage) - 1, recordsPerPage);
            if (currentPage < totalPages)
                btNext.Enabled = true;
            lbPageInfo.Text = "Page " + currentPage + " of " + totalPages;
        }

        private void btNext_Click(object sender, EventArgs e)
        {
            currentPage++;
            performSearch(((currentPage - 1) * recordsPerPage), recordsPerPage);
            lbPageInfo.Text = "Page " + currentPage + " of " + totalPages;
            if (currentPage == totalPages)
                btNext.Enabled = false;
            if (currentPage > 1)
                btPrev.Enabled = true;

        }

        private void setSummaryData()
        {
            int totalSoldQuantity = 0;
            decimal totalProfit = 0;
            String startDate = dpStartDate.Value.ToShortDateString();
            String endDate = dpEndDate.Value.ToShortDateString();
            long itemTypeId = long.Parse(cmb_itemType.SelectedValue.ToString());
            totalRecords = ShopDAL.SearchTotalProfitSummary(startDate, endDate, itemTypeId, ref totalSoldQuantity, ref totalProfit);

            lblSoldQuantity.Text = totalSoldQuantity.ToString();
            lblTotalProfit.Text = ConfigurationDAL.GetCurrentCurrency() + " " + totalProfit.ToString();

        }
             
    }
}
