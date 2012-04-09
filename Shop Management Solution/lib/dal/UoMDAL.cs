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
        public static List<UoM> GetUoMList()
        {
            List<UoM> uoms = new List<UoM>();

            OleDbConnection connectionString = new OleDbConnection(DBUtil.GetConnectionString());
            string query = "SELECT UoM.ID, UoM.UoM_Name FROM UoM";
            OleDbDataAdapter DataAdapter = new OleDbDataAdapter(query, connectionString);
            DataSet ds = new DataSet();

            try
            {
                DataAdapter.Fill(ds, "UoM");
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
            string query = "SELECT UoM.ID, UoM.UoM_Name FROM UoM";
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
