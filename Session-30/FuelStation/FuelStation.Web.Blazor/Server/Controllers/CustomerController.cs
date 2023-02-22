using FuelStation.EF.Repository;
using FuelStation.Model;
using FuelStation.Web.Blazor.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FuelStation.Web.Blazor.Server.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase {
        // Properties
        private readonly IEntityRepo<Customer> _cutomerRepo;

        // Constructors
        public CustomerController(IEntityRepo<Customer> customerRepo) {
            _cutomerRepo = customerRepo;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        [Authorize(Roles = "Manager,Cashier")]
        public async Task<IEnumerable<CustomerListDto>?> Get() {
            try {
                var result = await _cutomerRepo.GetAll();
                var selectCustomerList = result.Select(c => new CustomerListDto(c)).ToList();
                return selectCustomerList;
            } catch (DbException) {
                return null;
            }
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Manager,Cashier")]
        public async Task<CustomerEditDto?> GetById(Guid id) {
            try {
                var result = await _cutomerRepo.GetById(id);
                if (result == null) {
                    return null;
                }
                CustomerEditDto customer = new CustomerEditDto(result);
                return customer;
            } catch (DbException) {
                return null;
            }
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id:guid}")]
        [Authorize(Roles = "Manager,Cashier")]
        public async Task<CustomerDetailsDto?> GetByIdDetails(Guid id) {
            try {
                var result = await _cutomerRepo.GetById(id);
                if (result == null) {
                    return null;
                }
                CustomerDetailsDto customer = new CustomerDetailsDto(result);
                return customer;
            } catch (DbException) {
                return null;
            }
        }

        // POST api/<CustomerController>
        [HttpPost]
        [Authorize(Roles = "Manager,Cashier")]
        public async Task<ActionResult> Post(CustomerEditDto customer) {
            try {
                var newCustomer = new Customer(customer.Name,
                                               customer.Surname,
                                               customer.CardNumber);
                await _cutomerRepo.Add(newCustomer);
                return Ok();
            } catch (DbException ex) {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CustomerController>/5
        [HttpPut]
        [Authorize(Roles = "Manager,Cashier")]
        public async Task<ActionResult> Put(CustomerEditDto customer) {
            try {
                var dbCustomer = await _cutomerRepo.GetById(customer.Id);
                if (dbCustomer == null) {
                    return BadRequest($"Customer with ID: {customer.Id} not found!");
                }
                dbCustomer.Name = customer.Name;
                dbCustomer.Surname = customer.Surname;
                dbCustomer.CardNumber = customer.CardNumber;
                await _cutomerRepo.Update(dbCustomer.Id, dbCustomer);
                return Ok();
            } catch (DbException) {
                return BadRequest($"Customer with ID: {customer.Id} not found");
            }
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Manager,Cashier")]
        public async Task<ActionResult> Delete(Guid id) {
            try {
                await _cutomerRepo.Delete(id);
                return Ok();
            } catch (DbException) {
                return BadRequest($"Could not delete Customer because it has Transactions");
            }
        }
    }
}
