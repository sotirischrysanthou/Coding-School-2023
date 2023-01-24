using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLib {
    public class University : Institute {
        // Properties
        public List<Student> Students { get; set; }
        public List<Course> Courses { get; set; }
        public List<Grade> Grades { get; set; }
        public List<Schedule> ScheduledCourse { get; set; }
        // Constractors
        public University() : base() { }

        public University(String name) : base(name) { }

        public University(String name, int yearsInService) : base(name, yearsInService) {
            Students = new List<Student>();
            Courses = new List<Course>();
            Grades = new List<Grade>();
            ScheduledCourse = new List<Schedule>();
        }

        public University(String name, int yearsInService, List<Student> students) : base(name, yearsInService) {
            Students = students;
        }

        public University(String name, int yearsInService, List<Student> students, List<Course> courses) : this(name, yearsInService, students) {
            Courses = courses;
        }

        public University(String name, int yearsInService, List<Student> students, List<Course> courses, List<Grade> grades) : this(name, yearsInService, students, courses) {
            Grades = grades;
        }

        public University(String name, int yearsInService, List<Student> students, List<Course> courses, List<Grade> grades, List<Schedule> scheduledCourse) : this(name, yearsInService, students, courses, grades) {
            ScheduledCourse = scheduledCourse;
        }


        // Methoods
        public List<Student> GetStudents() { return Students; }
        public List<Course> GetCourses() { return Courses; }
        public List<Grade> GetGrades() { return Grades; }
        public void SetScheduledCourse(Guid courseID,Guid professorID,DateTime datetime) { }
    }
}
