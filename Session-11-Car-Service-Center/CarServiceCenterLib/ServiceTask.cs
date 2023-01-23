using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCenterLib {
    public class ServiceTask {
        public Guid ID { get; set; }
        public int Code { get; set; }
        public string Description { get; set; }

        public double Hours { get; set; }

        public ServiceTask(int code, String description, double hours) {
            ID = Guid.NewGuid();
            Code = code;
            Description = description;
            Hours = hours;
        }
    }
}
