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
using System.Data.OleDb;

namespace Shop_Management_Solution
{
    public partial class frmItemManagement : Form
    {
        private DataSet _itemsDs;
        private int _itemChangedId;
        private OleDbDataAdapter _itemAdapter;
        private bool isDirty;

        public frmItemManagement()
        {
            InitializeComponent();
        }

        private void frmItemManagement_Load(object sender, EventArgs e)
        {

            try
            {

                ItemDAL dal = new ItemDAL();
                _itemsDs = dal.getItemsPresentationDs();

                DataView dv = _itemsDs.Tables[0].DefaultView;
                dv.RowFilter = "Is_Deleted = 0";
                dgItem.DataSource = dv;

                DataSet uomDs = UoMDAL.GetUoMsDataSet();
                DataRow defaultRowUnit = uomDs.Tables[0].NewRow();
                defaultRowUnit["ID"] = "0";
                defaultRowUnit["UoM_Name"] = "-------------- Select Unit  ----------------";
                uomDs.Tables[0].Rows.InsertAt(defaultRowUnit, 0);

                cmbUoM.DataSource = uomDs.Tables[0];
                cmbUoM.DisplayMember = "UoM_Name";
                cmbUoM.ValueMember = "ID";

                DataSet venDs = VendorDAL.getVendorsDs();
                DataRow defaultRow = venDs.Tables[0].NewRow();
                defaultRow["ID"] = "0";
                defaultRow["Name"] = "-------------- Select Vendor  -------------------";
                venDs.Tables[0].Rows.InsertAt(defaultRow, 0);

                cmbVendor.DataSource = venDs.Tables[0];
                cmbVendor.DisplayMember = "Name";
                cmbVendor.ValueMember = "ID";

                btAddNewItem.Focus();
                _itemAdapter = dal.getItemAdapter();
                this.dgItem.SelectionChanged += new EventHandler(dgItems_SelectionChanged);
                isDirty = false;
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

        private void dgItems_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            //User selected WHOLE ROW (by clicking in the margin)
            if (dgv.SelectedRows.Count > 0)
            {
                if (dgv.SelectedRows.Count > 0)
                {
                    if (!String.IsNullOrEmpty(dgv.CurrentRow.Cells[0].Value.ToString()))
                    {
                        _itemChangedId = int.Parse(dgv.CurrentRow.Cells[0].Value.ToString());
                    }

                    fillItemControls();

                    btnDeleteItem.Enabled = true;
                    btUpdateItem.Enabled = true;
                }
               
                
            }
            else
            {
                btnDeleteItem.Enabled = false;
                btUpdateItem.Enabled = false;
            }


        }

        private void fillItemControls()
        {
            txtName.Text = dgItem.CurrentRow.Cells["clName"].Value.ToString();
            txtPurchasePrice.Text = dgItem.CurrentRow.Cells["clPurchasePrice"].Value.ToString();
            txtExpectedSalePrice.Text = dgItem.CurrentRow.Cells["clSalePrice"].Value.ToString();
            if (!String.IsNullOrEmpty(dgItem.CurrentRow.Cells["clUoMID"].Value.ToString()))
            {
                cmbUoM.SelectedIndex = int.Parse(dgItem.CurrentRow.Cells["clUoMID"].Value.ToString());
            }
            if (!String.IsNullOrEmpty(dgItem.CurrentRow.Cells["clVendorID"].Value.ToString()))
            {
                cmbVendor.SelectedIndex = int.Parse(dgItem.CurrentRow.Cells["clVendorID"].Value.ToString());
            }
            cbDeleted.Checked = dgItem.CurrentRow.Cells["clIsDeleted"].Value.ToString() == "1";
        }

        private void btAddNewItem_Click(object sender, EventArgs e)
        {
            if (validateItemData())
            {
                String deleted = "0";
                if (cbDeleted.Checked)
                    deleted = "1";

                DataRow newRow = _itemsDs.Tables[0].NewRow();
                newRow["ItemType_Name"] = txtName.Text;
                newRow["Price"] = txtPurchasePrice.Text;
                newRow["Sale_Price"] = txtExpectedSalePrice.Text;
                newRow["UoM_ID"] = cmbUoM.SelectedValue.ToString();
                newRow["UoM_Name"] = cmbUoM.Text.ToString();
                newRow["Vendor_ID"] = cmbVendor.SelectedValue.ToString();
                newRow["vendor_name"] = cmbVendor.Text.ToString();
                newRow["Is_Deleted"] = deleted;


                _itemsDs.Tables[0].Rows.Add(newRow);
                dgItem.Refresh();


               clearData();
                btnDeleteItem.Enabled = false;
                btUpdateItem.Enabled = false;
            }
            else
            {
                MessageBox.Show("Please fill all necessary data", "Missing data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                highlitghtMissingItemData();
            }
        }

        private bool validateItemData()
        {
            bool positiveValidated = true;
            //checking if all but Address Line 2 text fields have any data
            if (String.IsNullOrEmpty(txtName.Text) || String.IsNullOrEmpty(txtExpectedSalePrice.Text) || String.IsNullOrEmpty(txtPurchasePrice.Text) ||
               cmbUoM.SelectedIndex.ToString() == "0" || cmbVendor.SelectedIndex.ToString() == "0" )
            {
                positiveValidated = false;
            }
                

            return positiveValidated;
        }

        private bool checkIfThereIsDataLeft()
        {
            bool isDataLeft = false;
            if (!(String.IsNullOrEmpty(txtName.Text) || String.IsNullOrEmpty(txtExpectedSalePrice.Text) || String.IsNullOrEmpty(txtPurchasePrice.Text) ||
               cmbUoM.SelectedIndex.ToString() == "0" || cmbVendor.SelectedIndex.ToString() == "0"))
                isDataLeft = true;

            return isDataLeft;
        }

        private void clearData()
        {
            txtName.Text = "";
            txtExpectedSalePrice.Text = "";
            txtPurchasePrice.Text = "";
            cmbUoM.SelectedIndex = 0;
            cmbVendor.SelectedIndex = 0;
            cbDeleted.Checked = false;
            btnDeleteItem.Enabled = false;
            btUpdateItem.Enabled = false;

        }

        private void highlitghtMissingItemData()
        {
            if (String.IsNullOrEmpty(txtName.Text))
            {
                lbName.Font = new Font(lbName.Font, FontStyle.Bold);
                lbName.ForeColor = Color.Red;
            }
            else
            {
                lbName.Font = new Font(lbName.Font, FontStyle.Regular);
                lbName.ForeColor = Color.Black;
            }

            if (String.IsNullOrEmpty(txtExpectedSalePrice.Text))
            {

                lblSalePrice.Font = new Font(lblSalePrice.Font, FontStyle.Bold);
                lblSalePrice.ForeColor = Color.Red;
            }
            else
            {
                lblSalePrice.Font = new Font(lblSalePrice.Font, FontStyle.Regular);
                lblSalePrice.ForeColor = Color.Black;
            }

            if (String.IsNullOrEmpty(txtPurchasePrice.Text))
            {
                lblPurchasePrice.Font = new Font(lblPurchasePrice.Font, FontStyle.Bold);
                lblPurchasePrice.ForeColor = Color.Red;
            }
            else
            {
                lblPurchasePrice.Font = new Font(lblPurchasePrice.Font, FontStyle.Regular);
                lblPurchasePrice.ForeColor = Color.Black;
            }

            if ( cmbUoM.SelectedIndex.ToString() == "0" )
            {

                lblUoM.Font = new Font(lblUoM.Font, FontStyle.Bold);
                lblUoM.ForeColor = Color.Red;
            }
            else
            {
                lblUoM.Font = new Font(lblUoM.Font, FontStyle.Regular);
                lblUoM.ForeColor = Color.Black;
            }

            if (cmbVendor.SelectedIndex.ToString() == "0")
            {

                lblVendor.Font = new Font(lblVendor.Font, FontStyle.Bold);
                lblVendor.ForeColor = Color.Red;
            }
            else
            {
                lblVendor.Font = new Font(lblVendor.Font, FontStyle.Regular);
                lblVendor.ForeColor = Color.Black;
            }

            
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            //ckeck if user is sure to clear data
            if (checkIfThereIsDataLeft())
            {
                if (MessageBox.Show("There is some data left in the fields. Do you want to clear it anyway?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                {
                    clearData();
                }
            }
        }

        private void btUpdateItem_Click(object sender, EventArgs e)
        {
            if (validateItemData())
            {
                String deleted = "0";
                if (cbDeleted.Checked)
                {
                    deleted = "1";
                }


                DataRow[] rowsTab = _itemsDs.Tables[0].Select("Type_ID = " + _itemChangedId);

                rowsTab[0]["ItemType_Name"] = txtName.Text;
                rowsTab[0]["Price"] = txtPurchasePrice.Text;
                rowsTab[0]["Sale_Price"] = txtExpectedSalePrice.Text;
                rowsTab[0]["UoM_ID"] = cmbUoM.SelectedValue.ToString();
                rowsTab[0]["UoM_Name"] = cmbUoM.Text.ToString();
                rowsTab[0]["Vendor_ID"] = cmbVendor.SelectedValue.ToString();
                rowsTab[0]["vendor_name"] = cmbVendor.Text.ToString();
                rowsTab[0]["Is_Deleted"] = deleted;

                dgItem.Refresh();
                clearData();
            }
            else
            {
                MessageBox.Show("Please fill all necessary data", "Missing data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                highlitghtMissingItemData();
            }
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {

            if (dgItem.SelectedRows.Count > 0)
            {
                if (!String.IsNullOrEmpty(_itemChangedId.ToString()) && _itemChangedId > 0)
                {
                    DataRow[] rowsTab = _itemsDs.Tables[0].Select("Type_ID = " + _itemChangedId);
                    rowsTab[0]["Is_Deleted"] = "1";
                    dgItem.Refresh();
                }
                else
                {
                    dgItem.Rows.RemoveAt(dgItem.SelectedRows[0].Index);
                }
                clearData();

            }

        }

        private void btSaveItems_Click(object sender, EventArgs e)
        {
            
            if (_itemsDs.HasChanges())
            {
                _itemAdapter.Update(_itemsDs);
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            isDirty = _itemsDs.HasChanges();
            if (isDirty)
            {
                if (MessageBox.Show("Do you want to exit without saving changes?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void dgItem_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgItem.SelectedRows.Count > 0)
            {
                dgItem.SelectedRows[0].Selected = false;
                btnDeleteItem.Enabled = false;
                btUpdateItem.Enabled = false;
            }
        }

        private void txtPurchasePrice_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtNameFilter_TextChanged(object sender, EventArgs e)
        {
            DataView dv = _itemsDs.Tables[0].DefaultView;

            if (cbShowDeleted.Checked)
            {
                dv.RowFilter = "ItemType_Name LIKE '*" + txtNameFilter.Text + "*'";
            }
            else
            {
                dv.RowFilter = "Is_Deleted = 0 and ItemType_Name LIKE '*" + txtNameFilter.Text + "*'";
            }
                
        }


    }
}
