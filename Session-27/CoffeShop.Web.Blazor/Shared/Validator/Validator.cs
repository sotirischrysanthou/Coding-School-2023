using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShop.Web.Blazor.Shared.Validator {
    public class Validator {
        public MinMax ManagerLimits { get; set; }
        public MinMax CashiersLimits { get; set; }
        public MinMax BaristasLimits { get; set; }
        public MinMax WaitersLimits { get; set; }
        public MinMax CustomersLimits { get; set; }

        public Validator() {
            ManagerLimits = new MinMax() { Min = 1, Max = 1 };
            CashiersLimits = new MinMax() { Min = 1, Max = 2 };
            BaristasLimits = new MinMax() { Min = 1, Max = 2 };
            WaitersLimits = new MinMax() { Min = 1, Max = 3 };
            CustomersLimits = new MinMax() { Min = 1, Max = 1 };
        }


    }

    public struct MinMax {
        public int Min;
        public int Max;
    }
}
