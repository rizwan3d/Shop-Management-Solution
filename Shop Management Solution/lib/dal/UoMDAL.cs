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
    class UoMDAL
    {

        public static bool addUoM(UoM objUom)
        {
            OleDbConnection conn = new OleDbConnection(DBUtil.GetConnectionString());
            OleDbCommand cmdInsert = new OleDbCommand();
            String query = "INSERT INTO Uom ( UoM_Name ) " +
                           "VALUES( @Name )";

            int iSqlStatus;
            cmdInsert.Parameters.Clear();
            try
            {
                bool isAlreadyExist = DBUtil.IsReferenceExists( "Uom", "UoM_Name",objUom.Name );
                if (isAlreadyExist)
                {
                    throw new Exception("Unit already exists");
                }

                cmdInsert.CommandText = query;
                cmdInsert.CommandType = CommandType.Text;

                cmdInsert.Parameters.AddWithValue("@Name", objUom.Name);

                cmdInsert.Connection = conn;
                DBUtil.HandleConnection(conn);
                iSqlStatus = cmdInsert.ExecuteNonQuery();

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
                //Now close the connection
                DBUtil.HandleConnection(conn);

                throw new Exception(ex.Message.ToString());
            }

        }

        public static List<UoM> GetUoMList()
        {
            List<UoM> uoms = new List<UoM>();

            OleDbConnection connectionString = new OleDbConnection(DBUtil.GetConnectionString());
            string query = "SELECT ID,UoM_Name FROM Uom";
            OleDbDataAdapter DataAdapter = new OleDbDataAdapter(query, connectionString);
            DataSet ds = new DataSet();

            try
            {
                DataAdapter.Fill(ds, "Uom");
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get UoM" + ex.Message);
            }

            DataTable dataTable = ds.Tables[0];

            foreach (DataRow dataRow in dataTable.Rows)
            {
                UoM objUoM = new UoM();
                objUoM.Id = int.Parse(dataRow["ID"].ToString());
                objUoM.Name = dataRow["UoM_Name"].ToString();

                uoms.Add(objUoM);

            }
            return uoms;

        }

        public static DataSet GetUoMsDataSet()
        {
            OleDbConnection connectionString = new OleDbConnection(DBUtil.GetConnectionString());
            string query = "SELECT ID, UoM_Name FROM Uom";
            OleDbDataAdapter DataAdapter = new OleDbDataAdapter(query, connectionString);
            DataSet ds = new DataSet();

            try
            {
                DataAdapter.Fill(ds, "ItemType");
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get UoMs Store" + ex.Message);
            }
        }
    }
}
