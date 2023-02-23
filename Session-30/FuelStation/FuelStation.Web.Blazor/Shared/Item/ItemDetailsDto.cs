using FuelStation.Model.Enums;
using FuelStation.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Web.Blazor.Shared {
    public class ItemDetailsDto {
        // Properties
        public Guid Id { get; set; }

        [Required]
        public String Code { get; set; } = null!;

        [Required]
        public String Description { get; set; } = null!;

        [Required]
        [Display(Name = "Item Type")]
        public ItemType ItemType { get; set; }

        [Required]
        [Display(Name = "Price")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Cost")]
        [DataType(DataType.Currency)]
        public decimal Cost { get; set; }

        // Relations
        public List<TransactionLineDetailsDto> TransactionLines { get; set; } = null!;

        // Constructors
        public ItemDetailsDto() {

        }
        public ItemDetailsDto(Item item) {
            Id = item.Id;
            Code = item.Code;
            Description = item.Description;
            ItemType = item.ItemType;
            Price = item.Price;
            Cost = item.Cost;
            TransactionLines = item.TransactionLines.Select(t => new TransactionLineDetailsDto(t)).ToList();
        }
    }
}
