using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckPrintMIS.Models
{
    public class CheckIssue
    {
        public int TrNo { get; set; }

        public string PartyId { get; set; }

        public string BankCode { get; set; }

        public double Amount { get; set; }

        public string ChequeDate { get; set; }

        public string Remarks { get; set; }

        public string Status { get; set; }

        public string EntryDate { get; set; }

        public string EntryTime { get; set; }

        public string UserName { get; set; }

    }
}