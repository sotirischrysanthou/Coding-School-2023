using CoffeeShop.EF.Repositories;
using CoffeeShop.Model;
using CoffeShop.Web.Blazor.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeShop.Web.Blazor.Server.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class TransactionLineController : ControllerBase {

        private readonly IEntityRepo<TransactionLine> _transactionLineRepo;

        public TransactionLineController(IEntityRepo<TransactionLine> transactionLineRepo) {
            _transactionLineRepo = transactionLineRepo;
        }

        [HttpGet("{id}")]
        public async Task<TransactionLineEditDto?> GetById(int id) {
            var result = await Task.Run(() => { return _transactionLineRepo.GetById(id); });
            if (result is null) {
                //Todo hlandle if result is null
                return null;
            }


            var transactionLine = new TransactionLineEditDto {
                Id = id,
                Quantity = result.Quantity,
                Discount = result.Discount,
                Price = result.Price,
                TotalPrice = result.TotalPrice,
                TransactionId = result.TransactionId,
                ProductId = result.ProductId,

            };

            return transactionLine;
        }

        [HttpPost]
        public async Task Post(TransactionLineEditDto transactionLine) {
            var newTransactionLine = new TransactionLine(transactionLine.Quantity, transactionLine.Discount, transactionLine.Price, transactionLine.TotalPrice) {
                TransactionId = transactionLine.TransactionId,
                ProductId = transactionLine.ProductId,
            };
            await Task.Run(() => { _transactionLineRepo.Add(newTransactionLine); });
        }


        [HttpPut]
        public async Task Put(TransactionLineEditDto transactionLine) {
            var dbTransactionLine = await Task.Run(() => { return _transactionLineRepo.GetById(transactionLine.Id); });
            if (dbTransactionLine is null) {
                //Todo: handle if dbTransaction is null
                return;
            }
            dbTransactionLine.Quantity = transactionLine.Quantity;
            dbTransactionLine.Discount = transactionLine.Discount;
            dbTransactionLine.Price = transactionLine.Price;
            dbTransactionLine.TotalPrice = transactionLine.TotalPrice;
            dbTransactionLine.TransactionId = transactionLine.TransactionId;
            dbTransactionLine.ProductId = transactionLine.ProductId;


            _transactionLineRepo.Update(transactionLine.Id, dbTransactionLine);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id) {
            await Task.Run(() => { _transactionLineRepo.Delete(id); });
        }

    }
}
