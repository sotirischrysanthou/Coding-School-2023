using CarServiceCenterLib.Models;
using CarServiceCenterLib.Orm.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCenterLib.Orm.Repositories {
    public class CarRepo : IEntityRepo<Car> {
        public void Add(Car entity) {
            using var context = new AppDbContext();
            if (!EntityExists(entity)) {
                context.Add(entity);
                context.SaveChanges();
            }
        }
        public void Delete(Guid id) {
            using var context = new AppDbContext();
            var CarDb = context.Cars.Where(car => car.ID == id).SingleOrDefault();
            if (CarDb is null)
                return;
            context.Remove(CarDb);
            context.SaveChanges();
        }

        public IList<Car> GetAll() {
            using var context = new AppDbContext();
            return context.Cars.ToList();

        }
        public Car? GetById(Guid id) {
            using var context = new AppDbContext();
            return context.Cars.Where(car => car.ID == id).SingleOrDefault(); ;

        }
        public void Update(Guid id, Car entity) {
            using var context = new AppDbContext();
            var CarDb = context.Cars.Where(car => car.ID == id).SingleOrDefault();
            if (CarDb is null)
                return;
            CarDb.Brand = entity.Brand;
            CarDb.Model = entity.Model;
            CarDb.CarRegistrationNumber = entity.CarRegistrationNumber;
            context.SaveChanges();
        }
        public bool EntityExists(Car entity) {
            using var context = new AppDbContext();
            var CarDb = context.Cars
                .Where(car => car.Brand == entity.Brand
                && car.Brand == entity.Brand
                && car.Model == entity.Model
                && car.CarRegistrationNumber == entity.CarRegistrationNumber
            ).SingleOrDefault();
            if (CarDb is null) {
                var Car1Db = context.Cars
                .Where(car => car.ID == entity.ID).SingleOrDefault();
                if (Car1Db is null) { return false; } else {
                    return true;
                }
            } else return true;
        }
    }
}
