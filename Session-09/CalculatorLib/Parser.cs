using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using calOps = CalculatorLib.CalcOperations.CalcOperation;


namespace CalculatorLib {
    internal class Parser {
        // Properties
        String _expresion;
        private List<double> _numbers;
        private List<calOps> _operators;
        // Constructors
        // Methods
        public void Parse(string expresion, List<double> numbers, List<calOps> operations) {
            Init(expresion, numbers, operations);
            String ops = "+-x/^√=";
            int start = 0;
            for (int i = 0; i < _expresion.Length; i++) {
                if (ops.Contains(_expresion[i])) {
                    if (_expresion[i] != '√') {
                        _numbers.Add(DoubleIsolation(start, i - start));
                    }
                    start = i + 1;
                    RecognizeAndAddOperator(_expresion[i]);
                }
            }
        }

        private void Init(string expresion, List<double> numbers, List<calOps> operations) {
            _numbers = numbers;
            _operators = operations;
            _numbers.Clear();
            _operators.Clear();
            _expresion = expresion;
        }


        /* Isolate double from _expresion*/
        private int DoubleIsolation(int start, int length) {
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

        private void RecognizeAndAddOperator(char op) {
            calOps res = calOps.Equal;
            switch (op) {
                case '+':
                    res = calOps.Add;
                    break;
                case '-':
                    res = calOps.Subtract;
                    break;
                case '/':
                    res = calOps.Divide;
                    break;
                case 'x':
                    res = calOps.Multiply;
                    break;
                case '^':
                    res = calOps.Exp;
                    break;
                case '√':
                    res = calOps.Root;
                    break;
                default:
                    // TODO ERROR
                    break;
            }
            _operators.Add(res);
        }
    }
}
