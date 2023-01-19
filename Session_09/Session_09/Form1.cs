namespace Session_09 {
    public partial class Form1 : Form {
        // It would be true when the last button pressed is an operator
        private bool _lastCharIsOperator;
        
        public Form1() {
            InitializeComponent();
            _lastCharIsOperator = false;
        }

        private void btnOne_Click(object sender, EventArgs e) {
            ctrlDisplay.Text += "1";
        }

        private void btnTwo_Click(object sender, EventArgs e) {
            ctrlDisplay.Text += "2";
        }
        private void btnThree_Click(object sender, EventArgs e) {
            ctrlDisplay.Text += "3";
        }
        private void btnFour_Click(object sender, EventArgs e) {
            ctrlDisplay.Text += "4";
        }
        private void btnFive_Click(object sender, EventArgs e) {
            ctrlDisplay.Text += "5";
        }
        private void btnSix_Click(object sender, EventArgs e) {
            ctrlDisplay.Text += "6";
        }
        private void btnSeven_Click(object sender, EventArgs e) {
            ctrlDisplay.Text += "7";
        }
        private void btnEight_Click(object sender, EventArgs e) {
            ctrlDisplay.Text += "8";
        }
        private void btnNine_Click(object sender, EventArgs e) {
            ctrlDisplay.Text += "9";
        }

        private void btnZero_Click(object sender, EventArgs e) {
            ctrlDisplay.Text += "0";
        }

        private void btnRoot_Click(object sender, EventArgs e) {
            ctrlDisplay.Text += "√";
        }

        private void btnAddition_Click(object sender, EventArgs e) {
            ctrlDisplay.Text += " + ";
        }

        private void btnSubtraction_Click(object sender, EventArgs e) {
            ctrlDisplay.Text += " - ";
        }

        private void btnΜultiplication_Click(object sender, EventArgs e) {
            ctrlDisplay.Text += " x ";
        }

        private void btnDivision_Click(object sender, EventArgs e) {
            ctrlDisplay.Text += " / ";
        }

        private void btnExposition_Click(object sender, EventArgs e) {
            ctrlDisplay.Text += "^";
        }

        private void btnEqual_Click(object sender, EventArgs e) {
            ctrlDisplay.Text += " = ";
        }

        private void OperatorPressed() {
            _lastCharIsOperator = true;
        }


    }
}