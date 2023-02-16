using CoffeeShop.EF.Repositories;
using CoffeeShop.Model;
using CoffeeShop.Model.Enums;
using CoffeShop.Web.Blazor.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoffeShop.Web.Blazor.Server.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase {
        // Properties
        private readonly IEntityRepo<Employee> _employeeRepo;
        private readonly IValidator _validator;
        public String errorMessage = String.Empty;

        // Constructors
        public EmployeeController(IEntityRepo<Employee> employeeRepo, IValidator validator) {
            _employeeRepo = employeeRepo;
            _validator = validator;
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

        // GET: api/<ProductsController>
        [Route("/employeelist/details/{id}")]
        [HttpGet]
        public async Task<EmployeeDetailsDto?> GetDetailsById(int id) {
            var result = await Task.Run(() => { return _employeeRepo.GetById(id); });
            if (result is null) {
                return null;
            } else {
                return new EmployeeDetailsDto {
                    Id = id,
                    Name = result.Name,
                    Surname = result.Surname,
                    SalaryPerMonth = result.SalaryPerMonth,
                    EmployeeType = result.EmployeeType,
                    Transactions = result.Transactions.Select(products => new TransactionListDto {
                        Date = products.Date,
                        TotalPrice = products.TotalPrice,
                        PaymentMethod = products.PaymentMethod,
                    }).ToList()
                };
            }
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<ActionResult> Post(EmployeeEditDto employee) {

            var newEmployee = new Employee(employee.Name, employee.Surname, employee.SalaryPerMonth, employee.EmployeeType);
            var employees = _employeeRepo.GetAll().ToList();
            if (_validator.ValidateAddEmployee(newEmployee.EmployeeType, employees, out errorMessage)) {
                try {
                    await Task.Run(() => { _employeeRepo.Add(newEmployee);});
                }catch(DbException ex) {
                    return BadRequest(ex.Message);
                }
                return Ok();
            }
            return BadRequest(errorMessage);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut]
        public async Task<ActionResult> Put(EmployeeEditDto employee) {
            var dbEmployee = await Task.Run(() => { return _employeeRepo.GetById(employee.Id); });
            if (dbEmployee == null) {
                // TODO: if dbEmployee is null
                return BadRequest($"Employee not found");
            } else if (_validator.ValidateUpdateEmployee(employee.EmployeeType, dbEmployee, _employeeRepo.GetAll().ToList(), out errorMessage)) {
                dbEmployee.Name = employee.Name;
                dbEmployee.Surname = employee.Surname;
                dbEmployee.SalaryPerMonth = employee.SalaryPerMonth;
                dbEmployee.EmployeeType = employee.EmployeeType;
                try {
                    _employeeRepo.Update(employee.Id, dbEmployee);
                } catch (DbUpdateException ex) {
                    return BadRequest(ex.Message);
                }
                return Ok();
            } else {
                return BadRequest(errorMessage);
            }
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id) {
            var employees = _employeeRepo.GetAll().ToList();
            if (_validator.ValidateDeleteEmployee(employees.Where(e => e.Id == id).Single().EmployeeType, employees, out errorMessage)) {
                try {
                    await Task.Run(() => { _employeeRepo.Delete(id); });
                } catch (DbUpdateException) {
                    return BadRequest($"Could not delete this employee because it has transactions");
                } catch (KeyNotFoundException) {
                    return BadRequest($"Employee not found");
                }
                return Ok();
            }
            return BadRequest(errorMessage);
        }
    }
}
