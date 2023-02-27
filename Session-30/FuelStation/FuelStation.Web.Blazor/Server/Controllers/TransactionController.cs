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
        private readonly IValidator _validator;
        private String _errorMessage = null!;

        // Constructors
        public TransactionController(IEntityRepo<Transaction> transactionRepo, IValidator validator) {
            _transactionRepo = transactionRepo;
            _validator = validator;
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
        public async Task<ActionResult<String>> Post(TransactionWinDto transaction) {
            var newTransaction = new Transaction(transaction.Date,
                                                 transaction.PaymentMethod,
                                                 transaction.TotalValue,
                                                 transaction.EmployeeId,
                                                 transaction.CustomerId);
            await _transactionRepo.Add(newTransaction);
            return Ok(newTransaction.Id.ToString());
        }

        // PUT api/<TransactionController>/5
        [HttpPut]
        [Authorize(Roles = "Manager,Cashier")]
        public async Task<ActionResult<String>> Put(TransactionWinDto transaction) {
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
            return Ok(transaction.Id.ToString());
        }

        // DELETE api/<TransactionController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Manager,Cashier")]
        public async Task<ActionResult> Delete(Guid id) {
            var transaction = await _transactionRepo.GetById(id);
            if (transaction is not null) {
                if (_validator.ValidateDeleteTransaction(transaction, out _errorMessage)) {
                    try {
                        await _transactionRepo.Delete(id);
                        return Ok();
                    } catch (DbUpdateException) {
                        return BadRequest($"Could not delete this transaction because it has transactionLines");
                    } catch (KeyNotFoundException) {
                        return NotFound($"Transaction not found");
                    }
                } else {
                    return BadRequest($"Could not delete this transaction because it has transactionLines");
                }
            } else {
                return NotFound($"Transaction not found");
            }
        }
    }
}
