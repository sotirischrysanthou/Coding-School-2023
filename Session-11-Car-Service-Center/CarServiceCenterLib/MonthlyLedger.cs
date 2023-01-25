using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCenterLib {
    public class MonthlyLedger {
        public int Year { get; set; }
        public int Month { get; set; }
        public double ManagersSalary { get; set; }
        public double EngineersSalary { get; set; }
        public double Expenses { get; set; }
        public double Income { get; set; }
        public double Total { get { return Income - Expenses; } }

        // Constructors
        public MonthlyLedger(int year, int month, double managerSalary, double engineersSalary) {
            Year = year;
            Month = month;
            ManagersSalary = managerSalary;
            EngineersSalary = engineersSalary;
            Expenses = ManagersSalary + EngineersSalary;
        }

        // Methods
        public void UpdateIncome(double income) {
            Income = income;
        }
        public void UpdateExpenses(double expense) {
            Expenses += expense;
        }

    }
}