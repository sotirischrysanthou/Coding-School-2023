using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml.Linq;

namespace FuelStation.Model {
    public class TransactionLine {
        // Properties
        public Guid Id { get; set; }

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
        
        // Relation
        [Required]
        public Guid TransactionId { get; set; }

        public Transaction Transaction { get; set; } = null!;
        
        [Required]
        public Guid ItemId { get; set; }

        public Item Item { get; set; } = null!;

        // Constructor
        public TransactionLine(int quantity, decimal netValue, decimal discountPercent, decimal discountValue, decimal totalValue, Guid transactionId, Guid itemId) {
            Id = Guid.NewGuid();
            Quantity= quantity;
            NetValue= netValue;
            DiscountPercent= discountPercent;
            DiscountValue= discountValue;
            TotalValue= totalValue;
            TransactionId= transactionId;
            ItemId= itemId;
        }
    }
}
