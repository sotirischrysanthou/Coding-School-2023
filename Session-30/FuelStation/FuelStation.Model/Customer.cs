using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace FuelStation.Model {
    public class Customer : Person {
        // Properties
        [Required]
        [RegularExpression("^A.{0,}$", ErrorMessage = "CardNumber should start with 'A'.")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "CardNumber must be between 1 and 20 characters.")]
        public String CardNumber { get; set; }

        // Relations
        public List<Transaction> Transactions { get; set; } = null!;

        // Constractors
        public Customer(String name, String surname, String cardNumber) : base(name, surname) {
            CardNumber = cardNumber;
        }
    }
}
