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
        public static bool InsertVendor(Vendor node)
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
                cmdInsert.Parameters.AddWithValue("@phone", node.PhoneNo);
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

        public static bool updateVendor(Vendor node)
        {
            OleDbConnection cnUpdate = new OleDbConnection(DBUtil.GetConnectionString());
            OleDbCommand cmdUpdate = new OleDbCommand();
            String query = "UPDATE Vendor SET Name = @Name, E-mail = @Email, Phone = @Phone, Mobile = @Mobile, Location = @Location " +
                            "WHERE ID = @ID ";

            int iSqlStatus;

            cmdUpdate.Parameters.Clear();
            try
            {
                cmdUpdate.CommandText = query;
                cmdUpdate.CommandType = CommandType.Text;

                cmdUpdate.Parameters.AddWithValue("@Name", node.Name);
                cmdUpdate.Parameters.AddWithValue("@Email", node.Email);
                cmdUpdate.Parameters.AddWithValue("@Phone", node.PhoneNo);
                cmdUpdate.Parameters.AddWithValue("@Mobile", node.MobileNo);
                cmdUpdate.Parameters.AddWithValue("@Location", node.Location);
                cmdUpdate.Parameters.AddWithValue("@ID", node.Id);

                cmdUpdate.Connection = cnUpdate;
                DBUtil.HandleConnection(cnUpdate);
                iSqlStatus = cmdUpdate.ExecuteNonQuery();

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
                DBUtil.HandleConnection(cnUpdate);
            }
            return true;
        }

        public static bool deleteVendor(int id)
        {
            OleDbConnection cnDelete = new OleDbConnection(DBUtil.GetConnectionString());
            OleDbCommand cmdDelete = new OleDbCommand();
            String query = "UPDATE Vendor SET Deleted = 1 " +
                            "WHERE ID = @ID ";

            int iSqlStatus;

            cmdDelete.Parameters.Clear();
            try
            {
                cmdDelete.CommandText = query;
                cmdDelete.CommandType = CommandType.Text;

                cmdDelete.Parameters.AddWithValue("ID", id);

                cmdDelete.Connection = cnDelete;
                DBUtil.HandleConnection(cnDelete);
                iSqlStatus = cmdDelete.ExecuteNonQuery();

                if (iSqlStatus == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                //Now close the connection
                DBUtil.HandleConnection(cnDelete);
            }
            return true;
        }

       public List<Vendor> GetVendorList()
       {
           List<Vendor> vendors = new List<Vendor>();
           OleDbConnection cnGet = new OleDbConnection(DBUtil.GetConnectionString());
           String query = "SELECT * FROM Vendor";
           OleDbDataAdapter DataAdapter = new OleDbDataAdapter(query, cnGet);

           DataSet ds = new DataSet();
           
           try{
               DataAdapter.Fill(ds);
           }
           catch(Exception ex){
               throw new Exception("Unable to get Vendors" + ex.Message);
           }

           DataTable vendorsTable = ds.Tables[0];

           foreach (DataRow dr in vendorsTable.Rows)
           {
               vendors.Add(
                   new Vendor(
                       int.Parse(dr["ID"].ToString()),
                       dr["Name"].ToString(),
                       dr["Email"].ToString(),
                       dr["Phone"].ToString(),
                       dr["Mobile"].ToString(),
                       dr["Location"].ToString()
                       )
               );
           }
           return vendors;
       }

       public DataSet getVendorsDs()
       {
           OleDbConnection cnGet = new OleDbConnection(DBUtil.GetConnectionString());
           String query = "SELECT * FROM Vendor";
           OleDbDataAdapter DataAdapter = new OleDbDataAdapter(query, cnGet);

           DataSet ds = new DataSet();
           
           try
           {
               DataAdapter.Fill(ds);
           }
           catch (Exception ex)
           {
               throw new Exception("Unable to get Vendors" + ex.Message);
           }

           return ds;
       }

    }
}
