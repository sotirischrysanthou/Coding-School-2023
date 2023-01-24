using CarServiceCenterLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Session_11_Car_Service_Center {
    public partial class MainMenuForm : Form {
        private CarServiceCenter _carServiceCenter;
        private TransactionsForm _transactionsForm;
        private CustomersAndCarsForm _customersAndCarsForm;
        public MainMenuForm() {
            InitializeComponent();
            _carServiceCenter = new CarServiceCenter();
            _transactionsForm = new TransactionsForm(_carServiceCenter);
            _customersAndCarsForm = new CustomersAndCarsForm(_carServiceCenter);
        }
        private void MainMenuForm_Load(object sender, EventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {
            _transactionsForm.ShowDialog(); // Shows _transactionsForm
        }


        private void btnCustomerAndCars_Click(object sender, EventArgs e) {
            _customersAndCarsForm.ShowDialog(); // Shows _customerAndCarsForm
        }
    }
}
