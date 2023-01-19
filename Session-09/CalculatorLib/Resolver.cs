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
        double[] _numbers;
        private _CalcOperation[] _operators;
        private int _numOfNums;
        private int _numOfOps;

        private enum _CalcOperation {
            Equal = 0,
            Add = 1,
            Subtract = 2,
            Multiply = 3,
            Divide = 4,
            Exp = 5,
            Root = 6
        };

        public Resolver() {
            _expresion = null;
            _numbers = new double[100];
            _numOfNums = 0;
            _operators = new _CalcOperation[100];
            _numOfOps = 0;
        }

        public string Resolve(String expresion) {
            _expresion = expresion;

            // writen like this for future Update. For more complex equations
            // with more than one operator and more than two numbers
            //--------------------------------------------------------------------

            String ops = "+-x/^=";
            int start = 0;
            for (int i = 0; i < _expresion.Length; i++) {
                if (ops.Contains(_expresion[i])) {
                    _numbers[_numOfNums] = DoubleIsolation(start, i - start);
                    _numOfNums++;
                    start = i + 1;
                    RecognizeAndAddOperator(_expresion[i]);
                } else if (_expresion[i] == '√') {
                    start = i + 1;
                    RecognizeAndAddOperator(_expresion[i]);
                }
            }
            //----------------------------------------------------------------------
            double res = 0;
            while (_numOfNums > 0) {
                res = SimpleEquation();
            }
            return res.ToString();
        }

        /* Isolate int from _expresion*/
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
            _CalcOperation res = _CalcOperation.Equal;
            switch (op) {
                case '+':
                    res = _CalcOperation.Add;
                    break;
                case '-':
                    res = _CalcOperation.Subtract;
                    break;
                case '/':
                    res = _CalcOperation.Divide;
                    break;
                case 'x':
                    res = _CalcOperation.Multiply;
                    break;
                case '^':
                    res = _CalcOperation.Exp;
                    break;
                case '√':
                    res = _CalcOperation.Root;
                    break;
                default:
                    // TODO ERROR
                    break;
            }
            int i = 0;
            while (_operators[i] != _CalcOperation.Equal) { i++; }
            _operators[i] = res;
            if (_operators[i] != _CalcOperation.Equal) {
                _numOfOps++;
            }
        }

        private int FindOperatorWithHighestPiority() {
            _CalcOperation op = _operators[0];
            int highestPriority = 0;
            int i = 0;
            while (_operators[i] != _CalcOperation.Equal) {
                if (_operators[i] > op) {
                    highestPriority = i;
                    op = _operators[i];
                }
                i++;
            }
            return highestPriority;
        }

        private double SimpleEquation() {
            int pos = FindOperatorWithHighestPiority();
            double res = _numbers[pos];
            switch (_operators[pos]) {
                case _CalcOperation.Add:
                    res = _numbers[pos] + _numbers[pos + 1];
                    break;
                case _CalcOperation.Subtract:
                    res = _numbers[pos] - _numbers[pos + 1];
                    break;
                case _CalcOperation.Multiply:
                    res = _numbers[pos] * _numbers[pos + 1];
                    break;
                case _CalcOperation.Divide:
                    res = _numbers[pos] / _numbers[pos + 1];
                    break;
                case _CalcOperation.Exp:
                    res = Math.Pow(_numbers[pos], _numbers[pos + 1]);
                    break;
                case _CalcOperation.Root:
                    res = Math.Sqrt(_numbers[pos]);
                    break;
                default:
                    // TODO ERROR
                    break;
            }
            ReplaceNumbersAndOparators(res, pos);
            return res;
        }

        private void ReplaceNumbersAndOparators(double res, int pos) {
            double[] newNumbers = new double[_numbers.Length];
            _CalcOperation[] newOperators = new _CalcOperation[_operators.Length];
            int oldOparatorsPos = 0;
            int newOperatorsPos = 0;
            int oldNumbersPos = 0;
            int newNumbersPos = 0;
            if (_numOfNums > 1) {
                for (oldNumbersPos = 0; oldNumbersPos < _numOfNums; oldNumbersPos++) {
                    if (oldNumbersPos == pos) {
                        newNumbers[newNumbersPos] = res;
                        if (_operators[pos] != _CalcOperation.Root) {
                            oldNumbersPos++;
                        }
                    } else {
                        newNumbers[newNumbersPos] = _numbers[oldNumbersPos];
                    }
                    newNumbersPos++;
                }
                _numbers = newNumbers;
                if (_operators[pos] != _CalcOperation.Root) {
                    _numOfNums--;
                }
            } else {
                _numbers[0] = 0;
                _numOfNums = 0;
            }
            if (_numOfOps > 0) {
                for (oldOparatorsPos = 0; oldOparatorsPos < _numOfOps; oldOparatorsPos++) {
                    if (oldOparatorsPos == pos) {
                        oldOparatorsPos++;
                    }
                    newOperators[newOperatorsPos] = _operators[oldOparatorsPos];
                    newOperatorsPos++;
                }
                _operators = newOperators;
                _numOfOps--;
            }
        }
    }
}
