using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Json;
using System.Security.Claims;

namespace FuelStation.Authorization {
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider {
        private readonly HttpClient httpClient;

        public CustomAuthenticationStateProvider(HttpClient httpClient) {
            this.httpClient = httpClient;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync() {
            var response = await httpClient.GetAsync("api/auth/status");
            if (response.IsSuccessStatusCode) {
                var result = await response.Content.ReadFromJsonAsync<AuthenticationResult>();
                var identity = new ClaimsIdentity(result.Claims, "Bearer");
                var user = new ClaimsPrincipal(identity);
                return new AuthenticationState(user);
            }
            return new AuthenticationState(new ClaimsPrincipal());
        }
    }
}