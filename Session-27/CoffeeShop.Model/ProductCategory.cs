using CoffeeShop.Model.Enums;

namespace CoffeeShop.Model
{
    public class ProductCategory
    {
        public ProductCategory(String code, String description, ProductType productType)
        {
            Code = code;
            Description = description;
            ProductType = productType;

            Products = new List<Product>();
        }

            public int Id { get; set; }
        public String Code { get; set; }
        public String Description { get; set; }
        public ProductType ProductType { get; set; }

        // Relations
        public List<Product> Products { get; set; }
    }
}
