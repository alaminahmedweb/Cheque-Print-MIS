using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CheckPrintMIS.Gateway;
using CheckPrintMIS.Manager;
using CheckPrintMIS.Models;

namespace CheckPrintMIS.UI
{
    public partial class CheckIssueUI : System.Web.UI.Page
    {
        ChequeIssueManager chequeIssueManager=new ChequeIssueManager();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPartyInfo();
                LoadBankInfo();
            }
        }

        private void LoadPartyInfo()
        {
            partyDropdownList.DataSource = chequeIssueManager.GetAllParty();
            partyDropdownList.DataValueField = "PartyId";
            partyDropdownList.DataTextField = "PartyName";
            partyDropdownList.DataBind();
        }

        private void LoadBankInfo()
        {
            bankDropDownList.DataSource = chequeIssueManager.GetAllBank();
            bankDropDownList.DataValueField = "BankCode";
            bankDropDownList.DataTextField = "BankName";
            bankDropDownList.DataBind();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;

            CheckIssue checkIssue = new CheckIssue();
            checkIssue.PartyId = partyDropdownList.SelectedValue;
            checkIssue.BankCode = bankDropDownList.SelectedValue;
            checkIssue.Amount = Convert.ToDouble(amountTextBox.Text);
            checkIssue.ChequeDate = chequeDateToTextBox.Text;
            checkIssue.Remarks = remarksTextBox.Text;
            checkIssue.Status = statusDropDownList.SelectedValue;
            checkIssue.EntryDate = date.ToString("yyyy-MM-dd");
            checkIssue.EntryTime = date.ToString("hh:mm:ss tt");
            checkIssue.UserName = Session["UserName"].ToString();
            checkIssue.TrNo = chequeIssueManager.GetInvNo();
            trNoTextBox.Text=checkIssue.TrNo.ToString();


            messageLabel.Text = chequeIssueManager.Save(checkIssue);
            
            if (messageLabel.Text == "Saved Successfully")
            {
                Response.Redirect("~/CrystalReport/Invoice.aspx?InvNo="+ trNoTextBox.Text +"");
            }
        }

        protected void reprintButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CrystalReport/Invoice.aspx?InvNo=" + trNoTextBox.Text + "");
        }

        protected void outputGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}