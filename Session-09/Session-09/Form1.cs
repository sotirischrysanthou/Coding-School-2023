namespace Session_09 {
    public partial class Form1 : Form {
        // It would be true when the last button pressed is an operator
        private bool _lastBtnIsNumber;

        public Form1() {
            InitializeComponent();
            _lastBtnIsNumber = false;
        }

        private void btnOne_Click(object sender, EventArgs e) {
            ctrlDisplay.Text += "1";
            NumberPressed();
        }

        private void btnTwo_Click(object sender, EventArgs e) {
            ctrlDisplay.Text += "2";
            NumberPressed();
        }
        private void btnThree_Click(object sender, EventArgs e) {
            ctrlDisplay.Text += "3";
            NumberPressed();
        }
        private void btnFour_Click(object sender, EventArgs e) {
            ctrlDisplay.Text += "4";
            NumberPressed();
        }
        private void btnFive_Click(object sender, EventArgs e) {
            ctrlDisplay.Text += "5";
            NumberPressed();
        }
        private void btnSix_Click(object sender, EventArgs e) {
            ctrlDisplay.Text += "6";
            NumberPressed();
        }
        private void btnSeven_Click(object sender, EventArgs e) {
            ctrlDisplay.Text += "7";
            NumberPressed();
        }
        private void btnEight_Click(object sender, EventArgs e) {
            ctrlDisplay.Text += "8";
            NumberPressed();
        }
        private void btnNine_Click(object sender, EventArgs e) {
            ctrlDisplay.Text += "9";
            NumberPressed();
        }

        private void btnZero_Click(object sender, EventArgs e) {
            ctrlDisplay.Text += "0";
            NumberPressed();
        }

        private void btnRoot_Click(object sender, EventArgs e) {
            if (_lastBtnIsNumber) {
                ctrlDisplay.Text += "√";
                OperatorPressed();
            }
        }

        private void btnAddition_Click(object sender, EventArgs e) {
            if (_lastBtnIsNumber) {
                ctrlDisplay.Text += " + ";
                OperatorPressed();
            }
        }

        private void btnSubtraction_Click(object sender, EventArgs e) {
            if (_lastBtnIsNumber) {
                ctrlDisplay.Text += " - ";
                OperatorPressed();
            }
        }

        private void btnΜultiplication_Click(object sender, EventArgs e) {
            if (_lastBtnIsNumber) {
                ctrlDisplay.Text += " x ";
                OperatorPressed();
            }
        }

        private void btnDivision_Click(object sender, EventArgs e) {
            if (_lastBtnIsNumber) {
                ctrlDisplay.Text += " / ";
                OperatorPressed();
            }
        }

        private void btnExposition_Click(object sender, EventArgs e) {
            if (_lastBtnIsNumber) {
                ctrlDisplay.Text += "^";
                OperatorPressed();
            }
        }

        private void btnEqual_Click(object sender, EventArgs e) {
            if (_lastBtnIsNumber) {
                ctrlDisplay.Text += " = ";
                OperatorPressed();
                int[] numbers = new int[30];
                int numOfNums = 0;
                String operators = "+-x/^√";
                String expresion = ctrlDisplay.Text;
                foreach (var c in expresion) {
                    numbers[numOfNums] = Convert.ToInt32(c);
                    //operators.Contains(c);
                    ctrlDisplay.Text = numbers[numOfNums].ToString();
                }
            }
        }

        private void OperatorPressed() {
            _lastBtnIsNumber = false;
        }

        private void NumberPressed() {
            _lastBtnIsNumber = true;
        }


    }
}