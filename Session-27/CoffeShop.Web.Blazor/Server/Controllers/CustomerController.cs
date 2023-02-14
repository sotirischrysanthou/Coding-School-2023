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
        public async Task<IEnumerable<CustomerListDto>> Get() {
            var result = _customerRepo.GetAll();
            var selectCustomerList= result.Select(customer => new CustomerListDto {
                Id = customer.Id,
                Code = customer.Code,
                Description = customer.Description,
            });
            return selectCustomerList;
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public String Get(int id) {
            return "value";
        }

        // POST api/<CustomersController>
        [HttpPost]
        public void Post([FromBody] String value) {
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public async Task Put(CustomerEditDto customer) {
            var dbCustomer = _customerRepo.GetById(customer.Id);
            dbCustomer.Code = customer.Code;
            dbCustomer.Description = customer.Description;
            _customerRepo.Update(customer.Id, dbCustomer);
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }
}
