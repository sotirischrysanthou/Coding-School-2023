using FuelStation.EF.Repository;
using FuelStation.Model;
using FuelStation.Web.Blazor.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FuelStation.Web.Blazor.Server.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase {
        // Properties
        private readonly IEntityRepo<Transaction> _transactionRepo;

        // Constructors
        public TransactionController(IEntityRepo<Transaction> transactionRepo) {
            _transactionRepo = transactionRepo;
        }

        // GET: api/<TransactionController>
        [HttpGet]
        [Authorize(Roles = "Manager,Cashier")]
        public async Task<ActionResult<IEnumerable<TransactionWinDto>>> Get() {
            var result = await _transactionRepo.GetAll();
            var selectTransactionList = result.Select(transaction => new TransactionWinDto(transaction));
            return Ok(selectTransactionList);
        }

        // POST api/<TransactionController>
        [HttpPost]
        [Authorize(Roles = "Manager,Cashier")]
        public async Task<ActionResult> Post(TransactionWinDto transaction) {
            var newTransaction = new Transaction(transaction.Date,
                                                 transaction.PaymentMethod,
                                                 transaction.TotalValue,
                                                 transaction.EmployeeId,
                                                 transaction.CustomerId);
            await _transactionRepo.Add(newTransaction);
            return Ok();
        }

        // PUT api/<TransactionController>/5
        [HttpPut]
        [Authorize(Roles = "Manager,Cashier")]
        public async Task<ActionResult> Put(TransactionWinDto transaction) {
            var dbTransaction = await _transactionRepo.GetById(transaction.Id);
            if (dbTransaction is null) {
                //Todo: handle if dbTransaction is null
                return NotFound("Transaction not Found");
            }
            dbTransaction.Date = transaction.Date;
            dbTransaction.TotalValue = transaction.TotalValue;
            dbTransaction.PaymentMethod = transaction.PaymentMethod;
            dbTransaction.CustomerId = transaction.CustomerId;
            dbTransaction.EmployeeId = transaction.EmployeeId;

            await _transactionRepo.Update(transaction.Id, dbTransaction);
            return Ok();
        }

        // DELETE api/<TransactionController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Manager,Cashier")]
        public async Task<ActionResult> Delete(Guid id) {
            try {
                await _transactionRepo.Delete(id);
                return Ok();
            } catch (DbUpdateException) {
                return BadRequest($"Could not delete this transaction because it has transactionLines");
            } catch (KeyNotFoundException) {
                return BadRequest($"Transaction not found");
            }
        }   
    }
}
