using System;
using System.Collections.Generic;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Shop_Management_Solution.lib.util;

namespace Shop_Management_Solution
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        public static void MoveWithReplace(string sourceFileName, string destFileName)
        {

            //first, delete target file if exists, as File.Move() does not support overwrite
            if (File.Exists(destFileName))
            {
                File.Delete(destFileName);
            }

            File.Move(sourceFileName, destFileName);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string currencySymbol = txtCurrencySybmol.Text;
            string shopName = txtShopName.Text;
            string shopAddress = txtAddress.Text;

            try
            {
                if (String.IsNullOrEmpty(currencySymbol) || String.IsNullOrEmpty(currencySymbol))
                {
                    MessageBox.Show(this, "Fill in currency symbol", "Error: Settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (String.IsNullOrEmpty(shopName) || String.IsNullOrEmpty(shopName))
                {
                    MessageBox.Show(this, "Fill in Shop name", "Error: Settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (String.IsNullOrEmpty(shopAddress) || String.IsNullOrEmpty(shopAddress))
                {
                    MessageBox.Show(this, "Fill in Shop Address", "Error: Settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    bool isInserted = ConfigurationDAL.UpdateConfigurationByName(ConfigurationDAL.CURRENCY, currencySymbol);
                    isInserted = ConfigurationDAL.UpdateConfigurationByName(ConfigurationDAL.SHOPNAME, shopName);
                    isInserted = ConfigurationDAL.UpdateConfigurationByName(ConfigurationDAL.ADDRESS, shopAddress); 

                    string defaultFileName = System.Reflection.Assembly.GetExecutingAssembly().Location;
                    string directory = System.IO.Path.GetDirectoryName(defaultFileName);
                    string defaultPath = directory + "\\Images\\Header.JPG";

                    string currentFile = txtFileImage.Text.ToString();

                    if ( !defaultPath.Equals(currentFile) )
                    {
                        if (File.Exists(defaultPath))
                        {
                            File.Delete(defaultPath);
                        }

                        Bitmap newImage = new Bitmap(currentFile); // ImageUtilities.ResizeImage(new Bitmap(currentFile), 220, 33);
                        ImageUtilities.SaveJpeg(defaultPath, newImage, 100);

                    }
                    
                    if (isInserted)
                    {
                        this.Close();
                        MessageBox.Show(this, "Settings updated successfully.", "Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(this, "Settings updation  failed.", "Error:Settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Error: Settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            txtCurrencySybmol.Text = ConfigurationDAL.GetCurrentCurrency();
            txtShopName.Text = ConfigurationDAL.GetShopName();
            txtAddress.Text = ConfigurationDAL.GetCurrentAddress();

            try
            {
                string defaultFileName = System.Reflection.Assembly.GetExecutingAssembly().Location;
                string directory = System.IO.Path.GetDirectoryName(defaultFileName);
                string path = directory+"\\Images\\Header.JPG";

                picHeaderImage.Image = ImageUtilities.ResizeImage(new Bitmap(path), 280, 70);
                txtFileImage.Text = path;
            }
            catch (Exception ex)
            {
                DebugUtil.genericShow(ex.Message.ToString());
            }
            
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            

            // open file dialog
            OpenFileDialog open = new OpenFileDialog();

            // image filters
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";

            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box

                picHeaderImage.Image = ImageUtilities.ResizeImage(new Bitmap(open.FileName), 280, 70); //new Bitmap(open.FileName);

                // image file path
                txtFileImage.Text = open.FileName;
            } 
        }


    }
}
