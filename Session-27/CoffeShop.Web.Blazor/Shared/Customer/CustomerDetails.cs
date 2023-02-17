﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShop.Web.Blazor.Shared
{
    internal class CustomerDetails
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
