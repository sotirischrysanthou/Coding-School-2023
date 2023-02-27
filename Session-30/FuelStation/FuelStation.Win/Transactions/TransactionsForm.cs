
using FuelStation.Model;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;
using FuelStation.Web.Blazor.Shared;
using System.Net.Http;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Json;
using FuelStation.Model.Enums;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Security.Policy;
using System.Net.Http.Headers;
using FuelStation.Win.Extensions;
using System.ComponentModel;
using FuelStation.Win.Transactions;
using DevExpress.Utils.Extensions;

namespace FuelStation.Win.Transactions {
    public partial class TransactionsForm : Form {
        // Properties
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authStateProvider;
        private List<TransactionWinDto>? transactions;
        private List<CustomerListDto> customers;
        private List<EmployeeListDto> employees;
        private List<ItemListDto> items;
        private bool isLoading = true;

        public TransactionsForm(HttpClient httpClient, AuthenticationStateProvider authStateProvider) {
            InitializeComponent();
            _httpClient = httpClient;
            _authStateProvider = authStateProvider;
        }

        // Methods
        // Initial Methods-----------------------------------------------------------------------------------------------------
        private async void TransactionsForm_Load(object sender, EventArgs e) {
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
            bsTransactions.DataSource = transactions;
            grdTransactions.DataSource = bsTransactions;
            bsTransactionLines.DataSource = bsTransactions;
            bsTransactionLines.DataMember = "TransactionLines";
            grdTransactionLines.DataSource = bsTransactionLines;

            SetLookUpEdit(repCustomers, customers, "Name", "Id");
            SetLookUpEdit(repEmployees, employees, "Name", "Id");
            SetLookUpEdit(repItems, items, "Description", "Id");
        }

        private async Task LoadItemsFromServer() {
            customers = await GetListFromApi<CustomerListDto>("api/customer");
            employees = await GetListFromApi<EmployeeListDto>("api/employee");
            items = await GetListFromApi<ItemListDto>("api/item");
            transactions = await _httpClient.GetFromJsonAsync<List<TransactionWinDto>>("api/transaction");
            if (transactions is null) {
                XtraMessageBox.Show("Not Authorized");
                this.Close();
            }
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

        private void SetLookUpEdit<T>(RepositoryItemLookUpEdit rep, List<T> list, String displayMembers, String valueMember) {
            rep.DataSource = list;
            rep.DisplayMember = displayMembers;
            rep.ValueMember = valueMember;
        }

        private void repoItems_QueryPopUp(object sender, CancelEventArgs e) {
            LookUpEdit edit = (LookUpEdit)sender;
            edit.Properties.DataSource = items.Where(x => x.Code.ToLower().Contains(edit.Text.ToLower())).ToList();
        }


        //--------------------------------------------------------------------------------------
        // -----------------------------grvTransaction Events-----------------------------------
        //--------------------------------------------------------------------------------------
        private async void grvTransactions_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e) {
            var transaction = (TransactionWinDto)bsTransactions.Current;
            GridView view = (GridView)sender;
            if (transaction.CustomerId == Guid.Empty) {
                e.Valid = false;
                view.SetColumnError(colCustomer, "Insert Valid Custmer Name");
            }
            if (transaction.EmployeeId == Guid.Empty) {
                e.Valid = false;
                view.SetColumnError(colEmployee, "Insert Valid Employee Name");
            }
            if (e.Valid) {
                view.ClearColumnErrors();
                HttpResponseMessage? response = null;
                if (transaction.Id == Guid.Empty) {
                    response = await _httpClient.PostAsJsonAsync("api/transaction", transaction);
                } else {
                    response = await _httpClient.PutAsJsonAsync("api/transaction", transaction);
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

        private void grvTransactions_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e) {
            GridView view = (GridView)sender;
            GridColumn column = (e as EditFormValidateEditorEventArgs)?.Column ?? view.FocusedColumn;
            if (column.FieldName == "CustomerId") {
                Guid id = (Guid)e.Value;
                if (id == Guid.Empty) {
                    e.Valid = false;
                    view.SetColumnError(colCustomer, "Insert Valid Customer");
                }
            }
            if (column.FieldName == "EmployeeId") {
                Guid id = (Guid)e.Value;
                if (id == Guid.Empty) {
                    e.Valid = false;
                    view.SetColumnError(colEmployee, "Insert Valid Employee Name");
                }
            }
        }
        private void grvTransactions_InitNewRow(object sender, InitNewRowEventArgs e) {
            ((TransactionWinDto)bsTransactions.Current).Date = DateTime.Today;
        }

        private async void grvTransactions_RowDeleting(object sender, DevExpress.Data.RowDeletingEventArgs e) {
            var transaction = (TransactionWinDto)bsTransactions.Current;
            var confirm = XtraMessageBox.Show("Delete Item. Are you sure?", "Confirmation", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes) {
                var response = await _httpClient.DeleteAsync($"api/transaction/{transaction.Id}");
                if (!response.IsSuccessStatusCode) {
                    var error = await response.Content.ReadAsStringAsync();
                    XtraMessageBox.Show(error);
                }
            } else {
                e.Cancel = true;
            }

        }
        //--------------------------------------------------------------------------------------
        // ------------------------grvTransactionLines Events-----------------------------------
        //--------------------------------------------------------------------------------------
        private async void grvTransactionLines_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e) {
            GridView view = (GridView)sender;
            var transactionLine = (TransactionLineWinDto)bsTransactionLines.Current;
            if (e.Column.Caption == "Item" || e.Column.Caption == "Quantity") {
                var item = items.Where(i => i.Id == transactionLine.ItemId).Single();
                if (item != null) {
                    transactionLine.ItemPrice = item.Price;
                    transactionLine.NetValue = transactionLine.Quantity * transactionLine.ItemPrice;
                    if (item.ItemType == ItemType.Fuel && transactionLine.NetValue > 20) {
                        transactionLine.DiscountPercent = 10;
                    } else {
                        transactionLine.DiscountPercent = 0;
                    }
                    transactionLine.DiscountValue = transactionLine.NetValue * transactionLine.DiscountPercent / 100;
                    transactionLine.TotalValue = transactionLine.NetValue - transactionLine.DiscountValue;
                    CalculateTransactionTotalValue();
                }
            }
        }

        private void CalculateTransactionTotalValue() {
            var transaction = (TransactionWinDto)bsTransactions.Current;
            decimal TotalValue = 0;
            foreach (TransactionLineWinDto transactionLine in transaction.TransactionLines) {
                TotalValue += transactionLine.TotalValue;
            }
            if (TotalValue > 50) {
                ((TransactionWinDto)bsTransactions.Current).PaymentMethod = PaymentMethod.Cash;
            }
            ((TransactionWinDto)bsTransactions.Current).TotalValue = TotalValue;
        }

        private async void grvTransactionLines_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e) {
            var transactionLine = (TransactionLineWinDto)bsTransactionLines.Current;
            var transaction = (TransactionWinDto)bsTransactions.Current;

            GridView view = (GridView)sender;
            if (transactionLine.ItemId == Guid.Empty) {
                e.Valid = false;
                view.SetColumnError(colItem, "Insert Valid Item");
            }
            if (items.Where(i => i.Id == transactionLine.ItemId && i.ItemType == ItemType.Fuel).Any()) {
                foreach (TransactionLineWinDto transactionL in transaction.TransactionLines) {
                    if (items.Where(i => i.Id == transactionL.ItemId && i.Id != transactionLine.ItemId && i.ItemType == ItemType.Fuel).Any()) {
                        e.Valid = false;
                        view.SetColumnError(colItem, "The transaction can only have one fuel transaction line");
                    }
                }
            }

            if (e.Valid) {
                view.ClearColumnErrors();
                HttpResponseMessage? response = null;
                if (transactionLine.Id == Guid.Empty) {
                    response = await _httpClient.PostAsJsonAsync("api/transactionLine", transactionLine);
                } else {
                    response = await _httpClient.PutAsJsonAsync("api/transactionLine", transactionLine);
                }
                if (response.IsSuccessStatusCode) {
                    await SetControlProperties();
                    XtraMessageBox.Show("Succsess");
                } else {
                    var error = await response.Content.ReadAsStringAsync();
                    XtraMessageBox.Show(error);
                }
                grvTransactions.RefreshData();
                response = await _httpClient.PutAsJsonAsync("api/transaction", transaction);
                if (response.IsSuccessStatusCode) {
                    await SetControlProperties();
                    XtraMessageBox.Show("Succsess");
                } else {
                    var error = await response.Content.ReadAsStringAsync();
                    XtraMessageBox.Show(error);
                }
            }
        }

        private void grvTransactionLines_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e) {
            GridView view = (GridView)sender;
            var transactionLine = (TransactionLineWinDto)bsTransactionLines.Current;
            GridColumn column = (e as EditFormValidateEditorEventArgs)?.Column ?? view.FocusedColumn;
            if (column.FieldName == "Item") {
                var item = items.Where(i => i.Id == (Guid)e.Value).SingleOrDefault();
                if (item == null) {
                    e.Valid = false;
                    view.SetColumnError(colItem, "Insert Valid Item");
                }
            }
        }

        private void grvTransactionLines_InitNewRow(object sender, InitNewRowEventArgs e) {
            var transactionLine = (TransactionLineWinDto)bsTransactionLines.Current;
            transactionLine.TransactionId = ((TransactionWinDto)bsTransactions.Current).Id;
        }
        private async void grvTransactionLines_RowDeleting(object sender, DevExpress.Data.RowDeletingEventArgs e) {
            TransactionLineWinDto transactionLine = (TransactionLineWinDto)bsTransactionLines.Current;
            var confirm = XtraMessageBox.Show("Delete Item. Are you sure?", "Confirmation", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes) {
                var response = await _httpClient.DeleteAsync($"api/transactionLine/{transactionLine.Id}");
                if (!response.IsSuccessStatusCode) {
                    var error = await response.Content.ReadAsStringAsync();
                    XtraMessageBox.Show(error);
                }
            } else {
                e.Cancel = true;
            }
        }

        private void grvTransactionLines_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e) {
            CalculateTransactionTotalValue();
        }

        //--------------------------------------------------------------------------------------
        // ---------------------------------Buttons Events--------------------------------------
        //--------------------------------------------------------------------------------------
        private void btn_Close_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_Close_MouseEnter(object sender, EventArgs e) {
            btn_Close.FlatAppearance.MouseOverBackColor = btn_Close.BackColor;
            btn_Close.ForeColor = Color.Blue;
            btn_Close.FlatAppearance.BorderColor = Color.Red;
            btn_Close.FlatAppearance.BorderSize = 2;
        }

        private void btn_Close_MouseLeave(object sender, EventArgs e) {
            btn_Close.ForeColor = Color.Black;
            btn_Close.FlatAppearance.BorderColor = Color.Black;
            btn_Close.FlatAppearance.BorderSize = 2;
        }

        private async void btnAddTransactionLine_Click(object sender, EventArgs e) {
            var transaction = (TransactionWinDto)bsTransactions.Current;
            if (transaction != null) {
                var transactionLineEditForm = new TransactionLineEditForm(items, null, canBeFuel());
                transactionLineEditForm.ShowDialog();
                if (transactionLineEditForm.DialogResult == DialogResult.OK) {
                    var transactionLine = new TransactionLineWinDto {
                        Id = Guid.Empty,
                        ItemId = transactionLineEditForm.Item.Id,
                        ItemPrice = transactionLineEditForm.Price,
                        NetValue = transactionLineEditForm.NetValue,
                        DiscountPercent = transactionLineEditForm.DiscountPercent,
                        DiscountValue = transactionLineEditForm.DiscountValue,
                        TotalValue = transactionLineEditForm.TotalValue,
                        TransactionId = transaction.Id,
                        Quantity = transactionLineEditForm.Quantity,

                    };
                    await AddOrUpdateTransactionLine(transactionLine);
                }
            }
        }
        private async void btnEditTransactionLine_Click(object sender, EventArgs e) {
            var transaction = (TransactionWinDto)bsTransactions.Current;
            var transactionLine = (TransactionLineWinDto)bsTransactionLines.Current;
            var itemId = transactionLine.ItemId;
            if (transaction != null) {
                var transactionLineEditForm = new TransactionLineEditForm(items, items.Find(i => i.Id == itemId), canBeFuel(), transactionLine.Quantity);
                transactionLineEditForm.ShowDialog();
                if (transactionLineEditForm.DialogResult == DialogResult.OK) {
                    transactionLine.ItemId = transactionLineEditForm.Item.Id;
                    transactionLine.ItemPrice = transactionLineEditForm.Price;
                    transactionLine.NetValue = transactionLineEditForm.NetValue;
                    transactionLine.DiscountPercent = transactionLineEditForm.DiscountPercent;
                    transactionLine.DiscountValue = transactionLineEditForm.DiscountValue;
                    transactionLine.TotalValue = transactionLineEditForm.TotalValue;
                    transactionLine.TransactionId = transaction.Id;
                    transactionLine.Quantity = transactionLineEditForm.Quantity;
                    await AddOrUpdateTransactionLine(transactionLine);
                }
            }
        }

        private async Task AddOrUpdateTransactionLine(TransactionLineWinDto transactionLine) {
            HttpResponseMessage? response = null;
            if (transactionLine.Id == Guid.Empty) {
                response = await _httpClient.PostAsJsonAsync("api/transactionLine", transactionLine);
            } else {
                response = await _httpClient.PutAsJsonAsync("api/transactionLine", transactionLine);
            }
            if (response.IsSuccessStatusCode) {
                await SetControlProperties();
                XtraMessageBox.Show("Succsess");
            } else {
                var error = await response.Content.ReadAsStringAsync();
                XtraMessageBox.Show(error);
            }
            CalculateTransactionTotalValue();
            var transaction = (TransactionWinDto)bsTransactions.Current;
            grvTransactions.RefreshData();
            response = await _httpClient.PutAsJsonAsync("api/transaction", transaction);
            if (response.IsSuccessStatusCode) {
                await SetControlProperties();
                XtraMessageBox.Show("Succsess");
            } else {
                var error = await response.Content.ReadAsStringAsync();
                XtraMessageBox.Show(error);
            }
        }

        private async void btnDeleteTransactionLine_Click(object sender, EventArgs e) {
            TransactionLineWinDto transactionLine = (TransactionLineWinDto)bsTransactionLines.Current;
            var confirm = XtraMessageBox.Show("Delete Item. Are you sure?", "Confirmation", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes) {
                var response = await _httpClient.DeleteAsync($"api/transactionLine/{transactionLine.Id}");
                if (!response.IsSuccessStatusCode) {
                    var error = await response.Content.ReadAsStringAsync();
                    XtraMessageBox.Show(error);
                }
                await SetControlProperties();
                CalculateTransactionTotalValue();
                var transaction = (TransactionWinDto)bsTransactions.Current;
                grvTransactions.RefreshData();
                response = await _httpClient.PutAsJsonAsync("api/transaction", transaction);
                if (response.IsSuccessStatusCode) {
                    await SetControlProperties();
                    XtraMessageBox.Show("Succsess");
                } else {
                    var error = await response.Content.ReadAsStringAsync();
                    XtraMessageBox.Show(error);
                }
            }
        }

        private void btnAddTransaction_Click(object sender, EventArgs e) {
            var transactionEditForm = new TransactionEditForm(customers, employees, DateTime.Today, CanBeCreditCard(), null, null, PaymentMethod.Cash);
            transactionEditForm.ShowDialog();
            if (transactionEditForm.DialogResult == DialogResult.OK) {
                var transaction = new TransactionWinDto {
                    Id = Guid.Empty,
                    Date = DateTime.Now,
                    PaymentMethod = transactionEditForm.PaymentMethod,
                    TotalValue = 0,
                    CustomerId = transactionEditForm.Customer.Id,
                    EmployeeId = transactionEditForm.Employee.Id,
                };
                AddOrUpdateTransaction(transaction);
            }
        }

        private async Task AddOrUpdateTransaction(TransactionWinDto transaction) {
            HttpResponseMessage? response = null;
            if (transaction.Id == Guid.Empty) {
                response = await _httpClient.PostAsJsonAsync("api/transaction", transaction);
            } else {
                response = await _httpClient.PutAsJsonAsync("api/transaction", transaction);
            }
            if (response.IsSuccessStatusCode) {
                await SetControlProperties();
                XtraMessageBox.Show("Succsess");
            } else {
                var error = await response.Content.ReadAsStringAsync();
                XtraMessageBox.Show("alert", error);
            }
        }

        private void btnEditTransaction_Click(object sender, EventArgs e) {
            var transaction = (TransactionWinDto)bsTransactions.Current;
            var customer = customers.Find(c => c.Id == transaction.CustomerId);
            var employee = employees.Find(e => e.Id == transaction.EmployeeId);
            var transactionEditForm = new TransactionEditForm(customers, employees, transaction.Date, CanBeCreditCard(), customer, employee, PaymentMethod.Cash);
            transactionEditForm.ShowDialog();
            if (transactionEditForm.DialogResult == DialogResult.OK) {
                var newTransaction = new TransactionWinDto {
                    Id = Guid.Empty,
                    Date = DateTime.Now,
                    PaymentMethod = transactionEditForm.PaymentMethod,
                    TotalValue = 0,
                    CustomerId = transactionEditForm.Customer.Id,
                    EmployeeId = transactionEditForm.Employee.Id,
                };
                AddOrUpdateTransaction(newTransaction);
            }
        }

        private bool canBeFuel() {
            var transaction = (TransactionWinDto)bsTransactions.Current;
            foreach (TransactionLineWinDto transactionLine in transaction.TransactionLines) {
                if (items.Find(i => i.Id == transactionLine.ItemId).ItemType == ItemType.Fuel) {
                    return false;
                }
            }
            return true;
        }

        private bool CanBeCreditCard() {
            var transaction = (TransactionWinDto)bsTransactions.Current;
            return transaction.TotalValue < 50;
        }
    }
}

//var transactionLine = (TransactionLineWinDto)bsTransactionLines.Current;
//if (transactionLine != null) {
//    var item = items.Find(i => i.Id == transactionLine.ItemId);
//    var tasactionLineEditForm = new TransactionLineEditForm(items, item)
//            }