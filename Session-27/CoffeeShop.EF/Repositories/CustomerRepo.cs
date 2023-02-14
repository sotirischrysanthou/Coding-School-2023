using CoffeeShop.EF.Context;
using CoffeeShop.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.EF.Repositories {
    public class CustomerRepo : IEntityRepo<Customer> {
        public void Add(Customer entity) {
            using var context = new CoffeeShopDbContext();
            context.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id) {
            using var context = new CoffeeShopDbContext();
            var dbCustomer = context.Customers.Where(customer => customer.Id == id).SingleOrDefault();
            if (dbCustomer is null)
                return;
            context.Remove(dbCustomer);
            context.SaveChanges();
        }

        public IList<Customer> GetAll() {
            using var context = new CoffeeShopDbContext();
            return context.Customers
                .Include(customer => customer.Transactions).ToList();
        }

        public Customer? GetById(int id) {
            using var context = new CoffeeShopDbContext();
            return context.Customers.Where(customer => customer.Id == id)
                .Include(customer => customer.Transactions).SingleOrDefault();
        }

        public void Update(int id, Customer entity) {
            using var context = new CoffeeShopDbContext();
            var dbCustomer = context.Customers.Where(customer => customer.Id == id).SingleOrDefault();
            if (dbCustomer is null)
                return;
            dbCustomer.Code = entity.Code;
            dbCustomer.Description = entity.Description;
            dbCustomer.Transactions = entity.Transactions;
            context.SaveChanges();
        }
    }
}
