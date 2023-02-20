using FuelStation.Model;
using FuelStation.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Web.Blazor.Shared {
    public class ItemListDto {
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

        // Constructors
        public ItemListDto(Item item) {
            Id = item.Id;
            Code = item.Code;
            Description = item.Description;
            ItemType = item.ItemType;
            Price = item.Price;
            Cost = item.Cost;
        }
    }
}
