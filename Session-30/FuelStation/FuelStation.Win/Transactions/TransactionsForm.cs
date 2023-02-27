
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
using FuelStation.Win.Enums;

namespace FuelStation.Win.Transactions {
    public partial class TransactionsForm : Form {
        // Properties
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly UserSession _userSession;
        private List<TransactionWinDto>? _transactions;
        private List<CustomerListDto> _customers = null!;
        private List<EmployeeListDto> _employees = null!;
        private List<ItemListDto> _items = null!;
        private bool _isLoading = true;

        public TransactionsForm(HttpClient httpClient, AuthenticationStateProvider authStateProvider, UserSession userSesion) {
            InitializeComponent();
            _httpClient = httpClient;
            _authStateProvider = authStateProvider;
            _userSession = userSesion;
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
            bsTransactions.DataSource = _transactions;
            grdTransactions.DataSource = bsTransactions;
            bsTransactionLines.DataSource = bsTransactions;
            bsTransactionLines.DataMember = "TransactionLines";
            grdTransactionLines.DataSource = bsTransactionLines;

            SetLookUpEdit(repCustomers, _customers, "Name", "Id");
            SetLookUpEdit(repEmployees, _employees, "Name", "Id");
            SetLookUpEdit(repItems, _items, "Description", "Id");
        }

        private async Task LoadItemsFromServer() {
            _customers = await GetListFromApi<CustomerListDto>("api/customer");
            _employees = await GetListFromApi<EmployeeListDto>("api/employee");
            _items = await GetListFromApi<ItemListDto>("api/item");
            _transactions = await _httpClient.GetFromJsonAsync<List<TransactionWinDto>>("api/transaction");
            if (_transactions is null) {
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
            edit.Properties.DataSource = _items.Where(x => x.Code.ToLower().Contains(edit.Text.ToLower())).ToList();
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

        protected override void OnFormClosing(FormClosingEventArgs e) {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.UserClosing) {
                this.DialogResult = DialogResult.OK;
            }
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
            if (_userSession.Role != "Manager" && transaction.EmployeeId != _userSession.EmployeeId) {
                XtraMessageBox.Show("Not Authorized to Edit this transaction. If you think something went wrong, please contact your manager");
                return;
            }
            if (transaction != null) {
                var transactionLineEditForm = new TransactionLineEditForm(_items, null, canBeFuel());
                transactionLineEditForm.ShowDialog();
                if (transactionLineEditForm.DialogResult == DialogResult.OK && transactionLineEditForm.Item is not null) {
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
            if (_userSession.Role != "Manager" && transaction.EmployeeId != _userSession.EmployeeId) {
                XtraMessageBox.Show("Not Authorized to Edit this transaction. If you think something went wrong, please contact your manager");
                return;
            }
            var transactionLine = (TransactionLineWinDto)bsTransactionLines.Current;
            var itemId = transactionLine.ItemId;
            if (transaction != null) {
                var transactionLineEditForm = new TransactionLineEditForm(_items, _items.Find(i => i.Id == itemId), canBeFuel(), transactionLine.Quantity);
                transactionLineEditForm.ShowDialog();
                if (transactionLineEditForm.DialogResult == DialogResult.OK && transactionLineEditForm.Item is not null) {
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
            var transaction = (TransactionWinDto)bsTransactions.Current;
            if (_userSession.Role != "Manager" && transaction.EmployeeId != _userSession.EmployeeId) {
                XtraMessageBox.Show("Not Authorized to Edit this transaction. If you think something went wrong, please contact your manager");
                return;
            }
            HttpResponseMessage? response = null;
            if (transactionLine.Id == Guid.Empty) {
                response = await _httpClient.PostAsJsonAsync("api/transactionLine", transactionLine);
            } else {
                response = await _httpClient.PutAsJsonAsync("api/transactionLine", transactionLine);
            }
            if (response.IsSuccessStatusCode) {
                await SetControlProperties();
                //XtraMessageBox.Show("Succsess");
            } else {
                var error = await response.Content.ReadAsStringAsync();
                XtraMessageBox.Show(error);
            }
            CalculateTransactionTotalValue();
            transaction = (TransactionWinDto)bsTransactions.Current;
            await AddOrUpdateTransaction(transaction, new(), new());
            //grvTransactions.RefreshData();
            //response = await _httpClient.PutAsJsonAsync("api/transaction", transaction);
            //if (response.IsSuccessStatusCode) {
            //    await SetControlProperties();
            //    //XtraMessageBox.Show("Succsess");
            //} else {
            //    var error = await response.Content.ReadAsStringAsync();
            //    XtraMessageBox.Show(error);
            //}
        }

        private async void btnDeleteTransactionLine_Click(object sender, EventArgs e) {
            TransactionLineWinDto transactionLine = (TransactionLineWinDto)bsTransactionLines.Current;
            var confirm = XtraMessageBox.Show("Delete Item. Are you sure?", "Confirmation", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes) {
                await DeleteTransactionLine(transactionLine);
                //var response = await _httpClient.DeleteAsync($"api/transactionLine/{transactionLine.Id}");
                //if (!response.IsSuccessStatusCode) {
                //    var error = await response.Content.ReadAsStringAsync();
                //    XtraMessageBox.Show(error);
                //}
                //await SetControlProperties();
                //CalculateTransactionTotalValue();
                //var transaction = (TransactionWinDto)bsTransactions.Current;
                //await AddOrUpdateTransaction(transaction, new(), new());
                //grvTransactions.RefreshData();
                //response = await _httpClient.PutAsJsonAsync("api/transaction", transaction);
                //if (response.IsSuccessStatusCode) {
                //    await SetControlProperties();
                //    //XtraMessageBox.Show("Succsess");
                //} else {
                //    var error = await response.Content.ReadAsStringAsync();
                //    XtraMessageBox.Show(error);
                //}
            }
        }

        public async Task DeleteTransactionLine(TransactionLineWinDto transactionLine) {
            var response = await _httpClient.DeleteAsync($"api/transactionLine/{transactionLine.Id}");
            if (!response.IsSuccessStatusCode) {
                var error = await response.Content.ReadAsStringAsync();
                XtraMessageBox.Show(error);
            }
            await SetControlProperties();
            CalculateTransactionTotalValue();
            var transaction = (TransactionWinDto)bsTransactions.Current;
            await AddOrUpdateTransaction(transaction, new(), new());
        }

        private async void btnAddTransaction_Click(object sender, EventArgs e) {
            var transactionEditForm = new TransactionEditForm(_customers,
                                                              _employees,
                                                              _items,
                                                              new(),
                                                              0,
                                                              DateTime.Today,
                                                              CanBeCreditCard(),
                                                              _userSession
                                                              );
            transactionEditForm.ShowDialog();
            if (transactionEditForm.DialogResult == DialogResult.OK && transactionEditForm.Customer is not null && transactionEditForm.Employee is not null) {
                var transaction = new TransactionWinDto {
                    Id = Guid.Empty,
                    Date = transactionEditForm.Date,
                    PaymentMethod = transactionEditForm.PaymentMethod,
                    TotalValue = transactionEditForm.TotalValue,
                    CustomerId = transactionEditForm.Customer.Id,
                    EmployeeId = transactionEditForm.Employee.Id,
                };
                await AddOrUpdateTransaction(transaction, transactionEditForm.TransactionLines, transactionEditForm.DeletedTransactionLines);

            }
        }

        private async Task AddOrUpdateTransaction(TransactionWinDto transaction,
                                                  List<TransactionLineWinDto> transactionLines,
                                                  List<TransactionLineWinDto> deletedTransactionLines) {
            HttpResponseMessage? response = null;
            if (transaction.Id == Guid.Empty) {
                response = await _httpClient.PostAsJsonAsync("api/transaction", transaction);
            } else {
                response = await _httpClient.PutAsJsonAsync("api/transaction", transaction);
            }
            if (response.IsSuccessStatusCode) {

                var transactionIdStr = await response.Content.ReadAsStringAsync();
                Guid transactionId = Guid.Parse(transactionIdStr);

                foreach (var transactionLine in transactionLines) {
                    transactionLine.TransactionId = transactionId;
                    await AddOrUpdateTransactionLine(transactionLine);
                }
                foreach (var toDeleteTransactionLine in deletedTransactionLines) {
                    await DeleteTransactionLine(toDeleteTransactionLine);
                }

                await SetControlProperties();
                //XtraMessageBox.Show("Succsess");
            } else {
                var error = await response.Content.ReadAsStringAsync();
                XtraMessageBox.Show("alert", error);
            }
        }

        private async void btnEditTransaction_Click(object sender, EventArgs e) {
            var transaction = (TransactionWinDto)bsTransactions.Current;
            if (_userSession.Role != "Manager" && transaction.EmployeeId != _userSession.EmployeeId) {
                XtraMessageBox.Show("Not Authorized to Edit this transaction. If you think something went wrong, please contact your manager");
                return;
            }
            var customer = _customers.Find(c => c.Id == transaction.CustomerId);
            var employee = _employees.Find(e => e.Id == transaction.EmployeeId);
            var transactionEditForm = new TransactionEditForm(_customers,
                                                              _employees,
                                                              _items,
                                                              transaction.TransactionLines,
                                                              transaction.TotalValue,
                                                              transaction.Date,
                                                              CanBeCreditCard(),
                                                              _userSession,
                                                              customer,
                                                              employee,
                                                              PaymentMethod.Cash);
            transactionEditForm.ShowDialog();
            if (transactionEditForm.DialogResult == DialogResult.OK && transactionEditForm.Customer is not null && transactionEditForm.Employee is not null) {
                var newTransaction = new TransactionWinDto {
                    Id = transaction.Id,
                    Date = transactionEditForm.Date,
                    PaymentMethod = transactionEditForm.PaymentMethod,
                    TotalValue = transactionEditForm.TotalValue,
                    CustomerId = transactionEditForm.Customer.Id,
                    EmployeeId = transactionEditForm.Employee.Id,
                };
                await AddOrUpdateTransaction(newTransaction, transactionEditForm.TransactionLines, transactionEditForm.DeletedTransactionLines);
            }
        }

        private bool canBeFuel() {
            var transaction = (TransactionWinDto)bsTransactions.Current;
            foreach (TransactionLineWinDto transactionLine in transaction.TransactionLines) {
                var item = _items.Find(i => i.Id == transactionLine.ItemId);
                if (item != null) {
                    if (item.ItemType == ItemType.Fuel) {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool CanBeCreditCard() {
            var transaction = (TransactionWinDto?)bsTransactions.Current;
            if (transaction != null)
                return transaction.TotalValue < 50;
            else return true;
        }

        private async void btnDeleteTransaction_Click(object sender, EventArgs e) {
            TransactionWinDto transaction = (TransactionWinDto)bsTransactions.Current;
            var confirm = XtraMessageBox.Show("Delete Item. Are you sure?", "Confirmation", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes) {
                var response = await _httpClient.DeleteAsync($"api/transaction/{transaction.Id}");
                if (!response.IsSuccessStatusCode) {
                    var error = await response.Content.ReadAsStringAsync();
                    XtraMessageBox.Show(error);
                }
                await SetControlProperties();
            }
        }
    }
}
