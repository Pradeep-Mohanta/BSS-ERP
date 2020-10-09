using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSSApp.FA.Models
{
    public class AcMaster
    {
        public int AcMasterID { get; set; }
        public int LedgerID  { get; set; } //ledger

        [Required]
        public string LedgerCode { get; set; }
        
        [Required]
        public string Acno { get; set; }
        
        [Required]
        public string Acname { get; set; }

        public string Compcode { get; set; }

        public double Opbal { get; set; }

        public DateTime Ason { get; set; }

        public string DrCr { get; set; }

        public string Acad1 { get; set; }

        public string Acad2 { get; set; }

        public string Acad3 { get; set; }

        public string Acad4 { get; set; }

        public string City { get; set; }

        public string Pin { get; set; }
        public int TypeMastID { get; set; } //TypeMast
        public int BSheetGroupID { get; set; }//BSheetGroup

        public string Descr { get; set; }

        public string Panno { get; set; }

        public string Tanno { get; set; }

        public string STaxno { get; set; }

        public string Tin_VatNo { get; set; }

        public string Phone { get; set; }

        public string Mobile1 { get; set; }

        public string Mobile2 { get; set; }

        public string FaxNo { get; set; }

        public string EMail { get; set; }

        public string ContactPerson { get; set; }

        public string GroupSeries { get; set; }

        public double LimitAmount { get; set; }

        public double CreditAmount { get; set; }

        public DateTime Dob { get; set; }
        public int StateID { get; set; } //State
        public int CountryID { get; set; } //Country

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string AuthorisedBy { get; set; }
        public bool AuthorisedAc { get; set; }

        public DateTime AuthorisedDate { get; set; }
        public int CostCenterID { get; set; } //CostCenter

        public string CorporateName { get; set; }

        public string GSTCode { get; set; }

        public string ServiceCode { get; set; }

        public string AdharNo { get; set; }

        public Ledger Ledger { get; set; }
        public TypeMast TypeMast { get; set; }
        public BSheetGroup BSheetGroup { get; set; }
        public State State { get; set; }
        public Country Country { get; set; }
        public CostCenter CostCenter { get; set; }
      
    }
}
