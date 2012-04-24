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
        private bool _contractorPreInsertMode = true;
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
                _contractorPreInsertMode = false;
                gbContractorDetails.Enabled = true;
                btUpdateContractor.Enabled = true;
                //foreach (DataGridViewCell item in dgContractors.CurrentRow.Cells)
                //{
                //    MessageBox.Show(item.Value.ToString());
                //}
                //sprawdzanie czy uzytkownik nie byl w trakcie wprowadzania jakichs danych- czyli insert mode + spr czy textboxy cos maja
            }
        }

        private void btAddNew_Click(object sender, EventArgs e)
        {
            if (_contractorPreInsertMode)
            {
                gbContractorDetails.Enabled = true;
                _contractorPreInsertMode = false;
                txtName.Focus();
            }
            else
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

                    btClearContractor_Click(this, null);
                    _contractorPreInsertMode = true;
                    btAddNewContractor.Text = "Add New";
                    gbContractorDetails.Enabled = false;
                    btUpdateContractor.Enabled = false;
                }
                else
                    MessageBox.Show("Please fill all necessary data", "Missing data", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btUpdateContractor_Click(object sender, EventArgs e)
        {
            String deleted = "0";
            if (cbDeleted.Checked)
                deleted = "1";
            //nie nowy lecz istniejacy!!! (w oparciu o ID zapisane w zmiennej!)
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
            
            //_contractorsDs.Tables[0].Rows.Add(newRow);
            dgContractors.Refresh();
        }

        private bool validateContractorData()
        {
            bool positiveValidated = true;
            if (String.IsNullOrEmpty(txtName.Text) || String.IsNullOrEmpty(txtEmail.Text) || String.IsNullOrEmpty(txtPhoneNo.Text) ||
                String.IsNullOrEmpty(txtMobileNo.Text) || String.IsNullOrEmpty(txtAddrLine1.Text) || String.IsNullOrEmpty(txtPostCode.Text) ||
                String.IsNullOrEmpty(txtCity.Text))
                positiveValidated = false;

            return positiveValidated;
        }

        private void highlitghtMissingContractorData()
        {

        }

        private void setupContractorColumnWidth()
        {

        }

        private void btClearContractor_Click(object sender, EventArgs e)
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
                //_contractorsDs.AcceptChanges();
//                _contractorsDs.
                _contractorAdapter.Update(_contractorsDs);
            }
        }

        private void txtNameFilter_TextChanged(object sender, EventArgs e)
        {
                int showDeleted = 0;
                if (cbDeleted.Checked)
                    showDeleted = 1;
                DataView dv = _contractorsDs.Tables[0].DefaultView;
                dv.RowFilter = "isDeleted = 0 and Name LIKE '*" + txtNameFilter.Text + "*'";
            
        }
    }
}
