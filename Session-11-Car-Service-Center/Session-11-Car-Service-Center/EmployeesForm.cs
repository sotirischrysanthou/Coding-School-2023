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
    public partial class EmployeesForm : Form {
        private Serializer _serializer;
        private CarServiceCenter _carServiceCenter;
        public EmployeesForm(CarServiceCenter carServiceCenter) {
            InitializeComponent();
            _serializer = new Serializer();
            _carServiceCenter = carServiceCenter;
        }

        private void EmployeesForm_Load(object sender, EventArgs e) {
            SetControlProperties();
        }
        private void SetControlProperties() {
            bsEngineers.DataSource = _carServiceCenter.Engineers;
            grdEngineers.DataSource = bsEngineers;
            bsManagers.DataSource = _carServiceCenter.Managers;
            grdManagers.DataSource = bsManagers;
        }

        private void btnSave_Click(object sender, EventArgs e) {
            _serializer.SerializeToFile(_carServiceCenter, "CarServiceCenter.json");
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
