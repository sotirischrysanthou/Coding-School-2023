using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Model {
    public class Account {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        // Relations
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
