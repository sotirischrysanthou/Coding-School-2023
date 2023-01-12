using Session_04;

internal class MainProgram
{
    private static void Main(string[] args)
    {
        /* PROGRAM #1 
         Write a C# program to print Hello and your name in the same line.*/
        ProgramOne progOne = new ProgramOne();
        Console.WriteLine("PROGRAM #1\n----------");
        Console.WriteLine(progOne.HelloName());
        Console.WriteLine("\n");

        /* PROGRAM #2 
         Write a C# program to print the sum of two numbers and the division
         of those two numbers.*/
        ProgramTwo progTwo = new ProgramTwo();
        Console.WriteLine("PROGRAM #2\n----------");
        Console.WriteLine("15 + 3 = " + progTwo.Sum());
        Console.WriteLine("15 / 3 = " + progTwo.Division());
        Console.WriteLine("\n");

        /* PROGRAM #3 
         Write a C# program to print the result of the specified operations:*/
        ProgramThree progThree = new ProgramThree();
        Console.WriteLine("PROGRAM #3\n----------");
        Console.WriteLine("-1 + 5 x 6 = " + progThree.equationOne());
        Console.WriteLine("38 + 5 mod 7 = " + progThree.equationTwo());
        Console.WriteLine("14 + ((-3 x 6) / 7) = " + progThree.equationThree());
        Console.WriteLine("2 + (13 / 6) x 6 + √7 = " + progThree.equationFour());
        Console.WriteLine("((6^4) + (5^7)) / (9 mod 4) = " + progThree.equationFive());
        Console.WriteLine("\n");

        /* PROGRAM #4 
         Write a C# program that assigns an age (number) (for example 20) and
         a gender (string) (for example female) and displays something like:
         "You are female and look younger than 20."*/
        ProgramFour progFour = new ProgramFour();
        Console.WriteLine("PROGRAM #4\n----------");
        Console.WriteLine(progFour.AgeAndGender());
        Console.WriteLine("\n");

        /* PROGRAM #5
         Write a C# program that takes an integer representing seconds (for
         example 45678) and converts it to : Minutes, Hours, Days, Years*/
        ProgramFive progFive = new ProgramFive();
        Console.WriteLine("PROGRAM #5\n----------");
        Console.WriteLine("1000000000 secs to:");
        Console.WriteLine(progFive.SecondsToMinutes() + "minutes");
        Console.WriteLine(progFive.SecondsToHours() + "hours");
        Console.WriteLine(progFive.SecondsToDays() + "days");
        Console.WriteLine(progFive.SecondsToYears() + "years");
        Console.WriteLine("\n");


        /* PROGRAM #6
         Rewrite Program #5 using .Net Libraries.*/
        ProgramSix progSix = new ProgramSix();
        Console.WriteLine("PROGRAM #6\n----------");
        Console.WriteLine("1000000000 secs to:");
        Console.WriteLine(progSix.SecondsToMinutes() + "minutes");
        Console.WriteLine(progSix.SecondsToHours() + "hours");
        Console.WriteLine(progSix.SecondsToDays() + "days");
        Console.WriteLine(progSix.SecondsToYears() + "years");
        Console.WriteLine("\n");


        /* PROGRAM #7
         Write a C# program to convert from celsius degrees to Kelvin and
         Fahrenheit.*/
        ProgramSeven progSeven = new ProgramSeven();
        Console.WriteLine("PROGRAM #6\n----------");
        Console.WriteLine("30 C = " + progSeven.CelsiusToKelvin() + " K");
        Console.WriteLine("30 C = " + progSeven.CelsiusToFahrenheit() + " F");

        Console.ReadLine();
    }
}