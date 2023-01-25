using CarServiceCenterLib;
using DevExpress.XtraBars;
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
    public partial class MonthlyLedgerForm : Form {
        private Serializer _serializer;
        private CarServiceCenter _carServiceCenter;

        public MonthlyLedgerForm(CarServiceCenter carServiceCenter) {
            InitializeComponent();
            _serializer = new Serializer();
            _carServiceCenter = carServiceCenter;
        }

        private void MonthlyLedgerForm_Load(object sender, EventArgs e) {
            SetControlProperties();
            _serializer = new Serializer();
        }

        private void SetControlProperties() {
            _serializer = new Serializer();

            bsManagers.DataSource = _carServiceCenter.Managers;
            grdMonthlyLedger.DataSource = bsManagers;
        }

        private void simpleButton3_Click(object sender, EventArgs e) {

        }

        private void btnLoad_Click(object sender, EventArgs e) {

        }

        private void grdCustomers_Click(object sender, EventArgs e) {

        }

        private void dtFromData_EditValueChanged(object sender, EventArgs e) {
            
            MessageBox.Show(dtFromData.EditValue.ToString());
        }
    }
}
