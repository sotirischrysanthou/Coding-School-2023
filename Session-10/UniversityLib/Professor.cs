using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Session_06 {
    public class Professor : Person {
        // Properties
        public string? Rank { get; set; }
        public Course[]? Courses { get; set; }

        // Constractors
        public Professor() : base() {
            ID = Guid.NewGuid();
            Console.WriteLine("Professor Constractors called without parameters");
        }

        public Professor(String name) : base(name) {
            Console.WriteLine("Professor Constractors called with parameters (String name = {0})",name);
        }

        public Professor(String name, int age) : base( name, age) {
            Console.WriteLine("Professor Constractors called with parameters (String name = {0}, int age = {1})", name, age);
        }

        public Professor(String name, int age,string rank) : base(name, age) {
            Console.WriteLine("Professor Constractors called with parameters (String name = {0}, int age = {1}, string rank ={2})",name, age, rank);
            Rank = rank;
        }

        public Professor(String name, int age, string rank, Course[] courses) : this(name, age, rank) {
            Console.WriteLine("Professor Constractors called with parameters (String name = {0}, int age = {1}, string rank ={2})", name, age, rank);
            Courses = courses;
        }


        public void Teach(Course course, DateTime datetime) {

        }

        public void SetGrate(Guid studentID,Guid courseID,int grade) {

        }

        public String GetName() {
            return String.Format("Dr {0} ", base.GetName());
        }


    }
}
