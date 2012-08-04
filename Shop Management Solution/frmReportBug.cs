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
    public partial class frmReportBug : Form
    {
        public frmReportBug()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateReportBugData())
                {
                    Bug objBug = new Bug();
                    objBug.Title = txtTitle.Text.ToString();
                    objBug.Description = txtDescription.Text.ToString();
                    objBug.Module = cmbModule.Text.ToString();
                    objBug.Serverity = cmbSeverity.Text.ToString();
                    string result = UpdateDAL.reportABug(objBug);
                    MessageBox.Show(this, result, "Report a bug", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    highlitghtMissingReportBugData();
                }
                
            }
            catch (Exception ex)
            {
                ///
            }
            
        }

        private bool validateReportBugData()
        {
            bool positiveValidated = true;
            //checking if all but Address Line 2 text fields have any data
            if (String.IsNullOrEmpty(txtTitle.Text) || String.IsNullOrEmpty(txtDescription.Text) || String.IsNullOrEmpty(cmbModule.Text) ||
                String.IsNullOrEmpty(cmbSeverity.Text) )
                positiveValidated = false;

            return positiveValidated;
        }

        private bool checkIfThereIsDataLeft()
        {
            bool isDataLeft = false;
            if (!(String.IsNullOrEmpty(txtTitle.Text) && String.IsNullOrEmpty(txtDescription.Text) && String.IsNullOrEmpty(cmbModule.Text) &&
                    String.IsNullOrEmpty(cmbSeverity.Text)))
                isDataLeft = true;

            return isDataLeft;
        }

        private void highlitghtMissingReportBugData()
        {
            if (String.IsNullOrEmpty(txtTitle.Text))
            {
                lblTitle.Font = new Font(lblTitle.Font, FontStyle.Bold);
                lblTitle.ForeColor = Color.Red;
            }
            else
            {
                lblTitle.Font = new Font(lblTitle.Font, FontStyle.Regular);
                lblTitle.ForeColor = Color.Black;
            }

            if (String.IsNullOrEmpty(txtDescription.Text))
            {

                lblDescription.Font = new Font(lblDescription.Font, FontStyle.Bold);
                lblDescription.ForeColor = Color.Red;
            }
            else
            {
                lblDescription.Font = new Font(lblDescription.Font, FontStyle.Regular);
                lblDescription.ForeColor = Color.Black;
            }

            if (String.IsNullOrEmpty(cmbModule.Text))
            {

                lblModule.Font = new Font(lblModule.Font, FontStyle.Bold);
                lblModule.ForeColor = Color.Red;
            }
            else
            {
                lblModule.Font = new Font(lblModule.Font, FontStyle.Regular);
                lblModule.ForeColor = Color.Black;
            }

            if (String.IsNullOrEmpty(cmbSeverity.Text))
            {
                lblSeverity.Font = new Font(lblSeverity.Font, FontStyle.Bold);
                lblSeverity.ForeColor = Color.Red;
            }
            else
            {
                lblSeverity.Font = new Font(lblSeverity.Font, FontStyle.Regular);
                lblSeverity.ForeColor = Color.Black;
            }
        }
    }
}
