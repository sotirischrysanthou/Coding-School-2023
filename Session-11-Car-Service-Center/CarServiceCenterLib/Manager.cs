using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCenterLib {
    public class Manager : Person {

        // Properties
        public double SalaryPerMonth { get; set; }
        public List<Engineer> Engineers { get; set; }
        public DateTime StartDate { get; set; }

        

        // Constructors
        public Manager() {

        }
        public Manager(string name, string surname, double salaryPerMonth, DateTime startDate) : base(name, surname) {
            Engineers = new List<Engineer>();
            SalaryPerMonth = salaryPerMonth;
            StartDate = startDate;
        }

        // Methods

        public void AddEngineer( Engineer engineer ) {
            Engineers.Add(engineer);
        } 
    }


}
