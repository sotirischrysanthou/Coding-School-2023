using CoffeeShop.EF.Context;
using CoffeeShop.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.EF.Repositories {
    public class ProductRepo : IEntityRepo<Product> {
        public void Add(Product entity) {
            using var context = new CoffeeShopDbContext();
            context.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id) {
            using var context = new CoffeeShopDbContext();
            var dbProduct = context.Products.Where(product => product.Id == id).SingleOrDefault();
            if (dbProduct is null)
                return;
            context.Remove(dbProduct);
            context.SaveChanges();
        }

        public IList<Product> GetAll() {
            using var context = new CoffeeShopDbContext();
            return context.Products
                .Include(product => product.TransactionLines)
                .Include(product => product.ProductCategory)
                .ToList();
        }

        public Product? GetById(int id) {
            using var context = new CoffeeShopDbContext();
            return context.Products.Where(customer => customer.Id == id)
                .Include(product => product.TransactionLines)
                .Include(product => product.ProductCategory)
                .SingleOrDefault();
        }

        public void Update(int id, Product entity) {
            using var context = new CoffeeShopDbContext();
            var dbProduct = context.Products.Where(product => product.Id == id).SingleOrDefault();
            if (dbProduct is null)
                return;
            dbProduct.Code = entity.Code;
            dbProduct.Description = entity.Description;
            dbProduct.Price = entity.Price;
            dbProduct.Cost = entity.Cost;
            dbProduct.ProductCategoryId = entity.ProductCategoryId;
            dbProduct.ProductCategory = entity.ProductCategory;
            context.SaveChanges();
        }
    }
}
