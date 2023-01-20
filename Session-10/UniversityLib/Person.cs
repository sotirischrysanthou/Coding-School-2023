using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_06 {
    public class Person {
        // Properties
        public Guid ID { get; set; }
        public String? Name { get; set; }
        public int Age { get; set; }

        // Constractors
        public Person() {
            ID = Guid.NewGuid();
            Console.WriteLine("Person Constractor called without parameters");
        }

        public Person(String name) : this() {
            Name = name;
            Console.WriteLine("Person Constractor called with parameters (String name = {0})",name);
        }

        public Person(String name, int age) : this(name) {
            Age = age;
            Console.WriteLine("Person Constractor called with parameters (String name = {0}, int age = {1})", name, age);
        }

        public String GetName() {
            return Name;
        }

        public void SetName(String name) {
            Name = name;
        }
    }
}
