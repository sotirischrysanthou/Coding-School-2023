using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCenterLib {
    public class Transaction {
        //Properties 
        public Guid ID { get; set; }
        public DateTime Date { get; set; }
        public Guid CustomerID { get; set; }
        public Guid CarID { get; set; }
        public Guid ManagerID { get; set; }
        public double TotalPrice { get; set; }
        public List<TransactionLine> TransactionLines { get; set; }

        // Constructors
        public Transaction() {
            ID = Guid.NewGuid();
        }
        public Transaction(Guid customerID, Guid carID, Guid managerID) {
            ID = Guid.NewGuid();
            Date = DateTime.Now;
            CustomerID = customerID;
            CarID = carID;
            ManagerID = managerID;

            TransactionLines = new List<TransactionLine>();
        }

        // Methods
        public void AddTransactionLine(TransactionLine transactionLine) {
            TransactionLines.Add(transactionLine);
            TotalPrice += transactionLine.Price;
        }
    }
}
