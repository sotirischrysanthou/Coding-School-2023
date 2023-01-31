using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCenterLib.Models {
    public class Manager : Person {

        // Properties
        public double SalaryPerMonth { get; set; }
        public DateTime? StartDate { get; set; }
        //public String Username { get; set; }
        //public String Password { get; set; }

        // Relations
        public List<Engineer> Engineers { get; set; }
        public List<Transaction> Transactions { get; set; }        

        // Constructors
        public Manager() {
            Engineers = new List<Engineer>();
            Transactions = new List<Transaction>();
            StartDate = null;
        }
        public Manager(string name, string surname, double salaryPerMonth, DateTime startDate) : base(name, surname) {
            Engineers = new List<Engineer>();
            Transactions = new List<Transaction>();
            SalaryPerMonth = salaryPerMonth;
            StartDate = startDate;
        }

        // Methods

        public void AddEngineer( Engineer engineer ) {
            Engineers.Add(engineer);
        } 

    }


}
