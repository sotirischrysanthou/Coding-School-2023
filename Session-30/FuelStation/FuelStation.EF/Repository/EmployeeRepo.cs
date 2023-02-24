using FuelStation.EF.Context;
using FuelStation.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.EF.Repository {
    public class EmployeeRepo : IEntityRepo<Employee> {
        public async Task Add(Employee entity) {
            using var context = new FuelStationDbContext();
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task Delete(Guid id) {
            using var context = new FuelStationDbContext();
            var dbEmployee = context.Employees
                .Where(c => c.Id == id)
                .SingleOrDefault();
            if (dbEmployee == null) {
                throw new Exception($"Employee with id: {id} not found");
            }
            context.Remove(dbEmployee);
            await context.SaveChangesAsync();
        }

        public async Task<IList<Employee>> GetAll() {
            using var context = new FuelStationDbContext();
            return await context.Employees
                                .Include(e => e.Transactions)
                                .Include(e => e.Account)
                                .ToListAsync();
        }

        public async Task<Employee?> GetById(Guid id) {
            using var context = new FuelStationDbContext();
            return await context.Employees
                                .Where(e => e.Id == id)
                                .Include(e => e.Transactions)
                                .Include(e => e.Account)
                                .SingleOrDefaultAsync();
        }

        public async Task Update(Guid id, Employee entity) {
            using var context = new FuelStationDbContext();
            var dbEmployee = await context.Employees
                                          .Where(e => e.Id == id)
                                          .Include(e => e.Account)
                                          .SingleOrDefaultAsync();
            if (dbEmployee is null)
                throw new Exception($"Employee with id: {id} not found");
            dbEmployee.Name = entity.Name;
            dbEmployee.Surname = entity.Surname;
            dbEmployee.SalaryPerMonth = entity.SalaryPerMonth;
            dbEmployee.HireDateStart = entity.HireDateStart;
            dbEmployee.HireDateEnd = entity.HireDateEnd;
            await context.SaveChangesAsync();
        }
    }
}
