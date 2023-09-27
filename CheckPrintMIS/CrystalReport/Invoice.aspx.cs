using System.Web.Configuration;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CheckPrintMIS.CrystalReport
{
    public partial class InvoiceUI : System.Web.UI.Page
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["ChequePrintConnString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            string invNo =Request.QueryString["InvNo"];
          
            SqlConnection connection = new SqlConnection(connectionString);
           
            string query = @"SELECT * FROM VW_Transact WHERE InvNo='"+ invNo +"'";
           
            connection.Open();

            SqlDataAdapter da = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath("//CrystalReport//Invoice.rpt"));
            rd.SetDataSource(dt);
            CrystalReportViewer1.ReportSource = rd;
        }
    }
}