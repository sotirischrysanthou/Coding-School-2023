using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_05
{
    internal class ProgramThree
    {
        public bool IsPrime(int n)
        {
            if (n == 2 || n == 3)
            {
                return true;
            }
            if (n <= 1 || n % 2 == 0 || n % 3 == 0)
            {
                return false;
            }
            int limit = (int)Math.Sqrt(n);
            for (int i = 5; i <= limit; i += 6)
            {
                if (n % i == 0 || n % (i + 2) == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
