using CarServiceCenterLib;
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

namespace Session_11_Car_Service_Center {
    public partial class MainMenuForm : Form {
        private CarServiceCenter _carServiceCenter;
        private Serializer _serializer;

        public MainMenuForm() {
            InitializeComponent();
            _carServiceCenter = new CarServiceCenter();
            _serializer = new Serializer();
        }
        private void MainMenuForm_Load(object sender, EventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {
            TransactionsForm transactionsForm = new TransactionsForm(_carServiceCenter);
            transactionsForm.ShowDialog(); // Shows _transactionsForm
        }


        private void btnCustomerAndCars_Click(object sender, EventArgs e) {
            CustomersAndCarsForm customersAndCarsForm = new CustomersAndCarsForm(_carServiceCenter);
            customersAndCarsForm.ShowDialog(); // Shows _customerAndCarsForm
        }

        private void Populate(CarServiceCenter _carServiceCenter) {
            _carServiceCenter.Customers.Add(new Customer("Sotiris", "Chrysanthou", "6954872136", "1303"));
            _carServiceCenter.Customers.Add(new Customer("Demetris", "Manolas", "6912342136", "5585"));
            _carServiceCenter.Customers.Add(new Customer("Giannis", "Tsimpris", "6912341234", "1365"));
            _carServiceCenter.Customers.Add(new Customer("Giannis", "Antetokoumpo", "6910646234", "2576"));
            _carServiceCenter.Customers.Add(new Customer("Panos", "Ioannides", "6912334867", "6453"));
            _carServiceCenter.Cars.Add(new Car("Ford", "Focus", "IZM 5469"));
            _carServiceCenter.Cars.Add(new Car("Ford", "Fiesta", "IMZ 1234"));
            _carServiceCenter.Cars.Add(new Car("Mazda", "6", "IAM 3369"));
            _carServiceCenter.Cars.Add(new Car("Suzuki", "Swift", "IAM 8888"));
            _carServiceCenter.Managers.Add(new Manager("Fotis", "Chrysoulas", 15000, DateTime.Parse("21/1/2023")));
            _carServiceCenter.Managers.Add(new Manager("Giannis", "Ioannou", 10000, DateTime.Parse("15/3/2023")));
            _carServiceCenter.Managers.Add(new Manager("Fotis", "Mitsou", 8000, DateTime.Parse("21/2/2023")));
            _carServiceCenter.Managers.Add(new Manager("Sotiris", "Kontizas", 8000, DateTime.Parse("21/2/2023")));
            _carServiceCenter.Engineers.Add(new Engineer("Demetris", "Raptodimos", _carServiceCenter.Managers[0].ID, 1000, DateTime.Parse("2/2/2023")));
            _carServiceCenter.Engineers.Add(new Engineer("Kostas", "Kostaki", _carServiceCenter.Managers[0].ID, 1500, DateTime.Parse("2/1/2023")));
            _carServiceCenter.Engineers.Add(new Engineer("Kostis", "Marvelias", _carServiceCenter.Managers[0].ID, 800, DateTime.Parse("2/3/2023")));

            _carServiceCenter.ServiceTasks.Add(new ServiceTask(1, "Air Filter", 2.0));
            _carServiceCenter.ServiceTasks.Add(new ServiceTask(2, "General service", 8.0));
            _carServiceCenter.ServiceTasks.Add(new ServiceTask(3, "Tire change", 3.0));
            _carServiceCenter.ServiceTasks.Add(new ServiceTask(4, "Change gasket", 6.0));
            _carServiceCenter.ServiceTasks.Add(new ServiceTask(5, "Oil Filter", 4.0));
            _carServiceCenter.ServiceTasks.Add(new ServiceTask(5, "Spark plug", 5.0));
            _carServiceCenter.ServiceTasks.Add(new ServiceTask(5, "Oil Filter", 7.0));

            Customer customer = _carServiceCenter.Customers[0];
            Car car = _carServiceCenter.Cars[0];
            Manager manager = _carServiceCenter.Managers[0];
            ServiceTask serviceTask = _carServiceCenter.ServiceTasks[0];
            Engineer engineer = _carServiceCenter.Engineers[0];
            _carServiceCenter.Transactions.Add(new Transaction(customer.ID, car.ID, manager.ID));
            Transaction transaction = _carServiceCenter.Transactions[0];
            transaction.AddTransactionLine(new TransactionLine(transaction.ID, serviceTask.ID, engineer.ID, serviceTask.Hours, 44.5));
            serviceTask = _carServiceCenter.ServiceTasks[1];
            transaction.AddTransactionLine(new TransactionLine(transaction.ID, serviceTask.ID, engineer.ID, serviceTask.Hours, 44.5));
            foreach (TransactionLine transactionLine in transaction.TransactionLines) {
                _carServiceCenter.AddTask(transactionLine, transaction.Date, out _);
            }
            customer = _carServiceCenter.Customers[1];
            car = _carServiceCenter.Cars[1];
            _carServiceCenter.Transactions.Add(new Transaction(customer.ID, car.ID, manager.ID));
            transaction = _carServiceCenter.Transactions[1];
            serviceTask = _carServiceCenter.ServiceTasks[2];
            transaction.AddTransactionLine(new TransactionLine(transaction.ID, serviceTask.ID, engineer.ID, serviceTask.Hours, 44.5));
            serviceTask = _carServiceCenter.ServiceTasks[3];
            transaction.AddTransactionLine(new TransactionLine(transaction.ID, serviceTask.ID, engineer.ID, serviceTask.Hours, 44.5));
            foreach (TransactionLine transactionLine in transaction.TransactionLines) {
                _carServiceCenter.AddTask(transactionLine, transaction.Date, out _);
            }
        }

        private void btnPopulate_Click(object sender, EventArgs e) {
            Populate(_carServiceCenter);
            DevExpress.XtraEditors.XtraMessageBox.Show("Populate Successful!");
        }

        private void btnServiceTasks_Click(object sender, EventArgs e) {
            ServiceTasksForm serviceTasksForm = new ServiceTasksForm(_carServiceCenter);
            serviceTasksForm.ShowDialog();  // shows _ServiceTasksForm
        }

        private void btnEmployees_Click(object sender, EventArgs e) {
            EmployeesForm employeesForm = new EmployeesForm(_carServiceCenter); 
            employeesForm.ShowDialog();
        }


        private void btn_MonthlyLedger_Click(object sender, EventArgs e) {
            MonthlyLedgerForm monthlyLedgerForm = new MonthlyLedgerForm(_carServiceCenter);
            monthlyLedgerForm.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e) {
            _serializer.SerializeToFile(_carServiceCenter, "CarServiceCenter.json");
            DevExpress.XtraEditors.XtraMessageBox.Show("Saved!");
        }

        private void btnLoad_Click(object sender, EventArgs e) {
            if (File.Exists("CarServiceCenter.json")) {
                _carServiceCenter = _serializer.Deserialize<CarServiceCenter>("CarServiceCenter.json");
                DevExpress.XtraEditors.XtraMessageBox.Show("Load Successful!");
            }
            else {
                DevExpress.XtraEditors.XtraMessageBox.Show("File Not Found!");
            }
           
        }   

        private void btnTransactions_Click(object sender, EventArgs e) {
            TransactionsForm transactionsForm = new TransactionsForm(_carServiceCenter);
            transactionsForm.ShowDialog(); // Shows _transactionsForm
        }

        private void btnCustomerAndCars_Click_1(object sender, EventArgs e) {
            CustomersAndCarsForm customersAndCarsForm = new CustomersAndCarsForm(_carServiceCenter);
            customersAndCarsForm.ShowDialog(); // Shows _customerAndCarsForm
        }

        private void btnServiceTasks_Click_1(object sender, EventArgs e) {
            ServiceTasksForm serviceTasksForm = new ServiceTasksForm(_carServiceCenter);
            serviceTasksForm.ShowDialog();  // shows _ServiceTasksForm
        }

        private void btnEmployees_Click_1(object sender, EventArgs e) {
            EmployeesForm employeesForm = new EmployeesForm(_carServiceCenter);
            employeesForm.ShowDialog();
        }

        private void btn_MonthlyLedger_Click_1(object sender, EventArgs e) {
            MonthlyLedgerForm monthlyLedgerForm = new MonthlyLedgerForm(_carServiceCenter);
            monthlyLedgerForm.ShowDialog();
        }

        private void panelMenu_Paint(object sender, PaintEventArgs e) {

        }

        private void button1_Click_1(object sender, EventArgs e) {
            this.Close();
        }

        //Customize Buttons
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

        private void btnSave_MouseEnter(object sender, EventArgs e) {
            btnSave.FlatAppearance.MouseOverBackColor = btnSave.BackColor;
            btnSave.ForeColor = Color.Blue;
            btnSave.FlatAppearance.BorderColor = Color.Red;
            btnSave.FlatAppearance.BorderSize = 2;
        }

        private void btnSave_MouseLeave(object sender, EventArgs e) {
            btnSave.ForeColor = Color.Black;
            btnSave.FlatAppearance.BorderSize = 0;
        }

        private void btnLoad_MouseEnter(object sender, EventArgs e) {
            btnLoad.FlatAppearance.MouseOverBackColor = btnLoad.BackColor;
            btnLoad.ForeColor = Color.Blue;
            btnLoad.FlatAppearance.BorderColor = Color.Red;
            btnLoad.FlatAppearance.BorderSize = 2;
        }

        private void btnLoad_MouseLeave(object sender, EventArgs e) {
            btnLoad.ForeColor = Color.Black;
            btnLoad.FlatAppearance.BorderSize = 0;
        }

 
    }
}
