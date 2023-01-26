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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;

namespace Session_11_Car_Service_Center {
    public partial class ServiceTasksForm : Form {
        private CarServiceCenter _carServiceCenter;
        private Serializer _serializer;
        
        public ServiceTasksForm(CarServiceCenter carServiceCenter) {
            InitializeComponent();
            _carServiceCenter = carServiceCenter;
            _serializer = new Serializer();   
        }
        private void ServiceTasksForm_Load_1(object sender, EventArgs e) {
            SetControlProperties();
        }

        private void SetControlProperties() {
            
            _serializer = new Serializer();
            bsServiceTasks.DataSource = _carServiceCenter.ServiceTasks;
            grdServiceTasks.DataSource = bsServiceTasks;
        }

        private void dgvServiceTasks_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }

        private void btnSave_Click(object sender, EventArgs e) {
            _serializer.SerializeToFile(_carServiceCenter, "CarServiceCenter.json");
            DevExpress.XtraEditors.XtraMessageBox.Show("Saved!");
        }

        private void btn_Close_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnSave_MouseEnter(object sender, EventArgs e) {
            btnSave.FlatAppearance.MouseOverBackColor = btnSave.BackColor;
            btnSave.ForeColor = Color.Blue;
            btnSave.FlatAppearance.BorderColor = Color.Red;
            btnSave.FlatAppearance.BorderSize = 2;
        }

        private void btnSave_MouseLeave(object sender, EventArgs e) {
            btnSave.ForeColor = Color.Black;
            btnSave.FlatAppearance.BorderSize = 0;
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
