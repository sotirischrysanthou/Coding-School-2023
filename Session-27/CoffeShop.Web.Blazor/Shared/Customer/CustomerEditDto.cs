using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShop.Web.Blazor.Shared {
    public class CustomerEditDto {
        public int Id { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Type less than 20 characters")]
        public string Code { get; set; } = null!;

        [Required]
        [MaxLength(150, ErrorMessage = "Type less than 150 characters")]
        public string Description { get; set; } = null!;
    }
}
