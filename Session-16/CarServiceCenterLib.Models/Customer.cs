using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCenterLib.Models {
    public class Customer : Person {
        // Properties
        public String Phone { get; set; }
        public String TIN { get; set; }

        // Relations
        public List<Transaction> Transactions { get; set; }

        // Constructors
        public Customer() {
            Transactions = new List<Transaction>();
        }
        public Customer(String name, String surname, String phone, String tin) : base(name, surname) {
            Transactions = new List<Transaction>();
            Phone = phone;
            TIN = tin;
        }

        // Methods
    }
}
