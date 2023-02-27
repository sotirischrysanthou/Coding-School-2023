using FuelStation.EF.Context;
using FuelStation.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.EF.Repository {
    public class TransactionRepo : IEntityRepo<Transaction> {
        public async Task Add(Transaction entity) {
            using var context = new FuelStationDbContext();
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task Delete(Guid id) {
            using var context = new FuelStationDbContext();
            var dbTransaction = await context.Transactions.Where(t => t.Id == id).SingleOrDefaultAsync();
            if (dbTransaction == null) {
                throw new Exception($"Transaction with id: {id} not found");
            }
            context.Remove(dbTransaction);
            await context.SaveChangesAsync();
        }

        public async Task<IList<Transaction>> GetAll() {
            using var context = new FuelStationDbContext();
            return await context.Transactions
                .Include(t => t.TransactionLines)
                .Include(t => t.Customer)
                .Include(t => t.Employee)
                .ToListAsync();
        }

        public async Task<Transaction?> GetById(Guid id) {
            using var context = new FuelStationDbContext();
            return await context.Transactions
                .Where(t => t.Id == id)
                .Include(t => t.TransactionLines)
                .Include(t => t.Customer)
                .Include(t => t.Employee)
                .SingleAsync();
        }

        public async Task Update(Guid id, Transaction entity) {
            using var context = new FuelStationDbContext();
            var dbTranansaction = await context.Transactions.Where(t => t.Id == id).SingleOrDefaultAsync();
            if (dbTranansaction == null) {
                throw new Exception($"Transaction with id: {id} not found");
            }
            dbTranansaction.PaymentMethod = entity.PaymentMethod;
            dbTranansaction.CustomerId = entity.CustomerId;
            dbTranansaction.EmployeeId = entity.EmployeeId;
            dbTranansaction.TotalValue = entity.TotalValue;
            dbTranansaction.Date = entity.Date;
            await context.SaveChangesAsync();
        }
    }
}
