using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Model {
    public class MonthlyLedger {
        // Properties
        public int Year { get; set; }
        public int Month { get; set; }
        public decimal Income { get; set; }
        public decimal Expenses { get; set; }
        public decimal Total { get { return Income - Expenses; } }

        // Constructors
        public MonthlyLedger(int year, int month, decimal income, decimal expenses) {
            Year = year;
            Month = month;
            Income = income;
            Expenses = expenses;
        }
    }
}
