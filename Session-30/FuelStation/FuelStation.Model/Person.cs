using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Model {
    public class Person {
        // Properties
        public Guid Id { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "The name must be less than 20 characters")]
        public String Name { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "The surname must be less than 20 characters")]
        public String Surname { get; set; }

        // Relations
        public List<Transaction> Transactions { get; set; } = null!;

        // Constructors
        public Person(String name, String surname) {
            Id = Guid.NewGuid();
            Name = name;
            Surname = surname;
        }
    }
}
