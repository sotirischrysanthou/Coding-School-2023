using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarServiceCenter.Model;
using CarServiceCenter.Functions;

namespace CarServiceCenter.Web.Mvc.Controllers {
    public class MonthlyLedgerController : Controller {
        // Properties
        private ExpensesAndIncomesManagment _expensesAndIncomesManagment;

        // Constructors
        public MonthlyLedgerController() {
            _expensesAndIncomesManagment = new ExpensesAndIncomesManagment();
        }

        // GET: MonthlyLedgerController
        public ActionResult Index() {
            List <MonthlyLedger> list = new List<MonthlyLedger>();
            MonthlyLedger monthlyLedger;
            int year = DateTime.Now.Year;
            for (int month = 1; month <= 12; month++) {
                monthlyLedger = new MonthlyLedger(year, month);
                monthlyLedger.Expenses += _expensesAndIncomesManagment.SalaryEngineersFrom(year, month);
                monthlyLedger.Expenses += _expensesAndIncomesManagment.SalaryManagersFrom(year, month);
                monthlyLedger.Incomes = _expensesAndIncomesManagment.CalculateIncomes(year, month);
                monthlyLedger.Total = monthlyLedger.Incomes - monthlyLedger.Expenses;
                list.Add(monthlyLedger);
            }
            return View(model: list);
        }
    }
}
