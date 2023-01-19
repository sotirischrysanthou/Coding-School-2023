using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLib {
    public class Resolver {
        //Properties
        private String _expresion;

        public Resolver() { }

        public string Resolve(String expresion) {
            _expresion = expresion;
            int[] numbers = new int[2];
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
        private int? IntIsolation(int start, int length) {
            String isolatedString = _expresion.Substring(start, length);
            int i;
            if (Int32.TryParse(isolatedString, out i))
                return i;
            return null;
        }

    }
}
