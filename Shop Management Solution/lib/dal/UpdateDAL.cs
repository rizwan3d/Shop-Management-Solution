using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Shop_Management_Solution.lib.util;

namespace Shop_Management_Solution.lib.dal
{
    class UpdateDAL
    {
        public static void RegisterClient()
        {
            string info = UpdateDAL.getSystemInfo();
            string result = NetworkUtil.generatePostCall("http://solution.xtrawebapps.com/web/registerClient.php", info);
            
        }

        public static void checkForUpdates()
        {
            AboutBox frmAbout = new AboutBox();
            float currentVersion = float.Parse(frmAbout.AssemblyVersion.Substring(0, 3));

            string postData = "getClient";
            string result = NetworkUtil.generatePostCall("http://solution.xtrawebapps.com/web/getLatestVersion.php", postData);
            float serverVersion = float.Parse(result);

            if (serverVersion > currentVersion)
            {
                MessageBox.Show("New Version:" + serverVersion + " is available");
                System.Diagnostics.Process.Start("https://sourceforge.net/projects/shopmanagement/files/latest/download");
            }
            else
            {
                MessageBox.Show("You already have latest version", "Updates");
            }


        }

        private static string getSystemInfo()
        {
            string ip = NetworkUtil.getIPAddresses();
            string mac = NetworkUtil.getMacAddress();
            string machine = System.Environment.MachineName.ToString();
            string userName = System.Environment.UserName.ToString();
            AboutBox frmAbout = new AboutBox();
            float currentVersion = float.Parse(frmAbout.AssemblyVersion.Substring(0, 3));
            string sVersion = frmAbout.AssemblyVersion.Substring(0, 3);

            string postData = "client=" + ip + "&mac=" + mac + "&machine=" + machine + "&user=" + userName + "&version=" + sVersion;
            return postData;
        }
    }
}
