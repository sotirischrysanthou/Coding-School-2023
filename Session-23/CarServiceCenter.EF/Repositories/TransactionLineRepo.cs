using CarServiceCenter.Model;
using CarServiceCenter.EF.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCenter.EF.Repositories {
    public class TransactionLineRepo : IEntityRepo<TransactionLine> {
        public void Add(TransactionLine entity) {
            using var context = new CarServiceCenterDbContext();
            if (!EntityExists(entity)) {
                context.Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(int id) {
            using var context = new CarServiceCenterDbContext();
            var TransactionLineDb = context.TransactionLines.Where(transactionLine => transactionLine.Id == id)
                .Include(transactionLine => transactionLine.Transaction)
                .Include(transactionLine => transactionLine.Engineer)
                .Include(transactionLine => transactionLine.ServiceTask)
                .SingleOrDefault();
            if (TransactionLineDb is null)
                return;
            context.Remove(TransactionLineDb);
            context.SaveChanges();
        }

        public bool EntityExists(TransactionLine entity) {
            using var context = new CarServiceCenterDbContext();
            var TransactionLineDb = context.TransactionLines
                .Where(transactionLine => transactionLine.ServiceTaskId == entity.ServiceTaskId
                && transactionLine.TransactionId == entity.TransactionId
                && transactionLine.Hours == entity.Hours
                && transactionLine.EngineerId == entity.EngineerId)
                .Include(transactionLine => transactionLine.Transaction)
                .Include(transactionLine => transactionLine.Engineer)
                .Include(transactionLine => transactionLine.ServiceTask)
                .SingleOrDefault();
            if (TransactionLineDb is null) {
                var TransactionLine1Db = context.TransactionLines
                    .Where(transactionLine => transactionLine.Id == entity.Id)
                    .Include(transactionLine => transactionLine.Engineer)
                    .Include(transactionLine => transactionLine.ServiceTask)
                    .SingleOrDefault();
                if (TransactionLine1Db is null) { return false; } else {
                    return true;
                }
            } else return true;
        }

        public IList<TransactionLine> GetAll() {
            using var context = new CarServiceCenterDbContext();
            return context.TransactionLines
                .Include(transactionLine => transactionLine.Transaction)
                .Include(transactionLine => transactionLine.Engineer)
                .Include(transactionLine => transactionLine.ServiceTask)
                .ToList();
        }

        public TransactionLine? GetById(int id) {
            using var context = new CarServiceCenterDbContext();
            return context.TransactionLines.Where(transactionLine => transactionLine.Id == id).SingleOrDefault();
        }

        public void Update(int id, TransactionLine entity) {
            using var context = new CarServiceCenterDbContext();
            var TransactionLineDb = context.TransactionLines.Where(transactionLine => transactionLine.Id == id)
                .Include(transactionLine => transactionLine.Transaction)
                .Include(transactionLine => transactionLine.Engineer)
                .Include(transactionLine => transactionLine.ServiceTask)
                .SingleOrDefault();
            if (TransactionLineDb is null)
                return;
            TransactionLineDb.Price = entity.Price;
            TransactionLineDb.PricePerHour = entity.PricePerHour;
            TransactionLineDb.Hours = entity.Hours;
            TransactionLineDb.ServiceTaskId = entity.ServiceTaskId;

            context.SaveChanges();
        }
    }
}
