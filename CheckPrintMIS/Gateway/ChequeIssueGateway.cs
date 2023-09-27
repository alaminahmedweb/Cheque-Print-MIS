using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using CheckPrintMIS.Models;
using System.Data.SqlClient;
using System.Data;

namespace CheckPrintMIS.Gateway
{
    public class ChequeIssueGateway
    {
        
        private string connectionString =
           WebConfigurationManager.ConnectionStrings["ChequePrintConnString"].ConnectionString;

        private string message = "";

        public string Save(CheckIssue checkIssue)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    string query = "INSERT INTO Transact(InvNo,PartyId,BankCode,Amount,ChequeDate,Remarks," +
                                   "Status,EntryDate,EntryTime,UserName,Valid) " +
                                   "VALUES" +
                                   "(@InvNo,@PartyId,@BankCode,@Amount," +
                                   "@ChequeDate,@Remarks,@Status,@EntryDate,@EntryTime,@UserName,1)";
                   
                    SqlCommand command = new SqlCommand(query, connection, transaction);

                    command.Parameters.Add("InvNo", SqlDbType.VarChar);
                    command.Parameters["InvNo"].Value = checkIssue.TrNo;

                    command.Parameters.Add("PartyId", SqlDbType.VarChar);
                    command.Parameters["PartyId"].Value = checkIssue.PartyId;

                    command.Parameters.Add("BankCode", SqlDbType.VarChar);
                    command.Parameters["BankCode"].Value = checkIssue.BankCode;

                    command.Parameters.Add("Amount", SqlDbType.VarChar);
                    command.Parameters["Amount"].Value = checkIssue.Amount;

                    command.Parameters.Add("ChequeDate", SqlDbType.VarChar);
                    command.Parameters["ChequeDate"].Value = checkIssue.ChequeDate;

                    command.Parameters.Add("Remarks", SqlDbType.VarChar);
                    command.Parameters["Remarks"].Value = checkIssue.Remarks;

                    command.Parameters.Add("Status", SqlDbType.VarChar);
                    command.Parameters["Status"].Value = checkIssue.Status;

                    command.Parameters.Add("EntryDate", SqlDbType.VarChar);
                    command.Parameters["EntryDate"].Value = checkIssue.EntryDate;

                    command.Parameters.Add("EntryTime", SqlDbType.VarChar);
                    command.Parameters["EntryTime"].Value = checkIssue.EntryTime;

                    command.Parameters.Add("UserName", SqlDbType.VarChar);
                    command.Parameters["UserName"].Value = checkIssue.UserName;

                    int rowAffected = command.ExecuteNonQuery();

                    query = "UPDATE SerialNoMaintenance SET TrNo=TrNo+1";
                    SqlCommand cmd = new SqlCommand(query, connection, transaction);
                    cmd.ExecuteNonQuery();

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

                    message = exception.Message;
                    transaction.Rollback();
                    return message;
                }
            }

        }

        public int GetInvNo()
        {
            int trNo = 0;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT Max(TrNo+1) AS TrNo FROM SerialNoMaintenance";

            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                trNo = (int) reader["TrNo"];
            }

            connection.Close();
            return trNo;
        }

        public List<BankInformation> GetAllBank()
        {

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM BankInformation  ORDER BY BankName";

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


        public List<PartyInformation> GetAllParty()
        {

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM PartyInformation ORDER BY PartyName";

            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();

            List<PartyInformation> AllParty = new List<PartyInformation>();

            while (reader.Read())
            {
                PartyInformation party = new PartyInformation();
                party.PartyId = reader["PartyId"].ToString();
                party.PartyName = reader["PartyName"].ToString();
                party.Address = reader["Address"].ToString();
                party.ContactNo = reader["ContactNo"].ToString();
                party.ContactName = reader["ContactName"].ToString();
                party.Status = reader["Status"].ToString();

                AllParty.Add(party);
            }

            connection.Close();
            return AllParty;
        }


    }
}