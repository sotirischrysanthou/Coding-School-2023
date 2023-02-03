using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCenterLib.Models {
    public class Car {

        // Properties
        public Guid ID { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string CarRegistrationNumber { get; set; }

        // Relations
        public List<Transaction> Transactions { get; set; }

        // Constructors
        public Car() {
            ID = Guid.NewGuid();
            Transactions = new List<Transaction>();
        }

        public Car(String brand, String model, String registrationNumber) {
            Transactions = new List<Transaction>();
            ID = Guid.NewGuid();
            Brand = brand;
            Model = model;
            CarRegistrationNumber = registrationNumber;
        }
        // Method

    }
}
