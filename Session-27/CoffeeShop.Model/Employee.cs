using CoffeeShop.Model.Enums;

namespace CoffeeShop.Model
{
    public class Employee
    {
        public Employee(String name, String surname, int salaryPerMonth, EmployeeType employeeType)
        {
            Name = name;
            Surname = surname;
            SalaryPerMonth = salaryPerMonth;
            EmployeeType = employeeType;
            Transactions = new List<Transaction>();
        }

        public int Id { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public int SalaryPerMonth { get; set; }
        public EmployeeType EmployeeType { get; set; }

        // Relations
        public List<Transaction> Transactions { get; set; }
    }
}
