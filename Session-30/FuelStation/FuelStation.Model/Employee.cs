using FuelStation.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace FuelStation.Model {
    public class Employee : Person {
        // Properties
        [Required]
        [Display(Name = "Hire Date (Start)")]
        [DataType(DataType.Date)]
        public DateTime HireDateStart { get; set; }

        [Display(Name = "Hire Date (End)")]
        [DataType(DataType.Date)]
        public DateTime? HireDateEnd { get; set; }

        [Required]
        [Display(Name = "Salary Per Month")]
        [DataType(DataType.Currency)]
        public decimal SalaryPerMonth { get; set; }

        [Required]
        [Display(Name = "Employee Type")]
        public EmployeeType EmployeeType { get; set; }

        // Relations
        public List<Transaction> Transactions { get; set; } = null!;
        public Account Account { get; set; }

        // Constructors
        public Employee(string name, string surname, DateTime hireDateStart, decimal salaryPerMonth, EmployeeType employeeType, Account account) : base(name, surname) {
            HireDateStart = hireDateStart;
            HireDateEnd = null;
            SalaryPerMonth = salaryPerMonth;
            EmployeeType = employeeType;
            Account = account;
        }
    }
}
