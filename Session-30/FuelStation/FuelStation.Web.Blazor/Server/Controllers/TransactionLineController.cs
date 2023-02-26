using FuelStation.EF.Repository;
using FuelStation.Model;
using FuelStation.Web.Blazor.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FuelStation.Web.Blazor.Server.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionLineController : ControllerBase {
        // Properties
        private readonly IEntityRepo<TransactionLine> _transactionLineRepo;

        // Constructors
        public TransactionLineController(IEntityRepo<TransactionLine> transactionLineRepo) {
            _transactionLineRepo = transactionLineRepo;
        }

        // POST api/<TransactionLineController>
        [HttpPost]
        [Authorize(Roles = "Manager,Cashier")]
        public async Task<ActionResult> Post(TransactionLineWinDto transactionLine) {
            var newTransactionLine = new TransactionLine(transactionLine.Quantity,
                                                         transactionLine.NetValue,
                                                         transactionLine.DiscountPercent,
                                                         transactionLine.DiscountValue,
                                                         transactionLine.TotalValue,
                                                         transactionLine.TransactionId,
                                                         transactionLine.ItemId
                                                         );
            await _transactionLineRepo.Add(newTransactionLine);
            return Ok();
        }

        // PUT api/<TransactionLineController>/5
        [HttpPut]
        [Authorize(Roles = "Manager,Cashier")]
        public async Task<ActionResult> Put(TransactionLineWinDto transactionLine) {
            var dbTransactionLine = await _transactionLineRepo.GetById(transactionLine.Id);
            if (dbTransactionLine is null) {
                //Todo: handle if dbTransaction is null
                return NotFound("TransactionLine not Found");
            }
            dbTransactionLine.Quantity = transactionLine.Quantity;
            dbTransactionLine.NetValue = transactionLine.NetValue;
            dbTransactionLine.DiscountPercent = transactionLine.DiscountPercent;
            dbTransactionLine.TotalValue = transactionLine.TotalValue;
            dbTransactionLine.ItemId = transactionLine.ItemId;

            await _transactionLineRepo.Update(transactionLine.Id, dbTransactionLine);
            return Ok();
        }

        // DELETE api/<TransactionLineController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Manager,Cashier")]
        public async Task<ActionResult> Delete(Guid id) {
            try {
                await _transactionLineRepo.Delete(id);
                return Ok();
            } catch (KeyNotFoundException) {
                return BadRequest($"Transaction not found");
            }
        }
    }
}
