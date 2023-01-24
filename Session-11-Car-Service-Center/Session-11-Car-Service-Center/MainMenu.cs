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
    public partial class MainMenu : Form {
        private CarServiceCenter carServiceCenter;
        public MainMenu() {
            InitializeComponent();
            carServiceCenter = new CarServiceCenter();
        }

        private void button1_Click(object sender, EventArgs e) {
            Transactions t = new Transactions(carServiceCenter);
            t.ShowDialog(); // Shows Form2
        }

        private void MainMenu_Load(object sender, EventArgs e) {

        }
    }
}
