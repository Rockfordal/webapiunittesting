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
    public interface IBankAccountService
    {
        IEnumerable<BankAccount> GetBankAccounts(string name = null);
        BankAccount GetBankAccount(int id);
        BankAccount GetBankAccount(string name);
        void CreateBankAccount(BankAccount BankAccount);
        void UpdateBankAccount(BankAccount BankAccount);
        void SaveBankAccount();
        void DeleteBankAccount(BankAccount BankAccount);
    }

    public class BankAccountService : IBankAccountService
    {
        private readonly IBankAccountRepository bankAccountRepository;
        private readonly IUnitOfWork unitOfWork;

        public BankAccountService(IBankAccountRepository BankAccountsRepository, IUnitOfWork unitOfWork)
        {
            this.bankAccountRepository = BankAccountsRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IBankAccountService Members

        public IEnumerable<BankAccount> GetBankAccounts(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return bankAccountRepository.GetAll();
            else
                return bankAccountRepository.GetAll().Where(c => c.Name == name);
        }

        public BankAccount GetBankAccount(int id)
        {
            var BankAccount = bankAccountRepository.GetById(id);
            return BankAccount;
        }

        public BankAccount GetBankAccount(string name)
        {
            var BankAccount = bankAccountRepository.GetBankAccountByName(name);
            return BankAccount;
        }

        public void CreateBankAccount(BankAccount BankAccount)
        {
            bankAccountRepository.Add(BankAccount);
        }

        public void UpdateBankAccount(BankAccount BankAccount)
        {
            bankAccountRepository.Update(BankAccount);
        }

        public void DeleteBankAccount(BankAccount BankAccount)
        {
            bankAccountRepository.Delete(BankAccount);
        }

        public void SaveBankAccount()
        {
            unitOfWork.Commit();
        }

        #endregion
    }
}
