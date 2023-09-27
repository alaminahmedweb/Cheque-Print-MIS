using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using CheckPrintMIS.Models;
using  System.Configuration;

namespace CheckPrintMIS.Gateway
{
    public class BankInformationGateway
    {
        private string connectionString =
                    WebConfigurationManager.ConnectionStrings["ChequePrintConnString"].ConnectionString;

        private string message = "";
        public string Save(BankInformation bankInformation)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    

                    string query = "INSERT INTO BankInformation(BankCode,BankName,BranchName,AccountNo,EntryDate,EntryTime,UserName,Valid) VALUES(@BankCode,@BankName,@BranchName,@AccountNo,@EntryDate,@EntryTime,@UserName,1)";

                    SqlCommand command = new SqlCommand(query, connection, transaction);

                    command.Parameters.Add("BankCode", SqlDbType.VarChar);
                    command.Parameters["BankCode"].Value = bankInformation.BankCode;

                    command.Parameters.Add("BankName", SqlDbType.VarChar);
                    command.Parameters["BankName"].Value = bankInformation.BankName;

                    command.Parameters.Add("BranchName", SqlDbType.VarChar);
                    command.Parameters["BranchName"].Value = bankInformation.BranchName;

                    command.Parameters.Add("AccountNo", SqlDbType.VarChar);
                    command.Parameters["AccountNo"].Value = bankInformation.AccountNo;

                    command.Parameters.Add("EntryDate", SqlDbType.VarChar);
                    command.Parameters["EntryDate"].Value = bankInformation.EntryDate;

                    command.Parameters.Add("EntryTime", SqlDbType.VarChar);
                    command.Parameters["EntryTime"].Value = bankInformation.EntryTime;

                    command.Parameters.Add("UserName", SqlDbType.VarChar);
                    command.Parameters["UserName"].Value = bankInformation.UserName;

                    int rowAffected = command.ExecuteNonQuery();

                    transaction.Commit();

                    if (rowAffected > 0)
                    {
                        message = "Saved Successfully";
                    }
                    else
                    {
                        message = "Failed To Save";
                    }

                    return message;
                }
                catch (Exception exception)
                {

                    message = exception.Message ;
                    transaction.Rollback();
                    return message;
                }

            }

        }

        public string Update(BankInformation bankInformation)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    string query = "UPDATE BankInformation SET BankName=@BankName,BranchName=@BranchName," +
                                   "AccountNo=@AccountNo,UserName=@UserName" +
                                   " WHERE BankCode=@BankCode";

                    SqlCommand command = new SqlCommand(query, connection, transaction);

                    command.Parameters.Add("BankCode", SqlDbType.VarChar);
                    command.Parameters["BankCode"].Value = bankInformation.BankCode;

                    command.Parameters.Add("BankName", SqlDbType.VarChar);
                    command.Parameters["BankName"].Value = bankInformation.BankName;

                    command.Parameters.Add("BranchName", SqlDbType.VarChar);
                    command.Parameters["BranchName"].Value = bankInformation.BranchName;

                    command.Parameters.Add("AccountNo", SqlDbType.VarChar);
                    command.Parameters["AccountNo"].Value = bankInformation.AccountNo;

                    command.Parameters.Add("EntryDate", SqlDbType.VarChar);
                    command.Parameters["EntryDate"].Value = bankInformation.EntryDate;

                    command.Parameters.Add("EntryTime", SqlDbType.VarChar);
                    command.Parameters["EntryTime"].Value = bankInformation.EntryTime;

                    command.Parameters.Add("UserName", SqlDbType.VarChar);
                    command.Parameters["UserName"].Value = bankInformation.UserName;


                    int rowAffected = command.ExecuteNonQuery();

                    transaction.Commit();

                    if (rowAffected > 0)
                    {
                        message = "Updated Successfully";
                    }
                    else
                    {
                        message = "Failed To Update";
                    }
                    connection.Close();
                    return message;
                }
                catch (Exception exception)
                {

                    message = exception.Message;
                    transaction.Rollback();
                    connection.Close();
                    return message;
                }
            }

        }

        public List<BankInformation> GetAllBank()
        {

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM BankInformation  ORDER BY BankCode";

            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();

            List<BankInformation> AllBanks = new List<BankInformation>();

            while (reader.Read())
            {
                BankInformation bank = new BankInformation();
                bank.BankCode = reader["BankCode"].ToString();
                bank.BankName = reader["BankName"].ToString();
                bank.BranchName = reader["BranchName"].ToString();
                bank.AccountNo = reader["AccountNo"].ToString();

                AllBanks.Add(bank);
            }

            connection.Close();
            return AllBanks;
        }

        public List<BankInformation> GetAllBankByCode(string code)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM BankInformation WHERE BankCode='"+ code +"'";

            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();

            List<BankInformation> AllBanks = new List<BankInformation>();

            while (reader.Read())
            {
                BankInformation bank = new BankInformation();
                bank.BankCode = reader["BankCode"].ToString();
                bank.BankName = reader["BankName"].ToString();
                bank.BranchName = reader["BranchName"].ToString();
                bank.AccountNo = reader["AccountNo"].ToString();

                AllBanks.Add(bank);
            }

            connection.Close();
            return AllBanks;
        }
    }
}