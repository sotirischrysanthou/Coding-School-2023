using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CarServiceCenterLib.Models {
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
            //initialize all lists
            WorkDays = new List<WorkDay>();
            Engineers = new List<Engineer>();
            Managers = new List<Manager>();
            Customers = new List<Customer>();
            Transactions = new List<Transaction>();
            Cars = new List<Car>();
            ServiceTasks = new List<ServiceTask>();

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

        public void UpdateWorkDays() {
            foreach (WorkDay workDay in WorkDays) {
                workDay.UpdateNumOfEngineers(Engineers.Count());
            }
        }

        public void DeleteTask(TransactionLine task, DateTime date) {
            foreach (WorkDay workDay in WorkDays) {
                if (workDay.Date.Year == date.Year && workDay.Date.Month == date.Month && workDay.Date.Day == date.Day) {
                    workDay.DeleteTask(task);
                }
            }
        }

        public double SalaryEngineersFrom(int Year, int Month) {
            double TotalSalary = 0;
            foreach (Engineer engineer in Engineers) {
                if (((DateTime)engineer.StartDate).Year <= Year && ((DateTime)engineer.StartDate).Month <= Month) {
                    TotalSalary += engineer.SalaryPerMonth;
                }
            }
            return TotalSalary;
        }
        public double SalaryManagersFrom(int Year, int Month) {
            double TotalSalary = 0;
            foreach (Manager manager in Managers) {
                if (((DateTime)manager.StartDate).Year <= Year && ((DateTime)manager.StartDate).Month <= Month) {
                    TotalSalary += manager.SalaryPerMonth;
                }
            }
            return TotalSalary;
        }

        //public void addManagerProfile(Guid managerID, String username, String password) {
        //    foreach (Manager manager in Managers) {
        //        if(manager.ID == managerID) {
        //            manager.Username = username;
        //            manager.Password = password;
        //        }
        //    }
        //}

        public bool ManagerExists() {
            bool ret = true;
            if(Managers.Count == 0) {
                ret = false;
            }
            return ret;
        }

        //public bool LogIn(String username, String password) {
        //    bool ret = false;
        //    foreach(Manager manager in Managers) {
        //        if(manager.Username == username && manager.Password == password) {
        //            ret = true;
        //        }
        //    }
        //    return ret;
        //}


    }
}
