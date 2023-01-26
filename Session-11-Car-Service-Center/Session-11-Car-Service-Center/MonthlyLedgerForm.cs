using CarServiceCenterLib;
using DevExpress.Utils.Extensions;
using DevExpress.XtraBars;
using DevExpress.XtraCharts.GLGraphics;
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
            bsMonthlyLedger.DataSource = _carServiceCenter.Managers;
            grdMonthlyLedger.DataSource = bsMonthlyLedger;
        }
        private void grdCustomers_Click(object sender, EventArgs e) {

        }

        private void deFrom_EditValueChanged(object sender, EventArgs e) {

            MessageBox.Show(deFrom.EditValue.ToString());
        }

        private void btnPrint_Click(object sender, EventArgs e) {

        }

        //TODO : Delete this
        //private void btnCreateLedger_Click(object sender, EventArgs e) {

        //    string txtYearValue = txtYear.Text;
        //    string txtMonthValue = txtMonth.Text;
        //    int year, month;

        //    if (string.IsNullOrEmpty(txtYearValue) || string.IsNullOrEmpty(txtMonthValue)) {
        //        MessageBox.Show("Please enter Year and Month, and not null or empty");
        //    } else {
        //        if (int.TryParse(txtYearValue, out year) && int.TryParse(txtMonthValue, out month)) {
        //            if (year >= 1990 && year <= DateTime.Now.Year) {
        //                if (month >= 1 && month <= 12) {
        //                    MessageBox.Show("Added!");
        //                    _carServiceCenter.MonthlyLedgers.Add(new MonthlyLedger(year, month, _carServiceCenter.SalaryManagersFrom(year, month), _carServiceCenter.SalaryEngineersFrom(year, month)));
        //                } else {
        //                    MessageBox.Show("Please enter valid month");
        //                }
        //            } else {
        //                MessageBox.Show("Please give Year between 1990 and Current Year");
        //            }
        //        } else {
        //            MessageBox.Show("Please enter integers");
        //        }
        //    }
        //}

        //private void btnCalculate_Click(object sender, EventArgs e) {
        //    List<MonthlyLedger> monthlyLedgers = null;
        //    if (deFrom.EditValue != null && deTo.EditValue != null) {
        //        if((DateTime)deTo.EditValue > (DateTime)deFrom.EditValue) {
        //            monthlyLedgers = _carServiceCenter.BookKeepingFromTo((DateTime)deFrom.EditValue, (DateTime)deTo.EditValue);
        //            bsMonthlyLedger.DataSource = monthlyLedgers;
        //            grdMonthlyLedger.DataSource = bsMonthlyLedger;
        //            gridView1.RefreshData();
        //        } else {
        //            MessageBox.Show("From should be before To");
        //        }
        //    } else {
        //        MessageBox.Show("Give Dates");
        //    }
        //}
    }
}
