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
    public class MonthlyLedgerController : ControllerBase {
        // Properties
        private readonly IEntityRepo<Transaction> _transactionRepo;
        private readonly IEntityRepo<Employee> _employeeRepo;
        private readonly IEntityRepo<Product> _productRepo;
        private readonly decimal _rent = 3000;
        private readonly DateTime _openingDate = new DateTime(2022, 1, 1);



        // Constructors
        public MonthlyLedgerController(IEntityRepo<Transaction> transactionRepo, IEntityRepo<Employee> employeeRepo, IEntityRepo<Product> productRepo) {
            _transactionRepo = transactionRepo;
            _employeeRepo = employeeRepo;
            _productRepo = productRepo;
        }

        // GET: api/<TransactionController>
        [HttpGet]
        public async Task<IEnumerable<MonthlyLedgerDto>> Get() {
            var result = await Task.Run(() => { return _transactionRepo.GetAll(); });
            List<MonthlyLedgerDto?> monthlyLedgers = new List<MonthlyLedgerDto?>();
            if (result == null) {
                return null;
            }

            var transactionList = _transactionRepo.GetAll();

            var employees = _employeeRepo.GetAll();

            int monthlyPayments = 0;    

            foreach(var employee in employees) {
                monthlyPayments += employee.SalaryPerMonth;
            }

            DateTime dateTimeNow = DateTime.Now;
            DateTime currentLedger = _openingDate;

            int totalMonths = ((dateTimeNow.Year - _openingDate.Year) * 12) + dateTimeNow.Month - _openingDate.Month;

            for (var i = 0; i < totalMonths + 1; i++) {
                var ml = new MonthlyLedgerDto(currentLedger);
                ml.Expenses += monthlyPayments;
                ml.AddRent(_rent);
                monthlyLedgers.Add(ml);
                currentLedger = currentLedger.AddMonths(1);
            }

            foreach (var transaction in transactionList) {
                foreach (var monthlyLedger in monthlyLedgers) {
                    if ((transaction.Date.Month == monthlyLedger.Month) && (transaction.Date.Year == monthlyLedger.Year)) {
                        monthlyLedger.Transactions.Add(transaction);
                    }
                }
            }

            foreach (var monthlyLedger in monthlyLedgers) {
                foreach (var transaction in monthlyLedger.Transactions) {
                    foreach(var transactionLine in transaction.TransactionLines) {
                        monthlyLedger.Expenses += _productRepo.GetById(transactionLine.ProductId).Cost * transactionLine.Quantity;
                        monthlyLedger.Income += transactionLine.TotalPrice;
                    }

                }
                monthlyLedger.Total = monthlyLedger.Income - monthlyLedger.Expenses;
                monthlyLedger.Transactions = null;
            }
            return monthlyLedgers;
        }
    }
}
