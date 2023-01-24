using CarServiceCenterLib;
using SerializerLib;

namespace Session_11_Car_Service_Center {
    public partial class Transactions : Form {
        // Properties
        //private List<Customer> _customers;
        //private List<Manager> _managers;
        //private List<Engineer> _engineers;
        //private List<Car> _cars;
        //private List<Transaction> _transactions;
        //private List<ServiceTask> _serviceTasks;
        private Serializer _serializer;
        private CarServiceCenter _carServiceCenter;

        // Constructors
        public Transactions(CarServiceCenter carServiceCenter) {
            InitializeComponent();
            _serializer = new Serializer();
            _carServiceCenter = carServiceCenter;
            //_customers = new List<Customer>();
            //_cars = new List<Car>();
            //_managers = new List<Manager>();
            //_engineers = new List<Engineer>();
            //_transactions = new List<Transaction>();
            //_serviceTasks = new List<ServiceTask>();
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


            _carServiceCenter.Transactions.Add(new Transaction(_carServiceCenter.Customers[0].ID, _carServiceCenter.Cars[0].ID, _carServiceCenter.Managers[0].ID));
            _carServiceCenter.Transactions[0].AddTransactionLine(new TransactionLine(_carServiceCenter.Transactions[0].ID, _carServiceCenter.ServiceTasks[0].ID, _carServiceCenter.Engineers[0].ID, _carServiceCenter.ServiceTasks[0].Hours, 44.5));
            _carServiceCenter.Transactions[0].AddTransactionLine(new TransactionLine(_carServiceCenter.Transactions[0].ID, _carServiceCenter.ServiceTasks[1].ID, _carServiceCenter.Engineers[0].ID, _carServiceCenter.ServiceTasks[1].Hours, 44.5));
            _carServiceCenter.Transactions.Add(new Transaction(_carServiceCenter.Customers[1].ID, _carServiceCenter.Cars[1].ID, _carServiceCenter.Managers[0].ID));
            _carServiceCenter.Transactions[1].AddTransactionLine(new TransactionLine(_carServiceCenter.Transactions[1].ID, _carServiceCenter.ServiceTasks[2].ID, _carServiceCenter.Engineers[0].ID, _carServiceCenter.ServiceTasks[2].Hours, 44.5));
            _carServiceCenter.Transactions[1].AddTransactionLine(new TransactionLine(_carServiceCenter.Transactions[1].ID, _carServiceCenter.ServiceTasks[3].ID, _carServiceCenter.Engineers[0].ID, _carServiceCenter.ServiceTasks[3].Hours, 44.5));

            bsTransactions.DataSource = _carServiceCenter.Transactions;
            bsTransactionLines.DataSource = bsTransactions;
            bsTransactionLines.DataMember = "TransactionLines";
        }
    }
}