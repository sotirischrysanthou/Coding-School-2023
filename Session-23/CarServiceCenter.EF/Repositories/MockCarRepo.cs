using CarServiceCenter.Model;
using CarServiceCenter.EF.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCenter.EF.Repositories {
    public class MockCarRepo : IEntityRepo<Car> {
        // Properties
        private readonly List<Car> _cars;

        // Constructors
        public MockCarRepo() {
            _cars = new List<Car> {
                new("Ford", "Focus", "ABC 1234"),
                new("Toyota", "Yaris", "DEF 5678"),
                new("Mazda", "Miata", "GHI 9101")
            };
        }


        public void Add(Car entity) {
            if (entity.Id != 0)
                throw new ArgumentException("Given entity should not have Id set", nameof(entity));

            var lastId = _cars.OrderBy(todo => todo.Id).Last().Id;
            entity.Id = ++lastId;
            _cars.Add(entity);
        }
        public void Delete(int id) {
            var CarDb = _cars
                .Where(car => car.Id == id)
                .SingleOrDefault();
            if (CarDb is null)
                throw new KeyNotFoundException($"Given id '{id}' was not found");
            _cars.Remove(CarDb);
        }

        public IList<Car> GetAll() {
            return _cars;
        }
        public Car? GetById(int id) {
            return _cars
                .Where(car => car.Id == id)
                .SingleOrDefault(); ;

        }
        public void Update(int id, Car entity) {
            var CarDb = _cars
                .Where(car => car.Id == id)
                .SingleOrDefault();
            if (CarDb is null)
                throw new KeyNotFoundException($"Given id '{id}' was not found");
            CarDb.Brand = entity.Brand;
            CarDb.Model = entity.Model;
            CarDb.CarRegistrationNumber = entity.CarRegistrationNumber;
        }
        public bool EntityExists(Car entity) {
            var CarDb = _cars
                .Where(car => car.Brand == entity.Brand
                && car.Brand == entity.Brand
                && car.Model == entity.Model
                && car.CarRegistrationNumber == entity.CarRegistrationNumber
            ).SingleOrDefault();
            if (CarDb is null) {
                var Car1Db = _cars
                .Where(car => car.Id == entity.Id)
                .SingleOrDefault();
                if (Car1Db is null) { return false; } else {
                    return true;
                }
            } else return true;
        }
    }
}
