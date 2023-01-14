using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_05
{
    internal class Programfour
    {
        public int[] MultiplyArrays(int[] arrayA, int[] arrayB)
        {
            int[] res = new int[arrayA.Length * arrayB.Length];
            for (int i = 0; i < arrayA.Length; i++)
            {
                for (int j = 0; j < arrayB.Length; j++)
                {
                    res[i * arrayB.Length + j] = arrayA[i] * arrayB[j];
                }
            }
            return res;
        }
    }
}
