using FuelStation.Web.Blazor.Shared;
using System.Net.Http;
using System.Net;
using FuelStation.Win.Extensions;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Authorization;
using FuelStation.Win.Enums;
using FuelStation.Model.Enums;

namespace FuelStation.Win {
    public partial class LoginForm : Form {
        // Properties
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authStateProvider;

        // Public property to store the returned object
        public object ReturnedObject { get; private set; } = null!;
        public String Role { get; set; }

        // Constructors
        public LoginForm(HttpClient httpClient, AuthenticationStateProvider authStateProvider) {
            InitializeComponent();
            _httpClient = httpClient;
            _authStateProvider = authStateProvider;
            this.DialogResult = DialogResult.Cancel;
        }

        // Methods
        private void LoginForm_Load(object sender, EventArgs e) {

        }

        private async void btnLogin_Click(object sender, EventArgs e) {
            LoginRequest loginRequest = new LoginRequest() {
                Username = txtUsername.Text,
                Password = txtPassword.Text,
            };
            var loginResponse = await _httpClient.PostAsJsonAsync<LoginRequest>("/api/Login", loginRequest);
            if (loginResponse.IsSuccessStatusCode) {
                var userSession = await loginResponse.Content.ReadFromJsonAsync<UserSession>();
                var customAuthStateProvider = (CustomAuthenticationStateProvider)_authStateProvider;
                await customAuthStateProvider.UpdateAthenticationState(userSession);
                MessageBox.Show("You are Logged in");
                // Set the returned object to the UserSession object
                ReturnedObject = userSession;
                Role = userSession.Role;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else if (loginResponse.StatusCode == HttpStatusCode.Unauthorized) {
                MessageBox.Show("Invalid User Name or Password");
            }
        }

    }
}
