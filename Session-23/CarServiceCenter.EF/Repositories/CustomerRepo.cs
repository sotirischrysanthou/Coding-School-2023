using CarServiceCenter.Model;
using CarServiceCenter.EF.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCenter.EF.Repositories {
    public class CustomerRepo : IEntityRepo<Customer> {
        public void Add(Customer entity) {
            using var context = new CarServiceCenterDbContext();
            if (!EntityExists(entity)) {
                context.Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(int id) {
            using var context = new CarServiceCenterDbContext();
            var CustomerDb = context.Customers
                .Where(customer => customer.Id == id)
                .Include(customer => customer.Transactions)
                .SingleOrDefault();
            if (CustomerDb is null)
                return;
            context.Remove(CustomerDb);
            context.SaveChanges();
        }

        public bool EntityExists(Customer entity) {
            using var context = new CarServiceCenterDbContext();
            var CustomerDb = context.Customers
                .Where(customer => customer.Name == entity.Name
                && customer.Surname == entity.Surname
                && customer.Tin == entity.Tin
                && customer.Phone == entity.Phone)
                .Include(customer => customer.Transactions)
                .SingleOrDefault();
            if (CustomerDb is null) {
                var Customer1Db = context.Customers
                .Where(customer => customer.Id == entity.Id)
                .Include(customer => customer.Transactions)
                .SingleOrDefault();
                if (Customer1Db is null) {
                    return false;
                } else return true;
            } else return true;
        }

        public IList<Customer> GetAll() {
            using var context = new CarServiceCenterDbContext();
            return context.Customers
                .Include(customer => customer.Transactions)
                .ToList();
        }

        public Customer? GetById(int id) {
            using var context = new CarServiceCenterDbContext();
            return context.Customers
                .Where(customer => customer.Id == id)
                .Include(customer => customer.Transactions)
                .SingleOrDefault();
        }

        public void Update(int id, Customer entity) {
            using var context = new CarServiceCenterDbContext();
            var CustomerDb = context.Customers
                .Where(customer => customer.Id == id)
                .Include(customer => customer.Transactions)
                .SingleOrDefault();
            if (CustomerDb is null) return;
            CustomerDb.Name = entity.Name;
            CustomerDb.Surname = entity.Surname;
            CustomerDb.Phone = entity.Phone;
            CustomerDb.Tin = entity.Tin;
            context.SaveChanges();
        }
    }
}
