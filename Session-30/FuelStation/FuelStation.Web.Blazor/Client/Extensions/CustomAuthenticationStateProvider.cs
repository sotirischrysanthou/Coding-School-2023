using Blazored.SessionStorage;
using FuelStation.Web.Blazor.Client.Extensions;
using FuelStation.Web.Blazor.Shared;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace uelStation.Web.Blazor.Client.Extensions {
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider {
        // Properties
        private readonly ISessionStorageService _sessionStorage;
        private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());

        // Constructors
        public CustomAuthenticationStateProvider(ISessionStorageService sessionStorage) {
            _sessionStorage = sessionStorage;
        }

        // Methods
        public override async Task<AuthenticationState> GetAuthenticationStateAsync() {
            try {
                var userSession = await _sessionStorage.ReadEncriptedItemAsync<UserSession>("UserSession");
                if (userSession == null) {
                    return await Task.FromResult(new AuthenticationState(_anonymous));
                }
                var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim> {
                    new Claim(ClaimTypes.Name, $"{userSession.Employee.Name} {userSession.Employee.Surname}"),
                    new Claim(ClaimTypes.Role, userSession.Role)
                },"JwtAuth"));
                return await Task.FromResult(new AuthenticationState(claimsPrincipal));
            } catch {
                return await Task.FromResult(new AuthenticationState(_anonymous));
            }
        }

        public async Task UpdateAthenticationState(UserSession? userSession) {
            ClaimsPrincipal claimsPrincipal;
            if (userSession != null) {
                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim> {
                    new Claim(ClaimTypes.Name , $"{userSession.Employee.Name} {userSession.Employee.Surname}"),
                    new Claim(ClaimTypes.Role, userSession.Role)
                }));
                userSession.ExpiryTimeStamp = DateTime.Now.AddSeconds(userSession.ExpiresIn);
                await _sessionStorage.SaveItemEncryptedAsync("UserSession", userSession);
            } else {  
                    claimsPrincipal = _anonymous;
                    await _sessionStorage.RemoveItemAsync("UserSession");
            }
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }

        public async Task<string> GetToken() {
            var result = string.Empty;
            try {
                var userSession = await _sessionStorage.ReadEncriptedItemAsync<UserSession>("UserSession");
                if (userSession != null && DateTime.Now < userSession.ExpiryTimeStamp) {
                    result = userSession.Token;
                }
            } catch {

                throw;
            }
            return result;
        }
    }
}
