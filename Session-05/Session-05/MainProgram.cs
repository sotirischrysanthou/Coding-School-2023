// See https://aka.ms/new-console-template for more information

using Session_05;

internal class MainProgram
{

    private static void Main(string[] args)
    {
        MyFunctions funcs = new MyFunctions();
        /* PROGRAM #1 
         * Write a C# program that reverses a given string (your name)*/
        ProgramOne progOne = new ProgramOne();
        Console.WriteLine("PROGRAM #1\n----------");
        string input;
        Console.WriteLine("Write your name:");
        input = Console.ReadLine();
        Console.WriteLine(progOne.ReverseString(input));
        Console.WriteLine("\n");

        /* PROGRAM #2 
         * Write a C# program that asks the user for an integer (n) and gives them 
         * the possibility to choose between computing the sum and computing 
         * the product of 1,...,n*/
        ProgramTwo progTwo = new ProgramTwo();
        Console.WriteLine("PROGRAM #2\n----------");
        int n = funcs.ReadNumberFromConsole();
        Console.WriteLine("Sum from 1 to n is : " + progTwo.SumFromOneToN(n));
        Console.WriteLine("Product from 1 to n is : " + progTwo.ProductFromOneToN(n));
        Console.WriteLine("\n");


        /* PROGRAM #3 
        * Write a C# program that asks the user for an integer (n) and finds all 
        * the prime numbers from 1 to n*/
        ProgramThree progThree = new ProgramThree();
        Console.WriteLine("PROGRAM #3\n----------");
        n = funcs.ReadNumberFromConsole();
        Console.WriteLine("Prime Numbers from 1 to {0} are:",n);
        if (n > 3)
            for (int i = 5; i < n; i += 6)
                if (progThree.IsPrime(i))
                    Console.WriteLine(i);
        else if (n > 1)
            Console.WriteLine("2\n3");
        else
            Console.WriteLine("Τhere are no prime numbers in this interval ");

        Console.ReadLine();
    }

    
}