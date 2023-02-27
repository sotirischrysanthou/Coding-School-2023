using FuelStation.Model;
using FuelStation.Model.Enums;
using FuelStation.Web.Blazor.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Web.Blazor.Shared {
    public class Validator : IValidator {
        public readonly MinMax ManagersLimits;
        public readonly MinMax CashiersLimits;
        public readonly MinMax StaffLimits;
        public readonly MinMax NameLimits;

        public Validator() {
            ManagersLimits = new MinMax() { Min = 1, Max = 3 };
            CashiersLimits = new MinMax() { Min = 1, Max = 4 };
            StaffLimits = new MinMax() { Min = 1, Max = 10 };
            NameLimits = new MinMax() { Min = 1, Max = 20 };
        }
        public bool ValidateAddEmployee(EmployeeEditDto employee, List<Employee> employees, out String errorMessage) {
            if (!ValidateNameAndSurname(employee.Name, employee.Surname, out errorMessage)) return false;
            if (!ValidateAddEmployeeByEmployeeType(employee.EmployeeType, employees, out errorMessage)) return false;
            return true;
        }

        public bool ValidateUpdateEmployee(EmployeeEditDto employee, Employee dbEmployee, List<Employee> employees, out String errorMessage) {
            if (!ValidateNameAndSurname(employee.Name, employee.Surname, out errorMessage)) return false;
            EmployeeType newType = employee.EmployeeType;
            if (newType != dbEmployee.EmployeeType) {
                if (!ValidateAddEmployeeByEmployeeType(newType, employees, out errorMessage)) return false;
            }
            return true;
        }

        //private bool ValidateAddOrUpdateAccount()

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

        public bool ValidateAddOrUpdadteAccount(AccountDto newAccount, List<Account> accounts, out String errorMessage) {
            bool ret = true;
            errorMessage = "Succeed ";
            foreach (Account account in accounts) {
                if (account.Id != newAccount.Id && account.Username == newAccount.Username) {
                    ret = false;
                    errorMessage = $"Username {account.Username} is already exist";
                }
            }
            return ret;
        }

        public bool ValidateDeleteAccount(out String errorMessage) {
            bool ret = true;
            errorMessage = "Succeed ";
            return ret;
        }

        public bool ValidateAddCustomer(List<Customer> customers, CustomerEditDto newCustomer, out String cardNumber, out String errorMessage) {
            bool ret = ValidateNameAndSurname(newCustomer.Name, newCustomer.Surname, out errorMessage);
            cardNumber = String.Empty;
            if (!ret) {
                return ret;
            }
            int startPos = customers.Count - 1;
            cardNumber = GenarateCardNumber(customers);
            return ret;
        }
        public bool ValidateUpdateCustomer(CustomerEditDto newCustomer, out String errorMessage) {
            return ValidateNameAndSurname(newCustomer.Name, newCustomer.Surname, out errorMessage);
        }

        public bool ValidateDeleteCustomer(Customer customer, out String errorMessage) {
            return ValidateDeleteCustomerOrEmployee("Customer", customer, out errorMessage);
        }

        public bool ValidateAddItem(List<Item> items, ItemEditDto newItem, out String errorMessage) {
            return ValidateAddOrUpdateItem(items, newItem, out errorMessage);
        }

        public bool ValidateUpdateItem(List<Item> items, Item oldItem, ItemEditDto newItem, out String errorMessage) {
            return ValidateAddOrUpdateItem(items, newItem, out errorMessage);
        }


        public bool ValidateDeleteItem(Item item, out String errorMessage) {
            errorMessage = "Succeed";
            bool ret = true;
            if (item.TransactionLines.Count > 0) {
                errorMessage = $"Can not delete Item with transactions";
                ret = false;
            }
            return ret;
        }
        public bool ValidateDeleteTransaction(Transaction? transaction, out String errorMessage) {
            if(transaction!=null&&transaction.TransactionLines.Count>0) {
                errorMessage = "Can not delete Transactions with transaction lines";
            }
            errorMessage = "Succeed";
            return true;
        }



        // shared functions

        private string GenarateCardNumber(List<Customer> customers) {
            int max = 0;
            foreach (Customer customer in customers) {
                int number = Int32.Parse(customer.CardNumber.Substring(1));
                if (number > max) {
                    max = number;
                }
            }
            return $"A{max + 1}";

            //int startPos = customers.Count - 1;
            //for (int i = customers.Count + 1; i > 0; i--) {
            //    for (int j = startPos; j >= 0; j--) {
            //        int number = Int32.Parse(customers[j].CardNumber.Substring(1));
            //        if (number == i) {
            //            break;
            //        }
            //        startPos--;
            //    }
            //    if (startPos < 0) {
            //        return $"A{i}";
            //    }
            //}
            //return String.Empty;
        }

        private bool ValidateAddEmployeeByEmployeeType(EmployeeType type, List<Employee> employees, out String errorMessage) {
            bool ret = true;
            errorMessage = "Succeed";
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

        private bool ValidateNameAndSurname(String name, String surname, out String errorMessage) {
            errorMessage = "Succeed";
            bool ret = true;
            if (name.Length < NameLimits.Min || name.Length > NameLimits.Max) {
                errorMessage = "Name must have lenght between 1 and 20 characters";
                ret = false;
            }
            else if (surname.Length < NameLimits.Min || surname.Length > NameLimits.Max) {
                errorMessage = "Surname must have lenght between 1 and 20 characters";
                ret = false;
            }
            return ret;
        }
        private bool ValidateAddOrUpdateItem(List<Item> items, ItemEditDto newItem, out String errorMessage) {
            errorMessage = "Succeed";
            bool ret = true;
            foreach (Item item in items) {
                if (item.Id != newItem.Id && item.Code == newItem.Code) {
                    errorMessage = $"Code must be unique among the items.\n" +
                                   $"Code {item.Code} is already taken by another item\n\n" +
                                   $"Suggestions:\n" +
                                   $"------------\n" +
                                   $"   1. Select another Code\n" +
                                   $"   2. Edit first the item with code {item.Code}\n" +
                                   $"      and the add a new with this code";
                    ret = false;
                }
                if (item.Id != newItem.Id && item.ItemType == newItem.ItemType && item.Description == newItem.Description) {
                    errorMessage = $"The same object exists in the database with\n" +
                                   $"Item Type:     {item.ItemType}\n" +
                                   $"Description:   {item.Description}\n" +
                                   $"Code:          {item.Code}\n" +
                                   $"Price:         {item.Price}\n" +
                                   $"Cost:          {item.Cost}";
                    ret = false;
                }
            }
            return ret;
        }
        private bool ValidateDeleteCustomerOrEmployee(String type, Person person, out String errorMessage) {
            errorMessage = "Succeed";
            bool ret = true;
            if (person.Transactions.Count > 0) {
                errorMessage = $"Can not delete {type} with transactions";
                ret = false;
            }
            return ret;
        }
    }

    public struct MinMax {
        public int Min;
        public int Max;
    }
}
