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

        public static string postComments(Comment objComment)
        {
            AboutBox frmAbout = new AboutBox();
            float currentVersion = float.Parse(frmAbout.AssemblyVersion.Substring(0, 3));
            string sVersion = frmAbout.AssemblyVersion.Substring(0, 3);

            string postData = "name=" + objComment.Name + "&comment=" + objComment.Comments + "&email=" + objComment.Email + "&version=" + sVersion + "&rating=" + objComment.Rating;
            string result = NetworkUtil.generatePostCall( ApplicationConstant.WEB_URL + "/web/registerComments.php", postData);
            return result;

        }

        public static string reportABug(Bug objBug)
        {
            AboutBox frmAbout = new AboutBox();
            float currentVersion = float.Parse(frmAbout.AssemblyVersion.Substring(0, 3));
            string sVersion = frmAbout.AssemblyVersion.Substring(0, 3);

            string postData = "title=" + objBug.Title + "&description=" + objBug.Description + "&module=" + objBug.Module + "&serverity=" + objBug.Serverity + "&version=" + sVersion;
            string result = NetworkUtil.generatePostCall( ApplicationConstant.WEB_URL + "/web/reportABug.php", postData);
            return result;

        }
        public static void RegisterClient()
        {
            string info = UpdateDAL.getSystemInfo();
            string result = NetworkUtil.generatePostCall( ApplicationConstant.WEB_URL + "/web/registerClient.php", info);
            
        }

        public static void checkForUpdates()
        {
            AboutBox frmAbout = new AboutBox();
            float currentVersion = float.Parse(frmAbout.AssemblyVersion.Substring(0, 3));

            string postData = "getClient";
            string result = NetworkUtil.generatePostCall(ApplicationConstant.WEB_URL + "/web/getLatestVersion.php", postData);
            float serverVersion = float.Parse(result);

            if (serverVersion > currentVersion)
            {
                MessageBox.Show("New Version:" + serverVersion + " is available");
                System.Diagnostics.Process.Start( ApplicationConstant.SOURCE_FORGE_URL );
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
