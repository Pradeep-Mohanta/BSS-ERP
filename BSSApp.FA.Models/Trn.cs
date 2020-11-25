using System;
using System.Collections.Generic;
using System.Text;

namespace BSSApp.FA.Models
{
    public class Trn
    {
        public int TrnID { get; set; }
        public string Vno { get; set; }
        public int SvNo { get; set; }
        public DateTime Vdt { get; set; }
        public int LedgerID { get; set; }
        public string Slcd { get; set; }
        public int SubLedgerID { get; set; }
        public string SubLcd { get; set; }
        public int AcMasterID { get; set; }
        public string Acno { get; set; }
        public string Narr1 { get; set; }
        public string Narr2 { get; set; }
        public string Narr3 { get; set; }
        public string Dc { get; set; }
        public string PairNo { get; set; }
        public double Amount { get; set; }
        public DateTime? Entrydate { get; set; }
        public int BookMasterID { get; set; }
        public int BookNo { get; set; }
        public string Username { get; set; }
        public int CostCenterID { get; set; }
        public string Comp_Id { get; set; }
        public string ChequeNo { get; set; }
        public string ChqBr { get; set; }
        public string RefModuleCode { get; set; }
        public string ShareTrnNo { get; set; }
        public string BranchCode { get; set; }

        public AcMaster AcMaster { get; set; }
        public Ledger Ledger { get; set; }
        public SubLedger SubLedger { get; set; }
        public CostCenter CostCenter { get; set; }
        public BookMaster BookMaster { get; set; }
    }
}
