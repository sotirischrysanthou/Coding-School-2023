﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Session_06 {
    internal class Professor : Person {
        // Properties
        public string? Rank { get; set; }
        //TODO: public Course[] Courses { get; set; }

        // Constractors
        public Professor() : base() {
            Console.WriteLine("Professor Constractors called without parameters");
        }
        public Professor(Guid id) : base(id) {
            Console.WriteLine("Professor Constractors called with parameters (Guid id = {0})", id);

        }

        public Professor(Guid id, String name) : base(id, name) {
            Console.WriteLine("Professor Constractors called with parameters (Guid id = {0}, String name = {1})",id,name);
        }

        public Professor(Guid id, String name, int age) : base(id, name, age) {
            Console.WriteLine("Professor Constractors called with parameters (Guid id = {0}, String name = {1}, int age = {2})", id, name, age);
        }

        public Professor(Guid id, String name, int age,string rank) : base(id, name, age) {
            Console.WriteLine("Professor Constractors called with parameters (Guid id = {0}, String name = {1}, int age = {2}, string rank ={3})", id, name, age, rank);
            Rank = rank;
        }


        // TODO: Teach(course, datetime)

        // TODO: SetGrate(studentID, courseID, grade)

        public String GetName() {
            return String.Format("Dr {0} ", base.GetName());
        }


    }
}
