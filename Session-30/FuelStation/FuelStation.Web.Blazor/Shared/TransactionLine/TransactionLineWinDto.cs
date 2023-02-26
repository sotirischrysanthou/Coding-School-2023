using FuelStation.Model;
using FuelStation.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Web.Blazor.Shared {
    public class TransactionLineWinDto {
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

        public ItemType ItemType { get; set; }
        // Relations
        public Guid ItemId { get; set; }
        public Guid TransactionId { get; set; }

        // Constructors
        public TransactionLineWinDto() {

        }
        public TransactionLineWinDto(TransactionLine transactionLine) {
            Id = transactionLine.Id;
            Quantity = transactionLine.Quantity;
            DiscountPercent = transactionLine.DiscountPercent;
            ItemPrice = transactionLine.ItemPrice;
            NetValue = transactionLine.NetValue;
            DiscountValue = transactionLine.DiscountValue;
            TotalValue = transactionLine.TotalValue;
            TransactionId = transactionLine.TransactionId;
            ItemId = transactionLine.ItemId;
        }
    }
}
