using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_06 {
    internal class Person {
        // Properties
        public Guid ID { get; set; }
        public String? Name { get; set; }
        public int Age { get; set; }

        // Constractors
        public Person() {
            Console.WriteLine("Person Constractor called without parameters");
        }

        public Person(Guid id) : this() {
            ID = id;
            Console.WriteLine("Person Constractor called with parameter  (Guid id = {0})", id);
        }

        public Person(Guid id, String name) : this(id) {
            Name = name;
            Console.WriteLine("Person Constractor called with parameters (Guid id = {0}, String name = {1})", id, name);
        }

        public Person(Guid id, String name, int age) : this(id, name) {
            Age = age;
            Console.WriteLine("Person Constractor called with parameters (Guid id = {0}, String name = {1}, int age = {2})", id, name, age);
        }

        public String GetName() {
            return Name;
        }

        public void SetName(String name) {
            Name = name;
        }
    }
}
