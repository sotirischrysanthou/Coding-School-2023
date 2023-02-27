using FuelStation.EF.Context;
using FuelStation.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.EF.Repository {
    public class SettingsRepo : IEntityRepo<Settings> {
        public Task Add(Settings entity) {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id) {
            throw new NotImplementedException();
        }

        public Task<IList<Settings>> GetAll() {
            throw new NotImplementedException();
        }

        public async Task<Settings?> GetById(Guid id) {
            var context = new FuelStationDbContext();
            return  await context.Settings.FirstAsync();
        }

        public async Task Update(Guid id, Settings entity) {
            var context = new FuelStationDbContext();
            var settings = await context.Settings.FirstAsync();
            settings.MinManagers = entity.MinManagers;
            settings.MaxManagers = entity.MaxManagers;
            settings.MinCashiers = entity.MinCashiers;
            settings.MaxCashiers = entity.MaxCashiers;
            settings.MinStaff =entity.MinStaff;
            settings.MaxStaff =entity.MaxStaff;
            settings.OpeningDate=entity.OpeningDate;
            settings.Rent = entity.Rent;
            context.SaveChanges();
        }
    }
}
