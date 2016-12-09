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
using System.Web.Http.Cors;

namespace UnitTestingWebAPI.API.Core.Controllers
{
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class BankTransactionsController : ApiController
    {
        private IBankTransactionService _BankTransactionService;

        public BankTransactionsController(IBankTransactionService BankTransactionService)
        {
            _BankTransactionService = BankTransactionService;
        }

        // GET: api/BankTransactions
        public IEnumerable<BankTransaction> GetBankTransactions()
        {
            return _BankTransactionService.GetBankTransactions();
        }

        //// GET: api/BankTransactions/5
        //[ResponseType(typeof(BankTransaction))]
        //public IHttpActionResult GetBankTransaction(int id)
        //{
        //    BankTransaction BankTransaction = _BankTransactionService.GetBankTransaction(id);
        //    if (BankTransaction == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(BankTransaction);
        //}

        //// PUT: api/BankTransactions/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutBankTransaction(int id, BankTransaction BankTransaction)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != BankTransaction.ID)
        //    {
        //        return BadRequest();
        //    }

        //    _BankTransactionService.UpdateBankTransaction(BankTransaction);

        //    try
        //    {
        //        _BankTransactionService.SaveBankTransaction();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!BankTransactionExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/BankTransactions
        //[ResponseType(typeof(BankTransaction))]
        //public IHttpActionResult PostBankTransaction(BankTransaction BankTransaction)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _BankTransactionService.CreateBankTransaction(BankTransaction);

        //    return CreatedAtRoute("DefaultApi", new { id = BankTransaction.ID }, BankTransaction);
        //}

        //// DELETE: api/BankTransactions/5
        //[ResponseType(typeof(BankTransaction))]
        //public IHttpActionResult DeleteBankTransaction(int id)
        //{
        //    BankTransaction BankTransaction = _BankTransactionService.GetBankTransaction(id);
        //    if (BankTransaction == null)
        //    {
        //        return NotFound();
        //    }

        //    _BankTransactionService.DeleteBankTransaction(BankTransaction);

        //    return Ok(BankTransaction);
        //}

        //private bool BankTransactionExists(int id)
        //{
        //    return _BankTransactionService.GetBankTransaction(id) != null;
        //}
    }
}
