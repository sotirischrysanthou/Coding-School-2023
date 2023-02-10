using CarServiceCenter.Model;
using CarServiceCenter.EF.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCenterLib.Orm.Repositories {
    public class CarRepo : IEntityRepo<Car> {
        public void Add(Car entity) {
            using var context = new CarServiceCenterDbContext();
            if (!EntityExists(entity)) {
                context.Add(entity);
                context.SaveChanges();
            }
        }
        public void Delete(int id) {
            using var context = new CarServiceCenterDbContext();
            var CarDb = context.Cars
                .Where(car => car.Id == id)
                .Include(car => car.Transactions)
                .SingleOrDefault();
            if (CarDb is null)
                return;
            context.Remove(CarDb);
            context.SaveChanges();
        }

        public IList<Car> GetAll() {
            using var context = new CarServiceCenterDbContext();
            return context.Cars
                .Include(car => car.Transactions)
                .ToList();

        }
        public Car? GetById(int id) {
            using var context = new CarServiceCenterDbContext();
            return context.Cars
                .Where(car => car.Id == id)
                .Include(car => car.Transactions)
                .SingleOrDefault(); ;

        }
        public void Update(int id, Car entity) {
            using var context = new CarServiceCenterDbContext();
            var CarDb = context.Cars.Where(car => car.Id == id).SingleOrDefault();
            if (CarDb is null)
                return;
            CarDb.Brand = entity.Brand;
            CarDb.Model = entity.Model;
            CarDb.CarRegistrationNumber = entity.CarRegistrationNumber;
            context.SaveChanges();
        }
        public bool EntityExists(Car entity) {
            using var context = new CarServiceCenterDbContext();
            var CarDb = context.Cars
                .Where(car => car.Brand == entity.Brand
                && car.Brand == entity.Brand
                && car.Model == entity.Model
                && car.CarRegistrationNumber == entity.CarRegistrationNumber
            ).SingleOrDefault();
            if (CarDb is null) {
                var Car1Db = context.Cars
                .Where(car => car.Id == entity.Id)
                .Include(car => car.Transactions)
                .SingleOrDefault();
                if (Car1Db is null) { return false; } else {
                    return true;
                }
            } else return true;
        }
    }
}
