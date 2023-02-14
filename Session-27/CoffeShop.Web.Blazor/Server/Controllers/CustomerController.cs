using CoffeeShop.EF.Repositories;
using CoffeeShop.Model;
using CoffeShop.Web.Blazor.Shared.Customer;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoffeShop.Web.Blazor.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase {
        // Properties
        private readonly IEntityRepo<Customer> _customerRepo;

        // Constructors
        public CustomerController(IEntityRepo<Customer> cutomerRepo) {
            _customerRepo = cutomerRepo;
        }

        // GET: api/<CustomersController>
        [HttpGet]
        public async Task<IEnumerable<EmployeeListDto>> Get() {
            var result = _customerRepo.GetAll();
            var selectCustomerList= result.Select(customer => new EmployeeListDto {
                Id = customer.Id,
                Code = customer.Code,
                Description = customer.Description,
            });
            return selectCustomerList;
        }

        // GET: api/<CustomersController>
        [HttpGet("{id}")]
        public async Task<EmployeeEditDto> GetById(int id) {
            var result = _customerRepo.GetById(id);
            return new EmployeeEditDto {
                Id = id,
                Code = result.Code,
                Description = result.Description,
            };
        }

        // POST api/<CustomersController>
        [HttpPost]
        public async Task Post(EmployeeEditDto customer) {
            var newCustomer = new Customer(customer.Code, customer.Description);
            _customerRepo.Add(newCustomer);
        }

        // PUT api/<CustomersController>/5
        [HttpPut]
        public async Task Put(EmployeeEditDto customer) {
            var dbCustomer = _customerRepo.GetById(customer.Id);
            dbCustomer.Code = customer.Code;
            dbCustomer.Description = customer.Description;
            _customerRepo.Update(customer.Id, dbCustomer);
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id) {
            _customerRepo.Delete(id);
        }
    }
}
