using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CheckPrintMIS.Gateway;
using CheckPrintMIS.Models;

namespace CheckPrintMIS.Manager
{
    public class BankInformationManager
    {
        BankInformationGateway bankInformationGateway = new BankInformationGateway();

        private string message;

        public string Save(BankInformation bankInformation)
        {
            message = bankInformationGateway.Save(bankInformation);
            return message;
        }

        public string Update(BankInformation bankInformation)
        {

            message = bankInformationGateway.Update(bankInformation);
            return message;
        }

        public List<BankInformation> GetAllBank()
        {
            return bankInformationGateway.GetAllBank();
        }


        public List<BankInformation> GetAllBankByCode(string code)
        {
            return bankInformationGateway.GetAllBankByCode(code);
        }
    }
}