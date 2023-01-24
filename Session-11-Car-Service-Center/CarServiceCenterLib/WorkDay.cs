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

        public double WorkLoad() {
            double sumWorkHours = 0.0;
            foreach (ServiceTask serviceTask in ServiceTasks) {
                sumWorkHours = sumWorkHours + serviceTask.Hours;
            }
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

            //Initialize message variable
            message = "";

            //Check if task is over 8 hours
            if (task.Hours > 8) {
                message = "Task cannot be over 8 hours.";
                return false;
            }

            //Check if adding the task will exceed the MaxWorkLoad
            if (WorkLoad() + task.Hours > MaxWorkLoad()) {
                message = "Adding this task will exceed the maximum workload.";
                return false;
            }

            //If task is valid, add it to the list and update the WorkLoad
            ServiceTasks.Add(task);


            //Return success message
            message = "Task added successfully";
            return true;

        }
    }
}

