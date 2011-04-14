using System.Configuration;
using System;
using System.Data.OleDb;
using System.Windows.Forms;  
using System.Data;
using System.Collections.Generic;

using System.Text;

namespace Shop_Management_Solution.lib.util
{
    class DBUtil
    {
        private static string CONNECTION_STRING = "Shop_Management_Solution.Properties.Settings.ExBrainConnectionString";

        public static string GetConnectionString()
        {
            
            //variable to hold our connection string for returning it  
             string strReturn = "";

            //check to see if the user provided a connection string name  
             //this is for if your application has more than one connection string  

            //if (!string.IsNullOrEmpty(strConnection)) //a connection string name was provided  
            //{

                //get the connection string by the name provided  
             
            //    strReturn = ConfigurationManager.ConnectionStrings[strConnection].ConnectionString;
           // }

            //else //no connection string name was provided  
            //{
                //get the default connection string  
              //  strReturn = ConfigurationManager.ConnectionStrings["Shop_Management_Solution.Properties.Settings.ExBrainConnectionString"].ConnectionString;
            //}

            //return the connection string to the calling method  

            strReturn = ConfigurationManager.ConnectionStrings[DBUtil.CONNECTION_STRING].ConnectionString;
            return strReturn;

        }

        public static void HandleConnection(OleDbConnection oCn)
        {
            //do a switch on the state of the connection
            switch (oCn.State)
            {
                case ConnectionState.Open: //the connection is open
                    //close then re-open
                    oCn.Close();
                    oCn.Open();
                    break;
                case ConnectionState.Closed: //connection is open
                    //open the connection
                    oCn.Open();
                    break;
                default:
                    oCn.Close();
                    oCn.Open();
                    break;
            }
        }

        public static long GetMaxID(String idName, String tableName)
        {
            long maxId = -1;
            OleDbConnection connectionString = new OleDbConnection(DBUtil.GetConnectionString());
            string query = "SELECT MAX(" + idName + ") As MaxID FROM " + tableName;
           
            OleDbDataAdapter DataAdapter = new OleDbDataAdapter(query, connectionString);
            DataSet ds = new DataSet();

            try
            {

                DataAdapter.Fill(ds);

                maxId = long.Parse(ds.Tables[0].Rows[0][0].ToString());
                return maxId;

            }

            catch (Exception ex)
            {
                throw new Exception ("Failed to Execute :"+query+ "\n"+ex.Message);

            }           

        }

        public static long GetNextID(String idName, String tableName)
        {
            long nextId = -1;

            long currentId = DBUtil.GetMaxID(idName, tableName);

            nextId = currentId + 1;

            return nextId;
        }

        public static BindingSource GetBindingSource(OleDbCommand cmd, OleDbConnection conn)
        {
            //declare our binding source
            BindingSource oBindingSource = new BindingSource();
            cmd.Connection = conn;
            // Create a new data adapter based on the specified query.
            OleDbDataAdapter daGet = new OleDbDataAdapter(cmd);
            // Populate a new data table and bind it to the BindingSource.
            DataTable dtGet = new DataTable();
            //set the timeout of the OleDbCommandObject
            cmd.CommandTimeout = 240;
            dtGet.Locale = System.Globalization.CultureInfo.InvariantCulture;
            try
            {
                //fill the DataTable with the OleDbDataAdapter
                daGet.Fill(dtGet);
            }
            //check for errors
            catch (Exception ex)
            {
                throw new Exception("Failed to Execute :" + cmd.ToString() + "\n" + ex.Message);
                return null;
            }
            //set the DataSource for the BindingSource to the DataTable
            oBindingSource.DataSource = dtGet;
            //return the BindingSource to the calling method or control
            return oBindingSource;
        }

        
    }
}
