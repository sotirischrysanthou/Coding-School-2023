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
        private bool _isClosingFromXButton = true;

        // Public property to store the returned object
        public UserSession? UserSession { get; set; }
        public String Role { get; set; }

        // Constructors
        public LoginForm(HttpClient httpClient, AuthenticationStateProvider authStateProvider, UserSession userSession) {
            InitializeComponent();
            txtPassword.Properties.PasswordChar = '*';
            _httpClient = httpClient;
            _authStateProvider = authStateProvider;
            this.DialogResult = DialogResult.Cancel;
            UserSession = userSession;
            Role = userSession.Role;
        }

        // Methods
        private void LoginForm_Load(object sender, EventArgs e) {
            txtUsername.Text = String.Empty;
            txtPassword.Text = String.Empty;
        }

        private async void btnLogin_Click(object sender, EventArgs e) {
            LoginRequest loginRequest = new LoginRequest() {
                Username = txtUsername.Text,
                Password = txtPassword.Text,
            };
            var loginResponse = await _httpClient.PostAsJsonAsync<LoginRequest>("/api/Login", loginRequest);
            if (loginResponse.IsSuccessStatusCode) {
                UserSession = await loginResponse.Content.ReadFromJsonAsync<UserSession>();
                var customAuthStateProvider = (CustomAuthenticationStateProvider)_authStateProvider;
                await customAuthStateProvider.UpdateAthenticationState(UserSession);
                MessageBox.Show("You are Logged in");
                // Set the returned object to the UserSession object
                if (UserSession is not null) {
                    Role = UserSession.Role;
                } else {
                    Role = "annonymous";
                }
                this.DialogResult = DialogResult.OK;
                _isClosingFromXButton = false;
                this.Close();
            } else if (loginResponse.StatusCode == HttpStatusCode.Unauthorized) {
                MessageBox.Show("Invalid User Name or Password");
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e) {
            base.OnFormClosing(e);
            if (_isClosingFromXButton && e.CloseReason == CloseReason.UserClosing) {
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
