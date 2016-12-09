using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using UnitTestingWebAPI.Domain;
using UnitTestingWebAPI.Service;

namespace UnitTestingWebAPI.API.Core.Controllers
{
    public class BankAccountsController : ApiController
    {
        private IBankAccountService _BankAccountService;

        public BankAccountsController(IBankAccountService BankAccountService)
        {
            _BankAccountService = BankAccountService;
        }

        // GET: api/BankAccounts
        public IEnumerable<BankAccount> GetBankAccounts()
        {
            return _BankAccountService.GetBankAccounts();
        }

        // GET: api/BankAccounts/5
        [ResponseType(typeof(BankAccount))]
        public IHttpActionResult GetBankAccount(int id)
        {
            BankAccount BankAccount = _BankAccountService.GetBankAccount(id);
            if (BankAccount == null)
            {
                return NotFound();
            }

            return Ok(BankAccount);
        }

        // PUT: api/BankAccounts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBankAccount(int id, BankAccount BankAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != BankAccount.ID)
            {
                return BadRequest();
            }

            _BankAccountService.UpdateBankAccount(BankAccount);

            try
            {
                _BankAccountService.SaveBankAccount();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BankAccountExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/BankAccounts
        [ResponseType(typeof(BankAccount))]
        public IHttpActionResult PostBankAccount(BankAccount BankAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _BankAccountService.CreateBankAccount(BankAccount);

            return CreatedAtRoute("DefaultApi", new { id = BankAccount.ID }, BankAccount);
        }

        // DELETE: api/BankAccounts/5
        [ResponseType(typeof(BankAccount))]
        public IHttpActionResult DeleteBankAccount(int id)
        {
            BankAccount BankAccount = _BankAccountService.GetBankAccount(id);
            if (BankAccount == null)
            {
                return NotFound();
            }

            _BankAccountService.DeleteBankAccount(BankAccount);

            return Ok(BankAccount);
        }

        private bool BankAccountExists(int id)
        {
            return _BankAccountService.GetBankAccount(id) != null;
        }
    }
}
