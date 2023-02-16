using CoffeeShop.EF.Repositories;
using CoffeeShop.Model;
using CoffeShop.Web.Blazor.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoffeShop.Web.Blazor.Server.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase {
        // Properties
        private readonly IEntityRepo<Transaction> _transactionRepo;

        // Constructors
        public TransactionController(IEntityRepo<Transaction> transactionRepo) {
            _transactionRepo = transactionRepo;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<IEnumerable<TransactionListDto>> Get() {
            var result = await Task.Run(() => { return _transactionRepo.GetAll(); });
            var selectTransactionList = result.Select(transaction => new TransactionListDto {
                Id = transaction.Id,
                Date = transaction.Date,
                TotalPrice = transaction.TotalPrice,
                PaymentMethod = transaction.PaymentMethod,
                CustomerId = transaction.CustomerId,
                EmployeeId = transaction.EmployeeId,
                //TransactionLines = transaction.TransactionLines,
            });
            return selectTransactionList;
        }

        // GET: api/<EmployeeController>
        [HttpGet("{id}")]
        public async Task<TransactionEditDto?> GetById(int id) {
            var result = await Task.Run(() => { return _transactionRepo.GetById(id); });
            if (result is null) {
                //Todo hlandle if result is null
                return null;
            }


            var transaction = new TransactionEditDto {
                Id = id,
                Date = result.Date,
                TotalPrice = result.TotalPrice,
                PaymentMethod = result.PaymentMethod,
                CustomerId = result.CustomerId,
                EmployeeId = result.EmployeeId,
                TransactionLines = result.TransactionLines.Select(transactionLine => new TransactionLineEditDto {
                    Id = transactionLine.Id,
                    Quantity = transactionLine.Quantity,
                    Discount = transactionLine.Discount,
                    Price = transactionLine.Price,
                    TotalPrice = transactionLine.TotalPrice,
                    TransactionId = transactionLine.TransactionId,
                    ProductId = transactionLine.ProductId,
                }).ToList()
            };

            return transaction;
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task Post(TransactionEditDto transaction) {
            var newTransaction = new Transaction(transaction.TotalPrice, transaction.PaymentMethod) {
                Date = transaction.Date,
                CustomerId = transaction.CustomerId,
                EmployeeId = transaction.EmployeeId,
            };
            await Task.Run(() => { _transactionRepo.Add(newTransaction); });
        }

        // PUT api/<EmployeeController>/5
        [HttpPut]
        public async Task Put(TransactionEditDto transaction) {
            var dbTransaction = await Task.Run(() => { return _transactionRepo.GetById(transaction.Id); });
            if (dbTransaction is null) {
                //Todo: handle if dbTransaction is null
                return;
            }
            dbTransaction.Date = transaction.Date;
            dbTransaction.TotalPrice = transaction.TotalPrice;
            dbTransaction.PaymentMethod = transaction.PaymentMethod;
            dbTransaction.CustomerId = transaction.CustomerId;
            dbTransaction.EmployeeId = transaction.EmployeeId;
            dbTransaction.TransactionLines = transaction.TransactionLines.Select(transactionLine => new TransactionLine(transactionLine.Quantity, transactionLine.Discount, transactionLine.Price, transactionLine.TotalPrice) {
                ProductId = transactionLine.ProductId,
                TransactionId = transactionLine.TransactionId,
                Id = transactionLine.Id
            }).ToList();

            _transactionRepo.Update(transaction.Id, dbTransaction);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id) {
            try {
                await Task.Run(() => { _transactionRepo.Delete(id); });
                return Ok();
            }catch(DbUpdateException ex) {
                return BadRequest($"Could not delete this transaction because it has transactionLines");
            }catch(KeyNotFoundException ex) {
                return BadRequest($"Transaction not found");
            }

        }

    }
}
