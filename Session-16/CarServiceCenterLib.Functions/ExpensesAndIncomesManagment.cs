using CarServiceCenterLib.Models;
using CarServiceCenterLib.Orm.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCenterLib.Functions {
    public class ExpensesAndIncomesManagment {
        public double SalaryEngineersFrom(int Year, int Month) {
            double TotalSalary = 0;
            EngineerRepo engineerRepo = new EngineerRepo();
            List<Engineer> engineers = engineerRepo.GetAll().ToList();
            DateTime date = new DateTime(Year, Month, DateTime.DaysInMonth(Year, Month));
            foreach (Engineer engineer in engineers) {
                if (((DateTime)engineer.StartDate) <= date) {
                    TotalSalary += engineer.SalaryPerMonth;
                }
            }
            return TotalSalary;
        }
        public double SalaryManagersFrom(int Year, int Month) {
            double TotalSalary = 0;
            ManagerRepo managerRepo = new ManagerRepo();
            List<Manager> managers = managerRepo.GetAll().ToList();
            DateTime date = new DateTime(Year, Month, DateTime.DaysInMonth(Year, Month));
            foreach (Manager manager in managers) {
                if (((DateTime)manager.StartDate) <= date) {
                    TotalSalary += manager.SalaryPerMonth;
                }
            }
            return TotalSalary;
        }

        public double CalculateIncomes(int Year, int Month) {
            double retValue = 0;
            TransactionRepo transactionRepo = new TransactionRepo();
            List<Transaction> transactions = transactionRepo.GetAll().ToList();
            foreach (Transaction transaction in transactions) {
                if (transaction.Date.Year == Year && transaction.Date.Month == Month) {
                    retValue += transaction.TotalPrice;
                }
            }
            return retValue;
        }
    }
}
