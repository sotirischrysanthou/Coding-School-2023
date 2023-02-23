using FuelStation.Authorization;
using FuelStation.EF.Repository;
using FuelStation.Model;
using FuelStation.Web.Blazor.Server.Authentication;
using FuelStation.Web.Blazor.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;

namespace FuelStation.Web.Blazor.Server.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase {
        // Properties
        private UserAccountService _userAccount;

        // Constructors
        public LoginController(UserAccountService userAccount) {
            _userAccount = userAccount;
        }

        
        [HttpPost]
        [AllowAnonymous]
        public ActionResult<UserSession> Login([FromBody] LoginRequest loginRequest) {
            var jwtAuthenticationManager = new JwtAuthenticationManager(_userAccount);
            var userSession = jwtAuthenticationManager.GenarateJwtToken(loginRequest.Username, loginRequest.Password);
            if(userSession is null) { 
                return Unauthorized();
            } else {
                return userSession;
            }
        }
    }
}
