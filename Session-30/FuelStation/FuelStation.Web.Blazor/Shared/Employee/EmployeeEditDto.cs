using FuelStation.Model.Enums;
using FuelStation.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Web.Blazor.Shared {
    public class EmployeeEditDto {
        // Properties
        [Required] public Guid Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Name must be between 1 and 20 characters.")]
        public String Name { get; set; } = null!;

        [Required]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Surname must be between 1 and 20 characters.")]
        public String Surname { get; set; } = null!;

        [Required]
        [Display(Name = "Hire Date (Start)")]
        [DataType(DataType.Date)]
        public DateTime HireDateStart { get; set; }


        [Required]
        [Display(Name = "Salary Per Month")]
        [DataType(DataType.Currency)]
        public decimal SalaryPerMonth { get; set; }

        [Required]
        [Display(Name = "Employee Type")]
        public EmployeeType EmployeeType { get; set; }

        [Display(Name = "Hire Date (End)")]
        [DataType(DataType.Date)]
        public DateTime? HireDateEnd { get; set; }

        // Relations
        public AccountDto Account { get; set; } = null!;

        // Constructors
        public EmployeeEditDto() {

        }
        public EmployeeEditDto(Employee employee) {
            Id = employee.Id;
            Name = employee.Name;
            Surname = employee.Surname;
            HireDateStart = employee.HireDateStart;
            HireDateEnd = employee.HireDateEnd;
            SalaryPerMonth = employee.SalaryPerMonth;
            EmployeeType = employee.EmployeeType;
        }
    }
}
