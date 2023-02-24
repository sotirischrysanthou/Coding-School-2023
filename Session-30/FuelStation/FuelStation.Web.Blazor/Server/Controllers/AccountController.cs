using FuelStation.Authorization;
using FuelStation.EF.Repository;
using FuelStation.Model;
using FuelStation.Web.Blazor.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;

namespace FuelStation.Web.Blazor.Server.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase {
        // Properties
        private readonly IEntityRepo<Account> _accountRepo;

        // Constructors
        public AccountController(IEntityRepo<Account> accountRepo) {
            _accountRepo = accountRepo;
        }

        // GET: api/<AccountController>
        [HttpGet]
        [Authorize(Roles = "Manager")]
        public async Task<IEnumerable<AccountDto>?> Get() {
            try {
                var result = await _accountRepo.GetAll();
                var selectAccountList = result.Select(a => new AccountDto(a)).ToList();
                return selectAccountList;
            } catch (DbException) {
                return null;
            }
        }
    }
}