using CarServiceCenterLib.Models;
using CarServiceCenterLib.Orm.Repositories;
using DevExpress.Mvvm.Native;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraScheduler.Native;
using SerializerLib;
using System.Reflection.Emit;

namespace Session_16.Win {
    public partial class TransactionsForm : Form {
        // Properties
        private List<WorkDay> _workDays;

        // Constructors
        public TransactionsForm() {
            InitializeComponent();
            _workDays = new List<WorkDay>();
        }

        // Methods
        // Initial Methods-----------------------------------------------------------------------------------------------------
        private void TransactionsForm_Load(object sender, EventArgs e) {
            CalculateWorkDays();
            SetControlProperties();
        }

        private void CalculateWorkDays() {
            TransactionLineRepo transactionLineRepo = new TransactionLineRepo();
            List<TransactionLine> transactionLines = transactionLineRepo.GetAll().ToList();
            foreach (TransactionLine transactionLine in transactionLines) {
                AddTask(transactionLine, transactionLine.Transaction.Date, out _);
            }
            UpdateWorkDays();
        }

        public bool AddTask(TransactionLine task, DateTime date, out String message) {
            //find from Workday list WorkDay.date==date
            //WorkDay.Add(task, message);
            EngineerRepo engineerRepo = new EngineerRepo();
            bool ret = false;
            bool workDayExists = false;
            String msg = "";
            foreach (WorkDay workDay in _workDays) {
                if (workDay.Date.Year == date.Year && workDay.Date.Month == date.Month && workDay.Date.Day == date.Day) {
                    ret = workDay.AddTask(task, out msg);
                    workDayExists = true;
                }
            }
            if (!workDayExists) {
                _workDays.Add(new WorkDay(new DateTime(date.Year, date.Month, date.Day), engineerRepo.GetAll().Count));
                ret = _workDays.Last().AddTask(task, out msg);
            }
            message = msg;
            return ret;
        }

        private void SetControlProperties() {
            TransactionRepo transactionRepo = new TransactionRepo();
            TransactionLineRepo transactionLineRepo = new TransactionLineRepo();
            CustomerRepo customerRepo = new CustomerRepo();
            CarRepo carRepo = new CarRepo();
            ManagerRepo managerRepo = new ManagerRepo();
            EngineerRepo engineerRepo = new EngineerRepo();
            ServiceTaskRepo serviceTaskRepo = new ServiceTaskRepo();
            bsTransactions.DataSource = transactionRepo.GetAll();
            grdTransactions.DataSource = bsTransactions;
            bsTransactionLines.DataSource = bsTransactions;
            bsTransactionLines.DataMember = "TransactionLines";
            grdTransactionLines.DataSource = bsTransactionLines;

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

        private void SetLookUpEdit<T>(RepositoryItemLookUpEdit rep, List<T> list, String displayMember, String valueMember) {
            rep.DataSource = list;
            rep.DisplayMember = displayMember;
            rep.ValueMember = valueMember;
        }


        //--------------------------------------------------------------------------------------
        // -----------------------------grvTransaction Events-----------------------------------
        //--------------------------------------------------------------------------------------
        private void grvTransactions_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e) {
            TransactionRepo transactionRepo = new TransactionRepo();
            GridView view = sender as GridView;
            Guid id = (Guid)view.GetRowCellValue(view.FocusedRowHandle, colID);
            Guid customerID = (Guid)view.GetRowCellValue(e.RowHandle, colCustomerName);
            Guid managerID = (Guid)view.GetRowCellValue(e.RowHandle, colManagerName);
            Guid carID = (Guid)view.GetRowCellValue(e.RowHandle, colCarBrand);
            if (carID == Guid.Empty) {
                e.Valid = false;
                view.SetColumnError(colCarBrand, "Insert Valid Car");
                view.SetColumnError(colCarModel, "Insert Valid Car");
            }
            if (customerID == Guid.Empty) {
                e.Valid = false;
                view.SetColumnError(colCustomerName, "Insert Valid Custmer Name");
                view.SetColumnError(colCustomerSurname, "Insert Valid Custmer Surname");
            }
            if (managerID == Guid.Empty) {
                e.Valid = false;
                view.SetColumnError(colManagerName, "Insert Valid Managerer Name");
                view.SetColumnError(colManagerSurname, "Insert Valid Managerer Name");
            }
            if (e.Valid) {
                view.ClearColumnErrors();
                Transaction transaction = (Transaction)bsTransactions.Current;
                if (transactionRepo.GetById(id) is null) {
                    transactionRepo.Add(transaction);
                } else {
                    transactionRepo.Update(id, transaction);
                }
            }
        }

        private void grvTransactions_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e) {
            GridView view = sender as GridView;
            GridColumn column = (e as EditFormValidateEditorEventArgs)?.Column ?? view.FocusedColumn;
            if (column.FieldName == "CarID") {
                Guid id = (Guid)e.Value;
                if (id == Guid.Empty) {
                    e.Valid = false;
                    view.SetColumnError(colCarBrand, "Insert Valid Car");
                    view.SetColumnError(colCarModel, "Insert Valid Car");
                }
            }
            if (column.FieldName == "CustomerID") {
                Guid id = (Guid)e.Value;
                if (id == Guid.Empty) {
                    e.Valid = false;
                    view.SetColumnError(colCustomerName, "Insert Valid Custmer Name");
                    view.SetColumnError(colCustomerSurname, "Insert Valid Custmer Surname");
                }
            }
            if (column.FieldName == "ManagerID") {
                Guid id = (Guid)e.Value;
                if (id == Guid.Empty) {
                    e.Valid = false;
                    view.SetColumnError(colManagerName, "Insert Valid Managerer Name");
                    view.SetColumnError(colManagerSurname, "Insert Valid Managerer Name");
                }
            }
        }

        private void grvTransactions_RowDeleting(object sender, DevExpress.Data.RowDeletingEventArgs e) {
            GridView view = sender as GridView;
            TransactionRepo transactionRepo = new TransactionRepo();
            Guid id = Guid.Parse(view.GetRowCellValue(view.FocusedRowHandle, colID).ToString());
            transactionRepo.Delete(id);
        }

        private void grvTransactions_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e) {
            GridView view = sender as GridView;
            Guid id = (Guid)view.GetRowCellValue(view.FocusedRowHandle, colCustomerName);
            if (id != Guid.Empty) {
                UpdateWorkDays();
                UpdateLabelWorkHour();
            }
        }
        //--------------------------------------------------------------------------------------
        // ------------------------grvTransactionLines Events-----------------------------------
        //--------------------------------------------------------------------------------------
        private void grvTransactionLines_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e) {
            GridView view = sender as GridView;
            ServiceTaskRepo serviceTaskRepo = new ServiceTaskRepo();
            if (e.Column.Caption != "Sevice Task Description") return;
            ServiceTask serviceTask = serviceTaskRepo.GetById((Guid)e.Value);
            if (serviceTask != null) {
                view.SetRowCellValue(e.RowHandle, "Hours", serviceTask.Hours);
                view.SetRowCellValue(e.RowHandle, "PricePerHour", 44.5); // PRICE PER HOUR
                view.SetRowCellValue(e.RowHandle, "Price", serviceTask.Hours * 44.5); // PRICE PER HOUR
                Transaction transaction = (Transaction)bsTransactions.Current;
                TransactionLine transactionLine = (TransactionLine)bsTransactionLines.Current;
                String message;
                if (AddTask(transactionLine, transaction.Date, out message)) {
                    transaction.UpdateTotalPrice();
                    grvTransactions.RefreshData();
                } else {
                    view.DeleteRow(e.RowHandle);
                }
                UpdateLabelWorkHour();
                MessageBox.Show(message);
            }
        }

        private void grvTransactionLines_InitNewRow(object sender, InitNewRowEventArgs e) {
            GridView view = sender as GridView;
            view.SetRowCellValue(e.RowHandle, "TransactionID", grvTransactions.GetRowCellValue(grvTransactions.GetSelectedRows()[0], "ID"));
        }
        private void gridView2_RowDeleting(object sender, DevExpress.Data.RowDeletingEventArgs e) {
            GridView view = sender as GridView;
            TransactionLineRepo transactionLineRepo = new TransactionLineRepo();
            Transaction transaction = (Transaction)bsTransactions.Current;
            TransactionLine transactionLine = (TransactionLine)bsTransactionLines.Current;
            DeleteTask(transactionLine, transaction.Date);
            transactionLineRepo.Delete(transactionLine.ID);

        }

        
        private void btn_Close_Click(object sender, EventArgs e) {
            this.Close();
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

        
        private void UpdateLabelWorkHour() {
            TransactionRepo transactionRepo = new TransactionRepo();
            Guid id = (Guid)grvTransactions.GetFocusedRowCellValue("ID");
            Transaction transaction = transactionRepo.GetById(id);
            foreach (WorkDay workDay in _workDays) {
                if (workDay.Date.Year == transaction.Date.Year && workDay.Date.Month == transaction.Date.Month && workDay.Date.Day == transaction.Date.Day) {
                    labelWorkHours.Text = (workDay.MaxWorkLoad() - workDay.WorkLoad()).ToString();
                }
            }
        }

        private void gridView2_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e) {
            UpdateWorkDays();
            UpdateLabelWorkHour();
        }

        public void DeleteTask(TransactionLine task, DateTime date) {
            foreach (WorkDay workDay in _workDays) {
                if (workDay.Date.Year == date.Year && workDay.Date.Month == date.Month && workDay.Date.Day == date.Day) {
                    workDay.DeleteTask(task);
                }
            }
        }

        public void UpdateWorkDays() {
            EngineerRepo engineerRepo = new EngineerRepo();
            foreach (WorkDay workDay in _workDays) {
                workDay.UpdateNumOfEngineers(engineerRepo.GetAll().Count());
            }
        }

        private void gridView2_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e) {
            TransactionRepo transactionRepo = new TransactionRepo();
            TransactionLineRepo transactionLineRepo = new TransactionLineRepo();
            GridView view = sender as GridView;
            Guid id = (Guid)view.GetRowCellValue(view.FocusedRowHandle, colLineID);
            Guid serviceTaskID = (Guid)view.GetRowCellValue(e.RowHandle, colServiceTaskDescription);
            Guid engineerID = (Guid)view.GetRowCellValue(e.RowHandle, colEngineerName);
            if (engineerID == Guid.Empty || engineerID.ToString() == "") {
                e.Valid = false;
                view.SetColumnError(colEngineerName, "Insert Valid Engineer");
                view.SetColumnError(colEngineerSurname, "Insert Valid Engineer");
            }
            if (serviceTaskID == Guid.Empty || serviceTaskID.ToString() == "") {
                e.Valid = false;
                view.SetColumnError(colServiceTaskDescription, "Insert Valid ServiceTask");
            }
            if (e.Valid) {
                view.ClearColumnErrors();
                TransactionLine transactionLine = (TransactionLine)bsTransactionLines.Current;
                Transaction transaction = (Transaction)bsTransactions.Current;
                if (transactionLineRepo.GetById(id) is null) {
                    transactionLineRepo.Add(transactionLine);
                } else {
                    transactionLineRepo.Update(id, transactionLine);
                }
                transactionRepo.Update(transactionLine.TransactionID, transaction);
            }
        }

        private void gridView2_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e) {
            GridView view = sender as GridView;
            GridColumn column = (e as EditFormValidateEditorEventArgs)?.Column ?? view.FocusedColumn;
            Guid id = (Guid)e.Value;
            if (column.FieldName == "EngineerID") {
                if (id == Guid.Empty) {
                    e.Valid = false;
                    view.SetColumnError(colEngineerName, "Insert Valid Engineer");
                    view.SetColumnError(colEngineerSurname, "Insert Valid Engineer");
                }
            } else {
                if (id == Guid.Empty) {
                    e.Valid = false;
                    view.SetColumnError(colServiceTaskDescription, "Insert Valid ServiceTask");
                }
            }
        }

        private void grvTransactionLines_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e) {

        }
    }
}