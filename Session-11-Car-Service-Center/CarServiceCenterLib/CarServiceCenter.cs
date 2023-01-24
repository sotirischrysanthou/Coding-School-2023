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

        // Constractors
        public CarServiceCenter() {
            List<WorkDay> WorkDays = new List<WorkDay>();
            List<Engineer> Engineers = new List<Engineer>();
            List<Manager> Managers = new List<Manager>();
            List<Customer> Customers = new List<Customer>();
            List<Transaction> Transactions = new List<Transaction>();
            List<Car> Cars = new List<Car>();

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
                WorkDays.Add(new WorkDay());
                WorkDays.Last().UpdateNumOfEngineers(Engineers.Count);
                ret = WorkDays.Last().AddTask(task, out msg);
            }
            message = msg;
            return ret;
        }


    }
}
