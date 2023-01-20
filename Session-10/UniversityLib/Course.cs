using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_06 {
    public class Course {
        // Properties
        public Guid ID { get; set; }
        public String? Code { get; set; }
        public String? Subject { get; set; }

        // Constructors
        public Course() {
            ID = Guid.NewGuid();
        }

        public Course(String code) : this() {
            Code = code;
        }

        public Course(String code, String subject) : this(code) {
            Subject = subject;
        }
    }
}
