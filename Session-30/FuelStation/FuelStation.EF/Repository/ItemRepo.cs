using FuelStation.EF.Context;
using FuelStation.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.EF.Repository {
    public class ItemRepo : IEntityRepo<Item> {
        public async Task Add(Item entity) {
            using var context = new FuelStationDbContext();
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task Delete(Guid id) {
            using var context = new FuelStationDbContext();
            var dbItem = await context.Items
                .Where(i => i.Id == id)
                .SingleOrDefaultAsync();
            if(dbItem == null) {
                throw new Exception($"Item with id: {id} not found");
            }
            context.Remove(dbItem);
            await context.SaveChangesAsync();
        }

        public async Task<IList<Item>> GetAll() {
            using var context = new FuelStationDbContext();
            return await context.Items
                .Include(i => i.TransactionLines).ThenInclude(t => t.Transaction).ThenInclude(t => t.Employee)
                .Include(i => i.TransactionLines).ThenInclude(t => t.Transaction).ThenInclude(t => t.Customer)
                .ToListAsync();
        }

        public async Task<Item?> GetById(Guid id) {
            using var context = new FuelStationDbContext();
            return await context.Items
                .Where(i => i.Id == id)
                .Include(i => i.TransactionLines).ThenInclude(t => t.Transaction).ThenInclude(t => t.Employee)
                .Include(i => i.TransactionLines).ThenInclude(t => t.Transaction).ThenInclude(t => t.Customer)
                .SingleAsync();
        }

        public async Task Update(Guid id, Item entity) {
            using var context = new FuelStationDbContext();
            var dbItem = await context.Items.Where(i => i.Id == id).SingleAsync();
            if(dbItem == null) {
                throw new Exception($"Item with id: {id} not found");
            }
            dbItem.Description = entity.Description;
            dbItem.Price = entity.Price;
            dbItem.ItemType = entity.ItemType;
            dbItem.Cost = entity.Cost;
            dbItem.Code = entity.Code;
            await context.SaveChangesAsync();
        }
    }
}
