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
    }
}
