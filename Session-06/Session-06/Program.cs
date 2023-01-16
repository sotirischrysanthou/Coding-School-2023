// See https://aka.ms/new-console-template for more information
using Session_06;



internal class Program {
    private static void Main(string[] args) {
        Console.WriteLine("Person Class test\n------------");
        Person person = new Person(Guid.NewGuid(), "Sotiris Chrysanthou", 25);
        Console.WriteLine(person.GetName());
    }
}