using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLib {
    public class Resolver {

        public Resolver() { }

        public string Resolve(String expresion) {
            int[] numbers = new int[2];
            StringBuilder operators = new StringBuilder();
            int numOfNums = 0;
            String ops = "+-x/^=";
            int start = 0;
            for (int i = 0; i < expresion.Length; i++) {
                if (ops.Contains(expresion[i])) {
                    numbers[numOfNums] = Convert.ToInt32(expresion.Substring(start, i - start));
                    numOfNums++;
                    start = i + 1;
                    operators.Append(expresion[i]);
                } else if (expresion[i] == '√') {
                    start = i + 1;
                    operators.Append(expresion[i]);
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

    }
}
