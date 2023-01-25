using CarServiceCenterLib;
using DevExpress.Utils.Extensions;
using DevExpress.XtraBars;
using DevExpress.XtraGantt.Scheduling;
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

            string txtYearValue = txtYear.Text;
            string txtMonthValue = txtMonth.Text;
            int year, month;

            if (!string.IsNullOrEmpty(txtYearValue) && !string.IsNullOrEmpty(txtMonthValue) 
                && int.TryParse(txtYearValue, out year) && int.TryParse(txtMonthValue, out month)) {

                MessageBox.Show("Added!");

            } else {
                MessageBox.Show("Please enter valid integers for Years and Month, and not null or empty");
            }

        }
    }
}
