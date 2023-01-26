using CarServiceCenterLib;
using SerializerLib;
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
    public partial class CustomersAndCarsForm : Form {
        private CarServiceCenter _carServiceCenter;
        private Serializer _serializer;

        public CustomersAndCarsForm(CarServiceCenter carServiceCenter) {
            InitializeComponent();
            _serializer = new Serializer();
            _carServiceCenter = carServiceCenter;
        }
        private void CustomersAndCarsForm_Load(object sender, EventArgs e) {
            SetControlProperties();
            _serializer = new Serializer();

        }

        private void SetControlProperties() {
            _serializer = new Serializer();
            bsService.DataSource = _carServiceCenter;
            bsCustomers.DataSource = bsService;

            bsCustomers.DataSource = _carServiceCenter.Customers;
            grdCustomers.DataSource = bsCustomers;

            bsCars.DataSource = _carServiceCenter.Cars;
            grdCars.DataSource = bsCars;

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e) {

        }

        private void bsCustomers_CurrentChanged(object sender, EventArgs e) {

        }

        private void bsCars_CurrentChanged(object sender, EventArgs e) {

        }

        private void bsService_CurrentChanged(object sender, EventArgs e) {

        }

        private void btn_Save_Click(object sender, EventArgs e) {
            _serializer.SerializeToFile(_carServiceCenter, "CarServiceCenter.json");
            DevExpress.XtraEditors.XtraMessageBox.Show("Saved!");

        }

        private void btn_Close_Click(object sender, EventArgs e) {
            this.Close();
        }

        //Customize Buttons

        private void btn_Save_MouseEnter(object sender, EventArgs e) {
            btn_Save.FlatAppearance.MouseOverBackColor = btn_Save.BackColor;
            btn_Save.ForeColor = Color.Blue;
            btn_Save.FlatAppearance.BorderColor = Color.Red;
            btn_Save.FlatAppearance.BorderSize = 2;
        }

        private void btn_Save_MouseLeave(object sender, EventArgs e) {
            btn_Save.ForeColor = Color.Black;
            btn_Save.FlatAppearance.BorderSize = 0;
        }

        private void btn_Close_MouseEnter(object sender, EventArgs e) {
            btn_Close.FlatAppearance.MouseOverBackColor = btn_Close.BackColor;
            btn_Close.ForeColor = Color.Blue;
            btn_Close.FlatAppearance.BorderColor = Color.Red;
            btn_Close.FlatAppearance.BorderSize = 2;
        }

        private void btn_Close_MouseLeave(object sender, EventArgs e) {
            btn_Close.ForeColor = Color.Black;
            btn_Close.FlatAppearance.BorderSize = 0;
        }
    }
}
