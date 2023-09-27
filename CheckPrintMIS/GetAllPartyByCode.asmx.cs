using System.Data.SqlClient;
using CheckPrintMIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Configuration;

namespace CheckPrintMIS
{
    /// <summary>
    /// Summary description for GetAllPartyByCode
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class GetAllPartyByCode : System.Web.Services.WebService
    {
        private string connectionString =
           WebConfigurationManager.ConnectionStrings["ChequePrintConnString"].ConnectionString;
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        public List<PartyInformation> GetAllParty(List<string> aData)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM PartyInformation WHERE PartyId='" + aData + "'";

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
