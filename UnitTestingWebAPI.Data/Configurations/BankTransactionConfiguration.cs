using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestingWebAPI.Domain;

namespace UnitTestingWebAPI.Data.Configurations
{
    public class BankTransactionConfiguration : EntityTypeConfiguration<BankTransaction>
    {
        public BankTransactionConfiguration()
        {
            ToTable("BankTransactions");
            Property(t => t.Amount).IsRequired();

            HasRequired(t => t.FromAccount)
            .WithMany()
            //.HasForeignKey(f => f.FromAccount)
            .WillCascadeOnDelete(false);

            HasRequired(t => t.ToAccount)
            .WithMany()
            //.HasForeignKey(f => f.FromAccount)
             .WillCascadeOnDelete(false);

        }
    }
}
