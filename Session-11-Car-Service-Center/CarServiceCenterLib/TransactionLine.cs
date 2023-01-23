﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCenterLib {
    public class TransactionLine {
        // Properties
        public Guid ID { get; set; }
        public Guid TransactionID { get; set; }
        public Guid ServiceTaskID { get; set; }
        public Guid EnginnerID { get; set; }
        public double Hours { get; set; }
        public double PricePerHour { get; set; } //constant maybe
        public double Price { get; set; }

        //Constrators
        public TransactionLine(Guid transactionID, Guid serviceTaskID, Guid enginnerID,double hours, double pricePerHour) {
            ID = Guid.NewGuid();
            TransactionID = transactionID;
            ServiceTaskID = serviceTaskID;
            EnginnerID = enginnerID;
            PricePerHour = pricePerHour;
            Price = pricePerHour * hours;
        }
        // Methods
    }
}
