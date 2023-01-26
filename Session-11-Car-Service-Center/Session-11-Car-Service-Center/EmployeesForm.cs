using CarServiceCenterLib;
using DevExpress.XtraEditors.Repository;
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
            SetLookUpEdit<Manager>(repManagerName, _carServiceCenter.Managers, "Name", "ID");
            SetLookUpEdit<Manager>(repManagerSurname, _carServiceCenter.Managers, "Surname", "ID");
        }

        private void btnSave_Click(object sender, EventArgs e) {
            _serializer.SerializeToFile(_carServiceCenter, "CarServiceCenter.json");
            DevExpress.XtraEditors.XtraMessageBox.Show("Saved!");

        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void SetLookUpEdit<T>(RepositoryItemLookUpEdit rep, List<T> list, String displayMember, String valueMember) {
            rep.DataSource = list;
            rep.DisplayMember = displayMember;
            rep.ValueMember = valueMember;
        }

        private void gridView2_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e) {
            GridView view = sender as GridView;
        }
        //Customize Buttons

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

        private void btnClose_MouseEnter(object sender, EventArgs e) {
            btnClose.FlatAppearance.MouseOverBackColor = btnClose.BackColor;
            btnClose.ForeColor = Color.Blue;
            btnClose.FlatAppearance.BorderColor = Color.Red;
            btnClose.FlatAppearance.BorderSize = 2;
        }

        private void btnClose_MouseLeave(object sender, EventArgs e) {
            btnClose.ForeColor = Color.Black;
            btnClose.FlatAppearance.BorderSize = 0;
        }
    }
}
