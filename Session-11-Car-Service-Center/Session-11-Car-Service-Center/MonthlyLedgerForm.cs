using CarServiceCenterLib;
using DevExpress.Utils.Extensions;
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
        private void grdCustomers_Click(object sender, EventArgs e) {

        }

        private void deFrom_EditValueChanged(object sender, EventArgs e) {
            
            MessageBox.Show(deFrom.EditValue.ToString());
        }

        private void btnPrint_Click(object sender, EventArgs e) {

        }

        private void btnCreateLedger_Click(object sender, EventArgs e) {
            if(txtYear.ContainerIsEmpty() || txtMonth.ContainerIsEmpty()) {
                MessageBox.Show("Complete Year and Month");
            }
        }
    }
}
