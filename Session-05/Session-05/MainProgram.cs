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
        Console.WriteLine("Sum from 1 to {0} is : {1}",n , progTwo.SumFromOneToN(n));
        Console.WriteLine("Product from 1 to {0} is : {1}",n , progTwo.ProductFromOneToN(n));
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
        Console.WriteLine("\n");


        /* PROGRAM #4 
         * Write a C# program to multiply all values from Array1 with all values 
         * from Array2 and display the results in a new Array*/
        Programfour progFour = new Programfour();
        Console.WriteLine("PROGRAM #4\n----------");
        int[] arrayA = new int[] {2, 4, 9, 12};
        int[] arrayB = new int[] {1, 3, 7, 10};
        int[] res = progFour.MultiplyArrays(arrayA, arrayB);
        for (int i = 0; i < arrayA.Length; i++)
        {
            for (int j = 0; j < arrayA.Length; j++)
            {
                Console.Write(res[i * arrayB.Length + j] + "  ");
            }
            Console.WriteLine();
        }

        Console.ReadLine();

        /* PROGRAM #5
        * Write a C# program to sort the given array of integers from the lowest 
        * to the highest number*/
        ProgramFive progFive = new ProgramFive();
        Console.WriteLine("PROGRAM #5\n----------");
        int[] array = new int[] { 0, -2, 1, 20, -31, 50, -4, 17, 89, 100 };
        array = progFive.InsertionSort(array);
        for (int i = 0; i < array.Length; i++)
        {
                Console.Write(array[i] + "  ");
        }
        Console.WriteLine();
    }
}