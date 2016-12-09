using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestingWebAPI.Data.Infrastructure;
using UnitTestingWebAPI.Domain;

namespace UnitTestingWebAPI.Data.Repositories
{
    public class BankTransactionRepository : RepositoryBase<BankTransaction>, IBankTransactionRepository
    {
        public BankTransactionRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public BankTransaction GetBankTransactionByName(string TransactionAmount)
        {
            var _BankTransaction = this.DbContext.BankTransactions.Where(b => b.Amount.ToString() == TransactionAmount).FirstOrDefault();

            return _BankTransaction;
        }
    }

    public interface IBankTransactionRepository : IRepository<BankTransaction>
    {
        BankTransaction GetBankTransactionByName(string BankTransactionName);
    }
}
