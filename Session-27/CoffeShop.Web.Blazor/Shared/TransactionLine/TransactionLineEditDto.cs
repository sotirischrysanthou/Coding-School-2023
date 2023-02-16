﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShop.Web.Blazor.Shared {
    public class TransactionLineEditDto {


        public int Id { get; set; }

        [Required]
        public int Quantity { get; set; }
        [Required]
        [Range(1, 99.99, ErrorMessage = "You must choose a category!")]
        public decimal Discount { get; set; }
        [Required]
        [Range(0, 99999999.99, ErrorMessage = "You must choose a category!")]
        public decimal Price { get; set; }
        [Required]
        [Range(0, 99999999.99, ErrorMessage = "You must choose a category!")]
        public decimal TotalPrice { get; set; }

        // Relations
        public int TransactionId { get; set; }
        public int ProductId { get; set; }
    }
}