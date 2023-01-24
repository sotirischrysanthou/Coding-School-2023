using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCenterLib {
    public class WorkDay {
        public DateTime Date { get; set; }
        public List<ServiceTask> ServiceTasks { get; set; }
        public int NumOfEngineers { get; set; }
        private double _workload { get; set; }


        public double WorkLoad() {
            double sumWorkHours = 0.0;
            foreach (ServiceTask serviceTask in ServiceTasks) {
                sumWorkHours = sumWorkHours + serviceTask.Hours;
            }
            _workload = sumWorkHours;
            return sumWorkHours;
        }
        public double MaxWorkLoad() {
            return NumOfEngineers * 8;
        }

        public int UpdateNumOfEngineers(int Engineers) {
            NumOfEngineers = Engineers;
            return NumOfEngineers;
        }
        public bool AddTask(ServiceTask task, out String message) {
            //task cannot be over 8 hours
            //(WorkLoad + task.Hours) cannot be > than MaxWorkLoad

            bool ret = false;
            //Check if task is less than 8 hours
            if (task.Hours < 8) {
                //Check if adding the task will not exceed the MaxWorkLoad
                if (WorkLoad() + task.Hours < MaxWorkLoad()) {
                    //If task is valid, add it to the list and update the WorkLoad
                    ServiceTasks.Add(task);
                    message = "Task added successfully";
                    _workload += task.Hours;
                    ret = true;
                } else {
                    message = "Adding this task will exceed the maximum workload.";
                    ret = false;
                }
            } else {
                message = "Task cannot be over 8 hours.";
                ret = false;
            }
            return ret;
        }
    }
}

