using CarServiceCenterLib.Models;
using CarServiceCenterLib.Orm.Repositories;
using DevExpress.Mvvm.Native;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraScheduler.Native;
using SerializerLib;

namespace Session_16.Win {
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
            TransactionRepo transactionRepo = new TransactionRepo();
            TransactionLineRepo transactionLineRepo = new TransactionLineRepo();
            CustomerRepo customerRepo = new CustomerRepo();
            CarRepo carRepo = new CarRepo();
            ManagerRepo managerRepo = new ManagerRepo();
            EngineerRepo engineerRepo = new EngineerRepo();
            ServiceTaskRepo serviceTaskRepo = new ServiceTaskRepo();
            bsTransactions.DataSource = transactionRepo.GetAll(); //_carServiceCenter.Transactions;
            grdTransactions.DataSource = bsTransactions;
            grdTransactionLines.DataSource = bsTransactions;
            grdTransactionLines.DataMember = "TransactionLines";


            SetLookUpEdit<Customer>(repCustomerName, customerRepo.GetAll().ToList(), "Name", "ID");
            SetLookUpEdit<Customer>(repCustomerSurname, customerRepo.GetAll().ToList(), "Surname", "ID");
            SetLookUpEdit<Car>(repCarBrand, carRepo.GetAll().ToList(), "Brand", "ID");
            SetLookUpEdit<Car>(repCarModel, carRepo.GetAll().ToList(), "Model", "ID");
            SetLookUpEdit<Manager>(repManagerName, managerRepo.GetAll().ToList(), "Name", "ID");
            SetLookUpEdit<Manager>(repManagerSurname, managerRepo.GetAll().ToList(), "Surname", "ID");
            SetLookUpEdit<Engineer>(repEngineersName, engineerRepo.GetAll().ToList(), "Name", "ID");
            SetLookUpEdit<Engineer>(repEngineersSurname, engineerRepo.GetAll().ToList(), "Surname", "ID");
            SetLookUpEdit<ServiceTask>(repServiceTasksDescription, serviceTaskRepo.GetAll().ToList(), "Description", "ID");
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
                if (_carServiceCenter.AddTask(transactionLine, transaction.Date, out message)) {
                    transaction.UpdateTotalPrice();
                    gridView1.RefreshData();
                } else {
                    view.DeleteRow(e.RowHandle);
                }
                UpdateLabelWorkHour();
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

        //Customize Buttons
        private void btnSave_MouseEnter(object sender, EventArgs e) {
            btnSave.FlatAppearance.MouseOverBackColor = btnSave.BackColor;
            btnSave.ForeColor = Color.Blue;
            btnSave.FlatAppearance.BorderColor = Color.Red;
            btnSave.FlatAppearance.BorderSize = 2;
        }

        private void btnSave_MouseLeave(object sender, EventArgs e) {
            btnSave.ForeColor = Color.Black;
            btnSave.FlatAppearance.BorderColor = Color.Black;
            btnSave.FlatAppearance.BorderSize = 2;
        }

        private void btn_Close_MouseEnter(object sender, EventArgs e) {
            btn_Close.FlatAppearance.MouseOverBackColor = btn_Close.BackColor;
            btn_Close.ForeColor = Color.Blue;
            btn_Close.FlatAppearance.BorderColor = Color.Red;
            btn_Close.FlatAppearance.BorderSize = 2;
        }

        private void btn_Close_MouseLeave(object sender, EventArgs e) {
            btn_Close.ForeColor = Color.Black;
            btn_Close.FlatAppearance.BorderColor = Color.Black;
            btn_Close.FlatAppearance.BorderSize = 2;
        }

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e) {
            UpdateLabelWorkHour();
        }
        private void UpdateLabelWorkHour() {
            Transaction transaction = FindTransactionWithID((Guid)gridView1.GetFocusedRowCellValue("ID"), _carServiceCenter.Transactions);
            foreach (WorkDay workDay in _carServiceCenter.WorkDays) {
                if (workDay.Date.Year == transaction.Date.Year && workDay.Date.Month == transaction.Date.Month && workDay.Date.Day == transaction.Date.Day) {
                    labelWorkHours.Text = (workDay.MaxWorkLoad() - workDay.WorkLoad()).ToString();
                }
            }
        }

        private void gridView2_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e) {
            UpdateLabelWorkHour();
        }
    }
}