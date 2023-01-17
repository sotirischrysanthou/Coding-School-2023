using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_07 {
    internal class ActionConvert : Action {
        public override bool Run(String input, out String output) {
            int num;
            if (Int32.TryParse(input, out num)) {
                output = Convert.ToString(num, 2);
                return true;
            } else {
                output = String.Format("Wrong input. {0} is not Decimal number", input);
                return false;
            }
        }
    }
}
