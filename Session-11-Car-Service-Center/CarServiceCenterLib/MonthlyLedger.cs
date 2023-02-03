using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCenterLib {
    public class MonthlyLedger {
        public int Year { get; set; }
        public int Month { get; set; }
        public double Expenses { get; set; }
        public double Incomes { get; set; }
        public double Total { get; set; }

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