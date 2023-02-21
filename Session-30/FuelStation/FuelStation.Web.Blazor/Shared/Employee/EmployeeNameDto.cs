using FuelStation.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Web.Blazor.Shared {
    public class EmployeeNameDto {
        // Properties
        [Required] public Guid Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Name must be between 1 and 20 characters.")]
        public String Name { get; set; } = null!;

        [Required]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Surname must be between 1 and 20 characters.")]
        public String Surname { get; set; } = null!;

        // Constructors
        public EmployeeNameDto() {

        }
        public EmployeeNameDto(Employee employee) {
            Id = employee.Id;
            Name = employee.Name;
            Surname = employee.Surname;
        }
    }
}
