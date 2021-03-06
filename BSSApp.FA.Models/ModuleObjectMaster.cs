﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BSSApp.FA.Models
{
    public class ModuleObjectMaster
    {
        [Key]
        public int ModuleObjectMasterID { get; set; }
        public int ModuleMasterID { get; set; }
        public string ModuleCode { get; set; }
        public string ObjectName { get; set; }
        public string ObjectControllerName { get; set; }
        public string ObjectType { get; set; }
        public string ObjectDisplayCaption { get; set; }
        public ModuleMaster ModuleMaster { get; set; }
        public UserObjectAssignMaster UserObjectAssignMaster { get; set; }
    }
}
