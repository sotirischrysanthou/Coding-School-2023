using CoffeeShop.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShop.Web.Blazor.Shared {
    public class ProductCategoryListDto {
        public int Id { get; set; }
        public String Code { get; set; } = null!;
        public String Description { get; set; } = null!;
        public ProductType ProductType { get; set; }
    }
}