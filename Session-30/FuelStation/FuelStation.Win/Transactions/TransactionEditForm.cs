using DevExpress.XtraEditors;
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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuelStation.Win.Transactions {
    public partial class TransactionEditForm : Form {
        // Properties
        private readonly List<CustomerListDto> _customers;
        private readonly List<EmployeeListDto> _employees;
        private readonly bool _canBeCreditCard;
        public CustomerListDto? Customer { get; set; }
        public EmployeeListDto? Employee { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public DateTime Date { get; set; }

        public TransactionEditForm(List<CustomerListDto> customers,
                                   List<EmployeeListDto> employees,
                                   DateTime date,
                                   bool canBeCreditCard,
                                   CustomerListDto? customer = null, 
                                   EmployeeListDto? employee = null,
                                   PaymentMethod paymentMethod = PaymentMethod.Cash
                                   ) {
            InitializeComponent();
            _customers = customers;
            _employees = employees;
            Customer = customer;
            Employee = employee;
            Date = date;
            _canBeCreditCard = canBeCreditCard;
        }
        private async void TransactionEditForm_Load(object sender, EventArgs e) {
            SetControlProperties();
            if (Customer != null) {
                txtCardNumber.Text = Customer.CardNumber;
            }
            if (Employee != null) {
                txtEmployeeName.Text = Employee.Name;
                txtEmployeeSurname.Text = Employee.Surname;
            }
            if(PaymentMethod == PaymentMethod.Cash) {
                btnCash_Click(sender, e);
            }
            if(PaymentMethod == PaymentMethod.CreditCard) {
                btnCreditCard_Click(sender, e);
            }
            dateEdit.DateTime = Date;
            
        }

        private void SetControlProperties() {
            var tempCustomer = Customer;
            var tempEmployee = Employee;
            bsCustomers.DataSource = _customers;
            grdCustomers.DataSource = bsCustomers;

            bsEmployees.DataSource = _employees;
            grdEmployees.DataSource = bsEmployees;

            Customer = tempCustomer;
            Employee = tempEmployee;


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
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e) {
            bool flag = true;
            if (Customer == null) {
                XtraMessageBox.Show("Please Choose Valid Customer");
                flag = false;
            }
            if(Employee == null) {
                XtraMessageBox.Show("Please Choose Valid Employee");
                flag = false;
            }
            if(!_canBeCreditCard && PaymentMethod == PaymentMethod.CreditCard) {
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
    }
}
