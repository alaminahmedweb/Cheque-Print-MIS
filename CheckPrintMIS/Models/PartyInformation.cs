using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckPrintMIS.Models
{
    public class PartyInformation
    {
        public string PartyId { get; set; }

        public string PartyName { get; set; }
        
        public string Address { get; set; }
        
        public string ContactNo { get; set; }

        public string ContactName { get; set; }

        public string Status { get; set; }

        public string EntryDate { get; set; }

        public string EntryTime { get; set; }

        public string UserName { get; set; }

    }
}