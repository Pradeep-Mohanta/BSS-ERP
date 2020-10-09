using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BSSApp.FA.Models
{
    public class AccountGroupMaster
    {
        [Key]
        public int AccountGroupID { get; set; }
        public string  LedgerCode { get; set; }
        public string AccountGroupCode { get; set; }
        public string AccountGroupName { get; set; }
        public string AccountGroupDesc { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
