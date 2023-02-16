using CoffeeShop.EF.Repositories;
using CoffeeShop.Model;
using CoffeeShop.Model.Enums;
using CoffeShop.Web.Blazor.Shared;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoffeShop.Web.Blazor.Server.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase {
        // Properties
        private readonly IEntityRepo<Employee> _employeeRepo;
        public int errorCode = 0;

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
        public async Task<int> Post(EmployeeEditDto employee) {
            
            var newEmployee = new Employee(employee.Name, employee.Surname, employee.SalaryPerMonth, employee.EmployeeType);
            if (ValidateAddEmployee(newEmployee.EmployeeType)) {
                await Task.Run(() => {
                    _employeeRepo.Add(newEmployee);
                });
                errorCode = 0;
            }
            return errorCode;
        }
        private bool ValidateAddEmployee(EmployeeType type) {
            bool ret = true;
            var employees = _employeeRepo.GetAll();
            var cashiers = employees.Where(e => e.EmployeeType == EmployeeType.Cashier);
            var baristas = employees.Where(e => e.EmployeeType == EmployeeType.Barista);
            var managers = employees.Where(e => e.EmployeeType == EmployeeType.Manager);
            var waiters = employees.Where(e => e.EmployeeType == EmployeeType.Waiter);
            if (type == EmployeeType.Cashier && cashiers.Count() == 2) {
                ret = false;
                errorCode = 101;
            }
            if (type == EmployeeType.Barista && baristas.Count() == 2) {
                ret = false;
                errorCode = 102;
            }
            if (type == EmployeeType.Manager && managers.Count() == 1) {
                ret = false;
                errorCode = 103;
            }
            if (type == EmployeeType.Waiter && waiters.Count() == 3) {
                ret = false;
                errorCode = 104;
            }
            return ret;
        }

        // PUT api/<EmployeeController>/5
        [HttpPut]
        public async Task<bool> Put(EmployeeEditDto employee) {
            var dbEmployee = await Task.Run(() => { return _employeeRepo.GetById(employee.Id); });
            if (dbEmployee == null) {
                // TODO: if dbEmployee is null
                return false;
            } else if (ValidateUpdateEmployee(employee.EmployeeType, dbEmployee)) {
                dbEmployee.Name = employee.Name;
                dbEmployee.Surname = employee.Surname;
                dbEmployee.SalaryPerMonth = employee.SalaryPerMonth;
                dbEmployee.EmployeeType = employee.EmployeeType;
                _employeeRepo.Update(employee.Id, dbEmployee);
                return true;
            } else {
                return false;
            }
        }

        private bool ValidateUpdateEmployee(EmployeeType type, Employee dbEmployee) {
            bool ret = true;
            var employees = _employeeRepo.GetAll();
            if (dbEmployee == null) {
                ret = false;
            } else {
                var cashiers = employees.Where(e => e.EmployeeType == EmployeeType.Cashier);
                var baristas = employees.Where(e => e.EmployeeType == EmployeeType.Barista);
                var managers = employees.Where(e => e.EmployeeType == EmployeeType.Manager);
                var waiters = employees.Where(e => e.EmployeeType == EmployeeType.Waiter);
                if (type == EmployeeType.Cashier && cashiers.Count() == 2) {
                    ret = false;
                }
                if (type == EmployeeType.Barista && baristas.Count() == 2) {
                    ret = false;
                }
                if (type == EmployeeType.Manager && managers.Count() == 1) {
                    ret = false;
                }
                if (type == EmployeeType.Waiter && waiters.Count() == 3) {
                    ret = false;
                }
            }
            return ret;
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id) {
            if (ValidateDeleteEmployee(id)) {
                await Task.Run(() => { _employeeRepo.Delete(id); });
                return true;
            }
            return false;
        }

        private bool ValidateDeleteEmployee(int id) {
            bool ret = true;
            var employees = _employeeRepo.GetAll();
            var cashiers = employees.Where(e => e.EmployeeType == EmployeeType.Cashier);
            var baristas = employees.Where(e => e.EmployeeType == EmployeeType.Barista);
            var managers = employees.Where(e => e.EmployeeType == EmployeeType.Manager);
            var waiters = employees.Where(e => e.EmployeeType == EmployeeType.Waiter);
            var employee = _employeeRepo.GetById(id);
            if (employee == null) {
                ret = false;
            } else {
                EmployeeType type = employee.EmployeeType;
                if (type == EmployeeType.Cashier && cashiers.Count() == 1) {
                    ret = false;
                }
                if (type == EmployeeType.Barista && baristas.Count() == 1) {
                    ret = false;
                }
                if (type == EmployeeType.Manager && managers.Count() == 1) {
                    ret = false;
                }
                if (type == EmployeeType.Waiter && waiters.Count() == 1) {
                    ret = false;
                }
            }
            return ret;
        }
    }
}
