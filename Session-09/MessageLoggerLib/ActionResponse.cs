using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageLoggerLib {
    public class ActionResponse {
        // Properties
        public Guid RequestID { get; set; }
        public Guid ResponseID { get; set; }
        public String? Output { get; set; } 

        public ActionResponse(Guid requestID) {
            RequestID = requestID;
            ResponseID = Guid.NewGuid();
        }
        
        public void SetOutput(String output) {
            Output = output;
        }
    }
}
