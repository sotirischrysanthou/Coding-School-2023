using FuelStation.Model.Enums;
using FuelStation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuelStation.Web.Blazor.Shared;

namespace FuelStation.Web.Blazor.Shared {
    public interface IValidator {
        bool ValidateAddEmployee(EmployeeEditDto employee, List<Employee> employees, out String errorMessage);
        bool ValidateUpdateEmployee(EmployeeEditDto employee, Employee dbEmployee, List<Employee> employees, out String errorMessage);
        bool ValidateDeleteEmployee(EmployeeType type, List<Employee> employees, out String errorMessage);
        bool ValidateAddCustomer(List<Customer> customers, CustomerEditDto newCustomer, out String cardNumber, out String errorMessage);
        bool ValidateUpdateCustomer(CustomerEditDto newCustomer, out String errorMessage);
        bool ValidateDeleteCustomer(Customer customer, out String errorMessage);
        bool ValidateAddItem(List<Item> items, ItemEditDto newItem, out String errorMessage);
        bool ValidateUpdateItem(List<Item> items, Item oldItem, ItemEditDto newItem, out String errorMessage);
        bool ValidateDeleteItem(Item item, out String errorMessage);
        bool ValidateTransaction(Transaction transaction, out String errorMessage);
    }
}
