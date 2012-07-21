using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using Shop_Management_Solution.lib.util;
using Shop_Management_Solution.lib.dal;

namespace Shop_Management_Solution
{
    public partial class frmMainMenu : Form
    {
        private Timer objTimer = new Timer();
        private double subTotal = 0;
        private long lastInvoiceID = 0;


        public frmMainMenu()
        {
            InitializeComponent();
            this.subTotal = 0;
            btnPaid.Enabled = false;
            btnChangeGiven.Enabled = false;
            lblPaymentStatusText.Text = "Ready! For Next Sale";
            lblPaymentStatusText.ForeColor = Color.Red;
            picNetworkActivity.Image = null; //global::Shop_Management_Solution.Properties.Resources.loading;
            try
            {
                bool isAvailable = NetworkUtil.isNetworkAvailable();
                if (isAvailable)
                {
                    picConnectivity.Image = global::Shop_Management_Solution.Properties.Resources.gnome_network_idle;
                    
                    
                }
                else
                {
                    picConnectivity.Image = global::Shop_Management_Solution.Properties.Resources.network_offline;
                    
                }
                NetworkChange.NetworkAvailabilityChanged += AvailabilityChanged;
                UpdateDAL.RegisterClient();
            }
            catch (Exception e)
            {
                //picConnectivity.Image = global::Shop_Management_Solution.Properties.Resources.network_offline;
               // tipConnectivity.SetToolTip(picConnectivity, "Disconnected");
            }
            
        }

        private void AvailabilityChanged(object sender, NetworkAvailabilityEventArgs e)
        {

            try
            {
                if (e.IsAvailable)
                {
                    picConnectivity.Image = global::Shop_Management_Solution.Properties.Resources.gnome_network_idle;
                    
                    UpdateDAL.RegisterClient();
                }
                else
                {
                    picConnectivity.Image = global::Shop_Management_Solution.Properties.Resources.network_offline;
                    

                }
            }
            catch (Exception ex)
            {
                //picConnectivity.Image = global::Shop_Management_Solution.Properties.Resources.network_offline;
                //tipConnectivity.SetToolTip(picConnectivity, "Disconnected");
            }
        }

        private void btnAddItemType_Click(object sender, EventArgs e)
        {
            //frmAddItemType frmItemType = new frmAddItemType();
            //frmItemType.ShowDialog();
            frmItemManagement objItemManagement = new frmItemManagement();
            objItemManagement.ShowDialog();
        }

        private void btn_SaleItem_Click(object sender, EventArgs e)
        {
            frmSaleItem frmSale = new frmSaleItem();
            frmSale.ShowDialog();
            lblTotalPrice.Text = ConfigurationDAL.GetCurrentCurrency() + frmSale.getSaleTotalPrice();
            this.subTotal = frmSale.getSaleTotalPrice();
            if (this.subTotal > 0)
            {
                btnPaid.Enabled = true;
                txtMoneyPaid.Enabled = true;
                picStatusPayment.Image = global::Shop_Management_Solution.Properties.Resources.recieve_cash;
                lblPaymentStatusText.Text = "Recieve Cash";
                lblPaymentStatusText.ForeColor = Color.Green;
            }
            
       
            
        }

        private void btn_BuyItems_Click(object sender, EventArgs e)
        {
            frmBuyItem frmBuy = new frmBuyItem();
            frmBuy.ShowDialog();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_SearchItems_Click(object sender, EventArgs e)
        {
            frmAuthenticate frmAuth = new frmAuthenticate();
            frmAuth.ShowDialog();
            if (frmAuth.isAuthenticated)
            {
                frmSearchSales frmSearch = new frmSearchSales();
                frmSearch.ShowDialog();
                frmSearch.Dispose();
            }
            frmAuth.Dispose();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Application.Exit();
        }

        private void aboutUsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AboutBox ab = new AboutBox();
            ab.ShowDialog();
        }

        private void frmMainMenu_Load(object sender, EventArgs e)
        {
            lblCurrentDateTime.Text = DateTime.Now.ToLongTimeString().ToString();
            lblCurrentDate.Text = DateTime.Now.ToLongDateString().ToString();
            objTimer.Interval = 1000;
            picStatusPayment.Image = global::Shop_Management_Solution.Properties.Resources.waiting_clock;
            lblTotalGiven.Text = ConfigurationDAL.GetCurrentCurrency() + " 0.00";
            lblTotalPrice.Text = ConfigurationDAL.GetCurrentCurrency() + " 0.00";
            lblChangeToBePaid.Text = ConfigurationDAL.GetCurrentCurrency() + " 0.00";
            txtMoneyPaid.Enabled = false;
            objTimer.Tick += new EventHandler(_Timer_Tick);
            objTimer.Start();

            
        }
        private void _Timer_Tick(object sender, EventArgs e)
        {
            lblCurrentDate.Text = DateTime.Now.ToLongDateString().ToString();
            lblCurrentDateTime.Text = DateTime.Now.ToLongTimeString().ToString();

        }

        private void addItemTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddItemType frmItemType = new frmAddItemType();
            frmItemType.ShowDialog();
        }

        private void buyItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBuyItem frmBuy = new frmBuyItem();
            frmBuy.ShowDialog();
        }

        private void saleItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSaleItem frmSale = new frmSaleItem();
            frmSale.ShowDialog();
        }

        private void searchItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAuthenticate frmAuth = new frmAuthenticate();
            frmAuth.ShowDialog();
            if (frmAuth.isAuthenticated)
            {
                frmSearchSales frmSearch = new frmSearchSales();
                frmSearch.ShowDialog();
                frmSearch.Dispose();
            }
            frmAuth.Dispose();
        }

        private void tsUpdates_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.xtrawebapps.com/");
            
        }

        private void mb_update_Click(object sender, EventArgs e)
        {
            try
            {
                picNetworkActivity.Image = global::Shop_Management_Solution.Properties.Resources.loading;
                UpdateDAL.checkForUpdates();
                picNetworkActivity.Image = null;
            }
            catch (Exception ex)
            {
                picNetworkActivity.Image = null;
            }
            

        }

        private void frmMainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnPaid_Click(object sender, EventArgs e)
        {
            try
            {
                long moneyPaid = long.Parse(txtMoneyPaid.Text);
                double changeToBeGiven = moneyPaid - this.subTotal;
                if (moneyPaid >= this.subTotal)
                {
                    lblTotalGiven.Text = ConfigurationDAL.GetCurrentCurrency() + moneyPaid.ToString();
                    lblChangeToBePaid.Text = ConfigurationDAL.GetCurrentCurrency() + changeToBeGiven.ToString();
                    btnChangeGiven.Enabled = true;
                    picStatusPayment.Image = global::Shop_Management_Solution.Properties.Resources._1_euro_rotating_lg_nwm1;
                    lastInvoiceID = 0;
                    if (changeToBeGiven > 0)
                    {
                        lblPaymentStatusText.Text = "Money Paid. Give change! ";
                        lblPaymentStatusText.ForeColor = Color.Green;
                    }
                    else
                    {
                        lblPaymentStatusText.Text = "No! Change to give back";
                        lblPaymentStatusText.ForeColor = Color.ForestGreen;
                        btnChangeGiven.Text = "Move to next";
                    }
                }
                else
                {
                    throw new Exception("Money can't be less then bill");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Error: Money Paid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }        

        }

        private void btnChangeGiven_Click(object sender, EventArgs e)
        {
            lblTotalPrice.Text = ConfigurationDAL.GetCurrentCurrency()+ " 0.00";
            lblChangeToBePaid.Text = ConfigurationDAL.GetCurrentCurrency() + " 0.00";
            lblTotalGiven.Text = ConfigurationDAL.GetCurrentCurrency() + " 0.00";
            btnChangeGiven.Text = "Change given (If any)";
            lblPaymentStatusText.Text = "Ready! For Next Sale";
            lblPaymentStatusText.ForeColor = Color.Red;
            this.subTotal = 0;
            txtMoneyPaid.Text = "";
            btnPaid.Enabled = false;
            btnChangeGiven.Enabled = false;
            txtMoneyPaid.Enabled = false;
            picStatusPayment.Image = global::Shop_Management_Solution.Properties.Resources.waiting_clock;
            lastInvoiceID = 0;
        }

        private void imgAdvertisment_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.xtrawebapps.com/");
        }

        private void currencySettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSettings frmCurrency = new frmSettings();
            frmCurrency.ShowDialog();

            lblTotalGiven.Text = ConfigurationDAL.GetCurrentCurrency() + " 0.00";
            lblTotalPrice.Text = ConfigurationDAL.GetCurrentCurrency() + " 0.00";
            lblChangeToBePaid.Text = ConfigurationDAL.GetCurrentCurrency() + " 0.00";
        }

        private void adminAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frmAccount = new frmChangePassword();
            frmAccount.ShowDialog();

        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void contractorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmContractorManagement cm = new frmContractorManagement();
            cm.ShowDialog();
        }

        private void vendorsManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVendorManagement vm = new frmVendorManagement();
            vm.ShowDialog();
        }

        private void manageItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmItemManagement im = new frmItemManagement();
            im.ShowDialog();

        }

    }
}
