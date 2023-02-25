using FuelStation.Web.Blazor.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FuelStation.Win.Extensions;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Authorization;

namespace FuelStation.Win {
    public partial class LoginForm : Form {
        // Properties
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authStateProvider;

        public LoginForm(HttpClient httpClient, AuthenticationStateProvider authStateProvider) {
            InitializeComponent();
            _httpClient = httpClient;
            _authStateProvider = authStateProvider;
        }

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
            }
            else if (loginResponse.StatusCode == HttpStatusCode.Unauthorized) {
                MessageBox.Show("Invalid User Name or Password");
            }
        }

    }
}
