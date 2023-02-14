using CoffeeShop.Model.Enums;
using CoffeeShop.Model;


namespace CoffeShop.Web.Blazor.Shared.Transaction {
    public class TransactionListDto {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalPrice { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        // Relations
        public CoffeeShop.Model.Customer Customer { get; set; }
        public CoffeeShop.Model.Employee Employee { get; set; }

        //public List<TransactionLine> TransactionLines { get; set; } = null!;
    }
}
