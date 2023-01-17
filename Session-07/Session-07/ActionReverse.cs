using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_07 {
    internal class ActionReverse : Action {
        public override bool Run(String input, out String output) {
            if (Int32.TryParse(input, out _)) {
                output = String.Format("{0} is not a String", input);
                return false;
            } else {
                output = ReverseString(input);
                return true;
            }
        }
        public string ReverseString(string? s) {
            StringBuilder sb = new StringBuilder(s);
            char c;
            int end = sb.Length - 1;
            int start = 0;

            while (end - start > 0) {
                c = sb[end];
                sb[end] = sb[start];
                sb[start] = c;
                start++;
                end--;
            }
            return sb.ToString();
        }
    }
}
