using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraScheduler.Outlook.Interop;
using FuelStation.Model;
using FuelStation.Model.Enums;
using FuelStation.Web.Blazor.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuelStation.Win.Transactions {
    public partial class TransactionEditForm : Form {
        // Properties
        private readonly List<CustomerListDto> _customers;
        private readonly List<EmployeeListDto> _employees;
        private readonly List<ItemListDto> _items;
        private readonly UserSession _userSession;
        private bool _canBeCreditCard;
        private bool _isClosingFromXButton = true;

        public List<TransactionLineWinDto> TransactionLines { get; set; }
        public List<TransactionLineWinDto> DeletedTransactionLines { get; set; } = new();
        public decimal TotalValue { get; set; }
        public DateTime Date { get; set; }
        public CustomerListDto? Customer { get; set; }
        public EmployeeListDto? Employee { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        public TransactionEditForm(List<CustomerListDto> customers,
                                   List<EmployeeListDto> employees,
                                   List<ItemListDto> items,
                                   List<TransactionLineWinDto> transactionLines,
                                   decimal totalValue,
                                   DateTime date,
                                   bool canBeCreditCard,
                                   UserSession userSession,
                                   CustomerListDto? customer = null,
                                   EmployeeListDto? employee = null,
                                   PaymentMethod paymentMethod = PaymentMethod.Cash
                                   ) {
            InitializeComponent();
            _customers = customers;
            _employees = employees.Where(e => e.HireDateEnd == null && e.EmployeeType != EmployeeType.Staff).ToList();
            _items = items;
            TransactionLines = transactionLines;
            TotalValue = totalValue;
            Customer = customer;
            Employee = employee;
            Date = date;
            _canBeCreditCard = canBeCreditCard;
            PaymentMethod = paymentMethod;
            _userSession = userSession;
        }
        private void TransactionEditForm_Load(object sender, EventArgs e) {
            SetControlProperties();
            CalculateTransactionTotalValue();
            if (Customer != null) {
                txtCardNumber.Text = Customer.CardNumber;
            }
            if (Employee != null) {
                txtEmployeeName.Text = Employee.Name;
                txtEmployeeSurname.Text = Employee.Surname;
            }
            if (PaymentMethod == PaymentMethod.Cash) {
                btnCash_Click(sender, e);
            }
            if (PaymentMethod == PaymentMethod.CreditCard) {
                btnCreditCard_Click(sender, e);
            }
            dateEdit.DateTime = Date;
            if(_userSession.Role != "Manager") {
                txtEmployeeName.Text = _userSession.Employee.Name;
                txtEmployeeSurname.Text = _userSession.Employee.Surname;
                txtEmployeeName.Enabled = false;
                txtEmployeeSurname.Enabled = false;
            }

        }

        private void SetControlProperties() {
            var tempCustomer = Customer;
            var tempEmployee = Employee;
            bsCustomers.DataSource = _customers;
            grdCustomers.DataSource = bsCustomers;

            bsEmployees.DataSource = _employees;
            grdEmployees.DataSource = bsEmployees;

            bsTransactionLines.DataSource = TransactionLines;
            grdTransactionLines.DataSource = bsTransactionLines;

            Customer = tempCustomer;
            Employee = tempEmployee;

            SetLookUpEdit(repItems, _items, "Description", "Id");
        }

        private void SetLookUpEdit<T>(RepositoryItemLookUpEdit rep, List<T> list, String displayMembers, String valueMember) {
            rep.DataSource = list;
            rep.DisplayMember = displayMembers;
            rep.ValueMember = valueMember;
        }




        private void Search() {
            String searchCardNumberTerm = (String)txtCardNumber.EditValue;
            String searchNameTerm = (String)txtCustomerName.EditValue;
            String searchSurnameTerm = (String)txtCustomerSurname.EditValue;
            if (String.IsNullOrEmpty(searchCardNumberTerm)) { searchCardNumberTerm = ""; }
            if (String.IsNullOrEmpty(searchNameTerm)) { searchNameTerm = ""; }
            if (String.IsNullOrEmpty(searchSurnameTerm)) { searchSurnameTerm = ""; }

            bsCustomers.DataSource = _customers.Where(c => c.CardNumber.StartsWith(searchCardNumberTerm)
                                                                &&
                                                           c.Name.StartsWith(searchNameTerm)
                                                                &&
                                                           c.Surname.StartsWith(searchSurnameTerm))
                                                           .ToList();
            searchNameTerm = (String)txtEmployeeName.EditValue;
            searchSurnameTerm = (String)txtEmployeeSurname.EditValue;
            if (String.IsNullOrEmpty(searchNameTerm)) { searchNameTerm = ""; }
            if (String.IsNullOrEmpty(searchSurnameTerm)) { searchSurnameTerm = ""; }

            bsEmployees.DataSource = _employees.Where(e => e.Name.StartsWith(searchNameTerm)
                                                                &&
                                                           e.Surname.StartsWith(searchSurnameTerm))
                                                           .ToList();
            gridView1.RefreshData();
        }

        private void bsCustomers_CurrentChanged(object sender, EventArgs e) {
            Customer = (CustomerListDto)bsCustomers.Current;
        }

        private void bsEmployees_CurrentChanged(object sender, EventArgs e) {
            Employee = (EmployeeListDto)bsEmployees.Current;
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            _isClosingFromXButton= false;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e) {
            _isClosingFromXButton= false;
            bool flag = true;
            if (Customer == null) {
                XtraMessageBox.Show("Please Choose Valid Customer");
                flag = false;
            }
            if (Employee == null) {
                XtraMessageBox.Show("Please Choose Valid Employee");
                flag = false;
            }
            if (!_canBeCreditCard && PaymentMethod == PaymentMethod.CreditCard) {
                XtraMessageBox.Show("Payment Method can not be credit card because the transaction's total value is over 50 euro");
                flag = false;
            }

            if (flag) {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCash_Click(object sender, EventArgs e) {
            btnCash.BackColor = Color.Chartreuse;
            btnCreditCard.BackColor = Color.Transparent;
            PaymentMethod = PaymentMethod.Cash;
        }

        private void btnCreditCard_Click(object sender, EventArgs e) {
            btnCreditCard.BackColor = Color.Chartreuse;
            btnCash.BackColor = Color.Transparent;
            PaymentMethod = PaymentMethod.CreditCard;
        }

        private void txtCardNumber_EditValueChanged(object sender, EventArgs e) {
            Search();
        }

        private void txtCustomerName_EditValueChanged(object sender, EventArgs e) {
            Search();
        }

        private void txtCustomerSurname_EditValueChanged(object sender, EventArgs e) {
            Search();
        }

        private void txtEmployeeName_EditValueChanged(object sender, EventArgs e) {
            Search();
        }

        private void txtEmployeeSurname_EditValueChanged(object sender, EventArgs e) {
            Search();
        }

        protected override void OnFormClosing(FormClosingEventArgs e) {
            base.OnFormClosing(e);
            if (_isClosingFromXButton && e.CloseReason == CloseReason.UserClosing) {
                this.DialogResult = DialogResult.Continue;
            }
        }

        private void btnAddTransactionLine_Click(object sender, EventArgs e) {
            var transactionLineEditForm = new TransactionLineEditForm(_items, null, canBeFuel());
            transactionLineEditForm.ShowDialog();
            if (transactionLineEditForm.DialogResult == DialogResult.OK && transactionLineEditForm.Item != null) {
                var transactionLine = new TransactionLineWinDto {
                    Id = Guid.Empty,
                    ItemId = transactionLineEditForm.Item.Id,
                    ItemPrice = transactionLineEditForm.Price,
                    NetValue = transactionLineEditForm.NetValue,
                    DiscountPercent = transactionLineEditForm.DiscountPercent,
                    DiscountValue = transactionLineEditForm.DiscountValue,
                    TotalValue = transactionLineEditForm.TotalValue,
                    TransactionId = Guid.Empty,
                    Quantity = transactionLineEditForm.Quantity,

                };
                TransactionLines.Add(transactionLine);
                CalculateTransactionTotalValue();
                //SetControlProperties();
                grvTransactionLines.RefreshData();
            }
        }
        private void btnEditTransactionLine_Click(object sender, EventArgs e) {
            var transactionLine = (TransactionLineWinDto)bsTransactionLines.Current;
            var itemId = transactionLine.ItemId;

            var transactionLineEditForm = new TransactionLineEditForm(_items, _items.Find(i => i.Id == itemId), canBeFuel(), transactionLine.Quantity);
            transactionLineEditForm.ShowDialog();
            if (transactionLineEditForm.DialogResult == DialogResult.OK && transactionLineEditForm.Item is not null) {
                transactionLine.ItemId = transactionLineEditForm.Item.Id;
                transactionLine.ItemPrice = transactionLineEditForm.Price;
                transactionLine.NetValue = transactionLineEditForm.NetValue;
                transactionLine.DiscountPercent = transactionLineEditForm.DiscountPercent;
                transactionLine.DiscountValue = transactionLineEditForm.DiscountValue;
                transactionLine.TotalValue = transactionLineEditForm.TotalValue;
                transactionLine.Quantity = transactionLineEditForm.Quantity;
                CalculateTransactionTotalValue();
                //SetControlProperties();
                grvTransactionLines.RefreshData();
            }
        }

        private void btnDeleteTransactionLine_Click(object sender, EventArgs e) {
            TransactionLineWinDto transactionLine = (TransactionLineWinDto)bsTransactionLines.Current;
            var confirm = XtraMessageBox.Show("Delete Item. Are you sure?", "Confirmation", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes) {
                if (transactionLine.Id != Guid.Empty) {
                    DeletedTransactionLines.Add(transactionLine);
                }
                bsTransactionLines.RemoveCurrent();
                CalculateTransactionTotalValue();
                SetControlProperties();
            }
        }

        private void CalculateTransactionTotalValue() {
            TotalValue = 0;
            foreach (TransactionLineWinDto transactionLine in TransactionLines) {
                TotalValue += transactionLine.TotalValue;
            }
            if (TotalValue > 50) {
                PaymentMethod = PaymentMethod.Cash;
                _canBeCreditCard = false;
            } else {
                _canBeCreditCard = true;
            }
            lblTotalPrice.Text = $"€ {TotalValue}";
        }

        private bool canBeFuel() {
            foreach (TransactionLineWinDto transactionLine in TransactionLines) {
                var item = _items.Find(i => i.Id == transactionLine.ItemId);
                if (item != null) {
                    if (item.ItemType == ItemType.Fuel) {
                        return false;
                    }
                }
            }
            return true;
        }

        private void dateEdit_DateTimeChanged(object sender, EventArgs e) {
            Date = dateEdit.DateTime;
        }
    }
}
