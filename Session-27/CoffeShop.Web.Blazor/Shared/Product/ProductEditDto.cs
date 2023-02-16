using CoffeeShop.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShop.Web.Blazor.Shared {
    public class ProductEditDto {

        public int Id { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "Type less than 20 characters")]
        public String Code { get; set; } = null!;

        [Required]
        [MaxLength(150, ErrorMessage = "Type less than 150 characters")]
        public String Description { get; set; } = null!;

        [Required]
        [Range(0, 99999999.99, ErrorMessage = "The range is from 0 to 99999999.99!")]
        public decimal Price { get; set; }

        [Required]
        [Range(0, 99999999.99, ErrorMessage = "The range is from 0 to 99999999.99!")]
        public decimal Cost { get; set; }

        //RELATIONS
        public int ProductCategoryId { get; set; }

    }
}
