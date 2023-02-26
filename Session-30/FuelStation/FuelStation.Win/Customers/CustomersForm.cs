using DevExpress.XtraGrid.Views.Grid;
using System.Text.RegularExpressions;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Components.Authorization;
using FuelStation.Win.Extensions;
using FuelStation.Web.Blazor.Shared;
using DevExpress.XtraEditors;
using System.Net.Http.Json;
using Microsoft.IdentityModel.Tokens;

namespace Session_16.Win {
    public partial class CustomersForm : Form {
        // Properties
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authStateProvider;
        private List<CustomerListDto> customers = new();
        private bool isLoading = true;

        public CustomersForm(HttpClient httpClient, AuthenticationStateProvider authStateProvider) {
            InitializeComponent();
            _httpClient = httpClient;
            _authStateProvider = authStateProvider;
        }
        private async void CustomersAndCarsForm_Load(object sender, EventArgs e) {
            var customAuthStateProvider = (CustomAuthenticationStateProvider)_authStateProvider;
            var token = await customAuthStateProvider.GetToken();
            if (!String.IsNullOrWhiteSpace(token)) {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
                await SetControlProperties();
            } else {
                XtraMessageBox.Show("Not Authorized");
            }
        }

        private async Task SetControlProperties() {
            await LoadItemsFromServer();
            isLoading = false;
            bsCustomers.DataSource = customers;
            grdCustomers.DataSource = bsCustomers;
        }

        private async Task LoadItemsFromServer() {
            var customerList = await _httpClient.GetFromJsonAsync<List<CustomerListDto>>("api/customer");
            if (customerList is not null) {
                customers = customerList;
            } else {
                XtraMessageBox.Show("Not Authorized");
                this.Close();
            }
        }

        private void btn_Close_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        //Customize Buttons

        private void btn_Close_MouseEnter(object sender, EventArgs e) {
            btn_Close.FlatAppearance.MouseOverBackColor = btn_Close.BackColor;
            btn_Close.ForeColor = Color.Blue;
            btn_Close.FlatAppearance.BorderColor = Color.Red;
            btn_Close.FlatAppearance.BorderSize = 2;
        }

        private void btn_Close_MouseLeave(object sender, EventArgs e) {
            btn_Close.ForeColor = Color.Black;
            btn_Close.FlatAppearance.BorderSize = 0;
        }

        private async void gridView1_ValidateRow(object sender, ValidateRowEventArgs e) {
            GridView view = (GridView)sender;
            var customer = (CustomerListDto)bsCustomers.Current;
            e.Valid = true;
            // Name Cell
            if (String.IsNullOrEmpty(customer.Name)) {
                e.Valid = false;
                view.SetColumnError(colName, "Insert Valid Name");
            }
            // Surname Cell
            if (String.IsNullOrEmpty(customer.Surname)) {
                e.Valid = false;
                view.SetColumnError(colSurname, "Insert Valid Surname");
            }
            if (customer.CardNumber is null) {
                customer.CardNumber = "A0";
            }
            if (e.Valid) {
                view.ClearColumnErrors();
                HttpResponseMessage? response = null;
                if (customer.Id == Guid.Empty) {
                    response = await _httpClient.PostAsJsonAsync("api/customer", customer);
                    if (response.IsSuccessStatusCode) {
                        var cardNumber = await response.Content.ReadAsStringAsync();
                        XtraMessageBox.Show($"Customer {customer.Name} {customer.Surname} has registered with card number {cardNumber}");
                        customer.CardNumber = cardNumber;
                    }
                } else {
                    response = await _httpClient.PutAsJsonAsync("api/customer", customer);
                }
                if (response.IsSuccessStatusCode) {
                    await SetControlProperties();
                    XtraMessageBox.Show("Succsess");
                } else {
                    var error = await response.Content.ReadAsStringAsync();
                    XtraMessageBox.Show("alert", error);
                }
            }
        }

        private void gridView1_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e) {
            ColumnView view = (ColumnView)sender;
            GridColumn column = (e as EditFormValidateEditorEventArgs)?.Column ?? view.FocusedColumn;
            String cellVal = (String)e.Value;
            // colName changed
            if (column.FieldName == "Name") {
                if (cellVal == null) {
                    e.Valid = false;
                    view.SetColumnError(colName, "Insert Valid Name");
                } else if (cellVal == "") {
                    e.Valid = false;
                    view.SetColumnError(colName, "Fill Name cell");
                }
            }
            // colSurname changed
            if (column.FieldName == "Surname") {
                if (cellVal == null) {
                    e.Valid = false;
                    view.SetColumnError(colSurname, "Insert Valid Surname");
                } else if (cellVal == "") {
                    e.Valid = false;
                    view.SetColumnError(colSurname, "Fill Surname cell");
                }
            }
        }
        private async void gridView1_RowDeleting(object sender, DevExpress.Data.RowDeletingEventArgs e) {
            var customer = (CustomerListDto)bsCustomers.Current;
            var confirm = XtraMessageBox.Show("Delete Item. Are you sure?", "Confirmation", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes) {
                var response = await _httpClient.DeleteAsync($"api/customer/{customer.Id}");
                if (!response.IsSuccessStatusCode) {
                    var error = await response.Content.ReadAsStringAsync();
                    XtraMessageBox.Show(error);
                }
            } else {
                e.Cancel = true;
            }
        }
    }
}
