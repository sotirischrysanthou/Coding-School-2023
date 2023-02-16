using CoffeeShop.Model.Enums;
using CoffeeShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeShop.Web.Blazor.Shared;
using System.ComponentModel.DataAnnotations;

namespace CoffeShop.Web.Blazor.Shared {
    public class TransactionEditDto {

        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [Range(0, 99999999.99, ErrorMessage = "The range is from 0 to 99999999.99!")]
        public decimal TotalPrice { get; set; }

        [Required]
        [Range(1, 2, ErrorMessage = "You must choose a payment method!")]
        public PaymentMethod PaymentMethod { get; set; }

        // Relations
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public List<TransactionLineEditDto> TransactionLines { get; set; } = new();
    }
}
