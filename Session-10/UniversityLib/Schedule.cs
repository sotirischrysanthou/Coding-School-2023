using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_06 {
    internal class Schedule {
        // Properties
        public Guid ID { get; set; }
        public Guid CourseID { get; set; }
        public Guid ProfessorID { get; set; }
        public DateTime Calendar { get; set; }

        public Schedule() {
            ID= Guid.NewGuid();
        }

        public Schedule(Guid courseID) : this() {
            CourseID = courseID;
        }

        public Schedule(Guid courseID, Guid professorID) : this(courseID) {
            ProfessorID = professorID;
        }

        public Schedule(Guid courseID, Guid professorID, DateTime calendar) : this(courseID, professorID) {
            Calendar = calendar;
        }
    }

}
