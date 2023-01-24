using System.Text;
using MessageLoggerLib;
using CalculatorLib;

namespace Session_09 {
    public partial class Form1 : Form {
        //Properties

        // It would be true when the last button pressed is an operator
        private bool _isLastBtnNumber;
        private bool _isEqualPressed;
        private Resolver _resolver;
        private ActionRequest _actionRequest;
        private ActionResponse _actionResponse;
        private ActionResolver _actionResolver;

        // Constractors
        public Form1() {
            InitializeComponent();
            _isLastBtnNumber = false;
            _resolver = new Resolver();
            _actionResolver = new ActionResolver();
        }


        //Methods

        private void Form1_Load(object sender, EventArgs e) {
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
        }

        private void Form1_FormClosing(System.Object sender, FormClosingEventArgs e){
            MessageBox.Show("closing..");
            _actionResolver.Logger.ReadAll();
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
            if (!_isLastBtnNumber) {
                ClealIfIsANewEquation();
                ctrlDisplay.Text += "√";
                OperatorPressed();
            }
        }

        private void btnAddition_Click(object sender, EventArgs e) {
            OperationProc(" + ");
        }

        private void btnSubtraction_Click(object sender, EventArgs e) {
            OperationProc(" - ");
        }

        private void btnΜultiplication_Click(object sender, EventArgs e) {
            OperationProc(" x ");
        }

        private void btnDivision_Click(object sender, EventArgs e) {
            OperationProc(" / ");
        }

        private void btnExposition_Click(object sender, EventArgs e) {
            OperationProc("^");
        }

        private void btnEqual_Click(object sender, EventArgs e) {
            String text;
            if (_isLastBtnNumber) {
                ctrlDisplay.Text += " = ";
                OperatorPressed();
                EqualPressed();
                _actionRequest = new ActionRequest(ctrlDisplay.Text, (MessageLoggerLib.Action)_resolver);
                _actionResponse = _actionResolver.Execute(_actionRequest);
                ctrlDisplay.Text += _actionResponse.Output;
            }
        }

        private void OperatorPressed() {
            _isLastBtnNumber = false;
        }
        private void EqualPressed() {
            _isEqualPressed = true;
        }

        private void NumberPressed() {
            _isLastBtnNumber = true;
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
            if (_isLastBtnNumber) {
                ctrlDisplay.Text += o;
                OperatorPressed();
            }
        }
    }
}