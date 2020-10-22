using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BSSApp.FA.Models
{
    public class ModuleMaster
    {
        [Key]
        public int ModuleMasterID { get; set; }
        public string ModuleCode { get; set; }
        public string ModuleName { get; set; }
        public bool ModuleActive { get; set; }
    }
}
