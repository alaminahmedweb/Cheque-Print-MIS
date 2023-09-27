using CheckPrintMIS.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CheckPrintMIS.UI
{
    public partial class ReportUI : System.Web.UI.Page
    {
        ChequeIssueManager chequeIssueManager = new ChequeIssueManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime date = DateTime.Now;
                chequeDateFromTextBox.Text = date.ToString("yyyy-MM-dd");
                chequeDateToTextBox.Text = date.ToString("yyyy-MM-dd");
                LoadBankInfo();
                LoadPartyInfo();
            }
        }

        protected void checkInfoButton_Click(object sender, EventArgs e)
        {
            string partyCode = "";
            string bankCode = "";
            if (partyDropdownList.SelectedIndex != 0)
            {
                partyCode = partyDropdownList.SelectedValue;
            }

            if (bankDropDownList.SelectedIndex != 0)
            {
                bankCode = bankDropDownList.SelectedValue;
            }

            Response.Redirect("~/CrystalReport/CheckInfoForCR.aspx?PartyId=" + Server.UrlEncode(partyCode) + "&BankCode=" + Server.UrlEncode(bankCode) + "&DateFrom=" + Server.UrlEncode(chequeDateFromTextBox.Text) + "&DateTo=" + Server.UrlEncode(chequeDateToTextBox.Text) + "");
        }

        protected void bankInfoButtonButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CrystalReport/BankInformationForCR.aspx");

        }

        protected void partyInfoButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CrystalReport/PartyInformationForCR.aspx");
        }
        private void LoadPartyInfo()
        {
            partyDropdownList.DataSource = chequeIssueManager.GetAllParty();
            partyDropdownList.DataValueField = "PartyId";
            partyDropdownList.DataTextField = "PartyName";
            partyDropdownList.DataBind();
            partyDropdownList.Items.Insert(0, "--Select Party--");
        }

        private void LoadBankInfo()
        {
            bankDropDownList.DataSource = chequeIssueManager.GetAllBank();
            bankDropDownList.DataValueField = "BankCode";
            bankDropDownList.DataTextField = "BankName";
            bankDropDownList.DataBind();
            bankDropDownList.Items.Insert(0, "--Select Bank--");
        }
    }
}