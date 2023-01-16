// See https://aka.ms/new-console-template for more information
using Session_06;



internal class Program {
    private static void Main(string[] args) {

        /* class Person Test*/
        Console.WriteLine("Person Class test\n------------");
        Person person = new Person(Guid.NewGuid(), "Sotiris Chrysanthou", 25);
        Console.WriteLine(person.GetName());

        /*class Professor Test*/
        Console.WriteLine("\n\nProfessor Class test\n------------");
        Professor[] professors = new Professor[5];

        Console.WriteLine("\tProfessor()\n\t------------");
        professors[0] = new Professor();
        
        Console.WriteLine("\n\tProfessor(id)\n\t------------");
        professors[1] = new Professor(Guid.NewGuid());
        
        Console.WriteLine("\n\tProfessor(id, name)\n\t------------");
        professors[2] = new Professor(Guid.NewGuid(), "Dimitris Raptodimos");

        Console.WriteLine("\n\tProfessor(id, name, age)\n\t------------");
        professors[3] = new Professor(Guid.NewGuid(), "Kostas Sofos", 38);

        Console.WriteLine("\n\tProfessor(id, name, age, rank)\n\t------------");
        professors[4] = new Professor(Guid.NewGuid(),"Fotis Chrysoulas", 44, "Instructor");

        Console.WriteLine("\n\tprofessors[4].GetName()\n\t------------");
        Console.WriteLine(professors[4].GetName());
    }
}