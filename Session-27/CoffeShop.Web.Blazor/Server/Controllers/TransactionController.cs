using CoffeeShop.EF.Repositories;
using CoffeeShop.Model;
using CoffeShop.Web.Blazor.Shared.Employee;
using CoffeShop.Web.Blazor.Shared.Transaction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeShop.Web.Blazor.Server.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase {
        // Properties
        private readonly IEntityRepo<Transaction> _transactionRepo;

        // Constructors
        public TransactionController(IEntityRepo<Transaction>  transactionRepo) {
            _transactionRepo = transactionRepo;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<IEnumerable<TransactionListDto>> Get() {
            var result = _transactionRepo.GetAll();
            var selectTransactionList = result.Select(transaction => new TransactionListDto {
                Id = transaction.Id,
                Date = transaction.Date,
                TotalPrice = transaction.TotalPrice,
                PaymentMethod = transaction.PaymentMethod,
                Customer = transaction.Customer,
                Employee = transaction.Employee,
                //TransactionLines = transaction.TransactionLines,
            });
            return selectTransactionList;
        }

        // GET: api/<EmployeeController>
        [HttpGet("{id}")]
        public async Task<TransactionEditDto> GetById(int id) {
            var result = _transactionRepo.GetById(id);
            return new TransactionEditDto {
                Id = id,
                Date = result.Date,
                TotalPrice = result.TotalPrice,
                PaymentMethod = result.PaymentMethod,
                CustomerId = result.CustomerId,
                EmployeeId = result.EmployeeId,
            };
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task Post(TransactionEditDto transaction) {
            var newTransaction = new Transaction(transaction.TotalPrice,transaction.PaymentMethod) { 
                Date = transaction.Date,
                CustomerId = transaction.CustomerId,
                EmployeeId = transaction.EmployeeId,
            };
            _transactionRepo.Add(newTransaction);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut]
        public async Task Put(TransactionEditDto transaction) {
            var dbTransaction = _transactionRepo.GetById(transaction.Id);
            dbTransaction.Date = transaction.Date;
            dbTransaction.TotalPrice = transaction.TotalPrice;
            dbTransaction.PaymentMethod = transaction.PaymentMethod;
            dbTransaction.CustomerId = transaction.CustomerId;
            dbTransaction.EmployeeId = transaction.EmployeeId;

            _transactionRepo.Update(transaction.Id, dbTransaction);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id) {
            _transactionRepo.Delete(id);
        }

    }
}
