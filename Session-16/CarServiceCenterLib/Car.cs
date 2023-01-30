using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCenterLib {
    public class Car {

        // Properties

        public Guid ID { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string CarRegistrationNumber { get; set; }



        // Constructors
        public Car() {
            ID = Guid.NewGuid();
        }

        public Car(String brand, String model, String registrationNumber) {
            ID = Guid.NewGuid();
            Brand = brand;
            Model = model;
            CarRegistrationNumber = registrationNumber;
        }
        // Method

    }
}
