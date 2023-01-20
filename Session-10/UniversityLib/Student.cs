using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLib {
    public class Student : Person {
        // Properties
        public int RegistrationNumber { get; set; }
        public List<Course> Courses { get; set; }

        // Constractors
        public Student() : base() {
            ID = Guid.NewGuid();
            Console.WriteLine("Student Constractors called without parameters");
        }

        public Student(String name) : base(name) {
            Console.WriteLine("Student Constractors called with parameters (String name = {0})", name);
        }

        public Student(String name, int age) : base(name, age) {
            Console.WriteLine("Person Constractor called with parameters (String name = {0}, int age = {1})", name, age);
        }

        public Student(String name, int age, int registrationNumber) : base(name, age) {
            Console.WriteLine("Student Constractors called with parameters (String name = {0}, int age = {1}, string rank ={2})",name, age, registrationNumber);
            RegistrationNumber = registrationNumber;
        }

        public void Attent(Course course, DateTime datetime) {

        }

        public void WriteExam(Guid course, DateTime datetime) {

        }
    }
}
