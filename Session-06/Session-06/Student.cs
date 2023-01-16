using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_06 {
    internal class Student : Person {
        // Properties
        public int RegistrationNumber { get; set; }
        public Course[]? Courses { get; set; }

        // Constractors
        public Student() : base() {
            Console.WriteLine("Student Constractors called without parameters");
        }
        public Student(Guid id) : base(id) {
            Console.WriteLine("Student Constractors called with parameters (Guid id = {0})", id);

        }

        public Student(Guid id, String name) : base(id, name) {
            Console.WriteLine("Student Constractors called with parameters (Guid id = {0}, String name = {1})", id, name);
        }

        public Student(Guid id, String name, int age) : base(id, name, age) {
            Console.WriteLine("Student Constractors called with parameters (Guid id = {0}, String name = {1}, int age = {2})", id, name, age);
        }

        public Student(Guid id, String name, int age, int registrationNumber) : base(id, name, age) {
            Console.WriteLine("Student Constractors called with parameters (Guid id = {0}, String name = {1}, int age = {2}, string rank ={3})", id, name, age, registrationNumber);
            RegistrationNumber = registrationNumber;
        }

        public void Attent(Course course, DateTime datetime) {

        }

        public void WriteExam(Guid courseID, DateTime datetime) {

        }
    }
}
