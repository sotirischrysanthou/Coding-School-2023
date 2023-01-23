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

        // Constructors
        public Manager(string name, string surname, double salaryPerMonth) : base(name, surname) {
            Engineers = new List<Engineer>();
            SalaryPerMonth = salaryPerMonth;
        }

        // Methods

        public void AddEngineer( Engineer engineer ) {
            Engineers.Add(engineer);
        } 
    }


}
