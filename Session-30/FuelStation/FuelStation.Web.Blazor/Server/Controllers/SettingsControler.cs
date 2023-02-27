using FuelStation.EF.Repository;
using FuelStation.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FuelStation.Web.Blazor.Server.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsControler : ControllerBase {
        // Properties
        private readonly IEntityRepo<Settings> _settingsRepo;

        public SettingsControler(IEntityRepo<Settings> settingsRepo) {
            _settingsRepo = settingsRepo;
        }

        [HttpGet]
        public async Task<Settings?> Get() {
            return await _settingsRepo.GetById(Guid.Empty);
        }

        [HttpPut]
        public async Task Put(Settings settings) {
            await _settingsRepo.Update(Guid.Empty, settings);
        }
    }
}
