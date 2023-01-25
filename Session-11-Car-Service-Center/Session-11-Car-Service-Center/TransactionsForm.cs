using CarServiceCenterLib;
using DevExpress.XtraEditors.Repository;
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
        }

        private void SetControlProperties() {
            bsTransactions.DataSource = _carServiceCenter.Transactions;
            grdTransactions.DataSource = bsTransactions;
            grdTransactionLines.DataSource = bsTransactions;
            grdTransactionLines.DataMember = "TransactionLines";


            SetLookUpEdit<Customer>(repCustomerName, _carServiceCenter.Customers, "Name", "ID");
            SetLookUpEdit<Customer>(repCustomerSurname, _carServiceCenter.Customers, "Surname", "ID");
            SetLookUpEdit<Car>(repCarBrand, _carServiceCenter.Cars, "Brand", "ID");
            SetLookUpEdit<Car>(repCarModel, _carServiceCenter.Cars, "Model", "ID");
            SetLookUpEdit<Manager>(repManagerName, _carServiceCenter.Managers, "Name", "ID");
            SetLookUpEdit<Manager>(repManagerSurname, _carServiceCenter.Managers, "Surname", "ID");
            SetLookUpEdit<Engineer>(repEngineersName, _carServiceCenter.Engineers, "Name", "ID");
            SetLookUpEdit<Engineer>(repEngineersSurname, _carServiceCenter.Engineers, "Surname", "ID");
            SetLookUpEdit<ServiceTask>(repServiceTasksDescription, _carServiceCenter.ServiceTasks, "Description", "ID");
            //SetLookUpEdit<TransactionLine>(repTransactionLineHours, _carServiceCenter.Transactions, "Hours", "ID");
            //SetLookUpEdit<ServiceTask>(repTransactionLinePricePerHour, _carServiceCenter.ServiceTasks, "PricePerHour", "ID");
            //SetLookUpEdit<ServiceTask>(repTransactionLinelPrice, _carServiceCenter.ServiceTasks, "Price", "ID");
        }



        private void btnSave_Click(object sender, EventArgs e) {
            _serializer.SerializeToFile(_carServiceCenter,"CarServiceCenter.json");
            DevExpress.XtraEditors.XtraMessageBox.Show("Saved!");

        }

        private void SetLookUpEdit<T>(RepositoryItemLookUpEdit rep, List<T> list, String displayMember, String valueMember) {
            rep.DataSource = list;
            rep.DisplayMember = displayMember;
            rep.ValueMember = valueMember;
        }

        private void btn_Close_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}