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

        }

        public Grade(Guid id) : this() {
            ID = id;
        }

        public Grade(Guid id, Guid studentID) : this(id) {
            StudentID = studentID;
        }

        public Grade(Guid id, Guid studentID, Guid courseID) : this(id,studentID) {
            CourseID = courseID;
        }

        public Grade(Guid id, Guid studentID, Guid courseID, int grade) : this(id, studentID,courseID) {
            GradeCourse = grade; ;
        }
    }
}
