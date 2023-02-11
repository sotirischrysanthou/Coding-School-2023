using CarServiceCenter.Model;
using CarServiceCenter.EF.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCenter.EF.Repositories {
    public class MockEngineerRepo : IEntityRepo<Engineer> {
        // Properties
        private readonly List<Engineer> _engineers;
        private readonly List<Manager> _managers;

        // Constructors
        public MockEngineerRepo() {
            MockManagerRepo mockManagerRepo= new MockManagerRepo();
            _managers = mockManagerRepo.GetAll().ToList();
            _engineers = new List<Engineer> { 
                new("Kostas", "Sofos", 1200) {
                    Id = 0,
                    Manager = _managers[0],
                    ManagerId = _managers[0].Id
                },
                new("Stavros", "Kasidis", 1250){
                    Id = 0,
                    Manager = _managers[1],
                    ManagerId = _managers[1].Id
                }
            };
        }

        public void Add(Engineer entity) {
            if (entity.Id != 0)
                throw new ArgumentException("Given entity should not have Id set", nameof(entity));

            var lastId = _engineers.OrderBy(todo => todo.Id).Last().Id;
            entity.Id = ++lastId;
            _engineers.Add(entity);
        }

        public void Delete(int id) {
            var EngineerDb = _engineers
                .Where(engineer => engineer.Id == id)
                .SingleOrDefault();
            if (EngineerDb is null)
                throw new KeyNotFoundException($"Given id '{id}' was not found");
            _engineers.Remove(EngineerDb);
        }

        public bool EntityExists(Engineer entity) {
            var EngineerDb = _engineers
                .Where(engineer => engineer.Name == entity.Name
                && engineer.Surname == entity.Surname
                && engineer.SalaryPerMonth == entity.SalaryPerMonth)
                //&& engineer.StartDate == entity.StartDate)
                .SingleOrDefault();
            if (EngineerDb is null) {
                var Engineer1Db = _engineers
                .Where(engineer => engineer.Id == entity.Id)
                .SingleOrDefault();
                if (Engineer1Db is null) {
                    return false;
                } else return true;
            } else return true;
        }

        public IList<Engineer> GetAll() {
            return _engineers;
        }

        public Engineer? GetById(int id) {
            return _engineers
                .Where(engineer => engineer.Id == id)
                .SingleOrDefault();
        }

        public void Update(int id, Engineer entity) {
            var EngineerDb = _engineers
                .Where(engineer => engineer.Id == id)
                .SingleOrDefault();
            if (EngineerDb is null) throw new KeyNotFoundException($"Given id '{id}' was not found");
            EngineerDb.Name = entity.Name;
            EngineerDb.Surname = entity.Surname;
            EngineerDb.ManagerId = entity.ManagerId;
            EngineerDb.SalaryPerMonth = entity.SalaryPerMonth;
            //EngineerDb.StartDate = entity.StartDate;
        }
    }
}
