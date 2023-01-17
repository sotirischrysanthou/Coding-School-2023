using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_07 {
    internal class ActionUppercase : Action {
        public override bool Run(String input, out String output) {
            String[] subs = input.Split(' ');
            if (subs.Length > 1) {
                ref String longestWord = ref subs[0];
                for (int i = 0; i < subs.Length; i++) {
                    if (subs[i].Length > longestWord.Length) {
                        longestWord = ref subs[i];
                    }
                }
                longestWord = longestWord.ToUpper();
                output = String.Join(" ", subs);
                return true;
            } else {
                output = String.Format("Wrong input. \"{0}\" has not more than 1 word", input);
                return false;
            }
        }
    }
}
