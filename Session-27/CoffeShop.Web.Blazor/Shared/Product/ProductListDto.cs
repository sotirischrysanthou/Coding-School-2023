using CoffeeShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShop.Web.Blazor.Shared {
    public class ProductListDto {

        public int Id { get; set; }
        public String Code { get; set; } = null!;
        public String Description { get; set; } = null!;
        public decimal Price { get; set; } 
        public decimal Cost { get; set; }

        //TODO: relations
        public int ProductCategoryId { get; set; }

    }
}
