using CarServiceCenterLib.Models;
using CarServiceCenterLib.Orm.Repositories;
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
            TransactionRepo transactionRepo = new TransactionRepo();
            List<Transaction> transactions = transactionRepo.GetAll().ToList();
            List<MonthlyLedger> list = new List<MonthlyLedger>();
            MonthlyLedger monthlyLedger;
            int year = DateTime.Now.Year;
            for (int month = 1; month <= 12; month++) {
                monthlyLedger = new MonthlyLedger(year, month);
                monthlyLedger.Expenses += SalaryEngineersFrom(year, month);
                monthlyLedger.Expenses += SalaryManagersFrom(year, month);
                foreach (Transaction transaction in transactions) {
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
        private double SalaryEngineersFrom(int Year, int Month) {
            double TotalSalary = 0;
            EngineerRepo engineerRepo = new EngineerRepo();
            List<Engineer> engineers = engineerRepo.GetAll().ToList();
            foreach (Engineer engineer in engineers) {
                if (((DateTime)engineer.StartDate).Year <= Year && ((DateTime)engineer.StartDate).Month <= Month) {
                    TotalSalary += engineer.SalaryPerMonth;
                }
            }
            return TotalSalary;
        }
        private double SalaryManagersFrom(int Year, int Month) {
            double TotalSalary = 0;
            ManagerRepo managerRepo = new ManagerRepo();
            List<Manager> managers = managerRepo.GetAll().ToList();
            foreach (Manager manager in managers) {
                if (((DateTime)manager.StartDate).Year <= Year && ((DateTime)manager.StartDate).Month <= Month) {
                    TotalSalary += manager.SalaryPerMonth;
                }
            }
            return TotalSalary;
        }
    }

}
