using CarServiceCenter.Model;
using CarServiceCenter.EF.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCenter.EF.Repositories {
    public class MockManagerRepo : IEntityRepo<Manager> {
        // Properties
        private readonly List<Manager> _managers;

        // Constructors
        public MockManagerRepo() {
            _managers = new List<Manager> {
                new("Fotis", "Chrysoulas", 2000){ Id = 0 },
                new("Thodoris", "Kapiris", 2100){ Id = 1 }
            };
        }

        public void Add(Manager entity) {
            if (entity.Id != 0)
                throw new ArgumentException("Given entity should not have Id set", nameof(entity));

            var lastId = _managers.OrderBy(todo => todo.Id).Last().Id;
            entity.Id = ++lastId;
            _managers.Add(entity);
        }
        public void Delete(int id) {
            var ManagerDb = _managers
                .Where(manager => manager.Id == id)
                .SingleOrDefault();
            if (ManagerDb is null)
                return;
            _managers.Remove(ManagerDb);
        }
        public IList<Manager> GetAll() {
            return _managers;

        }

        public Manager? GetById(int id) {
            return _managers
                .Where(manager => manager.Id == id)
                .SingleOrDefault();
        }

        public void Update(int id, Manager entity) {
            var ManagerDb = _managers
                .Where(manager => manager.Id == id)
                .SingleOrDefault();
            if (ManagerDb is null)
                throw new KeyNotFoundException($"Given id '{id}' was not found");
            ManagerDb.Name = entity.Name;
            ManagerDb.Surname = entity.Surname;
            ManagerDb.SalaryPerMonth = entity.SalaryPerMonth;
        }
        public bool EntityExists(Manager entity) {
            var ManagerDb = _managers
                .Where(Manager => Manager.Name == entity.Name
                && Manager.Surname == entity.Surname
                && Manager.SalaryPerMonth == entity.SalaryPerMonth)
                .SingleOrDefault();
            if (ManagerDb is null) {
                var Manager1Db = _managers
                .Where(manager => manager.Id == entity.Id)
                .SingleOrDefault();
                if (Manager1Db is null) { return false; } else {
                    return true;
                }
            } else return true;
        }
    }
}

