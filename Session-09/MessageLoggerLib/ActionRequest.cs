using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageLoggerLib {

    public class ActionRequest {
        // Properties
        public Guid ID { get; set; }
        public String Input { get; set; }
        public MessageLoggerLib.Action ActionObj { get; set; }

        // Constructors
        public ActionRequest(String input, MessageLoggerLib.Action action) {
            ID = Guid.NewGuid();
            Input = input;
            ActionObj = action;
        }

    }
}
