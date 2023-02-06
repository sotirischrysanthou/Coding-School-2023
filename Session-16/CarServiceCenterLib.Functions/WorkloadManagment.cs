using CarServiceCenterLib.Models;
using CarServiceCenterLib.Orm.Repositories;

namespace CarServiceCenterLib.Functions {
    public class WorkloadManagment {

        public List<WorkDay> _workDays;

        public WorkloadManagment() {
            _workDays = new List<WorkDay>();
        }

        public String UpdateLabelWorkHour(Transaction transaction) {
            TransactionRepo transactionRepo = new TransactionRepo();
            String retString = "";
            foreach (WorkDay workDay in _workDays) {
                if (workDay.Date.Year == transaction.Date.Year && workDay.Date.Month == transaction.Date.Month && workDay.Date.Day == transaction.Date.Day) {
                    retString = (workDay.MaxWorkLoad() - workDay.WorkLoad()).ToString();
                }
            }
            return retString;
        }

        public void CalculateWorkDays() {
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
    }
}