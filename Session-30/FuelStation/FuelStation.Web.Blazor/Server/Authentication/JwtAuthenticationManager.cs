using FuelStation.Authorization;
using FuelStation.Web.Blazor.Shared;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FuelStation.Web.Blazor.Server.Authentication {
    public class JwtAuthenticationManager {
        // Properties
        public const String JWT_SECURITY_KEY = "yPkCqn4kSWLtaJwXvN2jGzpQRyTZ3gdXkt7FeBJP";
        private const int JWT_TOKEN_VALIDITY_HOURS = 8;
        private UserAccountService _userAccountService;

        // Constructors
        public JwtAuthenticationManager(UserAccountService userAccountService) {
            _userAccountService = userAccountService;
        }

        //Methods
        public UserSession? GenarateJwtToken(String ussername, String password) {
            if (String.IsNullOrEmpty(ussername) || String.IsNullOrEmpty(password)) {
                return null;
            }

            /* Validating the User Credentials */
            var userAccount = _userAccountService.GetUserAccountByUsername(ussername);
            if (userAccount == null || userAccount.Password != password) {
                return null;
            }
            /* Generating JWT Token*/
            var tokenExpiryTimeStamp = DateTime.UtcNow.AddHours(JWT_TOKEN_VALIDITY_HOURS);
            var tokenKey = Encoding.ASCII.GetBytes(JWT_SECURITY_KEY);
            var claimsIdentity = new ClaimsIdentity(new List<Claim> {
                new Claim(ClaimTypes.Name, $"{userAccount.Employee.Name} {userAccount.Employee.Surname}"),
                new Claim(ClaimTypes.Role, userAccount.Role.ToString())
            });
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature);
            var securityTokenDescriptor = new SecurityTokenDescriptor {
                Subject = claimsIdentity,
                Expires = tokenExpiryTimeStamp,
                SigningCredentials = signingCredentials
            };

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var securityToken = jwtSecurityTokenHandler.CreateJwtSecurityToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(securityToken);

            /* Returning the User Session object */
            var userSession = new UserSession {
                Username = userAccount.Username,
                Role = userAccount.Role.ToString(),
                Token = token,
                ExpiresIn = (int)tokenExpiryTimeStamp.Subtract(DateTime.Now).TotalSeconds,
                Employee = userAccount.Employee,
                EmployeeId = userAccount.EmployeeId,
            };
            return userSession;
        }
    }
}
