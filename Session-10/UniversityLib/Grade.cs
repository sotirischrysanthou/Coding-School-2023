using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_06 {
    internal class Grade {
        public Guid ID { get; set; }
        public Guid StudentID { get; set; }
        public Guid CourseID { get; set; }
        public int GradeCourse { get; set; }

        public Grade() {
            ID= Guid.NewGuid();
        }

        public Grade(Guid studentID) : this() {
            StudentID = studentID;
        }

        public Grade(Guid studentID, Guid courseID) : this(studentID) {
            CourseID = courseID;
        }

        public Grade(Guid studentID, Guid courseID, int grade) : this(studentID, courseID) {
            GradeCourse = grade; ;
        }
    }
}
