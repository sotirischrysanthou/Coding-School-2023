using System.Text;
using CalculatorLib;

namespace Session_09 {
    public partial class Form1 : Form {
        //Properties
        
        // It would be true when the last button pressed is an operator
        private bool _lastBtnIsNumber;
        private bool _isOperatorPressed;
        private bool _isEqualPressed;
        private Resolver _resolver;
        private Addition _addition;


        //Methods
        public Form1() {
            InitializeComponent();
            _lastBtnIsNumber = false;
            _isOperatorPressed = false;
            _resolver = new Resolver();
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
                ctrlDisplay.Text += _resolver.Resolve(ctrlDisplay.Text);
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