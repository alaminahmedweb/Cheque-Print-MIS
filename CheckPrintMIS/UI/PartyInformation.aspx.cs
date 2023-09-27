using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using CheckPrintMIS.CrystalReport;
using CheckPrintMIS.Manager;
using System.Web.Script.Serialization;
using PartyInformation = CheckPrintMIS.Models.PartyInformation;

namespace CheckPrintMIS.UI
{
    public partial class PartyInformationUI : System.Web.UI.Page
    {
        PartyInformationManager partyInformationManager = new PartyInformationManager();
        private List<PartyInformation> AllParty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAllParty();
                refreshAll();
                
            }
        }

        private void refreshAll()
        {
            codeTextBox.Text = "";
            nameTextBox.Text = "";
            addressTextBox.Text = "";
            contactNoTextBox.Text = "";
            contactNameTextBox.Text = "";
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;

            PartyInformation partyInformation = new PartyInformation();
            partyInformation.PartyId = codeTextBox.Text;
            partyInformation.PartyName = nameTextBox.Text;
            partyInformation.Address = addressTextBox.Text;
            partyInformation.ContactNo = contactNoTextBox.Text;
            partyInformation.ContactName = contactNameTextBox.Text;
            partyInformation.Status = statusDropDownList.SelectedValue;
            partyInformation.EntryDate = date.ToString("yyyy-MM-dd");
            partyInformation.EntryTime = date.ToString("hh:mm:ss tt");
            partyInformation.UserName = Session["UserName"].ToString();

            messageLabel.Text = partyInformationManager.Save(partyInformation);
            if (messageLabel.Text == "Saved Successfully")
            {
                GetAllParty();
                refreshAll();
            }
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            PartyInformation partyInformation = new PartyInformation();
            partyInformation.PartyId = codeTextBox.Text;
            partyInformation.PartyName = nameTextBox.Text;
            partyInformation.Address = addressTextBox.Text;
            partyInformation.ContactNo = contactNoTextBox.Text;
            partyInformation.ContactName = contactNameTextBox.Text;
            partyInformation.Status = statusDropDownList.SelectedValue;
            partyInformation.EntryDate = date.ToString("yyyy-MM-dd");
            partyInformation.EntryTime = date.ToString("hh:mm:ss tt");
            partyInformation.UserName = Session["UserName"].ToString();

            messageLabel.Text = partyInformationManager.Update(partyInformation);
        }

        private void GetAllParty()
        {
            outputGridView.DataSource = partyInformationManager.GetAllParty();
            outputGridView.DataBind();
        }


        protected void homeButton_Click(object sender, EventArgs e)
        {
           
        }

        protected void getPartyButton_Click(object sender, EventArgs e)
        {
            List<PartyInformation> allParty = partyInformationManager.GetAllPartyByCode(codeTextBox.Text);

            foreach (var party in allParty)
            {
                nameTextBox.Text = party.PartyName;
                addressTextBox.Text = party.Address;
                contactNoTextBox.Text = party.ContactNo;
                contactNameTextBox.Text = party.ContactName;
                statusDropDownList.DataTextField = party.Status;
            }
        }

        protected void printButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CrystalReport/PartyInformationForCR.aspx");
        }

        protected void outputGridView_PreRender(object sender, EventArgs e)
        {
            outputGridView.UseAccessibleHeader = false;
            outputGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        protected void outputGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            outputGridView.PageIndex = e.NewPageIndex;
            GetAllParty();
        }
        
    }
}