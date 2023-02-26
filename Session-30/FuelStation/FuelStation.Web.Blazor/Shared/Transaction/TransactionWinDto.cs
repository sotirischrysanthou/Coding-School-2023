using FuelStation.Model.Enums;
using FuelStation.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Web.Blazor.Shared {
    public class TransactionWinDto {
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
        public List<TransactionLineWinDto> TransactionLines { get; set; } = new();
        public Guid EmployeeId { get; set; }
        public Guid CustomerId { get; set; }

        // Constructors
        public TransactionWinDto() {

        }
        public TransactionWinDto(Transaction transaction) {
            Id = transaction.Id;
            Date = transaction.Date;
            PaymentMethod = transaction.PaymentMethod;
            TotalValue = transaction.TotalValue;
            EmployeeId = transaction.EmployeeId;
            CustomerId = transaction.CustomerId;
            TransactionLines = transaction.TransactionLines.Select(t => new TransactionLineWinDto(t)).ToList();
        }
    }
}
