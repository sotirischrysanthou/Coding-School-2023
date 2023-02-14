using CoffeeShop.EF.Repositories;
using CoffeeShop.Model;
using CoffeShop.Web.Blazor.Shared.Customer;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoffeShop.Web.Blazor.Server.Controllers {
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
            var result = await Task.Run(() => { return _customerRepo.GetAll(); });
            var selectCustomerList = result.Select(customer => new CustomerListDto {
                Id = customer.Id,
                Code = customer.Code,
                Description = customer.Description,
            });
            return selectCustomerList;
        }

        // GET: api/<CustomersController>
        [HttpGet("{id}")]
        public async Task<CustomerEditDto?> GetById(int id) {
            var result = await Task.Run(() => { return _customerRepo.GetById(id); });
            if (result == null) {
                return null;
            }
            return new CustomerEditDto {
                Id = id,
                Code = result.Code,
                Description = result.Description,
            };
        }

        // POST api/<CustomersController>
        [HttpPost]
        public async Task Post(CustomerEditDto customer) {
            var newCustomer = new Customer(customer.Code, customer.Description);
            await Task.Run(() => {
                _customerRepo.Add(newCustomer);
            });
        }

        // PUT api/<CustomersController>/5
        [HttpPut]
        public async Task Put(CustomerEditDto customer) {
            var dbCustomer = _customerRepo.GetById(customer.Id);
            if (dbCustomer == null) {
                // TODO if customer is null
                return;
            }
            dbCustomer.Code = customer.Code;
            dbCustomer.Description = customer.Description;
            _customerRepo.Update(customer.Id, dbCustomer);
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id) {
            await Task.Run(() => {
                _customerRepo.Delete(id);
            });
        }
    }
}
