using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Shop_Management_Solution.lib;


namespace Shop_Management_Solution.lib.util
{
    class DebugUtil
    {
        public static void displayDataSetContents(DataSet ds)
        {
            String dataResult = "";
            foreach(DataTable dt in ds.Tables)
            {
                foreach(DataRow row in dt.Rows)
                {
                    foreach(DataColumn dc in dt.Columns)
                    {
                        dataResult += dc.ColumnName + " = ";
                        dataResult += row[dc].ToString() + " ";                       
                    }                    
                    dataResult += "\n\n--- Break ---- \n\n";
                }
            }
            MessageBox.Show(dataResult, "Debug :: Dataset Contents", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static void genericShow(String str)
        {
            MessageBox.Show(str, "Debug :: Generic Show", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
