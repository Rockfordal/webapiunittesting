using System;

namespace UnitTestingWebAPI.Domain
{
    public class BankAccount
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Owner { get; set; }
        public DateTime DateCreated { get; set; }
        public int xxx { get; set; }

        //public virtual ICollection<Article> Transactions { get; set; }

        public BankAccount()
        {
            //Transactions = new HashSet<Transaction>();
        }
    }
}
