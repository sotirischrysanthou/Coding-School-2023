using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_07 {
    internal class Action {
        // Properties
        public String Input { get; set; }
        public String Output { get; set; }

        // Constructors
        public Action() {

        }

        // Methods
        public virtual bool Run(String input, out String output) {
            output = "Νo specific action was given";
            return false;
        }
    }
}
