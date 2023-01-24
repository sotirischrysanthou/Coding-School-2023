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
        public MainMenuForm() {
            InitializeComponent();
            _carServiceCenter = new CarServiceCenter();
        }

        private void button1_Click(object sender, EventArgs e) {
            TransactionsForm t = new TransactionsForm(_carServiceCenter);
            t.ShowDialog(); // Shows Form2
        }

        private void MainMenuForm_Load(object sender, EventArgs e) {

        }
    }
}
