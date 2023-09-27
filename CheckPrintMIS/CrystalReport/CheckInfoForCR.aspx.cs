using System.Web.UI.WebControls.WebParts;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CheckPrintMIS.CrystalReport
{
    public partial class CheckInfoForCR : System.Web.UI.Page
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["ChequePrintConnString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            string partyId = Request.QueryString["PartyId"];
            string bankCode = Request.QueryString["BankCode"];
            string dateFrom = Request.QueryString["DateFrom"];
            string dateTo = Request.QueryString["DateTo"];

            string lcCondition= "";
            lcCondition = "AND Valid=1";

            if (partyId != "")
            {
                lcCondition = lcCondition +" AND PartyId='"+ partyId +"'" ;
            }
            if (bankCode != "")
            {
                lcCondition = lcCondition + " AND BankCode='" + bankCode + "'";
            }

            SqlConnection connection = new SqlConnection(connectionString);

            string query = @"SELECT * FROM VW_Transact WHERE ChequeDate BETWEEN '"+ dateFrom +"' AND '"+ dateTo +"' "+ lcCondition +"";
            connection.Open();

            SqlDataAdapter da = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath("//CrystalReport//CheckInfoChequeDateWise.rpt"));
            rd.SetDataSource(dt);
            CrystalReportViewer1.ReportSource = rd;
        }
    }
}