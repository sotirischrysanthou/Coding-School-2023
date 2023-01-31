using CarServiceCenterLib.Models;
using CarServiceCenterLib.Orm.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCenterLib.Orm.Repositories {
    public class ServiceTaskRepo : IEntityRepo<ServiceTask> {
        public void Add(ServiceTask entity) {
            using var context = new AppDbContext();
            if (!EntityExists(entity)) {
                context.Add(entity);
                context.SaveChanges();
            }
        }
        public void Delete(Guid id) {
            using var context = new AppDbContext();
            var ServiceTaskDb = context.ServiceTasks.Where(serviceTask => serviceTask.ID == id).SingleOrDefault();
            if (ServiceTaskDb is null)
                return;
            context.Remove(ServiceTaskDb);
            context.SaveChanges();
        }

        public IList<ServiceTask> GetAll() {
            using var context = new AppDbContext();
            return context.ServiceTasks.ToList();

        }
        public ServiceTask? GetById(Guid id) {
            using var context = new AppDbContext();
            return context.ServiceTasks.SingleOrDefault();

        }
        public void Update(Guid id, ServiceTask entity) {
            using var context = new AppDbContext();
            var ServiceTaskDb = context.ServiceTasks.Where(serviceTask => serviceTask.ID == id).SingleOrDefault();
            if (ServiceTaskDb is null)
                return;
            ServiceTaskDb.Code = entity.Code;
            ServiceTaskDb.Description = entity.Description;
            ServiceTaskDb.Hours = entity.Hours;
            context.SaveChanges();
        }
        public bool EntityExists(ServiceTask entity) {
            using var context = new AppDbContext();
            var ServiceTaskDb = context.ServiceTasks
                .Where(serviceTask => serviceTask.Code == entity.Code
                && serviceTask.Description == entity.Description
                && serviceTask.Hours == entity.Hours
                && serviceTask.Description == entity.Description)
                .SingleOrDefault();
            if (ServiceTaskDb is null) {
                var ServiceTask1Db = context.ServiceTasks
                .Where(serviceTask => serviceTask.ID == entity.ID).SingleOrDefault();
                if (ServiceTask1Db is null) { return false; } else {
                    return true;
                }
            } else return true;
        }
    }
}
