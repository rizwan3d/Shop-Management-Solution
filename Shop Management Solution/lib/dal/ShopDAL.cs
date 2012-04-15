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
    class ShopDAL
    {
        public static bool InsertNewItemType(ItemType item)
        {
            //Create the objects we need to insert a new record
            OleDbConnection cnInsert = new OleDbConnection(DBUtil.GetConnectionString());
            OleDbCommand cmdInsert = new OleDbCommand();
            string query = "INSERT INTO ItemType(Name,Price,Sale_Price,UoM_ID) VALUES(@name,@price,@salePrice,@uomId)";
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
                //Now add the parameters to our query
                //NOTE: Replace @value1.... with your parameter names in your query
                //and add all your parameters in this fashion
                cmdInsert.Parameters.AddWithValue("@name", item.ItemName);
                cmdInsert.Parameters.AddWithValue("@price", item.Price);
                cmdInsert.Parameters.AddWithValue("@salePrice", item.SalePrice);
                cmdInsert.Parameters.AddWithValue("@uomId", item.Uom.Id);

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
                long maxId = DBUtil.GetMaxID("Type_ID", "ItemType");
                ShopDAL.insertValueOfStockInHand(cnInsert, maxId);
            }
        }

        public static float getItemTypeSalePrice(long typeId)
        {
            float quantity = 0;
            OleDbConnection connectionString = new OleDbConnection(DBUtil.GetConnectionString());
            string query = "SELECT Sale_Price FROM ItemType WHERE Type_ID = " + typeId;

            OleDbDataAdapter DataAdapter = new OleDbDataAdapter(query, connectionString);
            DataSet ds = new DataSet();
            try
            {
                DataAdapter.Fill(ds);
                quantity = float.Parse(ds.Tables[0].Rows[0][0].ToString());
                return quantity;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get the Stock in hand. Please try to add some stock first." + ex.Message);
            }
        }

        public static string getItemTypeUoM(long typeId)
        {
            string uom = null;
            OleDbConnection connectionString = new OleDbConnection(DBUtil.GetConnectionString());
            string query =  "SELECT UoM.UoM_Name FROM ItemType " + 
                            "LEFT JOIN UoM ON (ItemType.UoM_ID = UoM.ID ) " +
                            "WHERE Type_ID = " + typeId;

            OleDbDataAdapter DataAdapter = new OleDbDataAdapter(query, connectionString);
            DataSet ds = new DataSet();
            try
            {
                DataAdapter.Fill(ds);
                uom = ds.Tables[0].Rows[0][0].ToString();
                return uom;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get UoM." + ex.Message);
            }
        }

        public List<ItemType> GetItemTypeList()
        {
            List<ItemType> itemtypes = new List<ItemType>();

            OleDbConnection connectionString = new OleDbConnection(DBUtil.GetConnectionString());
            string query = "SELECT ItemType.Type_ID, ItemType.Name,ItemType.Price FROM ItemType";
            OleDbDataAdapter DataAdapter = new OleDbDataAdapter(query, connectionString);
            DataSet ds = new DataSet();

            try
            {

                DataAdapter.Fill(ds, "ItemType");

            }

            catch (Exception ex)
            {

                return itemtypes;

            }

            DataTable dataTable = ds.Tables[0];

            foreach (DataRow dataRow in dataTable.Rows)
            {
                ItemType objItemType = new ItemType();
                objItemType.ItemId = int.Parse(dataRow["Type_ID"].ToString());
                objItemType.ItemName = dataRow["Name"].ToString();
                objItemType.Price = float.Parse(dataRow["Price"].ToString());

                itemtypes.Add(objItemType);

            }
            return itemtypes;

        }

        public DataSet GetItemsType()
        {
            OleDbConnection connectionString = new OleDbConnection(DBUtil.GetConnectionString());
            string query = "SELECT Type_ID, Name, Price FROM ItemType";
            OleDbDataAdapter DataAdapter = new OleDbDataAdapter(query, connectionString);
            DataSet ds = new DataSet();

            try
            {
                //DataRow defaultRow = ds.Tables["ItemType"].NewRow();
                //defaultRow["Type_ID"] = "2";
                //defaultRow["Name"] = "-- Select Item Type --";
                //ds.Tables[0].Rows.Add(defaultRow);

                DataAdapter.Fill(ds, "ItemType");
                return ds;

            }

            catch (Exception ex)
            {

                return ds;

            }
        }
        private static bool insertValueOfStockInHand(OleDbConnection connection, long itemTypeId)
        {
            OleDbCommand cmdInsert = new OleDbCommand();
            string query = "INSERT INTO Stock_In_Hand(Type_ID,Quantity) VALUES(@itemTypeId,0)";
            int iSqlStatus;

            cmdInsert.Parameters.Clear();
            cmdInsert.CommandText = query;
            cmdInsert.CommandType = CommandType.Text;
            cmdInsert.Parameters.AddWithValue("@itemTypeId", itemTypeId);
            cmdInsert.Connection = connection;
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

        public static bool AddPurchasedItem(string dateOfPurchase, long itemTypeId, long quantity)
        {
            //Create the objects we need to insert a new record
            OleDbConnection cnInsert = new OleDbConnection(DBUtil.GetConnectionString());
            OleDbCommand cmdInsert = new OleDbCommand();
            string query = "INSERT INTO Purchase(Purchase_Date,Type_ID,Quantity) VALUES(@purcahseDate,@typeId, @quantity)";
            int iSqlStatus;

            cmdInsert.Parameters.Clear();
            try
            {
                cmdInsert.CommandText = query;
                cmdInsert.CommandType = CommandType.Text;

                cmdInsert.Parameters.AddWithValue("@purcahseDate", dateOfPurchase);
                cmdInsert.Parameters.AddWithValue("@typeId", itemTypeId);
                cmdInsert.Parameters.AddWithValue("@quantity", quantity);

                cmdInsert.Connection = cnInsert;


                //Now take care of the connection
                DBUtil.HandleConnection(cnInsert);
                //Set the iSqlStatus to the ExecuteNonQuery 
                //status of the insert (0 = failed, 1 = success)
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
                long currentQuantity = ShopDAL.getStockInHandQuantity(itemTypeId);
                long newQuantity = currentQuantity + quantity;
                ShopDAL.updateStockQuantity(cnInsert, itemTypeId, newQuantity);
            }
        }

        public static long getStockInHandQuantity(long typeId)
        {
            long quantity = 0;
            OleDbConnection connectionString = new OleDbConnection(DBUtil.GetConnectionString());
            string query = "SELECT Quantity FROM Stock_In_Hand WHERE Type_ID = " + typeId;

            OleDbDataAdapter DataAdapter = new OleDbDataAdapter(query, connectionString);
            DataSet ds = new DataSet();
            try
            {
                DataAdapter.Fill(ds);
                quantity = long.Parse(ds.Tables[0].Rows[0][0].ToString());
                return quantity;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to Execute :" + query + "\n" + ex.Message);
            }
        }
        public static bool isItemTypeExists()
        {
            bool isExist = false;
            OleDbConnection connectionString = new OleDbConnection(DBUtil.GetConnectionString());
            string query = "SELECT Type_ID FROM ItemType";

            OleDbDataAdapter DataAdapter = new OleDbDataAdapter(query, connectionString);
            DataSet ds = new DataSet();
            try
            {
                DataAdapter.Fill(ds);
                long itemId = long.Parse(ds.Tables[0].Rows[0][0].ToString());
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Please add an Item Type");
            }
        }
        private static bool updateStockQuantity(OleDbConnection connection, long itemTypeId, long quantity)
        {
            OleDbCommand cmdUpdate = new OleDbCommand();
            string query = "UPDATE Stock_In_Hand SET Quantity = @quantity WHERE Type_ID = @itemTypeId";
            int iSqlStatus;

            cmdUpdate.Parameters.Clear();
            cmdUpdate.CommandText = query;
            cmdUpdate.CommandType = CommandType.Text;
            cmdUpdate.Parameters.AddWithValue("@quantity", quantity);
            cmdUpdate.Parameters.AddWithValue("@itemTypeId", itemTypeId);

            cmdUpdate.Connection = connection;
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

        public static long SaleItems(string dateOfPurchase, List<Sale> saleItems)
        {

            OleDbConnection cnInsert = new OleDbConnection(DBUtil.GetConnectionString());
            long lastInsertId = -1;
            OleDbTransaction saleTransaction;
            string query = "INSERT INTO Sales(Sale_Date,Type_ID,Quantity, Sale_Price) VALUES(@saleDate,@typeId, @quantity, @price)";
            int iSqlStatus = 0;


            try
            {

                DBUtil.HandleConnection(cnInsert);
                saleTransaction = cnInsert.BeginTransaction();

                foreach (Sale item in saleItems)
                {
                    OleDbCommand cmdInsert = new OleDbCommand();
                    cmdInsert.CommandText = query;
                    cmdInsert.CommandType = CommandType.Text;
                    cmdInsert.Connection = cnInsert;
                    cmdInsert.Transaction = saleTransaction;
                    cmdInsert.Parameters.Clear();
                    cmdInsert.Parameters.AddWithValue("@saleDate", dateOfPurchase);
                    cmdInsert.Parameters.AddWithValue("@typeId", item.ItemTypeId);
                    cmdInsert.Parameters.AddWithValue("@quantity", item.Quantity);
                    cmdInsert.Parameters.AddWithValue("@price", item.SalePrice);
                    long avaliableQuantity = ShopDAL.getStockInHandQuantity(item.ItemTypeId);
                    if (avaliableQuantity < item.Quantity)
                    {
                        saleTransaction.Rollback();
                        throw new Exception("Error: Low available quantity " + item.ItemName + " has only " + avaliableQuantity);
                    }
                    long newQuantity = avaliableQuantity - item.Quantity;
                    ShopDAL.updateStockQuantityTransaction(cnInsert, saleTransaction, item.ItemTypeId, newQuantity);
                    iSqlStatus = cmdInsert.ExecuteNonQuery();
                    if (iSqlStatus == 0)
                    {
                        saleTransaction.Rollback();
                        throw new Exception("Error: Inserting value");
                    }
                }
                saleTransaction.Commit();
                lastInsertId = DBUtil.GetMaxID("Sale_ID", "Sales");
                return lastInsertId ;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                //Now close the connection
                DBUtil.HandleConnection(cnInsert);
            }
        }
        private static bool updateStockQuantityTransaction(OleDbConnection connection, OleDbTransaction transction, long itemTypeId, long quantity)
        {
            OleDbCommand cmdUpdate = new OleDbCommand();
            cmdUpdate.Transaction = transction;
            string query = "UPDATE Stock_In_Hand SET Quantity = @quantity WHERE Type_ID = @itemTypeId";
            int iSqlStatus;

            cmdUpdate.Parameters.Clear();
            cmdUpdate.CommandText = query;
            cmdUpdate.CommandType = CommandType.Text;
            cmdUpdate.Parameters.AddWithValue("@quantity", quantity);
            cmdUpdate.Parameters.AddWithValue("@itemTypeId", itemTypeId);
            cmdUpdate.Connection = connection;
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

        public static DataSet SearchTotalProfitDS(String startDate, String endDate, long itemTypeId, int startRecord, int noOfRecords)
        {
            OleDbConnection connectionString = new OleDbConnection(DBUtil.GetConnectionString());
            string query = "SELECT ItemType.Name, Sum(Sales.Quantity) AS Sold_Quantity, ItemType.Price AS Actual_Price, Avg(Sales.Sale_Price) AS Sold_Price, Stock_In_Hand.Quantity AS Remaining_Quantity, ((Sold_Quantity*Sold_Price)-(Actual_Price*Sold_Quantity)) AS Proft, (Sold_Price*Sold_Quantity) AS Total_Sale_Price,(Actual_Price*Sold_Quantity) AS Total_Purchase_Price   FROM (ItemType INNER JOIN Sales ON ItemType.Type_ID=Sales.Type_ID) INNER JOIN Stock_In_Hand ON ItemType.Type_ID=Stock_In_Hand.Type_ID GROUP BY ItemType.Name, Stock_In_Hand.Quantity, ItemType.Price, ItemType.Type_ID, Sales.Sale_Date, Sales.Sale_Price HAVING (((ItemType.Type_ID)=" + itemTypeId + ") And ((Sales.Sale_Date) Between #" + startDate + "# And #" + endDate + "#))";
            if (endDate.Equals(startDate))
            {
                query = "SELECT ItemType.Name, Sum(Sales.Quantity) AS Sold_Quantity, ItemType.Price AS Actual_Price, Avg(Sales.Sale_Price) AS Sold_Price, Stock_In_Hand.Quantity AS Remaining_Quantity, ((Sold_Quantity*Sold_Price)-(Actual_Price*Sold_Quantity)) AS Proft, (Sold_Price*Sold_Quantity) AS Total_Sale_Price,(Actual_Price*Sold_Quantity) AS Total_Purchase_Price   FROM (ItemType INNER JOIN Sales ON ItemType.Type_ID=Sales.Type_ID) INNER JOIN Stock_In_Hand ON ItemType.Type_ID=Stock_In_Hand.Type_ID GROUP BY ItemType.Name, Stock_In_Hand.Quantity, ItemType.Price, ItemType.Type_ID, Sales.Sale_Date, Sales.Sale_Price HAVING (((ItemType.Type_ID)=" + itemTypeId + ") And ((Sales.Sale_Date)  = #" + startDate + "#))";
            }


            OleDbDataAdapter DataAdapter = new OleDbDataAdapter(query, connectionString);

            DataSet ds = new DataSet();
            DataTable resultTable;
            
            try
            {
                resultTable = ds.Tables.Add();
                DataAdapter.Fill(startRecord, noOfRecords, resultTable);
                int x = resultTable.Rows.Count;
                return ds;
            }

            catch (Exception ex)
            {
                DebugUtil.genericShow(ex.Message.ToString());
                return ds;
            }
        }

        //function returns number of rows found and sets referenced arguments to contain total sold quantity and total profit
        public static int SearchTotalProfitSummary(String startDate, String endDate, long itemTypeId, ref int totalSoldQuantity, ref decimal totalProfit)
        {
            OleDbConnection connectionString = new OleDbConnection(DBUtil.GetConnectionString());
            string query = "SELECT ItemType.Name, Sum(Sales.Quantity) AS Sold_Quantity, ItemType.Price AS Actual_Price, Avg(Sales.Sale_Price) AS Sold_Price, Stock_In_Hand.Quantity AS Remaining_Quantity, ((Sold_Quantity*Sold_Price)-(Actual_Price*Sold_Quantity)) AS Proft, (Sold_Price*Sold_Quantity) AS Total_Sale_Price,(Actual_Price*Sold_Quantity) AS Total_Purchase_Price   FROM (ItemType INNER JOIN Sales ON ItemType.Type_ID=Sales.Type_ID) INNER JOIN Stock_In_Hand ON ItemType.Type_ID=Stock_In_Hand.Type_ID GROUP BY ItemType.Name, Stock_In_Hand.Quantity, ItemType.Price, ItemType.Type_ID, Sales.Sale_Date, Sales.Sale_Price HAVING (((ItemType.Type_ID)=" + itemTypeId + ") And ((Sales.Sale_Date) Between #" + startDate + "# And #" + endDate + "#))";
            if (endDate.Equals(startDate))
            {
                query = "SELECT ItemType.Name, Sum(Sales.Quantity) AS Sold_Quantity, ItemType.Price AS Actual_Price, Avg(Sales.Sale_Price) AS Sold_Price, Stock_In_Hand.Quantity AS Remaining_Quantity, ((Sold_Quantity*Sold_Price)-(Actual_Price*Sold_Quantity)) AS Proft, (Sold_Price*Sold_Quantity) AS Total_Sale_Price,(Actual_Price*Sold_Quantity) AS Total_Purchase_Price   FROM (ItemType INNER JOIN Sales ON ItemType.Type_ID=Sales.Type_ID) INNER JOIN Stock_In_Hand ON ItemType.Type_ID=Stock_In_Hand.Type_ID GROUP BY ItemType.Name, Stock_In_Hand.Quantity, ItemType.Price, ItemType.Type_ID, Sales.Sale_Date, Sales.Sale_Price HAVING (((ItemType.Type_ID)=" + itemTypeId + ") And ((Sales.Sale_Date)  = #" + startDate + "#))";
            }


            OleDbDataAdapter DataAdapter = new OleDbDataAdapter(query, connectionString);

            DataSet ds = new DataSet();            
            
            try
            {                
                DataAdapter.Fill(ds);
                totalSoldQuantity = int.Parse(ds.Tables[0].Compute("SUM(Sold_Quantity)", "").ToString());
                totalProfit = decimal.Parse(ds.Tables[0].Compute("SUM(Proft)", "").ToString());                
                return ds.Tables[0].Rows.Count;
            }

            catch (Exception ex)
            {
                DebugUtil.genericShow(ex.Message.ToString());
                return 0;
            }
        }

        public static BindingSource SearchTotalProfit(String startDate, String endDate, long itemTypeId)
        {
            //query to execute
            string query = "SELECT ItemType.Name, Avg(Sales.Sale_Price) AS Sold_Price, Stock_In_Hand.Quantity AS Remaining_Quantity, ItemType.Price AS Actual_Price, Sum(Sales.Quantity) AS Sold_Quantity, ((Sold_Quantity*Sold_Price)-(Actual_Price*Sold_Quantity)) AS Proft FROM (ItemType INNER JOIN Sales ON ItemType.Type_ID=Sales.Type_ID) INNER JOIN Stock_In_Hand ON ItemType.Type_ID=Stock_In_Hand.Type_ID GROUP BY ItemType.Name, Stock_In_Hand.Quantity, ItemType.Price, ItemType.Type_ID, Sales.Sale_Date HAVING (((ItemType.Type_ID)= @itemTypeId ) And ((Sales.Sale_Date) Between @startDate And @endDate))";
            //OleDbConnection Object to use
            OleDbConnection cnGetRecords = new OleDbConnection(DBUtil.GetConnectionString());
            //OleDbCommand Object to use
            OleDbCommand cmdGetRecords = new OleDbCommand();
            //OleDbDataAdapter Object to use
            OleDbDataAdapter daAgents = new OleDbDataAdapter();
            DataSet dsGetRecords = new DataSet();
            //Clear any parameters
            cmdGetRecords.Parameters.Clear();
            try
            {
                //set the OleDbCommand Object Parameters
                cmdGetRecords.CommandText = query; //tell it what to execute
                cmdGetRecords.CommandType = CommandType.Text; //tell it its executing a query
                //heres the difference from the last method
                //here we are adding a parameter to send to our query
                //you use the AddWithValue, then the name of the parameter in your query
                //then the variable that holds that value
                cmdGetRecords.Parameters.AddWithValue("@itemTypeId", itemTypeId);
                cmdGetRecords.Parameters.AddWithValue("@startDate", startDate);
                cmdGetRecords.Parameters.AddWithValue("@endDate", endDate);
                //set the state of the OleDbConnection Object
                DBUtil.HandleConnection(cnGetRecords);
                //create BindingSource to return for our DataGrid Control
                BindingSource oBindingSource = DBUtil.GetBindingSource(cmdGetRecords, cnGetRecords);

                if (oBindingSource == null)
                {
                    throw new Exception("There was no BindingSource returned");
                }
                else
                {
                    return oBindingSource;


                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
            DBUtil.HandleConnection(cnGetRecords);
            //now we close the connection
            return null;
            
        }

        public static long GetItemPrice(long typeId)
        {
            long price = 0;
            OleDbConnection connectionString = new OleDbConnection(DBUtil.GetConnectionString());
            string query = "SELECT ItemType.Price FROM ItemType WHERE Type_ID = " + typeId;

            OleDbDataAdapter DataAdapter = new OleDbDataAdapter(query, connectionString);
            DataSet ds = new DataSet();
            try
            {
                DataAdapter.Fill(ds);
                price = long.Parse(ds.Tables[0].Rows[0][0].ToString());
                return price;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to Execute :" + query + "\n" + ex.Message);
            }
        }
    }
}
