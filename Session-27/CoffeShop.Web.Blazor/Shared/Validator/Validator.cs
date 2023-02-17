using CoffeeShop.Model;
using CoffeeShop.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShop.Web.Blazor.Shared {
    public class Validator : IValidator{
        public readonly MinMax ManagersLimits;
        public readonly MinMax CashiersLimits;
        public readonly MinMax BaristasLimits;
        public readonly MinMax WaitersLimits;
        public readonly MinMax CustomersLimits;

        public Validator() {
            ManagersLimits = new MinMax() { Min = 1, Max = 1 };
            CashiersLimits = new MinMax() { Min = 1, Max = 2 };
            BaristasLimits = new MinMax() { Min = 1, Max = 2 };
            WaitersLimits = new MinMax() { Min = 1, Max = 3 };
            CustomersLimits = new MinMax() { Min = 1, Max = 1 };
        }
        public bool ValidateAddEmployee(EmployeeType type, List<Employee> employees, out String errorMessage) {
            errorMessage = "Succeed ";
            bool ret = true;
            var cashiers = employees.Where(e => e.EmployeeType == EmployeeType.Cashier);
            var baristas = employees.Where(e => e.EmployeeType == EmployeeType.Barista);
            var managers = employees.Where(e => e.EmployeeType == EmployeeType.Manager);
            var waiters = employees.Where(e => e.EmployeeType == EmployeeType.Waiter);
            if (type == EmployeeType.Manager && managers.Count() == ManagersLimits.Max) {
                ret = false;
                errorMessage = $"You have already {ManagersLimits.Max} Managers. Max number of managers is {ManagersLimits.Max}";
            }
            if (type == EmployeeType.Cashier && cashiers.Count() >= CashiersLimits.Max) {
                ret = false;
                errorMessage = $"You have already {CashiersLimits.Max} Cashiers. Max number of Cashiers is {CashiersLimits.Max}";
            }
            if (type == EmployeeType.Barista && baristas.Count() >= BaristasLimits.Max) {
                ret = false;
                errorMessage = $"You have already {BaristasLimits.Max} Baristas. Max number of Baristas is {BaristasLimits.Max}";
            }
            if (type == EmployeeType.Waiter && waiters.Count() >= WaitersLimits.Max) {
                ret = false;
                errorMessage = $"You have already {WaitersLimits.Max} Waiters. Max number of Waiters is {WaitersLimits.Max}";
            }
            return ret;
        }

        public bool ValidateUpdateEmployee(EmployeeType NewType, Employee dbEmployee, List<Employee> employees, out String errorMessage) {
            errorMessage = "Succeed ";
            bool ret = true;
            if (dbEmployee == null) {
                ret = false;
            } else if (NewType != dbEmployee.EmployeeType) {
                var cashiers = employees.Where(e => e.EmployeeType == EmployeeType.Cashier);
                var baristas = employees.Where(e => e.EmployeeType == EmployeeType.Barista);
                var managers = employees.Where(e => e.EmployeeType == EmployeeType.Manager);
                var waiters = employees.Where(e => e.EmployeeType == EmployeeType.Waiter);
                if (NewType == EmployeeType.Manager && managers.Count() >= ManagersLimits.Max) {
                    errorMessage = $"You have already {ManagersLimits.Max} Managers. Max number of managers is {ManagersLimits.Max}";
                    ret = false;
                }
                if (NewType == EmployeeType.Cashier && cashiers.Count() >= CashiersLimits.Max) {
                    errorMessage = $"You have already {CashiersLimits.Max} cashiers. Max number of cashiers is {CashiersLimits.Max}";
                    ret = false;
                }
                if (NewType == EmployeeType.Barista && baristas.Count() >= BaristasLimits.Max) {
                    errorMessage = $"You have already {BaristasLimits.Max} Baristas. Max number of Baristas is {BaristasLimits.Max}";
                    ret = false;
                }
                if (NewType == EmployeeType.Waiter && waiters.Count() >= WaitersLimits.Max) {
                    errorMessage = $"You have already {WaitersLimits.Max} Waiters. Max number of Waiters is {WaitersLimits.Max}";
                    ret = false;
                }
            }
            return ret;
        }

        public bool ValidateDeleteEmployee(EmployeeType type, List<Employee> employees, out String errorMessage) {
            bool ret = true;
            errorMessage = "Succeed ";
            var cashiers = employees.Where(e => e.EmployeeType == EmployeeType.Cashier);
            var baristas = employees.Where(e => e.EmployeeType == EmployeeType.Barista);
            var managers = employees.Where(e => e.EmployeeType == EmployeeType.Manager);
            var waiters = employees.Where(e => e.EmployeeType == EmployeeType.Waiter);
            if (type == EmployeeType.Manager && managers.Count() <= ManagersLimits.Min) {
                errorMessage = $"You have only {ManagersLimits.Min} Manager. Min number of Managers is {ManagersLimits.Min}";
                ret = false;
            }
            if (type == EmployeeType.Cashier && cashiers.Count() <= CashiersLimits.Min) {
                errorMessage = $"You have only {CashiersLimits.Min} Cashier. Min number of Cashiers is {CashiersLimits.Min}";
                ret = false;
            }
            if (type == EmployeeType.Barista && baristas.Count() <= BaristasLimits.Min) {
                errorMessage = $"You have only {BaristasLimits.Min} Barista. Min number of Baristas is {BaristasLimits.Min}";
                ret = false;
            }
            if (type == EmployeeType.Waiter && waiters.Count() <= WaitersLimits.Min) {
                errorMessage = $"You have only {WaitersLimits.Min} Waiter. Min number of Waiters is {WaitersLimits.Min}";

                ret = false;
            }

            return ret;
        }

        public bool ValidateAddCustomer(List<Customer> customers, out string errorMessage) {
            if(customers.Count >= CustomersLimits.Max) {
                errorMessage = $"You have already {CustomersLimits.Max} Customers. Max number of Customers is {CustomersLimits.Max}";
                return false;
            }
            errorMessage = "Succeed";
            return true;
        }

        public bool ValidateDeleteCustomer(List<Customer> customers, out string errorMessage) {
            errorMessage = "Succeed";
            if (customers.Count <= CustomersLimits.Min) {
                errorMessage = $"You have only {CustomersLimits.Min} Customers. Min number of Customers is {CustomersLimits.Min}";
                return false;
            }
            return true;
        }

        public bool ValidateTransaction(Transaction transaction, out string errorMessage) {
            errorMessage = "Succeed";
            throw new NotImplementedException();
        }
    }

    public struct MinMax {
        public int Min;
        public int Max;
    }
}
