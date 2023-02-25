using System.Security.Claims;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using FuelStation.Web.Blazor.Shared;
using Microsoft.AspNetCore.Components.Authorization;

namespace FuelStation.Win.Extensions {
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider {
        // Properties
        private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());

        // Constructors
        public CustomAuthenticationStateProvider() {
        }

        // Methods
        public override async Task<AuthenticationState> GetAuthenticationStateAsync() {
            try {
                var userSession = await SessionStorageServiceExtension.ReadEncriptedItemAsync<UserSession>("UserSession");
                if (userSession == null) {
                    return await Task.FromResult(new AuthenticationState(_anonymous));
                }
                var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim> {
                    new Claim(ClaimTypes.Name, $"{userSession.Employee.Name} {userSession.Employee.Surname}"),
                    new Claim(ClaimTypes.Role, userSession.Role)
                }, "JwtAuth"));
                return await Task.FromResult(new AuthenticationState(claimsPrincipal));
            }
            catch {
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
                await SessionStorageServiceExtension.SaveItemEncryptedAsync("UserSession", userSession);
            }
            else {
                claimsPrincipal = _anonymous;
                await SessionStorageServiceExtension.RemoveItemAsync("UserSession");
            }
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }

        public async Task<string> GetToken() {
            var result = string.Empty;
            try {
                var userSession = await SessionStorageServiceExtension.ReadEncriptedItemAsync<UserSession>("UserSession");
                if (userSession != null && DateTime.Now < userSession.ExpiryTimeStamp) {
                    result = userSession.Token;
                }
            }
            catch {

                throw;
            }
            return result;
        }
    }
}
