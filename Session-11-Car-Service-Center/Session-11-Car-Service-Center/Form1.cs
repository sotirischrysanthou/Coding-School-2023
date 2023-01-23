using CarServiceCenterLib;
using SerializerLib;

namespace Session_11_Car_Service_Center {
    public partial class Form1 : Form {
        // Properties
        private Serializer _serializer;
        private List<Customer> _customers;
        private List<Manager> _managers;
        private List<Engineer> _engineers;
        private List<Car> _cars;
        private List<Transaction> _transactions;
        private List<ServiceTask> _serviceTasks;

        // Constructors
        public Form1() {
            InitializeComponent();
            _serializer = new Serializer();
            _customers = new List<Customer>();
            _cars = new List<Car>();
            _managers = new List<Manager>();
            _engineers = new List<Engineer>();
            _transactions = new List<Transaction>();
            _serviceTasks = new List<ServiceTask>();
        }

        // Methods
        private void Form1_Load(object sender, EventArgs e) {
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
            _customers.Add(new Customer("Sotiris", "Chrysanthou", "6954872136", "1303"));
            _customers.Add(new Customer("Demetris", "Manolas", "6912342136", "5585"));
            _customers.Add(new Customer("Giannis", "Tsimpris", "6912341234", "1234"));
            _cars.Add(new Car("Ford", "Focus", "IZM 5469"));
            _cars.Add(new Car("Ford", "Fiesta", "IMZ 1234"));
            _cars.Add(new Car("Mazda", "6", "IAM 3369"));
            _managers.Add(new Manager("Fotis", "Chrysoulas", 15000));
            _engineers.Add(new Engineer("Demetris", "Raptodimos", _managers[0].ID, 10000));

            _serviceTasks.Add(new ServiceTask(1, "alagi ladiou", 15.0));
            _serviceTasks.Add(new ServiceTask(2, "geniko service", 1.0));
            _serviceTasks.Add(new ServiceTask(3, "alagi elastikou", 5.0));
            _serviceTasks.Add(new ServiceTask(4, "alagi flatzas", 5.0));
            _serviceTasks.Add(new ServiceTask(5, "filtro ladiou", 7.0));


            _transactions.Add(new Transaction(_customers[0].ID, _cars[0].ID, _managers[0].ID));
            _transactions[0].AddTransactionLine(new TransactionLine(_transactions[0].ID, _serviceTasks[0].ID, _engineers[0].ID, _serviceTasks[0].Hours, 44.5));
            _transactions[0].AddTransactionLine(new TransactionLine(_transactions[0].ID, _serviceTasks[1].ID, _engineers[0].ID, _serviceTasks[1].Hours, 44.5));
            _transactions.Add(new Transaction(_customers[1].ID, _cars[1].ID, _managers[0].ID));
            _transactions[1].AddTransactionLine(new TransactionLine(_transactions[1].ID, _serviceTasks[2].ID, _engineers[0].ID, _serviceTasks[2].Hours, 44.5));
            _transactions[1].AddTransactionLine(new TransactionLine(_transactions[1].ID, _serviceTasks[3].ID, _engineers[0].ID, _serviceTasks[3].Hours, 44.5));

            bsTransactions.DataSource = _transactions;
            bsTransactionLines.DataSource = bsTransactions;
            bsTransactionLines.DataMember = "TransactionLines";
        }
    }
}