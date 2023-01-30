using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCenterLib.Models {
    public class WorkDay {
        public DateTime Date { get; set; }
        public List<TransactionLine> Tasks { get; set; }
        public int NumOfEngineers { get; set; }
        private double _workload { get; set; }

        // Constructor
        public WorkDay(DateTime date, int numofEngineers) {
            Date = date;
            NumOfEngineers = numofEngineers;
            Tasks = new List<TransactionLine>();
        }

        public double WorkLoad() {
            double sumWorkHours = 0.0;
            foreach (TransactionLine task in Tasks) {
                sumWorkHours = sumWorkHours + task.Hours;
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
        public bool AddTask(TransactionLine task, out String message) {
            //task cannot be over 8 hours
            //(WorkLoad + task.Hours) cannot be > than MaxWorkLoad

            bool ret = false;
            //Check if task is less than 8 hours
            if (task.Hours <= 8) {
                //Check if adding the task will not exceed the MaxWorkLoad
                if (WorkLoad() + task.Hours <= MaxWorkLoad()) {
                    //If task is valid, add it to the list and update the WorkLoad
                    Tasks.Add(task);
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

        public void DeleteTask(TransactionLine task) {
            Tasks.Remove(task);
        }
    }
}

