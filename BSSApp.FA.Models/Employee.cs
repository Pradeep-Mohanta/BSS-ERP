using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
//using System.ComponentModel.DataAnnotations.Validation;

namespace BSSApp.FA.Models
{
    public class Employee
    {
        //Validation Attributes
        //[Required],[Range],[MinLength],[MaxLength],[Compare],[RegularExpression]
        public int EmployeeID { get; set; }

        [Required(ErrorMessage ="First name must be required.")] //validation attribute
        [MinLength(2,ErrorMessage ="Minimum 2 charecter required for the FirstName field.")] //validation attribute
        public string FirstName { get; set; }

        [Required(ErrorMessage ="Last name must be required.")]//validation attribute
        public string LastName { get; set; }

        [EmailAddress]
        //[EmailDomainValidator(AllowedDomain ="BioScanSolution.com",ErrorMessage ="Only BioScanSolution.com domain is allow.")]
        public string Email { get; set; }
        public DateTime DateofBirth { get; set; }
        //public Gender Gender { get; set; }
        public int DepartmentID { get; set; }
        //public string PhotoPath { get; set; }
        
        ////[ValidateComplexType]
        //public Department Department { get; set; } //Navigation property
    }
}
