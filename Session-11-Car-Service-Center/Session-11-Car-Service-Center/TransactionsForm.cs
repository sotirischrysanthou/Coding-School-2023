using CarServiceCenterLib;
using DevExpress.XtraGrid.Views.Grid;
using SerializerLib;

namespace Session_11_Car_Service_Center {
    public partial class TransactionsForm : Form {
        // Properties
        private Serializer _serializer;
        private CarServiceCenter _carServiceCenter;

        // Constructors
        public TransactionsForm(CarServiceCenter carServiceCenter) {
            InitializeComponent();
            _serializer = new Serializer();
            _carServiceCenter = carServiceCenter;
        }

        // Methods
        private void TransactionsForm_Load(object sender, EventArgs e) {
            SetControlProperties();
            Populate();
        }

        private void SetControlProperties() {

            _serializer = new Serializer();
            dgvTransactions.AutoGenerateColumns = false;
            dgvTransactionLines.AutoGenerateColumns = false;
            dgvTransactions.DataSource = bsTransactions;
            dgvTransactionLines.DataSource = bsTransactionLines;
            grdTransactions.DataSource = bsTransactions;
        }

        private void Populate() {
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

            bsTransactions.DataSource = _carServiceCenter.Transactions;
            bsTransactionLines.DataSource = bsTransactions;
            bsTransactionLines.DataMember = "TransactionLines";
        }
    }
}