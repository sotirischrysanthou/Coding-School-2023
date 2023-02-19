using FuelStation.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Model {
    public class Transaction {
        // Properties
        [Required]public Guid Id { get; set; }

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
        [Required]
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;

        [Required]
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        public List<TransactionLine> TransactionLines { get; set; } = null!;

        // Constructors
        public Transaction(DateTime date, PaymentMethod paymentMethod, decimal totalValue, Guid employeeId, Guid customerId) {
            Id = Guid.NewGuid();
            Date = date;
            PaymentMethod = paymentMethod;
            TotalValue = totalValue;
            EmployeeId = employeeId;
            CustomerId = customerId;
        }
    }
}
