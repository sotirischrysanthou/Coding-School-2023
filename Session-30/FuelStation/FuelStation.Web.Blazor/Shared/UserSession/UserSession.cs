using FuelStation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Web.Blazor.Shared {
    public class UserSession {
        // Properties
        public String Username { get; set; } = String.Empty;
        public String Token { get; set; } = String.Empty;
        public String Role { get; set; } = String.Empty;
        public int ExpiresIn { get; set; }
        public DateTime ExpiryTimeStamp { get; set; }

        // Relations
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;
    }
}
