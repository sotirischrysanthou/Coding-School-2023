using CoffeeShop.EF.Repositories;
using CoffeeShop.Model;
using CoffeShop.Web.Blazor.Shared;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoffeShop.Web.Blazor.Server.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase {
        // Properties
        private readonly IEntityRepo<Employee> _employeeRepo;

        // Constructors
        public EmployeeController(IEntityRepo<Employee> employeeRepo) {
            _employeeRepo = employeeRepo;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<IEnumerable<EmployeeListDto>> Get() {
            var result = await Task.Run(() => {
                return _employeeRepo.GetAll();
            });
            var selectEmployeeList = result.Select(employee => new EmployeeListDto {
                Id = employee.Id,
                Name = employee.Name,
                Surname = employee.Surname,
                SalaryPerMonth = employee.SalaryPerMonth,
                EmployeeType = employee.EmployeeType,
            });
            return selectEmployeeList;
        }

        // GET: api/<EmployeeController>
        [HttpGet("{id}")]
        public async Task<EmployeeEditDto?> GetById(int id) {
            var result = await Task.Run(() => { return _employeeRepo.GetById(id); });
            if (result == null) {
                return null;
            } else {
                return new EmployeeEditDto {
                    Id = id,
                    Name = result.Name,
                    Surname = result.Surname,
                    SalaryPerMonth = result.SalaryPerMonth,
                    EmployeeType = result.EmployeeType,
                };
            }
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task Post(EmployeeEditDto employee) {
            var newEmployee = new Employee(employee.Name, employee.Surname, employee.SalaryPerMonth, employee.EmployeeType);
            await Task.Run(() => {
                _employeeRepo.Add(newEmployee);
            });
        }

        // PUT api/<EmployeeController>/5
        [HttpPut]
        public async Task Put(EmployeeEditDto employee) {
            var dbEmployee = await Task.Run(() => { return _employeeRepo.GetById(employee.Id); });
            if (dbEmployee == null) {
                // TODO: if dbEmployee is null
                return;
            }
            dbEmployee.Name = employee.Name;
            dbEmployee.Surname = employee.Surname;
            dbEmployee.SalaryPerMonth = employee.SalaryPerMonth;
            dbEmployee.EmployeeType = employee.EmployeeType;
            _employeeRepo.Update(employee.Id, dbEmployee);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id) {
            await Task.Run(() => { _employeeRepo.Delete(id); });
        }
    }
}
