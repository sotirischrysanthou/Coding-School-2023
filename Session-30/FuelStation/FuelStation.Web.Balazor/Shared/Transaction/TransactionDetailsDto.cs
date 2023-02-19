using FuelStation.Model;
using FuelStation.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Web.Balazor.Shared {
    public class TransactionDetailsDto {
        // Properties
        [Required] public Guid Id { get; set; }

        [Required]
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Payment Type")]
        public PaymentMethod PaymentMethod { get; set; }

        [Required]
        [Display(Name = "Total Price")]
        [DataType(DataType.Currency)]
        public decimal TotalValue { get; set; }

        // Relations
        public EmployeeListDto Employee { get; set; } = null!;

        public CustomerListDto Customer { get; set; } = null!;

        // Relations
        public List<TransactionLineListDto> TransactionLines { get; set; } = null!;

        // Constructors
        public TransactionDetailsDto(Transaction transaction) {
            Id = transaction.Id;
            Date = transaction.Date;
            PaymentMethod = transaction.PaymentMethod;
            TotalValue = transaction.TotalValue;
        }
    }
}
