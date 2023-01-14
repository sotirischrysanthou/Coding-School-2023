using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_05
{
    internal class ProgramTwo
    {
        public int SumFromOneToN(int n)
        {
            int sum = 0;
            for (int i = 1; i <= n; i++)
            {
                sum += i;
            }
            return sum;
        }

        public int ProductFromOneToN(int n)
        {
            int sum = 1;
            for (int i = 1; i <= n; i++)
            {
                sum *= i;
            }
            return sum;
        }
    }
}
