using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using Shop_Management_Solution.lib.util;

namespace Shop_Management_Solution.lib.dal
{
    class ContractorDAL
    {
        public static bool InsertContractor(Contractor node)
        {
            OleDbConnection cnInsert = new OleDbConnection(DBUtil.GetConnectionString());
            OleDbCommand cmdInsert = new OleDbCommand();
            string query = "INSERT INTO Contractor (Name, E-mail, Phone, Mobile, AddresLine1, AddresLine2, PostCode, Country, IsDeleted, City) " +
                            "VALUES (@name, @email, @phone, @mobile, @addresLine1, @addresLine2, @postCode, @country, 0, @city) ";

            int iSqlStatus;
            cmdInsert.Parameters.Clear();

            try
            {
                cmdInsert.CommandText = query;
                cmdInsert.CommandType = CommandType.Text;


                cmdInsert.Parameters.AddWithValue("@name", node.Name);
                cmdInsert.Parameters.AddWithValue("@email", node.Email);
                cmdInsert.Parameters.AddWithValue("@phone", node.Phone);
                cmdInsert.Parameters.AddWithValue("@mobile", node.Mobile);
                cmdInsert.Parameters.AddWithValue("@addresLine1", node.AddressLine1);
                cmdInsert.Parameters.AddWithValue("@addresLine2", node.AddressLine2);
                cmdInsert.Parameters.AddWithValue("@postCode", node.PostCode);
                cmdInsert.Parameters.AddWithValue("@country", node.Country);
                cmdInsert.Parameters.AddWithValue("@city", node.City);

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

        public static bool updateContractor(Contractor node)
        {
            OleDbConnection cnUpdate = new OleDbConnection(DBUtil.GetConnectionString());
            OleDbCommand cmdUpdate = new OleDbCommand();
            String query = "UPDATE Contractor SET Name = @Name, E-mail = @Email, Phone = @Phone, Mobile = @Mobile, AddresLine1 = @AddresLine1" +
                        ", AddresLine2 = @AddresLine2, PostCode = @PostCode, Country = @Country, City = @City WHERE ID = @ID ";
                            

            int iSqlStatus;

            cmdUpdate.Parameters.Clear();
            try
            {
                cmdUpdate.CommandText = query;
                cmdUpdate.CommandType = CommandType.Text;

                cmdUpdate.Parameters.AddWithValue("@Name", node.Name);
                cmdUpdate.Parameters.AddWithValue("@Email", node.Email);
                cmdUpdate.Parameters.AddWithValue("@phone", node.Phone);
                cmdUpdate.Parameters.AddWithValue("@mobile", node.Mobile);
                cmdUpdate.Parameters.AddWithValue("@addresLine1", node.AddressLine1);
                cmdUpdate.Parameters.AddWithValue("@addresLine2", node.AddressLine2);
                cmdUpdate.Parameters.AddWithValue("@postCode", node.PostCode);
                cmdUpdate.Parameters.AddWithValue("@country", node.Country);
                cmdUpdate.Parameters.AddWithValue("@city", node.City);
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

        public static bool deleteContractor(int id)
        {
            OleDbConnection cnDelete = new OleDbConnection(DBUtil.GetConnectionString());
            OleDbCommand cmdDelete = new OleDbCommand();
            String query = "UPDATE Contractor SET Deleted = 1 " +
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

        public List<Contractor> GetContractorList()
        {
            List<Contractor> contractors = new List<Contractor>();
            OleDbConnection cnGet = new OleDbConnection(DBUtil.GetConnectionString());
            String query = "SELECT * FROM Contractor";
            OleDbDataAdapter DataAdapter = new OleDbDataAdapter(query, cnGet);

            DataSet ds = new DataSet();

            try
            {
                DataAdapter.Fill(ds);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get Contractors" + ex.Message);
            }

            DataTable contractorsTable = ds.Tables[0];

            foreach (DataRow dr in contractorsTable.Rows)
            {
                contractors.Add(
                    new Contractor(
                        int.Parse(dr["ID"].ToString()),
                        dr["Name"].ToString(),
                        dr["Email"].ToString(),
                        dr["Phone"].ToString(),
                        dr["Mobile"].ToString(),
                        dr["AddresLine1"].ToString(),
                        dr["AddresLine2"].ToString(),
                        dr["PostCode"].ToString(),
                        int.Parse(dr["Country"].ToString()),
                        dr["City"].ToString()
                        )
                );
            }
            return contractors;
        }

        public DataSet getContractorsDs()
        {
            OleDbConnection cnGet = new OleDbConnection(DBUtil.GetConnectionString());
            String query = "SELECT * FROM Contractor";
            OleDbDataAdapter DataAdapter = new OleDbDataAdapter(query, cnGet);

            DataSet ds = new DataSet();

            try
            {
                DataAdapter.Fill(ds);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get Contractors" + ex.Message);
            }

            return ds;
        }

        public DataSet getContractorsPresentationDs()
        {
            OleDbConnection cnGet = new OleDbConnection(DBUtil.GetConnectionString());
            String query = "SELECT [c].[ID], [c].[Name], [c].[E-mail], [c].[Phone], [c].[Mobile], [c].[AddressLine1], [c].[AddressLine2], " +
                            "[c].[PostCode], [c].[Country], [ct].[CountryName], [c].[IsDeleted], [c].[City] " +
                            "FROM Contractor c INNER JOIN Countries ct ON [ct].[ID] = [c].[Country]";
            OleDbDataAdapter DataAdapter = new OleDbDataAdapter(query, cnGet);

            DataSet ds = new DataSet();

            try
            {
                DataAdapter.Fill(ds);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get Contractors" + ex.Message);
            }

            return ds;
        }

        public OleDbDataAdapter getContractorAdapter()
        {
            String query = "SELECT [c].[ID], [c].[Name], [c].[E-mail], [c].[Phone], [c].[Mobile], [c].[AddressLine1], [c].[AddressLine2], " +
                            "[c].[PostCode], [c].[Country], [ct].[CountryName], [c].[IsDeleted], [c].[City] " +
                            "FROM Contractor c INNER JOIN Countries ct ON [ct].[ID] = [c].[Country]";
            OleDbConnection conn = new OleDbConnection(DBUtil.GetConnectionString());
            OleDbDataAdapter resultAdapter = new OleDbDataAdapter(query, DBUtil.GetConnectionString());
            resultAdapter.InsertCommand = new OleDbCommand("INSERT INTO Contractor ([Name], [E-mail], [Phone], [Mobile], [AddressLine1], [AddressLine2], [PostCode], [Country], [IsDeleted], [City]) " +
                            "VALUES (@Name, @Email, @Phone, @Mobile, @AddressLine1, @AddressLine2, @PostCode, @Country, @IsDeleted, @City) ", conn);
                            

            resultAdapter.InsertCommand.Parameters.Add("@Name", OleDbType.VarChar, 255, "Name");
            resultAdapter.InsertCommand.Parameters.Add("@Email", OleDbType.VarChar, 100, "E-mail");
            resultAdapter.InsertCommand.Parameters.Add("@Phone", OleDbType.VarChar, 30, "Phone");
            resultAdapter.InsertCommand.Parameters.Add("@Mobile", OleDbType.VarChar, 30, "Mobile");
            resultAdapter.InsertCommand.Parameters.Add("@AddressLine1", OleDbType.VarChar, 255, "Addressline1");
            resultAdapter.InsertCommand.Parameters.Add("@AddressLine2", OleDbType.VarChar, 255, "AddressLine2");
            resultAdapter.InsertCommand.Parameters.Add("@PostCode", OleDbType.VarChar, 30, "PostCode");
            resultAdapter.InsertCommand.Parameters.Add("@Country", OleDbType.Integer, 4, "Country");
            resultAdapter.InsertCommand.Parameters.Add("@IsDeleted", OleDbType.Integer, 4, "IsDeleted");
            resultAdapter.InsertCommand.Parameters.Add("@City", OleDbType.VarChar, 100, "City");

            resultAdapter.UpdateCommand = new OleDbCommand("UPDATE Contractor SET [Name] = @Name, [E-mail] = @Email, [Phone] = @Phone, [Mobile] = @Mobile, [AddressLine1] = @AddressLine1" +
                        ", [AddressLine2] = @AddressLine2, [PostCode] = @PostCode, [Country] = @Country, [IsDeleted] = @IsDeleted, [City] = @City WHERE [ID] = @ID ", conn);

            resultAdapter.UpdateCommand.Parameters.Add("@Name", OleDbType.VarChar, 255, "Name");
            resultAdapter.UpdateCommand.Parameters.Add("@Email", OleDbType.VarChar, 100, "E-mail");
            resultAdapter.UpdateCommand.Parameters.Add("@Phone", OleDbType.VarChar, 30, "Phone");
            resultAdapter.UpdateCommand.Parameters.Add("@Mobile", OleDbType.VarChar, 30, "Mobile");
            resultAdapter.UpdateCommand.Parameters.Add("@AddressLine1", OleDbType.VarChar, 255, "Addressline1");
            resultAdapter.UpdateCommand.Parameters.Add("@AddressLine2", OleDbType.VarChar, 255, "AddressLine2");
            resultAdapter.UpdateCommand.Parameters.Add("@PostCode", OleDbType.VarChar, 30, "PostCode");
            resultAdapter.UpdateCommand.Parameters.Add("@Country", OleDbType.Integer, 4, "Country");
            resultAdapter.UpdateCommand.Parameters.Add("@IsDeleted", OleDbType.Integer, 4, "IsDeleted");
            resultAdapter.UpdateCommand.Parameters.Add("@City", OleDbType.VarChar, 100, "City");
            resultAdapter.UpdateCommand.Parameters.Add("@ID", OleDbType.Integer, 4, "ID");

            return resultAdapter;
        }
    }
}
