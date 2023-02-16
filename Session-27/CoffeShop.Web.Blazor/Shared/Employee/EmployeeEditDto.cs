using CoffeeShop.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShop.Web.Blazor.Shared {
    public class EmployeeEditDto {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Type less than 50 characters")]
        public String Name { get; set; } = null!;

        [Required]
        [MaxLength(50, ErrorMessage = "Type less than 50 characters")]
        public String Surname { get; set; } = null!;

        [Required]
        [Range(0, 9999, ErrorMessage = "The range is from 0 to 9999!")]
        public int SalaryPerMonth { get; set; }

        [Required]
        [Range(1, 4, ErrorMessage = "You must choose a type!")]
        public EmployeeType EmployeeType { get; set; }

    }
}
