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
    public partial class BankInformationForCR : System.Web.UI.Page
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["ChequePrintConnString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = @"SELECT * FROM BankInformation";
            connection.Open();

            SqlDataAdapter da = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath("//CrystalReport//BankInfo.rpt"));
            rd.SetDataSource(dt);
            CrystalReportViewer1.ReportSource = rd;
        }
    }
}