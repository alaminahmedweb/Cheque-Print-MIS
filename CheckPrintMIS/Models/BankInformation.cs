using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckPrintMIS.Models
{
    public class BankInformation
    {
        public string BankCode { get; set; }

        public string BankName { get; set; }

        public string BranchName { get; set; }

        public string AccountNo { get; set; }

        public string EntryDate { get; set; }

        public string EntryTime { get; set; }

        public string UserName { get; set; }

    }
}