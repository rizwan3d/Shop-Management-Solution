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
    public partial class frmContractorManagement : Form
    {
        private DataSet _contractorsDs;
        private int _contractorChangedId;
        private OleDbDataAdapter _contractorAdapter;

        public frmContractorManagement()
        {
            InitializeComponent();
        }

        private void ContractorManagement_Load(object sender, EventArgs e)
        {
            ContractorDAL contractor = new ContractorDAL();
            _contractorsDs = contractor.getContractorsPresentationDs();
            DataView dv = _contractorsDs.Tables[0].DefaultView;
            dv.RowFilter = "IsDeleted = 0";
            dgContractors.DataSource = dv;
            combCountries.DataSource = CountryDAL.GetCountries();
            btAddNewContractor.Focus();
            _contractorAdapter = contractor.getContractorAdapter();
        }

        private void fillContractorControls()
        {
            txtName.Text = dgContractors.CurrentRow.Cells["clName"].Value.ToString();
            txtAddrLine1.Text = dgContractors.CurrentRow.Cells["clAddressLine1"].Value.ToString();
            txtAddrLine2.Text = dgContractors.CurrentRow.Cells["clAddressLine2"].Value.ToString();
            combCountries.SelectedValue = dgContractors.CurrentRow.Cells["clCountry"].Value.ToString();
            txtPostCode.Text = dgContractors.CurrentRow.Cells["clPostCode"].Value.ToString();
            txtCity.Text = dgContractors.CurrentRow.Cells["clCity"].Value.ToString();
            txtPhoneNo.Text = dgContractors.CurrentRow.Cells["clPhone"].Value.ToString();
            txtMobileNo.Text = dgContractors.CurrentRow.Cells["clMobile"].Value.ToString();
            txtEmail.Text = dgContractors.CurrentRow.Cells["clEmail"].Value.ToString();
            cbDeleted.Checked = dgContractors.CurrentRow.Cells["clIsDeleted"].Value.ToString() == "1";

        }

        private void dgContractors_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex >= 0) && (e.RowIndex >= 0))
            {
                fillContractorControls();
                _contractorChangedId = int.Parse(dgContractors.CurrentRow.Cells[0].Value.ToString());
                btUpdateContractor.Enabled = true;
            }
        }

        private void btAddNew_Click(object sender, EventArgs e)
        {

            if (validateContractorData())
            {
                String deleted = "0";
                if (cbDeleted.Checked)
                    deleted = "1";
                DataRow newRow = _contractorsDs.Tables[0].NewRow();
                newRow["Name"] = txtName.Text;
                newRow["E-mail"] = txtEmail.Text;
                newRow["Phone"] = txtPhoneNo.Text;
                newRow["Mobile"] = txtMobileNo.Text;
                newRow["AddressLine1"] = txtAddrLine1.Text;
                newRow["AddressLine2"] = txtAddrLine2.Text;
                newRow["PostCode"] = txtPostCode.Text;
                newRow["Country"] = combCountries.SelectedValue.ToString();
                newRow["CountryName"] = combCountries.SelectedText.ToString();
                newRow["City"] = txtCity.Text;
                newRow["IsDeleted"] = deleted;

                _contractorsDs.Tables[0].Rows.Add(newRow);
                dgContractors.Refresh();

                clearData();
                //gbContractorDetails.Enabled = false;
                btUpdateContractor.Enabled = false;
            }
            else
            {
                MessageBox.Show("Please fill all necessary data", "Missing data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                highlitghtMissingContractorData();
            }

        }

        private void btUpdateContractor_Click(object sender, EventArgs e)
        {
            if (validateContractorData())
            {
                String deleted = "0";
                if (cbDeleted.Checked)
                    deleted = "1";

                DataRow[] rowsTab = _contractorsDs.Tables[0].Select("ID = " + _contractorChangedId);

                rowsTab[0]["Name"] = txtName.Text;
                rowsTab[0]["E-mail"] = txtEmail.Text;
                rowsTab[0]["Phone"] = txtPhoneNo.Text;
                rowsTab[0]["Mobile"] = txtMobileNo.Text;
                rowsTab[0]["AddressLine1"] = txtAddrLine1.Text;
                rowsTab[0]["AddressLine2"] = txtAddrLine2.Text;
                rowsTab[0]["PostCode"] = txtPostCode.Text;
                rowsTab[0]["Country"] = combCountries.SelectedValue.ToString();
                rowsTab[0]["CountryName"] = combCountries.SelectedText.ToString();
                rowsTab[0]["City"] = txtCity.Text;
                rowsTab[0]["IsDeleted"] = deleted;

                dgContractors.Refresh();
                clearData();
            }
            else
            {
                MessageBox.Show("Please fill all necessary data", "Missing data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                highlitghtMissingContractorData();
            }
        }

        private bool validateContractorData()
        {
            bool positiveValidated = true;
            //checking if all but Address Line 2 text fields have any data
            if (String.IsNullOrEmpty(txtName.Text) || String.IsNullOrEmpty(txtEmail.Text) || String.IsNullOrEmpty(txtPhoneNo.Text) ||
                String.IsNullOrEmpty(txtMobileNo.Text) || String.IsNullOrEmpty(txtAddrLine1.Text) ||
                String.IsNullOrEmpty(txtPostCode.Text) || String.IsNullOrEmpty(txtCity.Text))
                positiveValidated = false;

            return positiveValidated;
        }

        private bool checkIfThereIsDataLeft()
        {
            bool isDataLeft = false;
            if (!(String.IsNullOrEmpty(txtName.Text) && String.IsNullOrEmpty(txtEmail.Text) && String.IsNullOrEmpty(txtPhoneNo.Text) &&
                    String.IsNullOrEmpty(txtMobileNo.Text) && String.IsNullOrEmpty(txtAddrLine1.Text) && String.IsNullOrEmpty(txtAddrLine2.Text) &&
                    String.IsNullOrEmpty(txtPostCode.Text) && String.IsNullOrEmpty(txtCity.Text)))
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

            if (String.IsNullOrEmpty(txtAddrLine1.Text))
            {
                lbAddrLine1.Font = new Font(lbAddrLine1.Font, FontStyle.Bold);
                lbAddrLine1.ForeColor = Color.Red;
            }
            else
            {
                lbAddrLine1.Font = new Font(lbAddrLine1.Font, FontStyle.Regular);
                lbAddrLine1.ForeColor = Color.Black;
            }

            if (String.IsNullOrEmpty(txtPostCode.Text))
            {
                lbPostCode.Font = new Font(lbPostCode.Font, FontStyle.Bold);
                lbPostCode.ForeColor = Color.Red;
            }
            else
            {
                lbPostCode.Font = new Font(lbPostCode.Font, FontStyle.Regular);
                lbPostCode.ForeColor = Color.Black;
            }

            if (String.IsNullOrEmpty(txtCity.Text))
            {
                lbCity.Font = new Font(lbCity.Font, FontStyle.Bold);
                lbCity.ForeColor = Color.Red;
            }
            else
            {
                lbCity.Font = new Font(lbCity.Font, FontStyle.Regular);
                lbCity.ForeColor = Color.Black;
            }
        }

        //private void setupContractorColumnWidth()
        //{

        //}

        private void btClearContractor_Click(object sender, EventArgs e)
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
            txtAddrLine1.Text = "";
            txtAddrLine2.Text = "";
            combCountries.SelectedIndex = 0;
            txtPostCode.Text = "";
            txtCity.Text = "";
            txtPhoneNo.Text = "";
            txtMobileNo.Text = "";
            txtEmail.Text = "";
            cbDeleted.Checked = false;
        }

        private void btSaveContractors_Click(object sender, EventArgs e)
        {
            if (_contractorsDs.HasChanges())
            {
                _contractorAdapter.Update(_contractorsDs);
                this.Close();
            }
        }

        private void txtNameFilter_TextChanged(object sender, EventArgs e)
        {
            DataView dv = _contractorsDs.Tables[0].DefaultView;
            if (cbShowDeleted.Checked)
                dv.RowFilter = "Name LIKE '*" + txtNameFilter.Text + "*'";
            else
                dv.RowFilter = "isDeleted = 0 and Name LIKE '*" + txtNameFilter.Text + "*'";

        }

        private void cbShowDeleted_CheckStateChanged(object sender, EventArgs e)
        {
            DataView dv = _contractorsDs.Tables[0].DefaultView;
            if (cbShowDeleted.Checked)
                dv.RowFilter = "Name LIKE '*" + txtNameFilter.Text + "*'";
            else
                dv.RowFilter = "isDeleted = 0 and Name LIKE '*" + txtNameFilter.Text + "*'";
            
        }

        private void frmContractorManagement_KeyDown(object sender, KeyEventArgs e)
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
