using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

//namespace Banken.Entities
namespace UnitTestingWebAPI.Domain
{
    public class Person
    {
        //[Key]
        public int Id { get; set; }

        //[Required]
        //[MinLength(8), MaxLength(12)]
        public string SSN { get; set; }

        //[Required]
        // [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        //[StringLength(50, ErrorMessage = "Firstname cannot be longer than 50 characters.")]
        public string FirstName { get; set; }

        //[Required]
        //[StringLength(50, ErrorMessage = "Lastname cannot be longer than 50 characters.")]
        public string LastName { get; set; }

        //[Display(Name = "Full Name")]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        public virtual ICollection<BankAccount> BankAccounts { get; set; }
    }
}