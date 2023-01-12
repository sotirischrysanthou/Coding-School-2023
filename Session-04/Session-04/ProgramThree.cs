using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_04
{
    internal class ProgramThree
    {
        public int equationOne()
        {
            int a = -1;
            int b = 5;
            int c = 6;
            return a + b * c; 
        }

        public int equationTwo()
        {
            int a = 38;
            int b = 5;
            int c = 7;
            return a + b % c;
        }
        public int equationThree()
        {
            int a = 14;
            int b = -3;
            int c = 6;
            int d = 7;
            return a + ((b * c) / d);
        }
        public int equationFour()
        {
            int a = 2;
            int b = 13;
            int c = 6;
            int d = 7;
            double result = a + (b / c) * c + Math.Sqrt(d);
            return (int)result;
        }

        public int equationFive()
        {
            int a = 6;
            int aPow = 4;
            int b = 5;
            int bPow = 7;
            int c = 9;
            int d = 4;
            double result = (Math.Pow(a, aPow) + Math.Pow(b, bPow)) / (c % d);

            return (int)result;
        }
    }
}
