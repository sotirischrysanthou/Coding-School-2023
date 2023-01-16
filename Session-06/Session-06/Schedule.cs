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

        }

        public Schedule(Guid id) : this() {
            ID = id;
        }

        public Schedule(Guid id, Guid courseID) : this(id) {
            CourseID = courseID;
        }

        public Schedule(Guid id, Guid courseID, Guid professorID) : this(id, courseID) {
            ProfessorID = professorID;
        }

        public Schedule(Guid id, Guid courseID, Guid professorID, DateTime calendar) : this(id, courseID, professorID) {
            Calendar = calendar;
        }
    }

}
