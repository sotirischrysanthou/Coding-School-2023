using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCenterLib.Models {
    public class Engineer : Person {
        // Properties
        public Guid ManagerID { get; set; }
        public double SalaryPerMonth { get; set; }

        public DateTime? StartDate { get; set; }
        


        // Constructors
        public Engineer() {
            StartDate = null;
        }
        public Engineer(string name, string surname, Guid managerID, double salaryPerMonth, DateTime startDate) : base(name, surname) {
            ManagerID = managerID;
            SalaryPerMonth = salaryPerMonth;
            StartDate = startDate;
        }
    }
}
