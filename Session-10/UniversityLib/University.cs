using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_06 {
    public class University : Institute {
        // Properties
        public Student[]? Students { get; set; }
        public Course[]? Courses { get; set; }
        public Grade[]? Grades { get; set; }
        public Schedule[]? ScheduledCourse { get; set; }
        // Constractors
        public University() : base() {

        }

        public University(String name) : base(name) { }

        public University(String name, int yearsInService) : base(name, yearsInService) { }

        public University(String name, int yearsInService, Student[]? students) : this(name, yearsInService) {
            Students = students;
        }

        public University(String name, int yearsInService, Student[]? students, Course[]? courses) : this(name, yearsInService, students) {
            Courses = courses;
        }

        public University(String name, int yearsInService, Student[]? students, Course[]? courses, Grade[]? grades) : this(name, yearsInService, students, courses) {
            Grades = grades;
        }

        public University(String name, int yearsInService, Student[]? students, Course[]? courses, Grade[]? grades, Schedule[]? scheduledCourse) : this(name, yearsInService, students, courses, grades) {
            ScheduledCourse = scheduledCourse;
        }


        // Methoods
        public Student[] GetStudents() { return Students; }
        public Course[] GetCourses() { return Courses; }
        public Grade[] GetGrades() { return Grades; }
        public void SetScheduledCourse(Guid courseID,Guid professorID,DateTime datetime) { }
    }
}
