using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_07 {

    public enum ActionEnum {
        Convert,
        UpperCase,
        Reverse
    }
    internal class ActionRequest {
        // Properties
        public Guid ID { get; set; }
        public String Input { get; set; }
        public ActionEnum Action { get; set; }

        // Constructors
        public ActionRequest(Guid id, String input, ActionEnum action) {
            ID = id;
            Input = input;
            Action = action;
        }

    }
}
