﻿using CoffeeShop.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShop.Web.Blazor.Shared {
    public class EmployeeEditDto
    {
        public int Id { get; set; }
        public String Name { get; set; } = null!;
        public String Surname { get; set; } = null!;
        public int SalaryPerMonth { get; set; } 
        public EmployeeType EmployeeType { get; set; } 
    }
}
