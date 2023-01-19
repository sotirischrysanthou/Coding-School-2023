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
            NumberProc("1");
        }

        private void btnTwo_Click(object sender, EventArgs e) {
            NumberProc("2");
        }
        private void btnThree_Click(object sender, EventArgs e) {
            NumberProc("3");
        }
        private void btnFour_Click(object sender, EventArgs e) {
            NumberProc("4");
        }
        private void btnFive_Click(object sender, EventArgs e) {
            NumberProc("5");
        }
        private void btnSix_Click(object sender, EventArgs e) {
            NumberProc("6");
        }
        private void btnSeven_Click(object sender, EventArgs e) {
            NumberProc("7");
        }
        private void btnEight_Click(object sender, EventArgs e) {
            NumberProc("8");
        }
        private void btnNine_Click(object sender, EventArgs e) {
            NumberProc("9");
        }

        private void btnZero_Click(object sender, EventArgs e) {
            NumberProc("0");
        }

        private void btnRoot_Click(object sender, EventArgs e) {
            OperationProc("√");
        }

        private void btnAddition_Click(object sender, EventArgs e) {
            OperationProc("+");
        }

        private void btnSubtraction_Click(object sender, EventArgs e) {
            OperationProc("-");
        }

        private void btnΜultiplication_Click(object sender, EventArgs e) {
            OperationProc("x");
        }

        private void btnDivision_Click(object sender, EventArgs e) {
            OperationProc("/");
        }

        private void btnExposition_Click(object sender, EventArgs e) {
            OperationProc("^");
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

        private void NumberProc(string n) {
            ClealIfIsANewEquation();
            ctrlDisplay.Text += n;
            NumberPressed();
        }

        private void OperationProc(string o) {
            if (_lastBtnIsNumber && !_isOperatorPressed) {
                ctrlDisplay.Text += o;
                OperatorPressed();
            }
        }


    }
}