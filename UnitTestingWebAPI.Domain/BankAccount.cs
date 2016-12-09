using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingWebAPI.Domain
{
    public class BankAccount
    {
        //[Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Number { get; set; }

        public DateTime DateCreated { get; set; }

        //[InverseProperty("FromAccount")]
        //public ICollection<BankTransaction> Outgoing { get; set; }
        
        //[InverseProperty("ToAccount")]
        //public ICollection<BankTransaction> Incoming { get; set; }

        public string Owner { get; set; }

        //public virtual Person Person { get; set; }

        public BankAccount()
        {
            //Transactions = new HashSet<Transaction>();
        }
    }
}

