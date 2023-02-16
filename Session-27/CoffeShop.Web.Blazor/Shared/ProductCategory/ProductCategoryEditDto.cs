using CoffeeShop.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShop.Web.Blazor.Shared {
    public class ProductCategoryEditDto {

        public int Id { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Type less than 20 characters")]
        public String Code { get; set; } = null!;

        [Required]
        [MaxLength(150, ErrorMessage = "Type less than 150 characters")]
        public String Description { get; set; } = null!;

        [Required]
        [Range(1, 3, ErrorMessage = "You must choose a type!")]
        public ProductType ProductType { get; set; }
    }
}
