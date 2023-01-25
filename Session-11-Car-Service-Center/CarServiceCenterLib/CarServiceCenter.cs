using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CarServiceCenterLib {
    public class CarServiceCenter {
        // Properties
        public List<WorkDay> WorkDays { get; set; }
        public List<Engineer> Engineers { get; set; }
        public List<Manager> Managers { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Transaction> Transactions { get; set; }
        public List<Car> Cars { get; set; }
        public List<ServiceTask> ServiceTasks { get; set; }
        public List<MonthlyLedger> MonthlyLedgers { get; set; }

        // Constructors
        public CarServiceCenter() {
            //initialize all lists
            WorkDays = new List<WorkDay>();
            Engineers = new List<Engineer>();
            Managers = new List<Manager>();
            Customers = new List<Customer>();
            Transactions = new List<Transaction>();
            Cars = new List<Car>();
            ServiceTasks = new List<ServiceTask>();
            MonthlyLedgers = new List<MonthlyLedger>();
        }

        // Methods
        public bool AddTask(TransactionLine task, DateTime date, out String message) {
            //find from Workday list WorkDay.date==date
            //WorkDay.Add(task, message);
            bool ret = false;
            bool workDayExists = false;
            String msg = "";
            foreach (WorkDay workDay in WorkDays) {
                if (workDay.Date.Year == date.Year && workDay.Date.Month == date.Month && workDay.Date.Day == date.Day) {
                    ret = workDay.AddTask(task, out msg);
                    workDayExists = true;
                }
            }
            if (!workDayExists) {
                WorkDays.Add(new WorkDay(new DateTime(date.Year, date.Month, date.Day), Engineers.Count));
                ret = WorkDays.Last().AddTask(task, out msg);
            }
            message = msg;
            return ret;
        }

        public double SalaryEngineersFrom(int Year, int Month) {
            double TotalSalary = 0;
            foreach (Engineer engineer in Engineers) {
                if (engineer.StartDate.Year <= Year && engineer.StartDate.Month <= Month) {
                    TotalSalary += engineer.SalaryPerMonth;
                }
            }
            return TotalSalary;
        }
        public double SalaryManagersFrom(int Year, int Month) {
            double TotalSalary = 0;
            foreach (Manager manager in Managers) {
                if (manager.StartDate.Year <= Year && manager.StartDate.Month <= Month) {
                    TotalSalary += manager.SalaryPerMonth;
                }
            }
            return TotalSalary;
        }

        public void UpdateMonthlyLedger(DateTime FromDate, double Salary) {
            foreach (MonthlyLedger monthlyLedger in MonthlyLedgers) {
                if (monthlyLedger.Year >= FromDate.Year && monthlyLedger.Month >= FromDate.Month) {
                    monthlyLedger.UpdateExpenses(Salary);
                }
            }
        }

        public List<MonthlyLedger> BookKeepingFromTo(DateTime from, DateTime to) {
            double incomes = 0;
            List<MonthlyLedger> bookKeeping = new List<MonthlyLedger>();
            foreach (MonthlyLedger monthlyLedger in MonthlyLedgers) {
                if (monthlyLedger.Year >= from.Year && monthlyLedger.Month >= from.Month && monthlyLedger.Year <= to.Year && monthlyLedger.Month <= to.Month) {
                    foreach (Transaction transaction in Transactions) {
                        if (transaction.Date.Year == monthlyLedger.Year && transaction.Date.Month == monthlyLedger.Month) {
                            incomes += transaction.TotalPrice;
                        }
                    }
                    monthlyLedger.UpdateIncomes(incomes);
                    bookKeeping.Add(monthlyLedger);
                }
            }
            return bookKeeping;
        }


    }
}
