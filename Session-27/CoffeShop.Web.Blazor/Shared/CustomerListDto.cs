using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShop.Web.Blazor.Shared {
    public class CustomerListDto {
        public int Id { get; set; }
        public String Code { get; set; } = null!;
        public String Description { get; set; } = null!;
    }
}
