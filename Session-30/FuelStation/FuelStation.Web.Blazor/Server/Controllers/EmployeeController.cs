using FuelStation.Web.Blazor.Shared;
using FuelStation.EF.Repository;
using FuelStation.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace FuelStation.Web.Blazor.Server.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase {
        // Properties
        private readonly IEntityRepo<Employee> _employeeRepo;
        private readonly IValidator _validator;
        public String _errorMessage = String.Empty;

        // Constructors
        public EmployeeController(IEntityRepo<Employee> employeeRepo, IValidator validator) {
            _employeeRepo = employeeRepo;
            _validator = validator;
            Uri baseUrl = new Uri("https://localhost:5000");
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        [Authorize(Roles = "Manager,Cashier")]
        public async Task<ActionResult<IEnumerable<EmployeeListDto>>> Get() {
            var result = await _employeeRepo.GetAll();
            var selectEmployeeList = result.Select(employee => new EmployeeListDto(employee)).ToList();
            return selectEmployeeList;
        }

        // GET: api/<EmployeeController>
        [Route("/api/employee/edit/{id}")]
        [HttpGet("{id:guid}")]
        [Authorize(Roles = "Manager")]
        public async Task<ActionResult<EmployeeEditDto?>> GetById(Guid id) {
            var result = await _employeeRepo.GetById(id);
            if (result == null) {
                return NotFound("Employee not Found");
            } else {
                return new EmployeeEditDto(result);
            }
        }

        // GET: api/<ProductsController>
        [Route("/api/employee/details/{id}")]
        [HttpGet("{id:guid}")]
        [Authorize(Roles = "Manager")]
        public async Task<EmployeeDetailsDto?> GetDetailsById(Guid id) {
            var result = await _employeeRepo.GetById(id);
            if (result is null) {
                return null;
            } else {
                return new EmployeeDetailsDto(result);
            }
        }

        // POST api/<EmployeeController>
        [HttpPost]
        [Authorize(Roles = "Manager")]
        public async Task<ActionResult<String>> Post(EmployeeEditDto newEmployee) {

            var employees = await _employeeRepo.GetAll();
            if (_validator.ValidateAddEmployee(newEmployee, employees.ToList(), out _errorMessage)) {
                var dbEmployee = new Employee(newEmployee.Name,
                                              newEmployee.Surname,
                                              newEmployee.HireDateStart,
                                              newEmployee.SalaryPerMonth,
                                              newEmployee.EmployeeType,
                                              newEmployee.Account.Id);
                try {
                    await _employeeRepo.Add(dbEmployee);
                    return Ok(dbEmployee.Id.ToString());
                } catch (DbException ex) {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest(_errorMessage);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut]
        [Authorize(Roles = "Manager")]
        public async Task<ActionResult> Put(EmployeeEditDto employee) {
            var employees = await _employeeRepo.GetAll();
            var dbEmployee = employees.Where(e => e.Id == employee.Id).SingleOrDefault();
            if (dbEmployee == null) {
                // TODO: if dbEmployee is null
                return BadRequest($"Employee not found");
            }
            if (_validator.ValidateUpdateEmployee(employee, dbEmployee, employees.ToList(), out _errorMessage)) {
                dbEmployee.Name = employee.Name;
                dbEmployee.Surname = employee.Surname;
                dbEmployee.HireDateStart = employee.HireDateStart;
                dbEmployee.HireDateEnd = employee.HireDateEnd;
                dbEmployee.SalaryPerMonth = employee.SalaryPerMonth;
                dbEmployee.EmployeeType = employee.EmployeeType;
                try {
                    await _employeeRepo.Update(employee.Id, dbEmployee);
                } catch (DbUpdateException ex) {
                    return BadRequest(ex.Message);
                }
                return Ok();
            } else {
                return BadRequest(_errorMessage);
            }
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Manager")]
        public async Task<ActionResult> Delete(Guid id) {
            var employees = await _employeeRepo.GetAll();
            var employee = employees.Where(e => e.Id == id).Single();
            if (_validator.ValidateDeleteEmployee(employee.EmployeeType, employees.ToList(), out _errorMessage)) {
                try {
                    await _employeeRepo.Delete(id);
                } catch (DbUpdateException) {
                    return BadRequest($"Can not delete this employee because it has transactions");
                } catch (KeyNotFoundException) {
                    return BadRequest($"Employee not found");
                }
                return Ok();
            }
            return BadRequest(_errorMessage);
        }
    }
}
