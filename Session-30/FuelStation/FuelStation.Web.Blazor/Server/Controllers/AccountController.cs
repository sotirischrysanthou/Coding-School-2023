using FuelStation.Authorization;
using FuelStation.EF.Repository;
using FuelStation.Model;
using FuelStation.Web.Blazor.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace FuelStation.Web.Blazor.Server.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase {
        // Properties
        private readonly IEntityRepo<Account> _accountRepo;
        private readonly IValidator _validator;
        private String _errorMessage;

        // Constructors
        public AccountController(IEntityRepo<Account> accountRepo, IValidator validator) {
            _accountRepo = accountRepo;
            _errorMessage = String.Empty;
            _validator = validator;
        }

        // GET: api/<AccountController>
        [HttpGet]
        [Authorize(Roles = "Manager")]
        public async Task<IEnumerable<AccountDto>?> Get() {
            try {
                var result = await _accountRepo.GetAll();
                var selectAccountList = result.Select(a => new AccountDto(a)).ToList();
                return selectAccountList;
            }
            catch (DbException) {
                return null;
            }
        }
        // POST api/<AcountController>
        [HttpPost]
        [Authorize(Roles = "Manager")]
        public async Task<ActionResult> Post(AccountDto newAccount) {

            var accounts = await _accountRepo.GetAll();
            if (_validator.ValidateAddOrUpdadteAccount(newAccount, accounts.ToList(), out _errorMessage)) {
                var dbAccount = new Account(newAccount.Id,
                                            newAccount.Username,
                                            newAccount.Password,
                                            newAccount.Role,
                                            newAccount.EmployeeId);
                try {
                    await _accountRepo.Add(dbAccount);
                    return Ok();
                }
                catch (DbException ex) {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest(_errorMessage);
        }

        // PUT api/<AccountController>/5
        [HttpPut]
        [Authorize(Roles = "Manager")]
        public async Task<ActionResult> Put(AccountDto account) {
            var accounts = await _accountRepo.GetAll();
            var dbAccount = accounts.Where(e => e.Id == account.Id).SingleOrDefault();
            if (dbAccount == null) {
                // TODO: if dbEmployee is null
                return BadRequest($"Account not found");
            }
            if (_validator.ValidateAddOrUpdadteAccount(account, accounts.ToList(), out _errorMessage)) {
                dbAccount.Username = account.Username;
                dbAccount.Password = account.Password;
                dbAccount.Role = account.Role;
                dbAccount.EmployeeId = account.EmployeeId;
                try {
                    await _accountRepo.Update(account.Id, dbAccount);
                }
                catch (DbUpdateException ex) {
                    return BadRequest(ex.Message);
                }
                return Ok();
            }
            else {
                return BadRequest(_errorMessage);
            }
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Manager")]
        public async Task<ActionResult> Delete(Guid id) {
            if (_validator.ValidateDeleteAccount(out _errorMessage)) {
                try {
                    await _accountRepo.Delete(id);
                }
                catch (KeyNotFoundException) {
                    return BadRequest($"Account not found");
                }
                return Ok();
            }
            return BadRequest(_errorMessage);
        }
    }

}