using FuelStation.Model;
using FuelStation.Model.Enums;
using FuelStation.Win.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuelStation.Win {
    public partial class MainMenuForm : Form {

        private readonly String _role;
        public FormType FormType { get; set; }
        private bool _isClosingFromXButton = true;

        public MainMenuForm(String role) {
            InitializeComponent();
            _role = role;
        }
        private void MainMenuForm_Load(object sender, EventArgs e) {
            switch (_role) {
                case "Manager":
                    break;
                case "Staff":
                    btnCustomers.Hide();
                    btnTransactions.Hide();
                    break;
                case "Cashier":
                    btnItems.Hide();
                    break;
                default:
                    break;
            }
        }

        private void btnTransactions_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
            FormType = FormType.Transactions;
            _isClosingFromXButton = false;
            this.Close();
        }

        private void btnCustomers_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
            FormType = FormType.Customers;
            _isClosingFromXButton = false;
            this.Close();
        }

        private void btnItems_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
            FormType = FormType.Items;
            _isClosingFromXButton = false;
            this.Close();
        }

        private void panelMenu_Paint(object sender, PaintEventArgs e) {

        }
        private void btnLogout_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Continue;
            FormType = FormType.Login;
            _isClosingFromXButton = false;
            this.Close();
        }

        //Customize Buttons
        private void btnTransactions_MouseEnter(object sender, EventArgs e) {
            btnTransactions.BackColor = Color.FromArgb(145, 31, 31);
            btnTransactions.FlatAppearance.MouseOverBackColor = btnTransactions.BackColor;
            btnTransactions.ForeColor = Color.White;
            btnTransactions.FlatAppearance.BorderColor = Color.Black;
            btnTransactions.FlatAppearance.BorderSize = 1;
        }
        private void btnTransactions_MouseLeave(object sender, EventArgs e) {
            btnTransactions.BackColor = Color.FromArgb(237, 234, 218);
            btnTransactions.ForeColor = Color.Black;
            btnTransactions.FlatAppearance.BorderSize = 0;
        }
        private void btnCustomerAndCars_MouseEnter(object sender, EventArgs e) {
            btnCustomers.BackColor = Color.FromArgb(145, 31, 31);
            btnCustomers.FlatAppearance.MouseOverBackColor = btnCustomers.BackColor;
            btnCustomers.ForeColor = Color.White;
            btnCustomers.FlatAppearance.BorderColor = Color.Black;
            btnCustomers.FlatAppearance.BorderSize = 1;
        }
        private void btnCustomerAndCars_MouseLeave(object sender, EventArgs e) {
            btnCustomers.BackColor = Color.FromArgb(237, 234, 218);
            btnCustomers.ForeColor = Color.Black;
            btnCustomers.FlatAppearance.BorderSize = 0;
        }
        private void btnItems_MouseEnter(object sender, EventArgs e) {
            btnItems.BackColor = Color.FromArgb(145, 31, 31);
            btnItems.FlatAppearance.MouseOverBackColor = btnItems.BackColor;
            btnItems.ForeColor = Color.White;
            btnItems.FlatAppearance.BorderColor = Color.Black;
            btnItems.FlatAppearance.BorderSize = 1;
        }
        private void btnItems_MouseLeave(object sender, EventArgs e) {
            btnItems.BackColor = Color.FromArgb(237, 234, 218);
            btnItems.ForeColor = Color.Black;
            btnItems.FlatAppearance.BorderSize = 0;
        }
        private void btnLogout_MouseEnter(object sender, EventArgs e) {
            btnLogout.BackColor = Color.FromArgb(145, 31, 31);
            btnLogout.FlatAppearance.MouseOverBackColor = btnLogout.BackColor;
            btnLogout.ForeColor = Color.White;
            btnLogout.FlatAppearance.BorderColor = Color.Black;
            btnLogout.FlatAppearance.BorderSize = 1;
        }

        private void btnLogout_MouseLeave(object sender, EventArgs e) {
            btnLogout.BackColor = Color.FromArgb(237, 234, 218);
            btnLogout.ForeColor = Color.Black;
            btnLogout.FlatAppearance.BorderSize = 0;
        }

        protected override void OnFormClosing(FormClosingEventArgs e) {
            base.OnFormClosing(e);
            if ( _isClosingFromXButton && e.CloseReason == CloseReason.UserClosing) {
                this.DialogResult = DialogResult.Continue;
                FormType = FormType.Login;
            }
        }
    }
}
