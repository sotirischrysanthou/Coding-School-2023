using System.Text;
using CalculatorLib;

namespace Session_09 {
    public partial class Form1 : Form {
        // It would be true when the last button pressed is an operator
        private bool _lastBtnIsNumber;
        private bool _isOperatorPressed;
        private bool _isEqualPressed;
        private Addition _addition;



        public Form1() {
            InitializeComponent();
            _lastBtnIsNumber = false;
            _isOperatorPressed = false;
            _addition = new Addition();
        }

        private void btnOne_Click(object sender, EventArgs e) {
            ClealIfIsANewEquation();
            ctrlDisplay.Text += "1";
            NumberPressed();
        }

        private void btnTwo_Click(object sender, EventArgs e) {
            ClealIfIsANewEquation();
            ctrlDisplay.Text += "2";
            NumberPressed();
        }
        private void btnThree_Click(object sender, EventArgs e) {
            ClealIfIsANewEquation();
            ctrlDisplay.Text += "3";
            NumberPressed();
        }
        private void btnFour_Click(object sender, EventArgs e) {
            ClealIfIsANewEquation();
            ctrlDisplay.Text += "4";
            NumberPressed();
        }
        private void btnFive_Click(object sender, EventArgs e) {
            ClealIfIsANewEquation();
            ctrlDisplay.Text += "5";
            NumberPressed();
        }
        private void btnSix_Click(object sender, EventArgs e) {
            ClealIfIsANewEquation();
            ctrlDisplay.Text += "6";
            NumberPressed();
        }
        private void btnSeven_Click(object sender, EventArgs e) {
            ClealIfIsANewEquation();
            ctrlDisplay.Text += "7";
            NumberPressed();
        }
        private void btnEight_Click(object sender, EventArgs e) {
            ClealIfIsANewEquation();
            ctrlDisplay.Text += "8";
            NumberPressed();
        }
        private void btnNine_Click(object sender, EventArgs e) {
            ClealIfIsANewEquation();
            ctrlDisplay.Text += "9";
            NumberPressed();
        }

        private void btnZero_Click(object sender, EventArgs e) {
            ctrlDisplay.Text += "0";
            NumberPressed();
        }

        private void btnRoot_Click(object sender, EventArgs e) {
            if (!_lastBtnIsNumber && !_isOperatorPressed) {
                ctrlDisplay.Text += "√";
                OperatorPressed();
            }
        }

        private void btnAddition_Click(object sender, EventArgs e) {
            if (_lastBtnIsNumber && !_isOperatorPressed) {
                ctrlDisplay.Text += " + ";
                OperatorPressed();
            }
        }

        private void btnSubtraction_Click(object sender, EventArgs e) {
            if (_lastBtnIsNumber && !_isOperatorPressed) {
                ctrlDisplay.Text += " - ";
                OperatorPressed();
            }
        }

        private void btnΜultiplication_Click(object sender, EventArgs e) {
            if (_lastBtnIsNumber && !_isOperatorPressed) {
                ctrlDisplay.Text += " x ";
                OperatorPressed();
            }
        }

        private void btnDivision_Click(object sender, EventArgs e) {
            if (_lastBtnIsNumber && !_isOperatorPressed) {
                ctrlDisplay.Text += " / ";
                OperatorPressed();
            }
        }

        private void btnExposition_Click(object sender, EventArgs e) {
            if (_lastBtnIsNumber && !_isOperatorPressed) {
                ctrlDisplay.Text += "^";
                OperatorPressed();
            }
        }

        private void btnEqual_Click(object sender, EventArgs e) {
            if (_lastBtnIsNumber) {
                ctrlDisplay.Text += " = ";
                OperatorPressed();
                EqualPressed();
                int[] numbers = new int[2];
                StringBuilder operators = new StringBuilder();
                int numOfNums = 0;
                String ops = "+-x/^=";
                String expresion = ctrlDisplay.Text;
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
                ctrlDisplay.Text += res.ToString();
            }
        }

        private void OperatorPressed() {
            _isOperatorPressed = true;
            _lastBtnIsNumber = false;
        }
        private void EqualPressed() {
            _isOperatorPressed = false;
            _isEqualPressed = true;
        }

        private void NumberPressed() {
            _lastBtnIsNumber = true;
        }

        private void ClealIfIsANewEquation() {
            if (_isEqualPressed) {
                _isEqualPressed = false;
                ctrlDisplay.Text = string.Empty;
            }
        }


    }
}