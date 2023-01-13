// See https://aka.ms/new-console-template for more information

using Session_05;

internal class MainProgram
{
    private static void Main(string[] args)
    {
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
        string input;
        int n;
        Console.WriteLine("Give a Number:");
        input = Console.ReadLine();
        while (! input.All(char.IsDigit))
        {
            Console.WriteLine("You gave wrong Input");
            Console.WriteLine("Give a Number:");
            input = Console.ReadLine();
        } 
        n = Convert.ToInt32(input);
        Console.WriteLine("Sum from 1 to n is : " + progTwo.SumFromOneToN(n));
        Console.WriteLine("Product from 1 to n is : " + progTwo.SumFromOneToN(n));
        
        Console.WriteLine("\n");

        Console.ReadLine();
    }
}