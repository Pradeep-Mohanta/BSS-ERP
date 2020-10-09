using System;
using System.Collections.Generic;
using System.Text;

namespace BSSApp.FA.Models
{
    public class SubLedger
    {
        public int SubLedgerID { get; set; }
        public int LedgerID { get; set; } //ledger
        public string LedgerCode { get; set; }
        public string SubLedgerCode { get; set; }
        public string SubLedgerName { get; set; }
        public int BSheetGroupID { get; set; } //BSheetGroupID
        public string DrCr { get; set; }
        public double OpBal { get; set; }
        public DateTime  Ason { get; set; }
        public string Remark { get; set; }
        public bool IsDisable { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Ledger Ledger { get; set; }
        public BSheetGroup BSheetGroup { get; set; }
    }
}
