using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCenterLib {
    public class Customer : Person {
        // Properties
        public String Phone { get; set; }
        public String TIN { get; set; }

        // Constructors
        public Customer() {

        }
        public Customer(String name, String surname, String phone, String tin) : base(name, surname) {
            Phone = phone;
            TIN = tin;
        }

        // Methods
    }
}
