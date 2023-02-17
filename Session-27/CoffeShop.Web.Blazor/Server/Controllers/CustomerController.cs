using CoffeeShop.EF.Repositories;
using CoffeeShop.Model;
using CoffeShop.Web.Blazor.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoffeShop.Web.Blazor.Server.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase {
        // Properties
        private readonly IEntityRepo<Customer> _customerRepo;
        private readonly IValidator _validator;
        private String _errorMessage;

        // Constructors
        public CustomerController(IEntityRepo<Customer> cutomerRepo, IValidator validator) {
            _customerRepo = cutomerRepo;
            _validator = validator;
            _errorMessage = String.Empty;
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
            CustomerEditDto customer = new CustomerEditDto {
                Id = id,
                Code = result.Code,
                Description = result.Description,
            };
            return customer;
        }

        // POST api/<CustomersController>
        [HttpPost]
        public async Task<ActionResult> Post(CustomerEditDto customer) {
            var newCustomer = new Customer(customer.Code, customer.Description);
            if (_validator.ValidateAddCustomer(_customerRepo.GetAll().ToList(), out _errorMessage)) {
                try {
                    await Task.Run(() => { _customerRepo.Add(newCustomer); });
                    return Ok();
                } catch (DbException ex) {
                    return BadRequest(ex.Message);
                }
            } else {
                return BadRequest(_errorMessage);
            }
        }

        // PUT api/<CustomersController>/5
        [HttpPut]
        public async Task Put(CustomerEditDto customer) {
            var dbCustomer = await Task.Run(() => { return _customerRepo.GetById(customer.Id); });
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
        public async Task<ActionResult> Delete(int id) {
            if (_validator.ValidateDeleteCustomer(_customerRepo.GetAll().ToList(), out _errorMessage)) {
                try {
                    await Task.Run(() => { _customerRepo.Delete(id); });
                } catch (DbException) {
                    return BadRequest("The customer cannot be deleted because they are in Transactions");
                }
                return Ok();
            } else {
                return BadRequest(_errorMessage);
            }
        }
    }
}
