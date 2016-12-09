using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Linq;
using System.Web;

namespace UnitTestingWebAPI.Domain
{
    public class BankTransaction
    {
        //[Key]
        public int ID { get; set; }

        //[Required]
        //public int FromAccountId { get; set; }
        //public virtual BankAccount FromAccount { get; set; }

        //[Required]
        public decimal Amount { get; set; }

        //[Required]
        //public int ToAccountId { get; set; }
        public virtual BankAccount ToAccount { get; set; }

        //public int FromAccountId { get; set; }
        //public int ToAccountId { get; set; }

        //[ForeignKey("FromAccountId")]
        //[InverseProperty("BankTransaction")]
        public virtual BankAccount FromAccount { get; set; }

        //[ForeignKey("ToAccountId")]
        //public virtual BankAccount ToAccount { get; set; }

        public DateTime timestamp { get; set; }
    }
}