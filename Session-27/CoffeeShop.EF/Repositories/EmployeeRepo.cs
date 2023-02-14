using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShop.EF.Context;
using CoffeeShop.Model;

namespace CoffeeShop.EF.Repositories
{
    public class EmployeeRepo : IEntityRepo<Employee>
    {
        public void Add(Employee entity)
        {
            using var context = new CoffeeShopDbContext();
            context.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            using var context = new CoffeeShopDbContext();
            var dbCoffeShop = context.Employees.Where(employee => employee.Id == id).SingleOrDefault();
            if (dbCoffeShop is null)
                return;
            context.Remove(dbCoffeShop);
            context.SaveChanges();
        }

        public IList<Employee> GetAll()
        {
            using var context = new CoffeeShopDbContext();
            return context.Employees.ToList();
        }

        public Employee? GetById(int id)
        {
            using var context = new CoffeeShopDbContext();
            return context.Employees.Where(employee => employee.Id == id).SingleOrDefault();
        }

        public void Update(int id, Employee entity)
        {
            using var context = new CoffeeShopDbContext();
            var dbCoffeShop = context.Employees.Where(employee => employee.Id == id).SingleOrDefault();
            if (dbCoffeShop is null)
                return;
            dbCoffeShop.Name = entity.Name;
            dbCoffeShop.Surname = entity.Surname;
            dbCoffeShop.SalaryPerMonth = entity.SalaryPerMonth;
            dbCoffeShop.EmployeeType = entity.EmployeeType;
            context.SaveChanges();
        }
    }
}
