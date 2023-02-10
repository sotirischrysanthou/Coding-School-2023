using CarServiceCenter.Model;
using CarServiceCenter.EF.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCenter.EF.Repositories {
    public class MockServiceTaskRepo : IEntityRepo<ServiceTask> {
        // Properties
        private readonly List<ServiceTask> _serviceTasks;
        // Constructors
        public MockServiceTaskRepo() {
            _serviceTasks= new List<ServiceTask> { 
                new("1","Air Filter",3),
                new("1","Oil Filter",3),
                new("1","Petrol Filter",3),
            };
        }


        public void Add(ServiceTask entity) {
            if (entity.Id != 0)
                throw new ArgumentException("Given entity should not have Id set", nameof(entity));

            var lastId = _serviceTasks.OrderBy(todo => todo.Id).Last().Id;
            entity.Id = ++lastId;
            _serviceTasks.Add(entity);
        }
        public void Delete(int id) {
            var ServiceTaskDb = _serviceTasks
                .Where(serviceTask => serviceTask.Id == id)
                .SingleOrDefault();
            if (ServiceTaskDb is null)
                return;
            
            _serviceTasks.Remove(ServiceTaskDb);
        }

        public IList<ServiceTask> GetAll() {
            return _serviceTasks;

        }
        public ServiceTask? GetById(int id) {
            return _serviceTasks
                .Where(serviceTask => serviceTask.Id == id)
                .SingleOrDefault();

        }
        public void Update(int id, ServiceTask entity) {
            var ServiceTaskDb = _serviceTasks
                .Where(serviceTask => serviceTask.Id == id)
                .SingleOrDefault();
            if (ServiceTaskDb is null)
                throw new KeyNotFoundException($"Given id '{id}' was not found");
            ServiceTaskDb.Code = entity.Code;
            ServiceTaskDb.Description = entity.Description;
            ServiceTaskDb.Hours = entity.Hours;
        }
        public bool EntityExists(ServiceTask entity) {
            var ServiceTaskDb = _serviceTasks
                .Where(serviceTask => serviceTask.Code == entity.Code
                && serviceTask.Description == entity.Description
                && serviceTask.Hours == entity.Hours
                && serviceTask.Description == entity.Description)
                .SingleOrDefault();
            if (ServiceTaskDb is null) {
                var ServiceTask1Db = _serviceTasks
                .Where(serviceTask => serviceTask.Id == entity.Id)
                .SingleOrDefault();
                if (ServiceTask1Db is null) { return false; } else {
                    return true;
                }
            } else return true;
        }
    }
}
