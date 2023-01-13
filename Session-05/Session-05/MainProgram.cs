// See https://aka.ms/new-console-template for more information

using Session_05;

internal class MainProgram
{
    private static void Main(string[] args)
    {
        /* PROGRAM #1 
         * Write a C# program to print Hello and your name in the same line.*/
        ProgramOne progOne = new ProgramOne();
        Console.WriteLine("PROGRAM #1\n----------");
        string input;
        Console.WriteLine("Write your name:");
        input = Console.ReadLine();
        Console.WriteLine(progOne.ReverseString(input));
        Console.WriteLine("\n");


    }
}