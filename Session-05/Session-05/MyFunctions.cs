using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_05
{
    internal class MyFunctions
    {
        public int ReadNumberFromConsole()
        {
            string? input;
            int n;
            Console.WriteLine("Give a Number:");
            input = Console.ReadLine();
            while (input!=null && (!input.All(char.IsDigit)))
            {
                Console.WriteLine("You gave wrong Input");
                Console.WriteLine("Give a Number:");
                input = Console.ReadLine();
            }
            n = Convert.ToInt32(input);
            return n;
        }
    }
}
