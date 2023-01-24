using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCenterLib {
    public class Engineer : Person {
        // Properties
        public Guid ManagerID { get; set; }
        public double SalaryPerMonth { get; set; }
        

        //Christos

        public DateTime StartDate { get; set; }
        public Engineer(Guid id, string name, string surname, Guid managerID, double salaryPerMonth, DateTime startDate) {
            ID = id;
            Name = name;
            Surname = surname;
            ManagerID = managerID;
            SalaryPerMonth = salaryPerMonth;
            StartDate = startDate;
        }
        //Christos



        // Constructors
        public Engineer() {

        }
        public Engineer(string name, string surname, Guid managerID, double salaryPerMonth) : base(name, surname) {
            ManagerID = managerID;
            SalaryPerMonth = salaryPerMonth;
        }
    }
}
