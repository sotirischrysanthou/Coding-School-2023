using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Web.Blazor.Shared {
    public class LoginRequest {
        public String Username { get; set; } = String.Empty;
        public String Password { get; set; } = String.Empty;
    }
}
