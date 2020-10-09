using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BSSApp.FA.Models
{
    public class BSheetGroup
    {
        public int BSheetGroupID { get; set; }

        public string G_Code { get; set; }

        public string P_Code { get; set; }

        public string G_Name { get; set; }

        public string G_Type { get; set; }
    }
}
