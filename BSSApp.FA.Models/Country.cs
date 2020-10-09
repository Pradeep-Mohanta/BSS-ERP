using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BSSApp.FA.Models
{
    public class Country
    {
        public int CountryID { get; set; }

        public string CountryName { get; set; }
    }
}
