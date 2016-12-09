using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestingWebAPI.Data.Infrastructure;
using UnitTestingWebAPI.Domain;

namespace UnitTestingWebAPI.Data.Repositories
{
    public class BankAccountRepository : RepositoryBase<BankAccount>, IBankAccountRepository
    {
        public BankAccountRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public BankAccount GetBankAccountByName(string BankAccountName)
        {
            var _BankAccount = this.DbContext.BankAccounts.Where(b => b.Name == BankAccountName).FirstOrDefault();

            return _BankAccount;
        }
    }

    public interface IBankAccountRepository : IRepository<BankAccount>
    {
        BankAccount GetBankAccountByName(string BankAccountName);
    }
}
