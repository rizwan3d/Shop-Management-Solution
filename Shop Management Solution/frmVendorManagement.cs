using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Shop_Management_Solution.lib;
using Shop_Management_Solution.lib.dal;
using System.Data.OleDb;


namespace Shop_Management_Solution
{
    public partial class frmVendorManagement : Form
    {
        private DataSet _vendorsDs;
        private int _vendorChangedId;
        private OleDbDataAdapter _vendorAdapter;

        public frmVendorManagement()
        {
            InitializeComponent();
        }

        private void frmVendorManagement_Load(object sender, EventArgs e)
        {
            VendorDAL vendor = new VendorDAL();
            _vendorsDs = vendor.getContractorsPresentationDs();
            DataView dv = _vendorsDs.Tables[0].DefaultView;
            dv.RowFilter = "IsDeleted = 0";
            dgVendors.DataSource = dv;            
            btAddNewVendor.Focus();
            _vendorAdapter = vendor.getContractorAdapter();
        }

        private void fillContractorControls()
        {
            txtName.Text = dgVendors.CurrentRow.Cells["clName"].Value.ToString();
            txtLocation.Text = dgVendors.CurrentRow.Cells["clLocation"].Value.ToString();            
            txtPhoneNo.Text = dgVendors.CurrentRow.Cells["clPhone"].Value.ToString();
            txtMobileNo.Text = dgVendors.CurrentRow.Cells["clMobile"].Value.ToString();
            txtEmail.Text = dgVendors.CurrentRow.Cells["clEmail"].Value.ToString();
            cbDeleted.Checked = dgVendors.CurrentRow.Cells["clIsDeleted"].Value.ToString() == "1";

        }

        private void dgVendors_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex >= 0) && (e.RowIndex >= 0))
            {
                fillContractorControls();
                _vendorChangedId = int.Parse(dgVendors.CurrentRow.Cells[0].Value.ToString());
                btUpdateVendor.Enabled = true;
            }
        }

        private void btAddNewVendor_Click(object sender, EventArgs e)
        {
            if (validateVendorData())
            {
                String deleted = "0";
                if (cbDeleted.Checked)
                    deleted = "1";
                DataRow newRow = _vendorsDs.Tables[0].NewRow();
                newRow["Name"] = txtName.Text;
                newRow["E-mail"] = txtEmail.Text;
                newRow["Phone"] = txtPhoneNo.Text;
                newRow["Mobile"] = txtMobileNo.Text;
                newRow["Location"] = txtLocation.Text;                
                newRow["IsDeleted"] = deleted;

                _vendorsDs.Tables[0].Rows.Add(newRow);
                dgVendors.Refresh();

                clearData();
                //gbContractorDetails.Enabled = false;
                btUpdateVendor.Enabled = false;
            }
            else
            {
                MessageBox.Show("Please fill all necessary data", "Missing data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                highlitghtMissingContractorData();
            }
        }

        private void btUpdateVendor_Click(object sender, EventArgs e)
        {
            if (validateVendorData())
            {
                String deleted = "0";
                if (cbDeleted.Checked)
                    deleted = "1";

                DataRow[] rowsTab = _vendorsDs.Tables[0].Select("ID = " + _vendorChangedId);

                rowsTab[0]["Name"] = txtName.Text;
                rowsTab[0]["E-mail"] = txtEmail.Text;
                rowsTab[0]["Phone"] = txtPhoneNo.Text;
                rowsTab[0]["Mobile"] = txtMobileNo.Text;
                rowsTab[0]["Location"] = txtLocation.Text;                
                rowsTab[0]["IsDeleted"] = deleted;

                dgVendors.Refresh();
                clearData();
            }
            else
            {
                MessageBox.Show("Please fill all necessary data", "Missing data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                highlitghtMissingContractorData();
            }
        }

        private bool validateVendorData()
        {
            bool positiveValidated = true;
            //checking if all but Address Line 2 text fields have any data
            if (String.IsNullOrEmpty(txtName.Text) || String.IsNullOrEmpty(txtEmail.Text) || String.IsNullOrEmpty(txtPhoneNo.Text) ||
                String.IsNullOrEmpty(txtMobileNo.Text) || String.IsNullOrEmpty(txtLocation.Text))
                positiveValidated = false;

            return positiveValidated;
        }

        private bool checkIfThereIsDataLeft()
        {
            bool isDataLeft = false;
            if (!(String.IsNullOrEmpty(txtName.Text) && String.IsNullOrEmpty(txtEmail.Text) && String.IsNullOrEmpty(txtPhoneNo.Text) &&
                    String.IsNullOrEmpty(txtMobileNo.Text) && String.IsNullOrEmpty(txtLocation.Text)))
                isDataLeft = true;

            return isDataLeft;
        }

        private void highlitghtMissingContractorData()
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

            if (String.IsNullOrEmpty(txtEmail.Text))
            {
                lbEmail.Font = new Font(lbEmail.Font, FontStyle.Bold);
                lbEmail.ForeColor = Color.Red;
            }
            else
            {
                lbEmail.Font = new Font(lbEmail.Font, FontStyle.Regular);
                lbEmail.ForeColor = Color.Black;
            }

            if (String.IsNullOrEmpty(txtPhoneNo.Text))
            {
                lbPhone.Font = new Font(lbPhone.Font, FontStyle.Bold);
                lbPhone.ForeColor = Color.Red;
            }
            else
            {
                lbPhone.Font = new Font(lbPhone.Font, FontStyle.Regular);
                lbPhone.ForeColor = Color.Black;
            }

            if (String.IsNullOrEmpty(txtMobileNo.Text))
            {
                lbMobile.Font = new Font(lbMobile.Font, FontStyle.Bold);
                lbMobile.ForeColor = Color.Red;
            }
            else
            {
                lbMobile.Font = new Font(lbMobile.Font, FontStyle.Regular);
                lbMobile.ForeColor = Color.Black;
            }

            if (String.IsNullOrEmpty(txtLocation.Text))
            {
                lbLocation.Font = new Font(lbLocation.Font, FontStyle.Bold);
                lbLocation.ForeColor = Color.Red;
            }
            else
            {
                lbLocation.Font = new Font(lbLocation.Font, FontStyle.Regular);
                lbLocation.ForeColor = Color.Black;
            }         
        }

        //private void setupContractorColumnWidth()
        //{

        //}

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

        private void clearData()
        {
            txtName.Text = "";
            txtLocation.Text = "";            
            txtPhoneNo.Text = "";
            txtMobileNo.Text = "";
            txtEmail.Text = "";
            cbDeleted.Checked = false;
        }

        private void btSaveVendors_Click(object sender, EventArgs e)
        {
            if (_vendorsDs.HasChanges())
            {
                _vendorAdapter.Update(_vendorsDs);
                this.Close();
            }
        }

        private void txtNameFilter_TextChanged(object sender, EventArgs e)
        {
            DataView dv = _vendorsDs.Tables[0].DefaultView;
            if (cbShowDeleted.Checked)
                dv.RowFilter = "Name LIKE '*" + txtNameFilter.Text + "*'";
            else
                dv.RowFilter = "isDeleted = 0 and Name LIKE '*" + txtNameFilter.Text + "*'";
        }

        private void cbShowDeleted_CheckStateChanged(object sender, EventArgs e)
        {
            DataView dv = _vendorsDs.Tables[0].DefaultView;
            if (cbShowDeleted.Checked)
                dv.RowFilter = "Name LIKE '*" + txtNameFilter.Text + "*'";
            else
                dv.RowFilter = "isDeleted = 0 and Name LIKE '*" + txtNameFilter.Text + "*'";
        }

        private void frmVendorManagement_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Keys)e.KeyValue == Keys.Escape)
            {
                if (checkIfThereIsDataLeft())
                {
                    if (MessageBox.Show("There is some data left in the fields. Do you want to close window anyway?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                        this.Close();
                }
                else
                    this.Close();
            }
        }    
           
    }
}
