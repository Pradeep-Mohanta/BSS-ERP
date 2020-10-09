using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BSSApp.FA.Models
{
    public class State
    {
        public int StateID { get; set; }
        public int CountryID { get; set; }

        public string StateCode { get; set; }

        public string StateName { get; set; }
        public bool StateActive { get; set; }

        public string Category { get; set; }

        public string EnterBy { get; set; }
        public DateTime EntryDate { get; set; }

        public Country Country { get; set; }
    }
}
