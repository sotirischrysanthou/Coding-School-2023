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
            _carServiceCenter.Customers.Add(new Customer("Giannis", "Tsimpris", "6912341234", "1234"));
            _carServiceCenter.Cars.Add(new Car("Ford", "Focus", "IZM 5469"));
            _carServiceCenter.Cars.Add(new Car("Ford", "Fiesta", "IMZ 1234"));
            _carServiceCenter.Cars.Add(new Car("Mazda", "6", "IAM 3369"));
            _carServiceCenter.Managers.Add(new Manager("Fotis", "Chrysoulas", 15000));
            _carServiceCenter.Engineers.Add(new Engineer("Demetris", "Raptodimos", _carServiceCenter.Managers[0].ID, 10000));

            _carServiceCenter.ServiceTasks.Add(new ServiceTask(1, "alagi ladiou", 15.0));
            _carServiceCenter.ServiceTasks.Add(new ServiceTask(2, "geniko service", 1.0));
            _carServiceCenter.ServiceTasks.Add(new ServiceTask(3, "alagi elastikou", 5.0));
            _carServiceCenter.ServiceTasks.Add(new ServiceTask(4, "alagi flatzas", 5.0));
            _carServiceCenter.ServiceTasks.Add(new ServiceTask(5, "filtro ladiou", 7.0));

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
            customer = _carServiceCenter.Customers[1];
            car = _carServiceCenter.Cars[1];
            _carServiceCenter.Transactions.Add(new Transaction(customer.ID, car.ID, manager.ID));
            transaction = _carServiceCenter.Transactions[1];
            serviceTask = _carServiceCenter.ServiceTasks[2];
            transaction.AddTransactionLine(new TransactionLine(transaction.ID, serviceTask.ID, engineer.ID, serviceTask.Hours, 44.5));
            serviceTask = _carServiceCenter.ServiceTasks[3];
            transaction.AddTransactionLine(new TransactionLine(transaction.ID, serviceTask.ID, engineer.ID, serviceTask.Hours, 44.5));
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
    }
}
