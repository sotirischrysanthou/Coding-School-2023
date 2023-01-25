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
        }

        public List<TransactionLine> ReturnAllTransactionLines() {
            List<TransactionLine> transactionLines = new List<TransactionLine>();
            foreach (Transaction transaction in _carServiceCenter.Transactions) {
                transactionLines = transactionLines.Concat(transaction.TransactionLines).ToList();
            }
            return transactionLines;
        }

        private void btnSave_Click(object sender, EventArgs e) {
            _serializer.SerializeToFile(_carServiceCenter, "CarServiceCenter.json");
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

        private void gridView2_InitNewRow(object sender, InitNewRowEventArgs e) {
            GridView view = sender as GridView;
            view.SetRowCellValue(e.RowHandle, "TransactionID", gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "ID"));
        }
        private void gridView2_RowDeleting(object sender, DevExpress.Data.RowDeletingEventArgs e) {
            GridView view = sender as GridView;
            Transaction transaction = FindTransactionWithID((Guid)gridView1.GetFocusedRowCellValue("ID"), _carServiceCenter.Transactions);
            TransactionLine transactionLine = FindTransactionLineWithID((Guid)gridView2.GetFocusedRowCellValue("ID"), transaction.TransactionLines);
            _carServiceCenter.DeleteTask(transactionLine, transaction.Date);
        }

        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e) {
            GridView view = sender as GridView;
            if (e.Column.Caption != "Sevice Task Description") return;
            ServiceTask serviceTask = FindServiceTaskWithID((Guid)e.Value, _carServiceCenter.ServiceTasks);
            if (serviceTask != null) {
                view.SetRowCellValue(e.RowHandle, "Hours", serviceTask.Hours);
                view.SetRowCellValue(e.RowHandle, "PricePerHour", 44.5); // PRICE PER HOUR
                view.SetRowCellValue(e.RowHandle, "Price", serviceTask.Hours * 44.5); // PRICE PER HOUR
                Transaction transaction = FindTransactionWithID((Guid)gridView1.GetFocusedRowCellValue("ID"), _carServiceCenter.Transactions);
                TransactionLine transactionLine = FindTransactionLineWithID((Guid)gridView2.GetFocusedRowCellValue("ID"), transaction.TransactionLines);
                String message; 
                if(_carServiceCenter.AddTask(transactionLine,transaction.Date, out message)){
                    transaction.UpdateTotalPrice();
                    gridView1.RefreshData();
                } else {
                    view.DeleteRow(e.RowHandle);
                }

                MessageBox.Show(message);
            }
        }

        private ServiceTask FindServiceTaskWithID(Guid serviceID, List<ServiceTask> serviceTasks) {
            ServiceTask retServiceTask = null;
            foreach (ServiceTask serviceTask in _carServiceCenter.ServiceTasks) {
                if (serviceTask.ID == serviceID) {
                    retServiceTask = serviceTask;
                    break;
                }
            }
            return retServiceTask;
        }
        private Transaction FindTransactionWithID(Guid transactionID, List<Transaction> transactions) {
            Transaction RetTransaction = null;

            foreach (Transaction transaction in _carServiceCenter.Transactions) {
                if (transaction.ID == transactionID) {
                    RetTransaction = transaction;
                    break;
                }
            }
            return RetTransaction;
        }

        private TransactionLine FindTransactionLineWithID(Guid transactionLineID, List<TransactionLine> transactionsLines) {
            TransactionLine RetTransactionLine = null;

            foreach (TransactionLine transactionLine in transactionsLines) {
                if (transactionLine.ID == transactionLineID) {
                    RetTransactionLine = transactionLine;
                    break;
                }
            }
            return RetTransactionLine;
        }

    }
}