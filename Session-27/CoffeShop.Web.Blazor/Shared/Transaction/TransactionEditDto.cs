using CoffeeShop.Model.Enums;
using CoffeeShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeShop.Web.Blazor.Shared.TransactionLine;

namespace CoffeShop.Web.Blazor.Shared.Transaction {
    public class TransactionEditDto {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalPrice { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        // Relations
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public List<TransactionLineEditDto> TransactionLines { get; set; } = null!;
    }
}
