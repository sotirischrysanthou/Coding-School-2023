using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Model {
    public class Settings {
        // Pproperties
        public int Id { get; set; }
        public DateTime OpeningDate { get; set; }
        public decimal Rent { get; set; }
        public int MinManagers { get; set; }
        public int MaxManagers { get; set; }
        public int MinCashiers { get; set; }
        public int MaxCashiers { get; set; }
        public int MinStaff { get; set; }
        public int MaxStaff { get; set; }
    }
}
