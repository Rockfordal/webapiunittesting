using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestingWebAPI.Domain;

namespace UnitTestingWebAPI.Data.Configurations
{
    public class BankAccountConfiguration : EntityTypeConfiguration<BankAccount>
    {
        public BankAccountConfiguration()
        {
            ToTable("BankAccount");
            Property(b => b.Name).IsRequired().HasMaxLength(100);
            Property(b => b.Number).IsRequired().HasMaxLength(200);
            Property(b => b.Owner).IsRequired().HasMaxLength(50);
            Property(b => b.DateCreated).HasColumnType("datetime2");
        }
    }
}
