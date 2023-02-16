using CoffeeShop.EF.Context;
using CoffeeShop.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.EF.Repositories
{
    public class TransactionLineRepo : IEntityRepo<TransactionLine>
    {
        public void Add(TransactionLine entity)
        {
            using var context = new CoffeeShopDbContext();
            context.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            using var context = new CoffeeShopDbContext();
            var dbCoffeShop = context.TransactionLines.Where(transactionline => transactionline.Id == id).SingleOrDefault();
            if (dbCoffeShop is null)
                return;
            context.Remove(dbCoffeShop);
            context.SaveChanges();
        }

        public IList<TransactionLine> GetAll()
        {
            using var context = new CoffeeShopDbContext();
            return context.TransactionLines.Include(product => product.Product).ToList();
        }

        public TransactionLine? GetById(int id)
        {
            using var context = new CoffeeShopDbContext();
            return context.TransactionLines
                .Where(transactionline => transactionline.Id == id)
                .Include(transactionLine => transactionLine.Product)
                .SingleOrDefault();
        }

        public void Update(int id, TransactionLine entity)
        {
            using var context = new CoffeeShopDbContext();
            var dbCoffeShop = context.TransactionLines.Where(transactionline => transactionline.Id == id).SingleOrDefault();
            if (dbCoffeShop is null)
                return;
            dbCoffeShop.Quantity = entity.Quantity;
            dbCoffeShop.Discount = entity.Discount;
            dbCoffeShop.Price = entity.Price;
            dbCoffeShop.TotalPrice = entity.TotalPrice;
            dbCoffeShop.TransactionId = entity.TransactionId;
            dbCoffeShop.Transaction = entity.Transaction;   
            dbCoffeShop.ProductId = entity.ProductId;
            dbCoffeShop.Product = entity.Product;

            context.SaveChanges();
        }
    }
}
