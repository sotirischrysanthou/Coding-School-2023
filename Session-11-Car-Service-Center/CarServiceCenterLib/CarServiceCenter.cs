using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCenterLib {
    public class CarServiceCenter {
        // Properties
        // public List<WorkDay> WorkDays {get; set;}

        public List<Engineer> Engineers { get; set; }
        public List<Manager> Managers { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Transaction> Transactions { get; set; }
        public List<Car> Cars { get; set; }

    }
}
