using CoffeShop.Web.Blazor.Shared;
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
    public class ItemController : ControllerBase {
        // Properties
        private readonly IEntityRepo<Item> _itemRepo;
        private readonly IValidator _validator;
        private String _errorMessage;
        // Constructors
        public ItemController(IEntityRepo<Item> itemRepo, IValidator validator) {
            _itemRepo = itemRepo;
            _validator = validator;
            _errorMessage = String.Empty;
        }

        // GET: api/<ItemController>
        [HttpGet]
        [Authorize(Roles = "Manager,Staff")]
        public async Task<IEnumerable<ItemListDto>?> Get() {
            try {
                var result = await _itemRepo.GetAll();
                var selectItemList = result.Select(i => new ItemListDto(i)).ToList();
                return selectItemList;
            } catch (DbException) {
                return null;
            }
        }

        // GET api/<ItemController>/5
        [Route("/api/item/edit/{id:guid}")]
        [HttpGet("{id:guid}")]
        [Authorize(Roles = "Manager,Staff")]
        public async Task<ItemEditDto?> GetById(Guid id) {
            try {
                var result = await _itemRepo.GetById(id);
                if (result == null) {
                    return null;
                }
                ItemEditDto item = new ItemEditDto(result);
                return item;
            } catch (DbException) {
                return null;
            }
        }

        // GET api/<ItemController>/5
        [Route("/api/item/details/{id:guid}")]
        [HttpGet("{id:guid}")]
        [Authorize(Roles = "Manager,Staff")]
        public async Task<ItemDetailsDto?> GetByIdDetails(Guid id) {
            try {
                var result = await _itemRepo.GetById(id);
                if (result == null) {
                    return null;
                }
                ItemDetailsDto Item = new ItemDetailsDto(result);
                return Item;
            } catch (DbException) {
                return null;
            }
        }

        // POST api/<ItemController>
        [HttpPost]
        [Authorize(Roles = "Manager,Staff")]
        public async Task<ActionResult> Post([FromBody] ItemEditDto item) {
            try {
                var items = await _itemRepo.GetAll();
                if (_validator.ValidateAddItem(items.ToList(), item, out _errorMessage)) {
                    var newItem = new Item(item.Code,
                                               item.Description,
                                               item.ItemType,
                                               item.Price,
                                               item.Cost);
                    await _itemRepo.Add(newItem);
                    return Ok();
                } else {
                    return BadRequest(_errorMessage);
                }
            } catch (DbException ex) {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ItemController>/5
        [HttpPut]
        [Authorize(Roles = "Manager,Staff")]
        public async Task<ActionResult> Put([FromBody] ItemEditDto item) {
            try {
                var items = await _itemRepo.GetAll();
                var dbItem = items.Where(c => c.Id == item.Id).SingleOrDefault();
                if (dbItem == null) {
                    return BadRequest($"item with ID: {item.Id} not found!");
                }
                if (_validator.ValidateUpdateItem(items.ToList(), dbItem, item, out _errorMessage)) {
                    dbItem.Code = item.Code;
                    dbItem.Description = item.Description;
                    dbItem.ItemType = item.ItemType;
                    dbItem.Price = item.Price;
                    dbItem.Cost = item.Cost;
                    await _itemRepo.Update(dbItem.Id, dbItem);
                    return Ok();
                } else {
                    return BadRequest(_errorMessage);
                }
            } catch (DbException) {
                return BadRequest($"item with ID: {item.Id} not found");
            }
        }

        // DELETE api/<ItemController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Manager,Staff")]
        public async Task<ActionResult> Delete(Guid id) {
            try {
                var Items = await _itemRepo.GetAll();
                if (_validator.ValidateDeleteItem(Items.ToList(), out _errorMessage)) {
                    await _itemRepo.Delete(id);
                    return Ok();
                } else {
                    return BadRequest(_errorMessage);
                }
            } catch (DbException) {
                return BadRequest($"Could not delete Item because it has Transactions");
            }
        }
    }
}
