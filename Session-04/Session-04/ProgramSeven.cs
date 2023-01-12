using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_04
{
    internal class ProgramSeven
    {
        public int CelsiusToKelvin()
        {
            int celsius = 30;
            return celsius + 273;
        }

        public int CelsiusToFahrenheit()
        {
            int celsius = 30;
            double fahrenheit = (celsius * 1.8) + 32;
            return (int)fahrenheit;
        }
    }
}
