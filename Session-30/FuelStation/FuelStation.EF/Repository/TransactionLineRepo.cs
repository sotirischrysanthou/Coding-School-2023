using FuelStation.EF.Context;
using FuelStation.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.EF.Repository {
    public class TransactionLineRepo : IEntityRepo<TransactionLine> {
        public async Task Add(TransactionLine entity) {
            using var context = new FuelStationDbContext();
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task Delete(Guid id) {
            using var context = new FuelStationDbContext();
            var dbTransactionLine = context.TransactionLines.Where(t => t.Id == id).SingleOrDefaultAsync();
            if (dbTransactionLine == null) {
                throw new Exception($"Transaction Line with id: {id} not found ");
            }
            context.Remove(dbTransactionLine);
            await context.SaveChangesAsync();
        }

        public async Task<IList<TransactionLine>> GetAll() {
            using var context = new FuelStationDbContext();
            return await context.TransactionLines
                .Include(t=>t.Transaction)
                .Include(t=>t.Item)
                .ToListAsync();
        }

        public async Task<TransactionLine?> GetById(Guid id) {
            using var context = new FuelStationDbContext();
            return await context.TransactionLines
                .Where(t => t.Id == id)
                .Include(t => t.Transaction)
                .Include(t => t.Item)
                .SingleOrDefaultAsync();
        }

        public async Task Update(Guid id, TransactionLine entity) {
            using var context = new FuelStationDbContext();
            var dbTransactionLine = await context.TransactionLines.Where(t=>t.Id == id).SingleOrDefaultAsync();
            if (dbTransactionLine == null) {
                throw new Exception($"TransactionLine with id: {id} not found");
            }
            await context.SaveChangesAsync();
        }
    }
}
