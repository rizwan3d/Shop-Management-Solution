using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using Shop_Management_Solution.lib.util;

namespace Shop_Management_Solution.lib.dal
{
    class CountryDAL
    {
        public static DataTable GetCountries()
        {
            OleDbConnection cnGet = new OleDbConnection(DBUtil.GetConnectionString());            
            String query = "SELECT * FROM Countries ORDER BY CountryName";
            OleDbDataAdapter getAdapter = new OleDbDataAdapter(query, cnGet);

            DataSet ds = new DataSet();

            try
            {
                getAdapter.Fill(ds);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get Countries" + ex.Message);
            }

            return ds.Tables[0];
        }
    }
}
