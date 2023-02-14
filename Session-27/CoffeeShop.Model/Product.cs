namespace CoffeeShop.Model
{
    public class Product
    {
        public Product(String code, String description, decimal price, decimal cost)
        {
            Code = code;
            Description = description;
            Price = price;
            Cost = cost;

            TransactionLines = new List<TransactionLine>();
        }

        public int Id { get; set; }
        public String Code { get; set; }
        public String Description { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }

        // Relations
        public int ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; } = null!;

        public List<TransactionLine> TransactionLines { get; set; }
    }
}
