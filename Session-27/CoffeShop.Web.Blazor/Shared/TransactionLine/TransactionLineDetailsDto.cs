using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShop.Web.Blazor.Shared {
    public class TransactionLineDetailsDto {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }

        // Relations
        public int TransactionId { get; set; }
        public int ProductId { get; set; }
        public ProductListDto Product { get; set; } = null!;
    }
}
