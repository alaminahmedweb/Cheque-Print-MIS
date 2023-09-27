using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using CheckPrintMIS.Models;
using System.Configuration;

namespace CheckPrintMIS.Gateway
{
    public class PartyInformationGateway
    {
        private string connectionString =
            WebConfigurationManager.ConnectionStrings["ChequePrintConnString"].ConnectionString;

        private string message = "";
        public string Save(PartyInformation partyInformation)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    string query = "INSERT INTO PartyInformation(PartyId,PartyName,Address,ContactNo,ContactName," +
                                   "Status,EntryDate,EntryTime,UserName,Valid) " +
                                   "VALUES" +
                                   "(@PartyId,@PartyName,@Address," +
                                   "@ContactNo,@ContactName,@Status,@EntryDate,@EntryTime,@UserName,1)";
                    SqlCommand command = new SqlCommand(query, connection, transaction);

                    command.Parameters.Add("PartyId", SqlDbType.VarChar);
                    command.Parameters["PartyId"].Value = partyInformation.PartyId;

                    command.Parameters.Add("PartyName", SqlDbType.VarChar);
                    command.Parameters["PartyName"].Value = partyInformation.PartyName;

                    command.Parameters.Add("Address", SqlDbType.VarChar);
                    command.Parameters["Address"].Value = partyInformation.Address;

                    command.Parameters.Add("ContactNo", SqlDbType.VarChar);
                    command.Parameters["ContactNo"].Value = partyInformation.ContactNo;

                    command.Parameters.Add("ContactName", SqlDbType.VarChar);
                    command.Parameters["ContactName"].Value = partyInformation.ContactName;

                    command.Parameters.Add("Status", SqlDbType.VarChar);
                    command.Parameters["Status"].Value = partyInformation.Status;

                    command.Parameters.Add("EntryDate", SqlDbType.VarChar);
                    command.Parameters["EntryDate"].Value = partyInformation.EntryDate;

                    command.Parameters.Add("EntryTime", SqlDbType.VarChar);
                    command.Parameters["EntryTime"].Value = partyInformation.EntryTime;

                    command.Parameters.Add("UserName", SqlDbType.VarChar);
                    command.Parameters["UserName"].Value = partyInformation.UserName;

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

                    message = exception.Message;
                    transaction.Rollback();
                    return message;
                }
            }

        }
        public string Update(PartyInformation partyInformation)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    string query = "UPDATE PartyInformation SET PartyName=@PartyName," +
                                   "Address=@Address,ContactNo=@ContactNo,ContactName=@ContactName," +
                                   "Status=@Status,UserName=@UserName WHERE PartyId=@PartyId";
                    SqlCommand command = new SqlCommand(query, connection, transaction);

                    command.Parameters.Add("PartyId", SqlDbType.VarChar);
                    command.Parameters["PartyId"].Value = partyInformation.PartyId;

                    command.Parameters.Add("PartyName", SqlDbType.VarChar);
                    command.Parameters["PartyName"].Value = partyInformation.PartyName;

                    command.Parameters.Add("Address", SqlDbType.VarChar);
                    command.Parameters["Address"].Value = partyInformation.Address;

                    command.Parameters.Add("ContactNo", SqlDbType.VarChar);
                    command.Parameters["ContactNo"].Value = partyInformation.ContactNo;

                    command.Parameters.Add("ContactName", SqlDbType.VarChar);
                    command.Parameters["ContactName"].Value = partyInformation.ContactName;

                    command.Parameters.Add("Status", SqlDbType.VarChar);
                    command.Parameters["Status"].Value = partyInformation.Status;

                    command.Parameters.Add("EntryDate", SqlDbType.VarChar);
                    command.Parameters["EntryDate"].Value = partyInformation.EntryDate;

                    command.Parameters.Add("EntryTime", SqlDbType.VarChar);
                    command.Parameters["EntryTime"].Value = partyInformation.EntryTime;

                    command.Parameters.Add("UserName", SqlDbType.VarChar);
                    command.Parameters["UserName"].Value = partyInformation.UserName;

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

        public List<PartyInformation> GetAllParty()
        {

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM PartyInformation ORDER BY PartyId";

            connection.Open();

            SqlCommand command = new SqlCommand(query,connection);

            SqlDataReader reader = command.ExecuteReader();

            List<PartyInformation> AllParty = new List<PartyInformation>();

            while (reader.Read())
            {
                PartyInformation party = new PartyInformation();
                party.PartyId=reader["PartyId"].ToString();
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

        public List<PartyInformation> GetAllPartyByCode(string Code)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM PartyInformation WHERE PartyId='"+ Code  + "'";

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