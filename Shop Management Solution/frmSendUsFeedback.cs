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
    public partial class frmSendUsFeedback : Form
    {
        public frmSendUsFeedback()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateCommentData())
                {
                    Comment objComment = new Comment();
                    objComment.Name = txtName.Text.ToString();
                    objComment.Email = txtEmail.Text.ToString();
                    objComment.Comments = txtComments.Text.ToString();
                    string result = UpdateDAL.postComments(objComment);
                    MessageBox.Show(this, result, "Send us feedback", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    highlitghtMissingCommentData();
                }
                
            }
            catch (Exception ex)
            {
                ///
            }
        }
        
        private bool validateCommentData()
        {
            bool positiveValidated = true;
            //checking if all but Address Line 2 text fields have any data
            if (String.IsNullOrEmpty(txtName.Text) || String.IsNullOrEmpty(txtEmail.Text) || String.IsNullOrEmpty(txtComments.Text))
                positiveValidated = false;

            return positiveValidated;
        }

        private bool checkIfThereIsDataLeft()
        {
            bool isDataLeft = false;
            if (!(String.IsNullOrEmpty(txtName.Text) && String.IsNullOrEmpty(txtEmail.Text) && String.IsNullOrEmpty(txtComments.Text)))
                isDataLeft = true;

            return isDataLeft;
        }

        private void highlitghtMissingCommentData()
        {
            if (String.IsNullOrEmpty(txtName.Text))
            {
                lblName.Font = new Font(lblName.Font, FontStyle.Bold);
                lblName.ForeColor = Color.Red;
            }
            else
            {
                lblName.Font = new Font(lblName.Font, FontStyle.Regular);
                lblName.ForeColor = Color.Black;
            }

            if (String.IsNullOrEmpty(txtEmail.Text))
            {

                lblEmail.Font = new Font(lblEmail.Font, FontStyle.Bold);
                lblEmail.ForeColor = Color.Red;
            }
            else
            {
                lblEmail.Font = new Font(lblEmail.Font, FontStyle.Regular);
                lblEmail.ForeColor = Color.Black;
            }

            if (String.IsNullOrEmpty(txtComments.Text))
            {

                lblComments.Font = new Font(lblComments.Font, FontStyle.Bold);
                lblComments.ForeColor = Color.Red;
            }
            else
            {
                lblComments.Font = new Font(lblComments.Font, FontStyle.Regular);
                lblComments.ForeColor = Color.Black;
            }

           
        }
    }
}
