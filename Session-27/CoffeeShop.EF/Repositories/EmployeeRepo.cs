using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShop.EF.Context;
using CoffeeShop.Model;
using Microsoft.EntityFrameworkCore;

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
            return context.Employees.Include(transactions => transactions.Transactions).ToList();
        }

        public Employee? GetById(int id)
        {
            using var context = new CoffeeShopDbContext();
            return context.Employees.Where(employee => employee.Id == id)
                .Include(transactions => transactions.Transactions)
                .SingleOrDefault();
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
