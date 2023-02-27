using FuelStation.EF.Repository;
using FuelStation.Model;
using FuelStation.Web.Blazor.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CoffeShop.Web.Blazor.Server.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class MonthlyLedgerController : ControllerBase {
        // Properties
        private readonly IEntityRepo<Transaction> _transactionRepo;
        private readonly IEntityRepo<Employee> _employeeRepo;
        private readonly IEntityRepo<Item> _itemRepo;
        private readonly IEntityRepo<Settings> _settingsRepo;
        private decimal _rent = 5000;
        private DateTime _openingDate = new DateTime(2023, 1, 1);



        // Constructors
        public MonthlyLedgerController(IEntityRepo<Transaction> transactionRepo, IEntityRepo<Employee> employeeRepo, IEntityRepo<Item> itemRepo, IEntityRepo<Settings> settingsRepo) {
            _transactionRepo = transactionRepo;
            _employeeRepo = employeeRepo;
            _itemRepo = itemRepo;
            _settingsRepo = settingsRepo;
        }

        // GET: api/<TransactionController>
        [HttpGet]
        [Authorize(Roles = "Manager")]
        public async Task<IEnumerable<MonthlyLedgerDto>> Get() {
            var result = await _transactionRepo.GetAll(); ;
            List<MonthlyLedgerDto> monthlyLedgers = new List<MonthlyLedgerDto>();
            if (result == null) {
                return null!;
            }
            var itemList = await _itemRepo.GetAll();
            var transactionList = await _transactionRepo.GetAll();
            var employees = await _employeeRepo.GetAll();
            var settings = await _settingsRepo.GetById(Guid.Empty);
            if (settings is not null) {
                _openingDate = settings.OpeningDate;
                _rent = settings.Rent;
            }
            DateTime dateTimeNow = DateTime.Now;
            DateTime currentLedger = _openingDate.AddDays(DateTime.DaysInMonth(_openingDate.Year, _openingDate.Month) - 1);

            int totalMonths = ((dateTimeNow.Year - _openingDate.Year) * 12) + dateTimeNow.Month - _openingDate.Month;

            //for (var i = 0; i < totalMonths + 1; i++) {
            //    var ml = new MonthlyLedgerDto(currentLedger);
            //    ml.Expenses += monthlyPayments;
            //    ml.AddRent(_rent);
            //    monthlyLedgers.Add(ml);
            //    currentLedger = currentLedger.AddMonths(1);
            //}

            for (var i = 0; i < totalMonths + 1; i++) {
                var monthlyLedger = new MonthlyLedgerDto(currentLedger);
                foreach (Employee employee in employees) {
                    if (employee.HireDateStart < currentLedger && (employee.HireDateEnd is not null ? currentLedger > employee.HireDateEnd : true)) {
                        monthlyLedger.Expenses += employee.SalaryPerMonth;
                    }
                }
                monthlyLedger.AddRent(_rent);
                monthlyLedgers.Add(monthlyLedger);
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
                    foreach (var transactionLine in transaction.TransactionLines) {
                        monthlyLedger.Expenses += itemList.First(i => i.Id == transactionLine.ItemId).Cost * transactionLine.Quantity;
                        monthlyLedger.Income += transactionLine.TotalValue;
                    }

                }
                monthlyLedger.Total = monthlyLedger.Income - monthlyLedger.Expenses;
                monthlyLedger.Transactions = null!;
            }
            return monthlyLedgers;
        }
    }
}
