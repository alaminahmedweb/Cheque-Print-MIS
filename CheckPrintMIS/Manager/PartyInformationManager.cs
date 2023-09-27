using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CheckPrintMIS.Gateway;
using CheckPrintMIS.Models;

namespace CheckPrintMIS.Manager
{
    public class PartyInformationManager
    {
        PartyInformationGateway partyInformationGateway=new PartyInformationGateway();

        private string message;

        public string Save(PartyInformation partyInformation)
        {

            message = partyInformationGateway.Save(partyInformation);
            return message;
        }

        public string Update(PartyInformation partyInformation)
        {

            message = partyInformationGateway.Update(partyInformation);
            return message;
        }

        public List<PartyInformation> GetAllParty()
        {
            return partyInformationGateway.GetAllParty();
        }

        public List<PartyInformation> GetAllPartyByCode(string Code)
        {
            return partyInformationGateway.GetAllPartyByCode(Code);
        }
    }
}