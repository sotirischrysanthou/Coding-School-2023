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
        }
    }
}
