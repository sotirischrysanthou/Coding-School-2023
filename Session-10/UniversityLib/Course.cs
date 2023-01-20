using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_06 {
    internal class Course {
        // Properties
        public Guid ID { get; set; }
        public String? Code { get; set; }
        public String? Subject { get; set; }

        // Constructors
        public Course() {

        }

        public Course(Guid id) : this() {
            ID = id;
        }

        public Course(Guid id,String code) : this(id) {
            Code = code;
        }

        public Course(Guid id, String code, String subject) : this(id, code) {
            Subject = subject;
        }
    }
}
