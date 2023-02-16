using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Model {
    public class MonthlyLedger {
        public int Year { get; set; }
        public int Month { get; set; }
        public decimal Income { get; set; }
        public decimal Expenses { get; set; }
        public decimal Total { get; set; }
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();

        public MonthlyLedger() {
        }

        public MonthlyLedger(DateTime datetime) {
            Year = datetime.Year;
            Month = datetime.Month;
        }

        public void AddRent(decimal rent) {
            Expenses += rent;
        }
    }
}
