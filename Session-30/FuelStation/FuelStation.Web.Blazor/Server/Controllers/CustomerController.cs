using FuelStation.Web.Blazor.Shared;
using FuelStation.EF.Repository;
using FuelStation.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Data.Common;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FuelStation.Web.Blazor.Server.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase {
        // Properties
        private readonly IEntityRepo<Customer> _cutomerRepo;
        private readonly IValidator _validator;
        private String _errorMessage;

        // Constructors
        public CustomerController(IEntityRepo<Customer> customerRepo, IValidator validator) {
            _cutomerRepo = customerRepo;
            _validator = validator;
            _errorMessage = String.Empty;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        [Authorize(Roles = "Manager,Cashier")]
        public async Task<ActionResult<IEnumerable<CustomerListDto>?>> Get() {
            try {
                var result = await _cutomerRepo.GetAll();
                var selectCustomerList = result.Select(c => new CustomerListDto(c)).ToList();
                return Ok(selectCustomerList);
            } catch (DbException) {
                return NotFound("Customer list was not found. Please contact support");
            }
        }

        // GET api/<CustomerController>/5
        [Route("/api/customer/edit/{id:guid}")]
        [HttpGet("{id:guid}")]
        [Authorize(Roles = "Manager,Cashier")]
        public async Task<ActionResult<CustomerEditDto?>> GetById(Guid id) {
            try {
                var result = await _cutomerRepo.GetById(id);
                if (result == null) {
                    return NotFound("The requested Customer was not found. Please contact support");
                }
                CustomerEditDto customer = new CustomerEditDto(result);
                return Ok(customer);
            } catch (DbException) {
                return NotFound("The requested Customer was not found. Please contact support");
            }
        }

        // GET api/<CustomerController>/5
        [Route("/api/customer/details/{id:guid}")]
        [HttpGet("{id:guid}")]
        [Authorize(Roles = "Manager,Cashier")]
        public async Task<ActionResult<CustomerDetailsDto?>> GetByIdDetails(Guid id) {
            try {
                var result = await _cutomerRepo.GetById(id);
                if (result == null) {
                    return NotFound("The requested Customer was not found. Please contact support");
                }
                CustomerDetailsDto customer = new CustomerDetailsDto(result);
                return Ok(customer);
            } catch (DbException) {
                return NotFound("The requested Customer was not found. Please contact support");
            }
        }

        // POST api/<CustomerController>
        [HttpPost]
        [Authorize(Roles = "Manager,Cashier")]
        public async Task<ActionResult<String>> Post(CustomerEditDto customer) {
            try {
                var customers = await _cutomerRepo.GetAll();
                String newCardNumber = String.Empty;
                if (_validator.ValidateAddCustomer(customers.ToList(), customer, out newCardNumber, out _errorMessage)) {
                    var newCustomer = new Customer(customer.Name,
                                                   customer.Surname,
                                                   newCardNumber);
                    await _cutomerRepo.Add(newCustomer);
                    return Ok(newCardNumber);
                } else {
                    return BadRequest(_errorMessage);
                }
            } catch (DbException ex) {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CustomerController>/5
        [HttpPut]
        [Authorize(Roles = "Manager,Cashier")]
        public async Task<ActionResult> Put(CustomerEditDto customer) {
            try {
                if (_validator.ValidateUpdateCustomer(customer, out _errorMessage)) {
                    var dbCustomer = await _cutomerRepo.GetById(customer.Id);
                    if (dbCustomer == null) {
                        return BadRequest($"Customer with ID: {customer.Id} not found!");
                    }
                    dbCustomer.Name = customer.Name;
                    dbCustomer.Surname = customer.Surname;
                    //dbCustomer.CardNumber = customer.CardNumber;
                    await _cutomerRepo.Update(dbCustomer.Id, dbCustomer);
                    return Ok();
                } else {
                    return BadRequest(_errorMessage);
                }
            } catch (DbException) {
                return BadRequest($"Customer with ID: {customer.Id} not found");
            }
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "Manager,Cashier")]
        public async Task<ActionResult> Delete(Guid id) {
            try {
                var customer = await _cutomerRepo.GetById(id);
                if(customer is null) {
                    return NotFound("Customer not Found");
                }
                if (_validator.ValidateDeleteCustomer(customer, out _errorMessage)) {
                    await _cutomerRepo.Delete(id);
                    return Ok();
                } else {
                    return BadRequest(_errorMessage);
                }
            } catch (DbException) {
                return BadRequest($"Could not delete Customer because it has Transactions");
            }
        }
    }
}
