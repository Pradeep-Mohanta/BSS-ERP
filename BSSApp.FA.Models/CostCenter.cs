using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BSSApp.FA.Models
{
    public class CostCenter
    {
        public int CostCenterID { get; set; }

        public string CostCenterName { get; set; }

        public string CCAdd1 { get; set; }

        public string CCAdd2 { get; set; }

        public int StateID { get; set; } //State

        public string CCCity { get; set; }

        public string CCPin { get; set; }

        public string CCEmail { get; set; }

        public string CCLst { get; set; }

        public string CCCst { get; set; }

        public string CCPan { get; set; }

        public string CCLink1 { get; set; }

        public string CCLink2 { get; set; }

        public string Phone { get; set; }
        public bool IsActive { get; set; }

        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public string GSTNo { get; set; }

        public string CType { get; set; }

        public State State { get; set; }
    }
}
