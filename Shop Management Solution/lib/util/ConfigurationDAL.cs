using System.Configuration;
using System;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Shop_Management_Solution.lib.util
{
    class ConfigurationDAL
    {
        public static string CURRENCY = "Currency";
        public static string ADMINISTRATOR = "Administrator";
        public static string SHOPNAME = "ShopName";

        public static string GetCurrentCurrency()
        {
            return ConfigurationDAL.GetConfigurationByName(ConfigurationDAL.CURRENCY);        
        }
        public static string GetAdministratorPassword()
        {
            return ConfigurationDAL.GetConfigurationByName(ConfigurationDAL.ADMINISTRATOR);
        }
        public static string GetShopName()
        {
            return ConfigurationDAL.GetConfigurationByName(ConfigurationDAL.SHOPNAME);
        }

        public static string GetConfigurationByName(string configurationName)
        {
            string keyValue = "";
            OleDbConnection connectionString = new OleDbConnection(DBUtil.GetConnectionString());
            string query = "SELECT Config_Value FROM Configuration WHERE Config_Name = '" + configurationName+ "'";

            OleDbDataAdapter DataAdapter = new OleDbDataAdapter(query, connectionString);
            DataSet ds = new DataSet();
            try
            {
                DataAdapter.Fill(ds);
                keyValue = ds.Tables[0].Rows[0][0].ToString();
                return keyValue;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to Execute :" + query + "\n" + ex.Message);
            }
        }

        public static bool UpdateConfigurationByName(string configurationName, string configurationValue)
        {
        
            OleDbConnection cnInsert = new OleDbConnection(DBUtil.GetConnectionString());
            OleDbCommand cmdInsert = new OleDbCommand();
            string query = "UPDATE Configuration SET Config_Name = @name, Config_Value = @value WHERE Config_Name = @name";
            
            int iSqlStatus;

            //Clear any parameters
            cmdInsert.Parameters.Clear();
            try
            {
                //Set the OleDbCommand Object Properties

                //Tell it what to execute
                cmdInsert.CommandText = query;
                //Tell it its a text query
                cmdInsert.CommandType = CommandType.Text;

                cmdInsert.Parameters.AddWithValue("@name", configurationName);
                cmdInsert.Parameters.AddWithValue("@value", configurationValue);

                //Set the connection of the object
                cmdInsert.Connection = cnInsert;


                //Now take care of the connection
                DBUtil.HandleConnection(cnInsert);
                //Set the iSqlStatus to the ExecuteNonQuery 
                //status of the insert (0 = failed, 1 = success)
                iSqlStatus = cmdInsert.ExecuteNonQuery();

                //Now check the status
                if (iSqlStatus == 0)
                {
                    //DO your failed messaging here
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                //Now close the connection
                DBUtil.HandleConnection(cnInsert);
            }
        }
    }
}
