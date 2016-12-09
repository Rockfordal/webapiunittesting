using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestingWebAPI.Data.Infrastructure;
using UnitTestingWebAPI.Data.Repositories;
using UnitTestingWebAPI.Domain;

namespace UnitTestingWebAPI.Service
{
    // operations you want to expose
    public interface IBankTransactionService
    {
        IEnumerable<BankTransaction> GetBankTransactions(string name = null);
        BankTransaction GetBankTransaction(int id);
        BankTransaction GetBankTransaction(string name);
        void CreateBankTransaction(BankTransaction BankTransaction);
        void UpdateBankTransaction(BankTransaction BankTransaction);
        void SaveBankTransaction();
        void DeleteBankTransaction(BankTransaction BankTransaction);
    }

    public class BankTransactionService : IBankTransactionService
    {
        private readonly IBankTransactionRepository BankTransactionRepository;
        private readonly IUnitOfWork unitOfWork;

        public BankTransactionService(IBankTransactionRepository BankTransactionsRepository, IUnitOfWork unitOfWork)
        {
            this.BankTransactionRepository = BankTransactionsRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IBankTransactionService Members

        public IEnumerable<BankTransaction> GetBankTransactions(string amount = null)
        {
            if (string.IsNullOrEmpty(amount))
                return BankTransactionRepository.GetAll();
            else
                return BankTransactionRepository.GetAll().Where(c => c.Amount.ToString() == amount);
        }

        public BankTransaction GetBankTransaction(int id)
        {
            var BankTransaction = BankTransactionRepository.GetById(id);
            return BankTransaction;
        }

        public BankTransaction GetBankTransaction(string name)
        {
            var BankTransaction = BankTransactionRepository.GetBankTransactionByName(name);
            return BankTransaction;
        }

        public void CreateBankTransaction(BankTransaction BankTransaction)
        {
            BankTransactionRepository.Add(BankTransaction);
        }

        public void UpdateBankTransaction(BankTransaction BankTransaction)
        {
            BankTransactionRepository.Update(BankTransaction);
        }

        public void DeleteBankTransaction(BankTransaction BankTransaction)
        {
            BankTransactionRepository.Delete(BankTransaction);
        }

        public void SaveBankTransaction()
        {
            unitOfWork.Commit();
        }

        #endregion
    }
}
