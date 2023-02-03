using CarServiceCenterLib.Models;
using DevExpress.Utils.Extensions;
using DevExpress.XtraBars;
using DevExpress.XtraCharts.GLGraphics;
using DevExpress.XtraGantt.Scheduling;
using DevExpress.XtraSpreadsheet.Commands;
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

namespace Session_16.Win {
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

        private void btnCalculate_Click(object sender, EventArgs e) {
            List<MonthlyLedger> list = new List<MonthlyLedger>();
            MonthlyLedger monthlyLedger;
            int year = DateTime.Now.Year;
            for (int month = 1; month <= 12; month++) {
                monthlyLedger = new MonthlyLedger(year, month);
                monthlyLedger.Expenses += _carServiceCenter.SalaryEngineersFrom(year, month);
                monthlyLedger.Expenses += _carServiceCenter.SalaryManagersFrom(year, month);
                foreach (Transaction transaction in _carServiceCenter.Transactions) {
                    if (transaction.Date.Year == year && transaction.Date.Month == month) {
                        monthlyLedger.Incomes += transaction.TotalPrice;
                    }
                }
                monthlyLedger.Total = monthlyLedger.Incomes - monthlyLedger.Expenses;
                list.Add(monthlyLedger);
            }
            bsMonthlyLedger.DataSource = list;
            grdMonthlyLedger.DataSource = bsMonthlyLedger;
            gridView1.RefreshData();
        }

        //Customize Button
        private void btnCalculate_MouseEnter(object sender, EventArgs e) {
            btnCalculate.FlatAppearance.MouseOverBackColor = btnCalculate.BackColor;
            btnCalculate.ForeColor = Color.Blue;
            btnCalculate.FlatAppearance.BorderColor = Color.Red;
            btnCalculate.FlatAppearance.BorderSize = 2;
        }

        private void btnCalculate_MouseLeave(object sender, EventArgs e) {
            btnCalculate.ForeColor = Color.Black;
            btnCalculate.FlatAppearance.BorderColor = Color.Black;
            btnCalculate.FlatAppearance.BorderSize = 2;
        }
    }
}
