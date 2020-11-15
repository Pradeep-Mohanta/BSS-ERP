using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BSSApp.FA.Models
{
    public class UserAssignModule
    {
        [Key]
        public int UserAssignModuleID { get; set; }
        public int ModuleMasterID { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public ModuleMaster ModuleMaster { get; set; }
    }
}
