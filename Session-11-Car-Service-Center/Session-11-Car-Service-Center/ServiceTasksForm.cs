using CarServiceCenterLib;
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
    public partial class ServiceTasksForm : Form {
        private CarServiceCenter _carServiceCenter;
        public ServiceTasksForm(CarServiceCenter carServiceCenter) {
            InitializeComponent();
            _carServiceCenter = carServiceCenter;
        }
        private void ServiceTasksForm_Load(object sender, EventArgs e) {
            SetControlProperties();
        }

        private void SetControlProperties() {
            bsServiceTasks.DataSource = _carServiceCenter.ServiceTasks;
            grdServiceTasks.DataSource = bsServiceTasks;
        }
    }
}
