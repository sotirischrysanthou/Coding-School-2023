using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCenterLib {
    public class Transaction {
        //Properties 
        public Guid ID { get; set; }
        public DateTime DateTime { get; set; }
        public Guid CustomerID { get; set; }
        public Guid CarID { get; set; }
        public Guid ManagerID { get; set; }
        public double TotalPrice { get; set; }

        List<TransactionLine> transactionLines = new List<TransactionLine>();


    }
}
