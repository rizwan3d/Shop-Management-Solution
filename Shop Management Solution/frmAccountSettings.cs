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
    public partial class frmAccountSettings : Form
    {
        public frmAccountSettings()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           try
           {
                

                string existingPassword = ConfigurationDAL.GetAdministratorPassword();
                string currentPassword = SecuirtyUtil.encodePassword(txtCurrentPassword.Text);

                string newPassword = txtNewPassword.Text;
                string confirmPassword = txtConfirmPassword.Text;

                newPassword = SecuirtyUtil.encodePassword(newPassword);
                MessageBox.Show(this, newPassword, "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
                if (string.IsNullOrEmpty(txtCurrentPassword.Text))
                {
                    throw new Exception("Missing current password");
                }
                else if(currentPassword == existingPassword)
                {
                    if (newPassword == confirmPassword)
                    {
                        newPassword = SecuirtyUtil.encodePassword(newPassword);

                        ConfigurationDAL.UpdateConfigurationByName(ConfigurationDAL.ADMINISTRATOR, newPassword);
                        MessageBox.Show(this, "Password changed successfully", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        throw new Exception("New Password and Confirm Password Mismatch");
                    }
                }
                else
                {
                    throw new Exception("Incorrect Password");
                }
                
           }
           catch (Exception ex)
           {
                 MessageBox.Show(this, ex.Message.ToString(), "Error: Sale Item(s)", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
