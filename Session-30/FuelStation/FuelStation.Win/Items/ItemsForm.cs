using DevExpress.XtraEditors;
using FuelStation.Model;
using FuelStation.Web.Blazor.Shared;
using FuelStation.Win.Extensions;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuelStation.Win.Items {
    public partial class ItemsForm : Form {
        // Properties
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly UserSession _userSession;
        private List<ItemListDto> _items = null!;
        private bool isLoading = true;
        private bool _isClosingFromXButton = true;

        public ItemsForm(HttpClient httpClient, AuthenticationStateProvider authStateProvider, UserSession userSesion) {
            InitializeComponent();
            _httpClient = httpClient;
            _authStateProvider = authStateProvider;
            _userSession = userSesion;
        }

        private async void ItemsForm_Load(object sender, EventArgs e) {
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
            bsItem.DataSource = _items;
            grdItems.DataSource = bsItem;
        }

        private async Task LoadItemsFromServer() {
            _items = await GetListFromApi<ItemListDto>("api/item");
        }

        private async Task<List<T>> GetListFromApi<T>(String Url) {
            var returnObj = await _httpClient.GetFromJsonAsync<List<T>>(Url);
            if (returnObj is null) {
                XtraMessageBox.Show("Not Authorized");
                this.Close();
                return new List<T>();
            } else {
                return returnObj;
            }
        }

        private async void btnAddItem_Click(object sender, EventArgs e) {
            await CreateOrUpdateItemAsync(null);
        }

        private async Task CreateOrUpdateItemAsync(ItemListDto? item) {
            var itemEditForm = new ItemEditForm(_items, item);
            itemEditForm.ShowDialog();
            if (itemEditForm.DialogResult == DialogResult.OK) {
                var newItem = new ItemEditDto {
                    Id = item == null ? Guid.Empty : item.Id,
                    Code = itemEditForm.Code,
                    Description = itemEditForm.Description,
                    Price = itemEditForm.Price,
                    Cost = itemEditForm.Cost,
                    ItemType = itemEditForm.ItemType
                };
                HttpResponseMessage? response = null;
                if (newItem.Id == Guid.Empty) {
                    response = await _httpClient.PostAsJsonAsync("api/Item", newItem);
                } else {
                    response = await _httpClient.PutAsJsonAsync("api/Item", newItem);
                }
                if (response.IsSuccessStatusCode) {
                    await SetControlProperties();
                    //XtraMessageBox.Show("Succsess");
                } else {
                    var error = await response.Content.ReadAsStringAsync();
                    XtraMessageBox.Show("alert", error);
                }
            }
        }

        private async void btnEditItem_Click(object sender, EventArgs e) {
            await CreateOrUpdateItemAsync((ItemListDto)bsItem.Current);
        }

        protected override void OnFormClosing(FormClosingEventArgs e) {
            base.OnFormClosing(e);
            if (_isClosingFromXButton && e.CloseReason == CloseReason.UserClosing) {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
            _isClosingFromXButton = false;
            this.Close();
        }

        private async void btnDeleteItem_Click(object sender, EventArgs e) {
            var item = (ItemListDto)bsItem.Current;
            var confirm = XtraMessageBox.Show("Delete Item. Are you sure?", "Confirmation", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes) {
                var response = await _httpClient.DeleteAsync($"api/item/{item.Id}");
                if (!response.IsSuccessStatusCode) {
                    var error = await response.Content.ReadAsStringAsync();
                    XtraMessageBox.Show(error);
                }
            }
        }
    }
}
