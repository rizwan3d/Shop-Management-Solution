using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data;
using Shop_Management_Solution.lib.util;

namespace Shop_Management_Solution.lib.dal
{
    class VendorDAL
    {
        public bool InsertVendor(Vendor node)
        {
            OleDbConnection cnInsert = new OleDbConnection(DBUtil.GetConnectionString());
            OleDbCommand cmdInsert = new OleDbCommand();
            string query =  "INSERT INTO Vendor(Name,E-mail,Mobile,Phone,Location,Is_Deleted)" + 
                            "VALUES (@name,@email,@mobile,@phone,@location,0) ";
            
            int iSqlStatus;
            cmdInsert.Parameters.Clear();

            try
            {
                cmdInsert.CommandText = query;
                cmdInsert.CommandType = CommandType.Text;


                cmdInsert.Parameters.AddWithValue("@name", node.Name);
                cmdInsert.Parameters.AddWithValue("@email", node.Email);
                cmdInsert.Parameters.AddWithValue("@mobile", node.MobileNo);
                cmdInsert.Parameters.AddWithValue("@phone", node.ContactNo);
                cmdInsert.Parameters.AddWithValue("@location", node.Location);

                cmdInsert.Connection = cnInsert;
                DBUtil.HandleConnection(cnInsert);
                iSqlStatus = cmdInsert.ExecuteNonQuery();

                //Now check the status
                if (iSqlStatus == 0)
                {
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
