using CoffeeShop.Model.Enums;
using CoffeeShop.Model;


namespace CoffeShop.Web.Blazor.Shared {
    public class TransactionListDto {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalPrice { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        // Relations
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }

        //public List<TransactionLine> TransactionLines { get; set; } = null!;
    }
}
