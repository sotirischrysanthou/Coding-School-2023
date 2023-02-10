using CarServiceCenter.Model;
using CarServiceCenter.EF.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCenter.EF.Repositories {
    public class EngineerRepo : IEntityRepo<Engineer> {
        public void Add(Engineer entity) {
            using var context = new CarServiceCenterDbContext();
            if (!EntityExists(entity)) {
                context.Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(int id) {
            using var context = new CarServiceCenterDbContext();
            var EngineerDb = context.Engineers
                .Where(engineer => engineer.Id == id)
                .Include(engineer => engineer.TransactionLines)
                .Include(engineer => engineer.Manager)
                .SingleOrDefault();
            if (EngineerDb is null)
                return;
            context.Remove(EngineerDb);
            context.SaveChanges();
        }

        public bool EntityExists(Engineer entity) {
            using var context = new CarServiceCenterDbContext();
            var EngineerDb = context.Engineers
                .Where(engineer => engineer.Name == entity.Name
                && engineer.Surname == entity.Surname
                && engineer.SalaryPerMonth == entity.SalaryPerMonth)
                //&& engineer.StartDate == entity.StartDate)
                .Include(engineer => engineer.TransactionLines)
                .Include(engineer => engineer.Manager)
                .SingleOrDefault();
            if (EngineerDb is null) {
                var Engineer1Db = context.Engineers
                .Where(engineer => engineer.Id == entity.Id)
                .Include(engineer => engineer.TransactionLines)
                .Include(engineer => engineer.Manager)
                .SingleOrDefault();
                if (Engineer1Db is null) {
                    return false;
                } else return true;
            } else return true;
        }

        public IList<Engineer> GetAll() {
            using var context = new CarServiceCenterDbContext();
            return context.Engineers.ToList();
        }

        public Engineer? GetById(int id) {
            using var context = new CarServiceCenterDbContext();
            return context.Engineers
                .Where(engineer => engineer.Id == id)
                .Include(engineer => engineer.TransactionLines)
                .Include(engineer => engineer.Manager)
                .SingleOrDefault();
        }

        public void Update(int id, Engineer entity) {
            using var context = new CarServiceCenterDbContext();
            var EngineerDb = context.Engineers
                .Where(engineer => engineer.Id == id)
                .Include(engineer => engineer.TransactionLines)
                .Include(engineer => engineer.Manager)
                .SingleOrDefault();
            if (EngineerDb is null) return;
            EngineerDb.Name = entity.Name;
            EngineerDb.Surname = entity.Surname;
            EngineerDb.ManagerId = entity.ManagerId;
            EngineerDb.SalaryPerMonth = entity.SalaryPerMonth;
            //EngineerDb.StartDate = entity.StartDate;
            context.SaveChanges();
        }
    }
}
