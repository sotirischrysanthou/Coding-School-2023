using CarServiceCenterLib.Models;
using CarServiceCenterLib.Orm.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCenterLib.Orm.Repositories {
    public class EngineerRepo : IEntityRepo<Engineer> {
        public void Add(Engineer entity) {
            using var context = new AppDbContext();
            if (!EntityExists(entity)) {
                context.Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(Guid id) {
            using var context = new AppDbContext();
            var EngineerDb = context.Engineers
                .Where(engineer => engineer.ID == id)
                .Include(engineer => engineer.TransactionLines)
                .Include(engineer => engineer.Manager)
                .SingleOrDefault();
            if (EngineerDb is null)
                return;
            context.Remove(EngineerDb);
            context.SaveChanges();
        }

        public bool EntityExists(Engineer entity) {
            using var context = new AppDbContext();
            var EngineerDb = context.Engineers
                .Where(engineer => engineer.Name == entity.Name
                && engineer.Surname == entity.Surname
                && engineer.SalaryPerMonth == entity.SalaryPerMonth
                && engineer.StartDate == entity.StartDate)
                .Include(engineer => engineer.TransactionLines)
                .Include(engineer => engineer.Manager)
                .SingleOrDefault();
            if (EngineerDb is null) {
                var Engineer1Db = context.Engineers
                .Where(engineer => engineer.ID == entity.ID)
                .Include(engineer => engineer.TransactionLines)
                .Include(engineer => engineer.Manager)
                .SingleOrDefault();
                if (Engineer1Db is null) {
                    return false;
                } else return true;
            } else return true;
        }

        public IList<Engineer> GetAll() {
            using var context = new AppDbContext();
            return context.Engineers.ToList();
        }

        public Engineer? GetById(Guid id) {
            using var context = new AppDbContext();
            return context.Engineers
                .Where(engineer => engineer.ID == id)
                .Include(engineer => engineer.TransactionLines)
                .Include(engineer => engineer.Manager)
                .SingleOrDefault();
        }

        public void Update(Guid id, Engineer entity) {
            using var context = new AppDbContext();
            var EngineerDb = context.Engineers
                .Where(engineer => engineer.ID == id)
                .Include(engineer => engineer.TransactionLines)
                .Include(engineer => engineer.Manager)
                .SingleOrDefault();
            if (EngineerDb is null) return;
            EngineerDb.Name = entity.Name;
            EngineerDb.Surname = entity.Surname;
            EngineerDb.ManagerID = entity.ManagerID;
            EngineerDb.SalaryPerMonth = entity.SalaryPerMonth;
            EngineerDb.StartDate = entity.StartDate;
            context.SaveChanges();
        }
    }
}
