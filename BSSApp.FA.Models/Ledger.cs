using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BSSApp.FA.Models
{
    public class Ledger
    {
        public int LedgerID { get; set; }

        public string LedgerCode { get; set; }

        public string LedgerName { get; set; }

        public float OpeningBal { get; set; }
        public DateTime Ason { get; set; }
        public int BSheetGroupID { get; set; } //BSheetGroup

        public string DrCr { get; set; }

        public int TypeMastID { get; set; } //TypeMast

        public string Remark { get; set; }

        public string TableName { get; set; }
        public int CostCenterID { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public TypeMast TypeMast { get; set; }
        public BSheetGroup BSheetGroup { get; set; }
        public CostCenter CostCenter { get; set; }
    }
}
