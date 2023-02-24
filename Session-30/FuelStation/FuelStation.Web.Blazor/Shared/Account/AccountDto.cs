using FuelStation.Model.Enums;
using FuelStation.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Web.Blazor.Shared {
    public class AccountDto {
        [Required] public Guid Id { get; set; }
        [Required] public String Username { get; set; } = String.Empty;
        [Required] public String Password { get; set; } = String.Empty;
        [Required] public EmployeeType Role { get; set; }

        // Relations
        public Guid EmployeeId { get; set; }
        public EmployeeListDto Employee { get; set; } = null!;


        // Constructors
        public AccountDto() {

        }

        public AccountDto(Account account) {
            Id = account.Id;
            Username = account.Username;
            Password = account.Password;
            Role = account.Role;
            EmployeeId = account.EmployeeId;
            Employee = new EmployeeListDto(account.Employee);
        }
    }
}
