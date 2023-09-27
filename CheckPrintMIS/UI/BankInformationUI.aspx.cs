using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CheckPrintMIS.Manager;
using CheckPrintMIS.Models;

namespace CheckPrintMIS.UI
{
    public partial class BankInformationUI : System.Web.UI.Page
    {
        BankInformationManager bankInformationManager=new BankInformationManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAllBanks();
                refreshAll();
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;

            BankInformation bankInformation = new BankInformation();
            bankInformation.BankCode = codeTextBox.Text;
            bankInformation.BankName = nameTextBox.Text;
            bankInformation.BranchName = branchTextBox.Text;
            bankInformation.AccountNo = accountNoTextBox.Text;
            bankInformation.EntryDate = date.ToString("yyyy-MM-dd");
            bankInformation.EntryTime = date.ToString("hh:mm:ss tt");
            bankInformation.UserName = Session["UserName"].ToString();

            messageLabel.Text = bankInformationManager.Save(bankInformation);
            if (messageLabel.Text == "Saved Successfully")
            {
                GetAllBanks();
                refreshAll();
            }
        }

        private void refreshAll()
        {
            codeTextBox.Text = "";
            nameTextBox.Text = "";
            branchTextBox.Text = "";
            accountNoTextBox.Text = "";
        }

        protected void outputGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void GetAllBanks()
        {
            outputGridView.DataSource = bankInformationManager.GetAllBank();
            outputGridView.DataBind();
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;

            BankInformation bankInformation = new BankInformation();
            bankInformation.BankCode = codeTextBox.Text;
            bankInformation.BankName = nameTextBox.Text;
            bankInformation.BranchName = branchTextBox.Text;
            bankInformation.AccountNo = accountNoTextBox.Text;
            bankInformation.EntryDate = date.ToString("yyyy-MM-dd");
            bankInformation.EntryTime = date.ToString("hh:mm:ss tt");
            bankInformation.UserName = Session["UserName"].ToString();

            messageLabel.Text = bankInformationManager.Update(bankInformation);
        }

        protected void printButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CrystalReport/BankInformationForCR.aspx");
        }

        protected void getBankButton_Click(object sender, EventArgs e)
        {
            List<BankInformation> allBank = bankInformationManager.GetAllBankByCode(codeTextBox.Text);

            foreach (var bank in allBank)
            {
                nameTextBox.Text = bank.BankName;
                branchTextBox.Text = bank.BranchName;
                accountNoTextBox.Text = bank.AccountNo;
            }
        }

        protected void outputGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            outputGridView.PageIndex = e.NewPageIndex;
            GetAllBanks();
        }
    }
}