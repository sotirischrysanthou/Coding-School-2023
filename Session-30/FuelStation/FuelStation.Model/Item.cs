using FuelStation.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FuelStation.Model {
    public class Item {
        // Properties
        public Guid Id { get; set; }

        [Required]
        public String Code { get; set; }

        [Required]
        public String Description { get; set; }

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
        public List<TransactionLine> TransactionLines { get; set; } = null!;

        // Constructors
        public Item(String code, String description, ItemType itemType, decimal price, decimal cost) {
            Id = Guid.NewGuid();
            Code = code;
            Description = description;
            ItemType = itemType;
            Price = price;
            Cost = cost;
        }
    }
}
