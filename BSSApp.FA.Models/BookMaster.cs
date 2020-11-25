using System;
using System.Collections.Generic;
using System.Text;

namespace BSSApp.FA.Models
{
    public class BookMaster
    {
        public int BookMasterID { get; set; }
        public string Comp_Id { get; set; }
        public int BookNo { get; set; }
        public string Type { get; set; }
        public string BookName { get; set; }
        public double Opbal { get; set; }
        public string Drcr { get; set; }
        public string G_Code_Dr { get; set; }
        public string G_Code_Cr { get; set; }
        public DateTime AsonDate { get; set; }
        public string Descr { get; set; }
        public string City { get; set; }
        public string Pin { get; set; }
        public int BookCategoryID { get; set; }
        public string CategoryCode { get; set; }
        public bool? DisplayBook { get; set; }
        public int CostCenterID { get; set; }
        public int ReportDisplay { get; set; }
        public bool? ActiveStatus { get; set; }

        public CostCenter CostCenter { get; set; }
        public BookCategory BookCategory { get; set; }
    }
}
