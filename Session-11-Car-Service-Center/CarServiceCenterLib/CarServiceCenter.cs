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

        // Constructors
        public CarServiceCenter() {
            WorkDays = new List<WorkDay>();
            Engineers = new List<Engineer>();
            Managers = new List<Manager>();
            Customers = new List<Customer>();
            Transactions = new List<Transaction>();
            Cars = new List<Car>();
            ServiceTasks = new List<ServiceTask>();

            //initialize all lists, done(correct??)
        }
        public bool AddTask(ServiceTask task, DateTime date, out String message) {
            //find from Workday list WorkDay.date==date
            //WorkDay.Add(task, message);
            bool ret = false;
            bool workDayExists = false;
            String msg = "";
            foreach (WorkDay workDay in WorkDays) {
                if (workDay.Date == date) {
                    ret = workDay.AddTask(task, out msg);
                    workDayExists = true;
                }
            }
            if (!workDayExists) {
                WorkDays.Add(new WorkDay(date, Engineers.Count));
                ret = WorkDays.Last().AddTask(task, out msg);
            }
            message = msg;
            return ret;
        }

        public double FromToEngineers(DateTime FromDate) {
            double TotalSalary = 0;
            foreach (Engineer engineer in Engineers) {
                if (engineer.StartDate < FromDate) {
                    TotalSalary += engineer.SalaryPerMonth;
                }
            }
            return TotalSalary;
        }
        public double FromToManagers(DateTime FromDate) {
            double TotalSalary = 0;
            foreach (Manager manager in Managers) {
                if (manager.StartDate < FromDate) {
                    TotalSalary += manager.SalaryPerMonth;
                }
            }
            return TotalSalary;
        }


    }
}
