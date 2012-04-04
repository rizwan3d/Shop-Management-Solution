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
    class XtraTreeDAL
    {
        public bool InsertXtraTreeNode(XtraTreeNode node)
        {
            //Create the objects we need to insert a new record
            OleDbConnection cnInsert = new OleDbConnection(DBUtil.GetConnectionString());
            OleDbCommand cmdInsert = new OleDbCommand();
            string query = "INSERT INTO Xtra_Tree(Name,Parent_ID,Type,Email,Mobile_No,Contact_No,Location,Is_Deleted)" + 
                            "VALUES(@name,@parentId,@type,@email,@mobile,@contactNo,@location,0)";
            
            int iSqlStatus;
            cmdInsert.Parameters.Clear();

            try
            {
                cmdInsert.CommandText = query;
                cmdInsert.CommandType = CommandType.Text;

                cmdInsert.Parameters.AddWithValue("@name", node.Name);
                cmdInsert.Parameters.AddWithValue("@parentId", node.Parent.Id);
                cmdInsert.Parameters.AddWithValue("@type",node.NodeType.Name );
                cmdInsert.Parameters.AddWithValue("@email", node.Email);
                cmdInsert.Parameters.AddWithValue("@mobile", node.MobileNo);
                cmdInsert.Parameters.AddWithValue("@contactNo", node.ContactNo);
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
