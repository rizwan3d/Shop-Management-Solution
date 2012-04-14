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
    public partial class frmAuthenticate : Form
    {
        private Boolean authenticated= false;

        public Boolean isAuthenticated
        {
            get { return authenticated; }
        }

        public frmAuthenticate()
        {
            InitializeComponent();
            lblAuthenticationStatus.Hide();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            String username = txtUsername.Text;
            String password = SecuirtyUtil.encodePassword(txtPassword.Text);
            String currentPassword = ConfigurationDAL.GetAdministratorPassword();

            if (username == ConfigurationDAL.ADMINISTRATOR)
            {
                if (password == currentPassword)
                {
                    gpAuthenticate.Hide();
                    lblAuthenticationStatus.Text = "Authentication Passed";
                    lblAuthenticationStatus.Show();
                    //frmSearchSales frmSearch = new frmSearchSales();
                    //frmSearch.ShowDialog();
                    authenticated = true;

                    this.Close();
                    
                }
                else
                {
                    MessageBox.Show(this, "Incorrect Username or Password", "Login Form", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    //this.Close();
                }
            }
            else
            {
                MessageBox.Show(this, "Incorrect Username or Password", "Login Form", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //this.Close();
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmAuthenticate_Load(object sender, EventArgs e)
        {

        }

        private void lblAuthenticationStatus_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btn_Login_Click(txtPassword, null);
        }
    }
}
