using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCenterLib {
    public class MonthlyLedger {
        public int Year { get; set; }
        public int Month { get; set; }
        public double Income { get; set; }
        public double Expenses { get; set; }
        public double Total { get { return Income - Expenses; } }

        private List<Engineer> engineers;
        private List<Manager> managers;
        private List<Transaction> transactions;

        public MonthlyLedger(int year, int month, List<Engineer> engineers, List<Manager> managers, List<Transaction> transactions) {
            Year = year;
            Month = month;
            this.engineers = engineers;
            this.managers = managers;
            this.transactions = transactions;
        }

        public MonthlyLedger() {

        }

        public void CalculateIncomeExpenses() {
            // Sum up the total price of all transactions in this month
            Income = transactions.Where(t => t.Date.Year == Year && t.Date.Month == Month).Sum(t => t.TotalPrice);

            // Sum up the salaries of all engineers and managers in this month
            Expenses = GetEngineerSalaries() + GetManagerSalaries();
        }

        private double GetEngineerSalaries() {
            // Retrieve all engineers and sum up their salaries for this month
            return engineers.Where(e => e.StartDate.Year == Year && e.StartDate.Month == Month).Sum(e => e.SalaryPerMonth);
        }

        private double GetManagerSalaries() {
            // Retrieve all managers and sum up their salaries for this month
            return managers.Where(m => m.StartDate.Year == Year && m.StartDate.Month == Month).Sum(m => m.SalaryPerMonth);
        }
    }
}