using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BSSApp.FA.Models
{
    public class TypeMast
    {
        public int TypeMastID { get; set; }

        public string TypeCode { get; set; }

        public string Description { get; set; }

        public string ActLgrBook { get; set; }
    }
}
