using FuelStation.EF.Context;
using FuelStation.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.EF.Repository {
    public class AccountRepo : IEntityRepo<Account> {
        public async Task Add(Account entity) {
            using var context = new FuelStationDbContext();
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task Delete(Guid id) {
            using var context = new FuelStationDbContext();
            var dbAccount = context.Accounts
                .Where(a => a.Id == id)
                .SingleOrDefault();
            if (dbAccount == null) {
                throw new Exception($"Account with id: {id} not found");
            }
            context.Remove(dbAccount);
            await context.SaveChangesAsync();
        }

        public async Task<IList<Account>> GetAll() {
            using var context = new FuelStationDbContext();
            return await context.Accounts
                .Include(a => a.Employee)
                .ToListAsync();
        }

        public async Task<Account?> GetById(Guid id) {
            using var context = new FuelStationDbContext();
            return await context.Accounts
                .Where(a => a.Id == id)
                .Include(a => a.Employee)
                .SingleOrDefaultAsync();
        }

        public async Task Update(Guid id, Account entity) {
            using var context = new FuelStationDbContext();
            var dbAccount = await context.Accounts
                .Where(a => a.Id == id)
                .SingleOrDefaultAsync();
            if (dbAccount is null)
                throw new Exception($"Customer with id: {id} not found");
            dbAccount.Username = entity.Username;
            dbAccount.Password = entity.Password;
            await context.SaveChangesAsync();
        }
    }
}
