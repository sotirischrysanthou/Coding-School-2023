using FuelStation.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Web.Blazor.Shared {
    public class CustomerDetailsDto {
        // Properties
        [Required]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Name must be between 1 and 20 characters.")]
        public String Name { get; set; } = null!;
        [Required]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Surname must be between 1 and 20 characters.")]
        public String Surname { get; set; } = null!;

        [Required]
        [RegularExpression("^A.{0,}$", ErrorMessage = "CardNumber should start with 'A'.")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "CardNumber must be between 1 and 20 characters.")]
        public String CardNumber { get; set; } = null!;

        // Relations
        public List<TransactionListDto> Transactions { get; set; } = new();

        // Constructors
        public CustomerDetailsDto() {

        }
        public CustomerDetailsDto(Customer customer) {
            Name = customer.Name;
            Surname = customer.Surname;
            CardNumber = customer.CardNumber;
            Transactions = customer.Transactions.Select(t => new TransactionListDto(t)).ToList();
        }
    }
}
