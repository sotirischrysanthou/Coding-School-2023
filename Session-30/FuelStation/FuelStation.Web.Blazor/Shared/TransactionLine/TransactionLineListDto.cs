using FuelStation.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Web.Blazor.Shared {
    public class TransactionLineListDto {
        // Properties
        [Required] public Guid Id { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        [Display(Name = "Item Price")]
        [DataType(DataType.Currency)]
        public decimal ItemPrice { get; set; }

        [Required]
        [Display(Name = "Net Value")]
        [DataType(DataType.Currency)]
        public decimal NetValue { get; set; }

        [Required]
        [Display(Name = "Discount Percent")]
        [Range(0, 100)]
        public decimal DiscountPercent { get; set; }

        [Display(Name = "Discount Value")]
        [DataType(DataType.Currency)]
        public decimal DiscountValue { get; set; }

        [Required]
        [Display(Name = "Total Value")]
        [DataType(DataType.Currency)]
        public decimal TotalValue { get; set; }

        // Relations
        public ItemListDto Item { get; set; } = null!;

        // Constructors
        public TransactionLineListDto() {

        }
        public TransactionLineListDto(TransactionLine transactionLine) {
            Id = transactionLine.Id;
            Quantity = transactionLine.Quantity;
            DiscountPercent = transactionLine.DiscountPercent;
            Item = new ItemListDto(transactionLine.Item);
            ItemPrice = transactionLine.ItemPrice;
            NetValue = transactionLine.NetValue;
            DiscountValue = transactionLine.DiscountValue;
            TotalValue = transactionLine.TotalValue;
        }
    }
}
