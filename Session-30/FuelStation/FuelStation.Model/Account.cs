using FuelStation.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Model {
    public class Account {
        [Required] public Guid Id { get; set; }
        [Required] public String Username { get; set; } = String.Empty;
        [Required] public String Password { get; set; } = String.Empty;
        [Required] public EmployeeType Role { get; set; }

        // Relations
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;


        // Constructors
        public Account() {

        }

        public Account(Guid id,String username, String password, EmployeeType role, Guid employeeId) {
            Id = id;
            Username = username;
            Password = password;
            EmployeeId = employeeId;
            Role = role;
        }
    }
}
