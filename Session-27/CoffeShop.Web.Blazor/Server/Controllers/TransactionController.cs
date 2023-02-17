using CoffeeShop.EF.Repositories;
using CoffeeShop.Model;
using CoffeShop.Web.Blazor.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoffeShop.Web.Blazor.Server.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase {
        // Properties
        private readonly IEntityRepo<Transaction> _transactionRepo;
        private readonly IEntityRepo<Product> _productRepo;

        // Constructors
        public TransactionController(IEntityRepo<Transaction> transactionRepo, IEntityRepo<Product> productRepo) {
            _transactionRepo = transactionRepo;
            _productRepo = productRepo;
        }

        // GET: api/<TransactionController>
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

        // GET: api/<TransactionController>
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

        // GET: api/<TransactionController>
        [Route("/transactionlist/details/{id}")]
        [HttpGet]
        public async Task<TransactionDetailsDto?> GetDetailsById(int id) {
            var result = await Task.Run(() => { return _transactionRepo.GetById(id); });
            if (result is null) {
                return null;
            } else {
                TransactionDetailsDto transaction = new TransactionDetailsDto {
                    Id = id,
                    Date = result.Date,
                    TotalPrice = result.TotalPrice,
                    PaymentMethod = result.PaymentMethod,
                    CustomerId = result.CustomerId,
                    EmployeeId = result.EmployeeId,
                    Customer = new CustomerListDto {
                        Code = result.Customer.Code,
                        Description = result.Customer.Description,
                        Id = result.CustomerId
                    },
                    Employee = new EmployeeListDto {
                        Id = result.EmployeeId,
                        Name = result.Employee.Name,
                        Surname = result.Employee.Surname,
                        SalaryPerMonth = result.Employee.SalaryPerMonth,
                        EmployeeType = result.Employee.EmployeeType
                    },
                    TransactionLines = result.TransactionLines.Select(transactionLine => new TransactionLineDetailsDto {
                        Id = transactionLine.Id,
                        Quantity = transactionLine.Quantity,
                        Discount = transactionLine.Discount,
                        Price = transactionLine.Price,
                        TotalPrice = transactionLine.TotalPrice,
                        TransactionId = transactionLine.TransactionId,
                        ProductId = transactionLine.ProductId,
                    }).ToList()
                };
                foreach (var transactionLine in transaction.TransactionLines) {
                    var product = _productRepo.GetById(transactionLine.ProductId);
                    transactionLine.Product = new ProductListDto {
                        Id = product.Id,
                        Code = product.Code,
                        Description = product.Description,
                        Price = product.Price,
                        Cost = product.Cost,
                        ProductCategoryId = product.ProductCategoryId
                    };
                }
                return transaction;
            }
        }

        // POST api/<TransactionController>
        [HttpPost]
        public async Task Post(TransactionEditDto transaction) {
            var newTransaction = new Transaction(transaction.TotalPrice, transaction.PaymentMethod) {
                Date = transaction.Date,
                CustomerId = transaction.CustomerId,
                EmployeeId = transaction.EmployeeId,
                TransactionLines = transaction.TransactionLines.Select(transactionLine => new TransactionLine(transactionLine.Quantity, transactionLine.Discount, transactionLine.Price, transactionLine.TotalPrice) {
                    Id = transactionLine.Id,
                    TransactionId = transactionLine.TransactionId,
                    ProductId = transactionLine.ProductId,
                }).ToList()
            };
            await Task.Run(() => { _transactionRepo.Add(newTransaction); });
        }

        // PUT api/<TransactionController>/5
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
            dbTransaction.TransactionLines = transaction.TransactionLines
                .Select(transactionLine => new TransactionLine(
                    transactionLine.Quantity,
                    transactionLine.Discount,
                    transactionLine.Price,
                    transactionLine.TotalPrice) {
                        ProductId = transactionLine.ProductId,
                        TransactionId = transactionLine.TransactionId,
                        Id = transactionLine.Id
                    }
                ).ToList();

            _transactionRepo.Update(transaction.Id, dbTransaction);
        }

        // DELETE api/<TransactionController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id) {
            try {
                await Task.Run(() => { _transactionRepo.Delete(id); });
                return Ok();
            }
            catch (DbUpdateException) {
                return BadRequest($"Could not delete this transaction because it has transactionLines");
            }
            catch (KeyNotFoundException) {
                return BadRequest($"Transaction not found");
            }
        }
    }
}
