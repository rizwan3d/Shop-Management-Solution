using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using Shop_Management_Solution.lib.util;

namespace Shop_Management_Solution.lib.dal
{
    class ItemDAL
    {

        public static bool deleteItem(int id)
        {
            OleDbConnection cnDelete = new OleDbConnection(DBUtil.GetConnectionString());
            OleDbCommand cmdDelete = new OleDbCommand();
            String query = "UPDATE ItemType SET IsDeleted = 1 " +
                            "WHERE Type_ID = @ID ";

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
            
        }

        public static DataSet getItemsDs()
        {
            OleDbConnection cnGet = new OleDbConnection(DBUtil.GetConnectionString());
            String query = "SELECT * FROM ItemType";
            OleDbDataAdapter DataAdapter = new OleDbDataAdapter(query, cnGet);

            DataSet ds = new DataSet();

            try
            {
                DataAdapter.Fill(ds);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get vendors" + ex.Message);
            }

            return ds;
        }

        public DataSet getItemsPresentationDs()
        {
            OleDbConnection cnGet = new OleDbConnection(DBUtil.GetConnectionString());
            String query = "SELECT ItemType.Type_ID, ItemType.Name AS ItemType_Name, ItemType.Price, ItemType.Sale_Price, ItemType.Is_Deleted, UoM.ID AS UoM_ID,  UoM.UoM_Name, Vendor.ID AS Vendor_ID, Vendor.Name AS Vendor_Name  " +
                           "FROM Vendor RIGHT JOIN (UoM RIGHT JOIN ItemType ON UoM.[ID] = ItemType.[UoM_ID]) ON Vendor.[ID] = ItemType.[Vendor_ID]";

            OleDbDataAdapter DataAdapter = new OleDbDataAdapter(query, cnGet);

            DataSet ds = new DataSet();

            try
            {
                DataAdapter.Fill(ds);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get vendors" + ex.Message);
            }

            return ds;
        }

        public OleDbDataAdapter getItemAdapter()
        {
            String query = "SELECT ItemType.Type_ID, ItemType.Name AS ItemType_Name, ItemType.Price, ItemType.Sale_Price, ItemType.Is_Deleted, UoM.ID AS UoM_ID,  UoM.UoM_Name, Vendor.ID AS Vendor_ID, Vendor.Name AS Vendor_Name  " +
                           "FROM Vendor RIGHT JOIN (UoM RIGHT JOIN ItemType ON UoM.[ID] = ItemType.[UoM_ID]) ON Vendor.[ID] = ItemType.[Vendor_ID]";

            OleDbConnection conn = new OleDbConnection(DBUtil.GetConnectionString()); 
            OleDbDataAdapter resultAdapter = new OleDbDataAdapter(query, DBUtil.GetConnectionString());
            resultAdapter.InsertCommand = new OleDbCommand("INSERT INTO ItemType ([Name], [Price], [Sale_Price], [Vendor_ID], [UoM_ID], [Is_Deleted]) " +
                            "VALUES (@Name, @Price, @SalePrice, @VendorID, @UoMID, @IsDeleted) ", conn);


            resultAdapter.InsertCommand.Parameters.Add("@Name", OleDbType.VarChar, 255, "ItemType_Name");
            resultAdapter.InsertCommand.Parameters.Add("@Price", OleDbType.Double, 11, "Price");
            resultAdapter.InsertCommand.Parameters.Add("@SalePrice", OleDbType.Double, 11, "Sale_Price");
            resultAdapter.InsertCommand.Parameters.Add("@VendorID", OleDbType.Integer, 7, "Vendor_ID");
            resultAdapter.InsertCommand.Parameters.Add("@UoMID", OleDbType.Integer, 7, "UoM_ID");
            resultAdapter.InsertCommand.Parameters.Add("@IsDeleted", OleDbType.Integer, 4, "Is_Deleted");

            resultAdapter.UpdateCommand = new OleDbCommand("UPDATE ItemType SET [Name] = @Name, [Price] = @Price, [Sale_Price] = @SalePrice, [Vendor_ID] = @VendorID, [UoM_ID] = @UoMID, " +
                        "[Is_Deleted] = @IsDeleted WHERE [Type_ID] = @ID ", conn);

            resultAdapter.UpdateCommand.Parameters.Add("@Name", OleDbType.VarChar, 255, "ItemType_Name");
            resultAdapter.UpdateCommand.Parameters.Add("@Price", OleDbType.Double, 11, "Price");
            resultAdapter.UpdateCommand.Parameters.Add("@SalePrice", OleDbType.Double, 11, "Sale_Price");
            resultAdapter.UpdateCommand.Parameters.Add("@VendorID", OleDbType.VarChar, 30, "Vendor_ID");
            resultAdapter.UpdateCommand.Parameters.Add("@UoMID", OleDbType.VarChar, 255, "UoM_ID");
            resultAdapter.UpdateCommand.Parameters.Add("@IsDeleted", OleDbType.Integer, 4, "Is_Deleted");
            resultAdapter.UpdateCommand.Parameters.Add("@ID", OleDbType.Integer, 4, "Type_ID");


            resultAdapter.RowUpdated += new OleDbRowUpdatedEventHandler(itemRowUpdated);

            return resultAdapter;
        }

        private void itemRowUpdated(object sender, OleDbRowUpdatedEventArgs e)
        {
            if (e.Status == UpdateStatus.Continue && e.StatementType == StatementType.Insert)
            {
                long maxId = DBUtil.GetMaxIDWithConnection("Type_ID", "ItemType", e.Command.Connection);
                ShopDAL.insertValueOfStockInHand(e.Command.Connection, maxId);
            }
             
            
        }

    }
}
