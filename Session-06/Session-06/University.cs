using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_06 {
    internal class University : Institute {
        // Properties
        public Student[]? Students { get; set; }
        public Course[]? Courses { get; set; }
        public Grade[]? Grades { get; set; }
        public Schedule[]? ScheduledCourse { get; set; }
        // Constractors
        public University() : base() {

        }

        public University(Guid id) : base(id) { }

        public University(Guid id, String name) : base(id, name) { }

        public University(Guid id, String name, int yearsInService) : base(id, name, yearsInService) { }

        public University(Guid id, String name, int yearsInService, Student[]? students) : this(id, name, yearsInService) {
            Students = students;
        }

        public University(Guid id, String name, int yearsInService, Student[]? students, Course[]? courses) : this(id, name, yearsInService, students) {
            Courses = courses;
        }

        public University(Guid id, String name, int yearsInService, Student[]? students, Course[]? courses, Grade[]? grades) : this(id, name, yearsInService, students, courses) {
            Grades = grades;
        }

        public University(Guid id, String name, int yearsInService, Student[]? students, Course[]? courses, Grade[]? grades, Schedule[]? scheduledCourse) : this(id, name, yearsInService, students, courses, grades) {
            ScheduledCourse = scheduledCourse;
        }


        // Methoods
        public Student[] GetStudents() { return Students; }
        public Course[] GetCourses() { return Courses; }
        public Grade[] GetGrades() { return Grades; }
        public void SetScheduledCourse(Guid courseID, Guid professorID, DateTime datetime) { }
    }
}
