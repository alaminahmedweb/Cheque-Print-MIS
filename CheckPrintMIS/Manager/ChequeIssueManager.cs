using CheckPrintMIS.Gateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CheckPrintMIS.Models;


namespace CheckPrintMIS.Manager
{
    public class ChequeIssueManager
    {
        ChequeIssueGateway chequeIssueGateway=new ChequeIssueGateway();

        private string message = "";
        public string Save(CheckIssue checkIssue)
        {
            message = chequeIssueGateway.Save(checkIssue);
            return message;
        }
        public List<PartyInformation> GetAllParty()
        {
            return chequeIssueGateway.GetAllParty();
        }
        public List<BankInformation> GetAllBank()
        {
            return chequeIssueGateway.GetAllBank();
        }

        public int GetInvNo()
        {
            return chequeIssueGateway.GetInvNo();
        }
    }
}