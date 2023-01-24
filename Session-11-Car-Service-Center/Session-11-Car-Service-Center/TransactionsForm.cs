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
        }

        private void SetControlProperties() {
            bsTransactions.DataSource = _carServiceCenter.Transactions;
            grdTransactions.DataSource = bsTransactions;
            grdTransactionLines.DataSource = bsTransactions;
            grdTransactionLines.DataMember = "TransactionLines";
        }

        private void btnSave_Click(object sender, EventArgs e) {
            _serializer.SerializeToFile(_carServiceCenter,"CarServiceCenter.json");
        }
    }
}