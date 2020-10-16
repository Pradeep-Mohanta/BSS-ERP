using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BSSApp.FA.Models
{
    public class UserObjectAssignMaster
    {
        [Key]
        public int UserObjectAssignMasterID { get; set; }
        public int ModuleObjectMasterID { get; set; }
        public string UserName { get; set; }
        public bool Op_Admin { get; set; }
        public bool Op_Read { get; set; }
        public bool Op_Write { get; set; }
        public bool Op_Edit { get; set; }
        public bool Op_Delete { get; set; }
    }
}
