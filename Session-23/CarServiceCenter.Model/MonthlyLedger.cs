using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCenter.Model {
    public class MonthlyLedger {
        public int Year { get; set; }
        public int Month { get; set; }
        public decimal Expenses { get; set; }
        public decimal Incomes { get; set; }
        public decimal Total { get; set; }

        // Constructors
        public MonthlyLedger(int year, int month) {
            Expenses = 0;
            Incomes = 0;
            Total = 0;
            Year = year;
            Month = month;
        }

    }
}