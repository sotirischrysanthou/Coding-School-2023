using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_05
{
    class ProgramOne
    {
        //reverses string ""Sotiris Chrysanthou""
        public StringBuilder ReverseStringBulder()
        {
            StringBuilder sb = new StringBuilder("Sotiris Chrysanthou");
            char c;
            int end = sb.Length - 1;
            int start = 0;

            while (end - start > 0)
            {
                c = sb[end];
                sb[end] = sb[start];
                sb[start] = c;
                start++;
                end--;
            }
            return sb;
        }
    }
}
