using FuelStation.Model;
using FuelStation.Model.Enums;
using FuelStation.Web.Blazor.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShop.Web.Blazor.Shared {
    public class Validator : IValidator{
        public readonly MinMax ManagersLimits;
        public readonly MinMax CashiersLimits;
        public readonly MinMax StaffLimits;

        public Validator() {
            ManagersLimits = new MinMax() { Min = 1, Max = 3 };
            CashiersLimits = new MinMax() { Min = 1, Max = 4 };
            StaffLimits = new MinMax() { Min = 1, Max = 10 };
        }
        public bool ValidateAddEmployee(EmployeeType type, List<Employee> employees, out String errorMessage) {
            errorMessage = "Succeed ";
            bool ret = true;
            var cashiers = employees.Where(e => e.EmployeeType == EmployeeType.Cashier);
            var staff = employees.Where(e => e.EmployeeType == EmployeeType.Staff);
            var managers = employees.Where(e => e.EmployeeType == EmployeeType.Manager);
            if (type == EmployeeType.Manager && managers.Count() == ManagersLimits.Max) {
                ret = false;
                errorMessage = $"You have already {ManagersLimits.Max} Managers. Max number of managers is {ManagersLimits.Max}";
            }
            if (type == EmployeeType.Cashier && cashiers.Count() >= CashiersLimits.Max) {
                ret = false;
                errorMessage = $"You have already {CashiersLimits.Max} Cashiers. Max number of Cashiers is {CashiersLimits.Max}";
            }
            if (type == EmployeeType.Staff && staff.Count() >= StaffLimits.Max) {
                ret = false;
                errorMessage = $"You have already {StaffLimits.Max} Staff. Max number of Staff is {StaffLimits.Max}";
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
                var staff = employees.Where(e => e.EmployeeType == EmployeeType.Staff);
                var managers = employees.Where(e => e.EmployeeType == EmployeeType.Manager);
                if (NewType == EmployeeType.Manager && managers.Count() >= ManagersLimits.Max) {
                    errorMessage = $"You have already {ManagersLimits.Max} Managers. Max number of managers is {ManagersLimits.Max}";
                    ret = false;
                }
                if (NewType == EmployeeType.Cashier && cashiers.Count() >= CashiersLimits.Max) {
                    errorMessage = $"You have already {CashiersLimits.Max} cashiers. Max number of cashiers is {CashiersLimits.Max}";
                    ret = false;
                }
                if (NewType == EmployeeType.Staff && staff.Count() >= StaffLimits.Max) {
                    errorMessage = $"You have already {StaffLimits.Max} Staff. Max number of Staff is {StaffLimits.Max}";
                    ret = false;
                }
            }
            return ret;
        }

        public bool ValidateDeleteEmployee(EmployeeType type, List<Employee> employees, out String errorMessage) {
            bool ret = true;
            errorMessage = "Succeed ";
            var cashiers = employees.Where(e => e.EmployeeType == EmployeeType.Cashier);
            var staff = employees.Where(e => e.EmployeeType == EmployeeType.Staff);
            var managers = employees.Where(e => e.EmployeeType == EmployeeType.Manager);
            if (type == EmployeeType.Manager && managers.Count() <= ManagersLimits.Min) {
                errorMessage = $"You have only {ManagersLimits.Min} Manager. Min number of Managers is {ManagersLimits.Min}";
                ret = false;
            }
            if (type == EmployeeType.Cashier && cashiers.Count() <= CashiersLimits.Min) {
                errorMessage = $"You have only {CashiersLimits.Min} Cashier. Min number of Cashiers is {CashiersLimits.Min}";
                ret = false;
            }
            if (type == EmployeeType.Staff && staff.Count() <= StaffLimits.Min) {
                errorMessage = $"You have only {StaffLimits.Min} Staff. Min number of Staff is {StaffLimits.Min}";
                ret = false;
            }

            return ret;
        }

        public bool ValidateAddCustomer(List<Customer> customers, out string errorMessage) {
            errorMessage = "Succeed";
            return true;
        }
        public bool ValidateUpdateCustomer(List<Customer> customers, Customer oldCustomer, CustomerEditDto newCustomer, out string errorMessage) {
            errorMessage = "Succeed";
            return true;
        }

        public bool ValidateDeleteCustomer(List<Customer> customers, out string errorMessage) {
            errorMessage = "Succeed";
            return true;
        }

        public bool ValidateTransaction(Transaction transaction, out string errorMessage) {
            errorMessage = "Succeed";
            return true;
        }

        public bool ValidateAddItem(List<Item> Items, out string errorMessage) {
            errorMessage = "Succeed";
            return true;
        }

        public bool ValidateUpdateItem(List<Item> Items, Item oldItem, ItemEditDto newItem, out string errorMessage) {
            errorMessage = "Succeed";
            return true;
        }

        public bool ValidateDeleteItem(List<Item> Items, out string errorMessage) {
            errorMessage = "Succeed";
            return true;
        }
    }

    public struct MinMax {
        public int Min;
        public int Max;
    }
}
