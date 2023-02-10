using CarServiceCenter.Model;
using CarServiceCenter.EF.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCenterLib.Orm.Repositories {
    public class ManagerRepo : IEntityRepo<Manager> {
        public void Add(Manager entity) {
            using var context = new CarServiceCenterDbContext();
            if (!EntityExists(entity)) {
                context.Add(entity);
                context.SaveChanges();
            }
        }
        public void Delete(int id) {
            using var context = new CarServiceCenterDbContext();
            var ManagerDb = context.Managers.Where(manager => manager.Id == id).SingleOrDefault();
            if (ManagerDb is null)
                return;
            context.Remove(ManagerDb);
            context.SaveChanges();
        }
        public IList<Manager> GetAll() {
            using var context = new CarServiceCenterDbContext();
            return context.Managers.ToList();

        }

        public Manager? GetById(int id) {
            using var context = new CarServiceCenterDbContext();
            return context.Managers.Where(manager => manager.Id == id).SingleOrDefault();
        }

        public void Update(int id, Manager entity) {
            using var context = new CarServiceCenterDbContext();
            var ManagerDb = context.Managers.Where(manager => manager.Id == id).SingleOrDefault();
            if (ManagerDb is null)
                return;
            ManagerDb.Name = entity.Name;
            ManagerDb.Surname = entity.Surname;
            ManagerDb.SalaryPerMonth = entity.SalaryPerMonth;

            context.SaveChanges();
        }
        public bool EntityExists(Manager entity) {
            using var context = new CarServiceCenterDbContext();
            var ManagerDb = context.Managers
                .Where(Manager => Manager.Name == entity.Name
            && Manager.Surname == entity.Surname
            && Manager.SalaryPerMonth == entity.SalaryPerMonth
            ).SingleOrDefault();
            if (ManagerDb is null) {
                var Manager1Db = context.Managers
                .Where(manager => manager.Id == entity.Id).SingleOrDefault();
                if (Manager1Db is null) { return false; } else {
                    return true;
                }
            } else return true;
        }
    }
}

