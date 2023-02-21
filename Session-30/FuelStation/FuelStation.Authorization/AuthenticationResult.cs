using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Authorization {
    public class AuthenticationResult {
        public bool IsAuthenticated { get; set; }
        public IEnumerable<Claim> Claims { get; set; }
    }
}
