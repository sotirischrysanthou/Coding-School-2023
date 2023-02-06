using CarServiceCenterLib.Models;
using CarServiceCenterLib.Orm.Context;
using CarServiceCenterLib.Orm.Repositories;
using SerializerLib;
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

namespace Session_16.Win {
    public partial class MainMenuForm : Form {

        

        public MainMenuForm() {
            InitializeComponent();
        }
        private void MainMenuForm_Load(object sender, EventArgs e) {
            
        }

        private void Populate() {
            using var appDbContext = new AppDbContext();
            CustomerRepo customerRepo = new CustomerRepo();
            EngineerRepo engineerRepo = new EngineerRepo();
            ManagerRepo managerRepo = new ManagerRepo();
            CarRepo carRepo = new CarRepo();
            TransactionRepo transactionRepo = new TransactionRepo();
            TransactionLineRepo transactionLineRepo = new TransactionLineRepo();
            ServiceTaskRepo serviceTaskRepo = new ServiceTaskRepo();
            customerRepo.Add(new Customer("Sotiris", "Chrysanthou", "6954872136", "154852984"));
            customerRepo.Add(new Customer("Demetris", "Manolas", "6912342136", "165826475"));
            customerRepo.Add(new Customer("Giannis", "Tsimpris", "6912341234", "182349528"));
            customerRepo.Add(new Customer("Giannis", "Antetokoumpo", "6910646234", "123456982"));
            customerRepo.Add(new Customer("Panos", "Ioannides", "6912334867", "165942358"));
            carRepo.Add(new Car("Ford", "Focus", "IZM 5469"));
            carRepo.Add(new Car("Ford", "Fiesta", "IMZ 1234"));
            carRepo.Add(new Car("Mazda", "6", "IAM 3369"));
            carRepo.Add(new Car("Suzuki", "Swift", "IAM 8888"));
            managerRepo.Add(new Manager("Fotis", "Chrysoulas", 15000, DateTime.Parse("21/1/2023")));
            managerRepo.Add(new Manager("Giannis", "Ioannou", 10000, DateTime.Parse("15/3/2023")));
            managerRepo.Add(new Manager("Fotis", "Mitsou", 8000, DateTime.Parse("21/2/2023")));
            managerRepo.Add(new Manager("Sotiris", "Kontizas", 8000, DateTime.Parse("21/2/2023")));
            engineerRepo.Add(new Engineer("Demetris", "Raptodimos", appDbContext.Managers.ToList()[0].ID, 1000, DateTime.Parse("2/2/2023")));
            engineerRepo.Add(new Engineer("Kostas", "Kostaki", appDbContext.Managers.ToList()[0].ID, 1500, DateTime.Parse("2/1/2023")));
            engineerRepo.Add(new Engineer("Kostis", "Marvelias", appDbContext.Managers.ToList()[0].ID, 800, DateTime.Parse("2/3/2023")));
            serviceTaskRepo.Add(new ServiceTask(1, "Air Filter", 2.0));
            serviceTaskRepo.Add(new ServiceTask(2, "General service", 8.0));
            serviceTaskRepo.Add(new ServiceTask(3, "Tire change", 3.0));
            serviceTaskRepo.Add(new ServiceTask(4, "Change gasket", 6.0));
            serviceTaskRepo.Add(new ServiceTask(5, "Oil Filter", 4.0));
            serviceTaskRepo.Add(new ServiceTask(6, "Spark plug", 5.0));
            serviceTaskRepo.Add(new ServiceTask(7, "Oil Filter", 7.0));
            Customer customer = appDbContext.Customers.ToList()[0];
            Car car = appDbContext.Cars.ToList()[0];
            Manager manager = appDbContext.Managers.ToList()[0];
            ServiceTask serviceTask = appDbContext.ServiceTasks.ToList()[0];
            Engineer engineer = appDbContext.Engineers.ToList()[0];
            transactionRepo.Add(new Transaction(customer.ID, car.ID, manager.ID));  
            Transaction transaction = appDbContext.Transactions.ToList()[0];
            transactionLineRepo.Add(new TransactionLine(transaction.ID, serviceTask.ID, engineer.ID, serviceTask.Hours, 44.5));
            serviceTask = appDbContext.ServiceTasks.ToList()[1];
            transactionLineRepo.Add(new TransactionLine(transaction.ID, serviceTask.ID, engineer.ID, serviceTask.Hours, 44.5));
            customer = appDbContext.Customers.ToList()[1];
            car = appDbContext.Cars.ToList()[1];
            transactionRepo.Add(new Transaction(customer.ID, car.ID, manager.ID));
            transaction = appDbContext.Transactions.ToList()[1];
            serviceTask = appDbContext.ServiceTasks.ToList()[2];
            transactionLineRepo.Add(new TransactionLine(transaction.ID, serviceTask.ID, engineer.ID, serviceTask.Hours, 44.5));
            serviceTask = appDbContext.ServiceTasks.ToList()[3];
        }

        private void btnPopulate_Click(object sender, EventArgs e) {
            Populate();
            DevExpress.XtraEditors.XtraMessageBox.Show("Populate Successful!");

        }

        private void btnTransactions_Click(object sender, EventArgs e) {
            TransactionsForm transactionsForm = new TransactionsForm();
            transactionsForm.ShowDialog(); // Shows _transactionsForm
        }

        private void btnCustomerAndCars_Click_1(object sender, EventArgs e) {
            CustomersAndCarsForm customersAndCarsForm = new CustomersAndCarsForm();
            customersAndCarsForm.ShowDialog(); // Shows _customerAndCarsForm
        }

        private void btnServiceTasks_Click_1(object sender, EventArgs e) {
            ServiceTasksForm serviceTasksForm = new ServiceTasksForm();
            serviceTasksForm.ShowDialog();  // shows _ServiceTasksForm
        }

        private void btnEmployees_Click_1(object sender, EventArgs e) {
            EmployeesForm employeesForm = new EmployeesForm();
            employeesForm.ShowDialog();
        }

        private void btn_MonthlyLedger_Click_1(object sender, EventArgs e) {
            MonthlyLedgerForm monthlyLedgerForm = new MonthlyLedgerForm();
            monthlyLedgerForm.ShowDialog();
        }

        private void panelMenu_Paint(object sender, PaintEventArgs e) {

        }

        private void btnExit_Click(object sender, EventArgs e) {
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
            btnCustomerAndCars.BackColor = Color.FromArgb(145, 31, 31);
            btnCustomerAndCars.FlatAppearance.MouseOverBackColor = btnCustomerAndCars.BackColor;
            btnCustomerAndCars.ForeColor = Color.White;
            btnCustomerAndCars.FlatAppearance.BorderColor = Color.Black;
            btnCustomerAndCars.FlatAppearance.BorderSize = 1;
        }

        private void btnCustomerAndCars_MouseLeave(object sender, EventArgs e) {
            btnCustomerAndCars.BackColor = Color.FromArgb(237, 234, 218);
            btnCustomerAndCars.ForeColor = Color.Black;
            btnCustomerAndCars.FlatAppearance.BorderSize = 0;
        }

        private void btnServiceTasks_MouseEnter(object sender, EventArgs e) {
            btnServiceTasks.BackColor = Color.FromArgb(145, 31, 31);
            btnServiceTasks.FlatAppearance.MouseOverBackColor = btnServiceTasks.BackColor;
            btnServiceTasks.ForeColor = Color.White;
            btnServiceTasks.FlatAppearance.BorderColor = Color.Black;
            btnServiceTasks.FlatAppearance.BorderSize = 1;
        }

        private void btnServiceTasks_MouseLeave(object sender, EventArgs e) {
            btnServiceTasks.BackColor = Color.FromArgb(237, 234, 218);
            btnServiceTasks.ForeColor = Color.Black;
            btnServiceTasks.FlatAppearance.BorderSize = 0;
        }

        private void btnEmployees_MouseEnter(object sender, EventArgs e) {
            btnEmployees.BackColor = Color.FromArgb(145, 31, 31);
            btnEmployees.FlatAppearance.MouseOverBackColor = btnEmployees.BackColor;
            btnEmployees.ForeColor = Color.White;
            btnEmployees.FlatAppearance.BorderColor = Color.Black;
            btnEmployees.FlatAppearance.BorderSize = 1;
        }

        private void btnEmployees_MouseLeave(object sender, EventArgs e) {
            btnEmployees.BackColor = Color.FromArgb(237, 234, 218);
            btnEmployees.ForeColor = Color.Black;
            btnEmployees.FlatAppearance.BorderSize = 0;
        }

        private void btn_MonthlyLedger_MouseEnter(object sender, EventArgs e) {
            btn_MonthlyLedger.BackColor = Color.FromArgb(145, 31, 31);
            btn_MonthlyLedger.FlatAppearance.MouseOverBackColor = btn_MonthlyLedger.BackColor;
            btn_MonthlyLedger.ForeColor = Color.White;
            btn_MonthlyLedger.FlatAppearance.BorderColor = Color.Black;
            btn_MonthlyLedger.FlatAppearance.BorderSize = 1;
        }

        private void btn_MonthlyLedger_MouseLeave(object sender, EventArgs e) {
            btn_MonthlyLedger.BackColor = Color.FromArgb(237, 234, 218);
            btn_MonthlyLedger.ForeColor = Color.Black;
            btn_MonthlyLedger.FlatAppearance.BorderSize = 0;
        }

        private void btnExit_MouseEnter(object sender, EventArgs e) {
            btnExit.BackColor = Color.FromArgb(145, 31, 31);
            btnExit.FlatAppearance.MouseOverBackColor = btnExit.BackColor;
            btnExit.ForeColor = Color.White;
            btnExit.FlatAppearance.BorderColor = Color.Black;
            btnExit.FlatAppearance.BorderSize = 1;
        }

        private void btnExit_MouseLeave(object sender, EventArgs e) {
            btnExit.BackColor = Color.FromArgb(237, 234, 218);
            btnExit.ForeColor = Color.Black;
            btnExit.FlatAppearance.BorderSize = 0;
        }
        private void btnPopulate_MouseEnter(object sender, EventArgs e) {
            btnPopulate.FlatAppearance.MouseOverBackColor = btnPopulate.BackColor;
            btnPopulate.ForeColor = Color.Blue;
            btnPopulate.FlatAppearance.BorderColor = Color.Red;
            btnPopulate.FlatAppearance.BorderSize = 2;
        }

        private void btnPopulate_MouseLeave(object sender, EventArgs e) {
            btnPopulate.ForeColor = Color.Black;
            btnPopulate.FlatAppearance.BorderSize = 0;
        }
    }
}
