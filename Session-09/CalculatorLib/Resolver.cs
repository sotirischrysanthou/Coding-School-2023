using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using calOps = CalculatorLib.CalcOperations.CalcOperation;
using MessageLoggerLib;

namespace CalculatorLib {
    public class Resolver : MessageLoggerLib.Action {
        // Properties
        private Parser _parser;
        private List<double> _numbers;
        private List<calOps> _operators;

        // Constructors
        public Resolver() {
            _parser = new Parser();
            _numbers = new List<double>();
            _operators = new List<calOps>();
        }

        // Methods
        public override bool Run(String expresion, out String output) {
            _parser.Parse(expresion, _numbers, _operators);
            double res = 0;
            while (_operators[0] != calOps.Equal) {
                res = SimpleEquation();
            }
            output = res.ToString();
            return true;
        }

        private int FindOperatorWithHighestPiority() {
            calOps op = _operators[0];
            int highestPriority = 0;
            for (int i = 0; i < _operators.Count; i++) {
                if (_operators[i] > op) {
                    highestPriority = i;
                    op = _operators[i];
                }
            }
            return highestPriority;
        }

        private double SimpleEquation() {
            int pos = FindOperatorWithHighestPiority();
            double res = _numbers[pos];

            switch (_operators[pos]) {
                case calOps.Add:
                    res = _numbers[pos] + _numbers[pos + 1];
                    break;
                case calOps.Subtract:
                    res = _numbers[pos] - _numbers[pos + 1];
                    break;
                case calOps.Multiply:
                    res = _numbers[pos] * _numbers[pos + 1];
                    break;
                case calOps.Divide:
                    res = _numbers[pos] / _numbers[pos + 1];
                    break;
                case calOps.Exp:
                    res = Math.Pow(_numbers[pos], _numbers[pos + 1]);
                    break;
                case calOps.Root:
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
            _numbers[pos] = res;
            if (_operators[pos] != calOps.Root) {
                _numbers.RemoveAt(pos+1);
            }
            _operators.RemoveAt(pos);
        }
    }
}

// 15 + 5 - 1 =
// 19
// =