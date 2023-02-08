using CarServiceCenterLib.Models;
using CarServiceCenterLib.Orm.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCenterLib.Orm.Repositories {
    public class TransactionRepo : IEntityRepo<Transaction> {
        public void Add(Transaction entity) {
            using var context = new AppDbContext();
            if (!EntityExists(entity)) {
                context.Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(Guid id) {
            using var context = new AppDbContext();
            var TransactionDb = context.Transactions
                .Where(transaction => transaction.ID == id)
                //.Include(transaction => transaction.TransactionLines)
                //.Include(transaction => transaction.Customer)
                //.Include(transaction => transaction.Car)
                //.Include(transaction => transaction.Manager)
                .SingleOrDefault();
            if (TransactionDb is null)
                return;
            context.Remove(TransactionDb);
            context.SaveChanges();
        }

        public bool EntityExists(Transaction entity) {
            using var context = new AppDbContext();
            var TransactionDb = context.Transactions
                .Where(transaction => transaction.CarID == entity.CarID
                && transaction.CustomerID == entity.CustomerID
                && transaction.ManagerID == entity.ManagerID
                && transaction.Date == entity.Date
                && transaction.TotalPrice == entity.TotalPrice)
                .Include(transaction => transaction.TransactionLines)
                .Include(transaction => transaction.Customer)
                .Include(transaction => transaction.Car)
                .Include(transaction => transaction.Manager)
                .SingleOrDefault();
            if (TransactionDb is null) {
                var Transaction1Db = context.Transactions
                .Where(transaction => transaction.ID == entity.ID)
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
            using var context = new AppDbContext();
            return context.Transactions
                .Include(transaction => transaction.TransactionLines)
                .Include(transaction => transaction.Customer)
                .Include(transaction => transaction.Car)
                .Include(transaction => transaction.Manager)
                .ToList();
        }

        public Transaction? GetById(Guid id) {
            using var context = new AppDbContext();
            return context.Transactions.Where(transaction => transaction.ID == id)
                .Include(transaction => transaction.TransactionLines)
                .Include(transaction => transaction.Customer)
                .Include(transaction => transaction.Car)
                .Include(transaction => transaction.Manager)
                .SingleOrDefault();
        }

        public void Update(Guid id, Transaction entity) {
            using var context = new AppDbContext();
            var TransactionDb = context.Transactions
                .Where(transaction => transaction.ID == id)
                .SingleOrDefault();
            if (TransactionDb is null)
                return;
            TransactionDb.Date = entity.Date;
            TransactionDb.CustomerID = entity.CustomerID;
            TransactionDb.CarID = entity.CarID;
            TransactionDb.ManagerID = entity.ManagerID;
            TransactionDb.TotalPrice = entity.TotalPrice;
            

            context.SaveChanges();
        }
    }
}
