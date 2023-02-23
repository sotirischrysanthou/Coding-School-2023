using FuelStation.EF.Context;
using FuelStation.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.EF.Repository {
    public class CustomerRepo : IEntityRepo<Customer> {
        public async Task Add(Customer entity) {
            using var context = new FuelStationDbContext();
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task Delete(Guid id) {
            using var context = new FuelStationDbContext();
            var dbCustomer = context.Customers
                .Where(c => c.Id == id)
                .SingleOrDefault();
            if (dbCustomer == null) {
                throw new Exception($"Customer with id: {id} not found");
            }
            context.Remove(dbCustomer);
            await context.SaveChangesAsync();
        }

        public async Task<IList<Customer>> GetAll() {
            using var context = new FuelStationDbContext();
            return await context.Customers
                .Include(c => c.Transactions).ThenInclude(t => t.Employee)
                .Include(c => c.Transactions).ThenInclude(t => t.TransactionLines)
                .OrderBy(c => c.CardNumber)
                .ToListAsync();
        }

        public async Task<Customer?> GetById(Guid id) {
            using var context = new FuelStationDbContext();
            return await context.Customers
                .Where(c => c.Id == id)
                .Include(c => c.Transactions).ThenInclude(t => t.Employee)
                .Include(c => c.Transactions).ThenInclude(t => t.TransactionLines)
                .SingleOrDefaultAsync();
        }

        public async Task Update(Guid id, Customer entity) {
            using var context = new FuelStationDbContext();
            var dbCustomer = await context.Customers.Where(customer => customer.Id == id).SingleOrDefaultAsync();
            if (dbCustomer is null)
                throw new Exception($"Customer with id: {id} not found");
            dbCustomer.Name = entity.Name;
            dbCustomer.Surname = entity.Surname;
            dbCustomer.CardNumber = entity.CardNumber;
            await context.SaveChangesAsync();
        }
    }
}
