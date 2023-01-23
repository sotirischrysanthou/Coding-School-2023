using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCenterLib
{
    public class Engineer : Person
    {
        //Properties
        public Guid ManagerID { get; set; }
        public double SalaryPerMonth { get; set; }


    }
}
