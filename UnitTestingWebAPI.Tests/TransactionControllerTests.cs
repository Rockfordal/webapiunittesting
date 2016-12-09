#region Usings
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Http.Routing;
using UnitTestingWebAPI.API.Core.Controllers;
using UnitTestingWebAPI.Data;
using UnitTestingWebAPI.Data.Infrastructure;
using UnitTestingWebAPI.Data.Repositories;
using UnitTestingWebAPI.Domain;
using UnitTestingWebAPI.Service;
#endregion

namespace UnitTestingWebAPI.Tests
{
    [TestFixture]
    public class TransactionControllerTests
    {
        #region Variables
        IBankTransactionService _bankTransactionService;
        IBankTransactionRepository _bankTransactionRepository;
        IUnitOfWork _unitOfWork;
        List<BankTransaction> _randomBankTransactions;
        #endregion

        #region Setup
        [SetUp]
        public void Setup()
        {
            _randomBankTransactions = SetupBankTransactions();
            _bankTransactionRepository = SetupBankTransactionRepository();
            _unitOfWork = new Mock<IUnitOfWork>().Object;
            _bankTransactionService = new BankAccountService(_bankAccountRepository, _unitOfWork);
        }

        public List<BankAccount> SetupBankAccounts()
        {
            int _counter = new int();
            List<BankTransaction> _transactions = BloggerInitializer.GetBankTransactions();

            foreach (BankTransaction _transaction in _transactions)
                _transaction.ID = ++_counter;

            return _transactions;
        }

        public IBankAccountRepository SetupBankTransactionRepository()
        {
            // Init repository
            var repo = new Mock<IBankTransactionRepository>();

            // Setup mocking behavior
            repo.Setup(r => r.GetAll()).Returns(_randomBankTransactions);

            repo.Setup(r => r.GetById(It.IsAny<int>()))
                .Returns(new Func<int, BankTransaction>(
                    id => _randomBankTransactions.Find(a => a.ID.Equals(id))));

            repo.Setup(r => r.Add(It.IsAny<BankTransaction>()))
                .Callback(new Action<BankTransaction>(newBankTransaction =>
                {
                    dynamic maxTransactionID = _randomBankTransactions.Last().ID;
                    dynamic nextTransactionID = maxTransactionID + 1;
                    newBankTransaction.ID = nextTransactionID;
                    //newBankAccount.DateCreated = DateTime.Now;
                    _randomBankTransactions.Add(newBankTransaction);
                }));

            repo.Setup(r => r.Update(It.IsAny<BankTransaction>()))
                .Callback(new Action<BankTransaction>(x =>
                {
                    var oldBankTransaction = _randomBankTransactions.Find(a => a.ID == x.ID);
                    //oldBankTransaction.DateCreated = DateTime.Now;
                    oldBankTransaction.Amount = x.Amount;
                    //oldBankAccount.Number = x.Number;
                    //oldBankAccount.Owner = x.OwnerID;
                    //oldBankACcount.URL = x.URL;
                }));

            repo.Setup(r => r.Delete(It.IsAny<BankTransaction>()))
                .Callback(new Action<BankTransaction>(x =>
                {
                    var _bankAccountToRemove = _randomBankTransactions.Find(a => a.ID == x.ID);

                    if (_bankAccountToRemove != null)
                        _randomBankTransactions.Remove(_bankTransactiontToRemove);
                }));

            // Return mock implementation
            return repo.Object;
        }

        #endregion

        #region Tests

        #endregion
    }
}
