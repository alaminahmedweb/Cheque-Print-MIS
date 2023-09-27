using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using CheckPrintMIS.Models;

namespace CheckPrintMIS.UI
{
    public partial class UserLogin : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ValidateUser()
        {
            try
            {
                int userId = 0;
                string ConnectionString = ConfigurationManager.ConnectionStrings["ChequePrintConnString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    string query = @"SELECT COUNT(UserName) AS UserId FROM Password WHERE UserName=@UserName AND Password=@Password ";
                    
                    SqlCommand cmd = new SqlCommand(query, con);
                    
                    cmd.Parameters.AddWithValue("@Username", username.Text);
                    cmd.Parameters.AddWithValue("@Password", password.Text);
                    
                    con.Open();
                    
                    SqlDataReader reader = cmd.ExecuteReader();
                    
                    if (reader.Read())
                    {
                        userId = (int)reader["UserId"];
                    }
                    con.Close();
                }

                switch (userId)
                {
                    case 0:
                        messageLabel.Text = "Username and/or password is incorrect.";
                        break;
                    default:
                        messageLabel.Text = "Successfully Loged in..!!";
                        Session.Clear();
                        Session["UserName"] = username.Text;
                        Response.Redirect("~/UI/Index.aspx");
                        break;
                }
            }
            catch (Exception exception)
            {
                messageLabel.Text = exception.Message;
            }
        }

        protected void cmdLogin_Click(object sender, EventArgs e)
        {
            ValidateUser();
        }

    }
}