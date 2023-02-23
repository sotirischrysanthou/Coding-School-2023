using FuelStation.Model.Enums;
using FuelStation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuelStation.Web.Blazor.Shared;

namespace CoffeShop.Web.Blazor.Shared {
    public interface IValidator {
        bool ValidateAddEmployee(EmployeeType type, List<Employee> employees, out String errorMessage);
        bool ValidateDeleteEmployee(EmployeeType type, List<Employee> employees, out String errorMessage);
        bool ValidateUpdateEmployee(EmployeeType NewType, Employee dbEmployee, List<Employee> employees, out String errorMessage);
        bool ValidateAddCustomer(List<Customer> customers, out String errorMessage);
        bool ValidateUpdateCustomer(List<Customer> customers,Customer oldCustomer, CustomerEditDto newCustomer, out String errorMessage);
        bool ValidateDeleteCustomer(List<Customer> customers, out String errorMessage);
        bool ValidateAddItem(List<Item> Items, out String errorMessage);
        bool ValidateUpdateItem(List<Item> Items, Item oldItem, ItemEditDto newItem, out String errorMessage);
        bool ValidateDeleteItem(List<Item> Items, out String errorMessage);
        bool ValidateTransaction(Transaction transaction, out String errorMessage);
    }
}
