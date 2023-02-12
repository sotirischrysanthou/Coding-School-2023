using CarServiceCenter.Model;
using CarServiceCenter.EF.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCenter.EF.Repositories {
    public class TransactionRepo : IEntityRepo<Transaction> {
        public void Add(Transaction entity) {
            using var context = new CarServiceCenterDbContext();
            if (!EntityExists(entity)) {
                context.Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(int id) {
            using var context = new CarServiceCenterDbContext();
            var TransactionDb = context.Transactions
                .Where(transaction => transaction.Id == id)
                .Include(transaction => transaction.TransactionLines)
                .Include(transaction => transaction.Customer)
                .Include(transaction => transaction.Car)
                .Include(transaction => transaction.Manager)
                .SingleOrDefault();
            if (TransactionDb is null)
                throw new KeyNotFoundException($"Given id '{id}' was not found");
            context.Remove(TransactionDb);
            context.SaveChanges();
        }

        public bool EntityExists(Transaction entity) {
            using var context = new CarServiceCenterDbContext();
            var TransactionDb = context.Transactions
                .Where(transaction => transaction.CarId == entity.CarId
                && transaction.CustomerId == entity.CustomerId
                && transaction.ManagerId == entity.ManagerId
                && transaction.Date == entity.Date
                && transaction.TotalPrice == entity.TotalPrice)
                .Include(transaction => transaction.TransactionLines)
                .Include(transaction => transaction.Customer)
                .Include(transaction => transaction.Car)
                .Include(transaction => transaction.Manager)
                .SingleOrDefault();
            if (TransactionDb is null) {
                var Transaction1Db = context.Transactions
                .Where(transaction => transaction.Id == entity.Id)
                .Include(transaction => transaction.TransactionLines)
                .Include(transaction => transaction.Customer)
                .Include(transaction => transaction.Car)
                .Include(transaction => transaction.Manager)
                .SingleOrDefault();
                if (Transaction1Db is null) { return false; } else {
                    return true;
                }
            } else return true;
        }

        public IList<Transaction> GetAll() {
            using var context = new CarServiceCenterDbContext();
            return context.Transactions
                .Include(transaction => transaction.TransactionLines)
                .Include(transaction => transaction.Customer)
                .Include(transaction => transaction.Car)
                .Include(transaction => transaction.Manager)
                .ToList();
        }

        public Transaction? GetById(int id) {
            using var context = new CarServiceCenterDbContext();
            return context.Transactions
                .Where(transaction => transaction.Id == id)
                .Include(transaction => transaction.TransactionLines)
                .Include(transaction => transaction.Customer)
                .Include(transaction => transaction.Car)
                .Include(transaction => transaction.Manager)
                .SingleOrDefault();
        }

        public void Update(int id, Transaction entity) {
            using var context = new CarServiceCenterDbContext();
            var TransactionDb = context.Transactions
                .Where(transaction => transaction.Id == id)
                .SingleOrDefault();
            if (TransactionDb is null)
                throw new KeyNotFoundException($"Given id '{id}' was not found");
            TransactionDb.Date = entity.Date;
            TransactionDb.CustomerId = entity.CustomerId;
            TransactionDb.CarId = entity.CarId;
            TransactionDb.ManagerId = entity.ManagerId;
            TransactionDb.TotalPrice = entity.TotalPrice;
            

            context.SaveChanges();
        }
    }
}
