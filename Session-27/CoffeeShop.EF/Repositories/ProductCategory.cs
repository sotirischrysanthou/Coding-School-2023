using CoffeeShop.EF.Context;
using CoffeeShop.Model;
using CoffeeShop.Model.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.EF.Repositories {
    public class ProductCategoryRepo : IEntityRepo<ProductCategory> {
        public void Add(ProductCategory entity) {
            using var context = new CoffeeShopDbContext();
            context.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id) {
            using var context = new CoffeeShopDbContext();
            var dbProductCategory = context.ProductCategories.Where(productCategory => productCategory.Id == id).SingleOrDefault();
            if (dbProductCategory is null)
                return;
            context.Remove(dbProductCategory);
            context.SaveChanges();
        }

        public IList<ProductCategory> GetAll() {
            using var context = new CoffeeShopDbContext();
            return context.ProductCategories
                .Include(productCategory => productCategory.Products).ToList();
        }

        public ProductCategory? GetById(int id) {
            using var context = new CoffeeShopDbContext();
            return context.ProductCategories.Where(customer => customer.Id == id)
                .Include(productCategory => productCategory.Products).SingleOrDefault();
        }

        public void Update(int id, ProductCategory entity) {
            using var context = new CoffeeShopDbContext();
            var dbProductCategory = context.ProductCategories.Where(productCategory => productCategory.Id == id).SingleOrDefault();
            if (dbProductCategory is null)
                return;
            dbProductCategory.Code = entity.Code;
            dbProductCategory.Description = entity.Description;
            dbProductCategory.ProductType = entity.ProductType;
            dbProductCategory.Products = entity.Products;
            context.SaveChanges();
        }
    }
}
