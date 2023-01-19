using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLib {
    public class Resolver {
        //Properties
        private String? _expresion;

        public Resolver() {
            _expresion = null;
        }

        public string Resolve(String expresion) {
            _expresion = expresion;

            // writen like this for future Update. For more complex equations
            // with more than one operator and more than two numbers
            //--------------------------------------------------------------------
            int[] numbers = new int[100]; 
            StringBuilder operators = new StringBuilder();
            int numOfNums = 0;
            String ops = "+-x/^=";
            int start = 0;
            for (int i = 0; i < _expresion.Length; i++) {
                if (ops.Contains(_expresion[i])) {
                    numbers[numOfNums] = IntIsolation(start, i - start);
                    numOfNums++;
                    start = i + 1;
                    operators.Append(_expresion[i]);
                } else if (_expresion[i] == '√') {
                    start = i + 1;
                    operators.Append(_expresion[i]);
                }
            }
            //----------------------------------------------------------------------
            double res = 0;
            switch (operators[0]) {
                case '+':
                    res = numbers[0] + numbers[1];
                    break;
                case '-':
                    res = numbers[0] - numbers[1];
                    break;
                case '/':
                    res = numbers[0] / numbers[1];
                    break;
                case 'x':
                    res = numbers[0] * numbers[1];
                    break;
                case '^':
                    res = Math.Pow(numbers[0], numbers[1]);
                    break;
                case '√':
                    res = Math.Sqrt(numbers[0]);
                    break;
                default:
                    res = numbers[0];
                    break;
            }
            return res.ToString();
        }

        /* Isolate int from _expresion*/
        private int IntIsolation(int start, int length) {
            int i;
            try {
                String isolatedString = _expresion.Substring(start, length);
                i = Int32.Parse(isolatedString);
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                throw;
            }
            return i;
        }

    }
}
