using CarServiceCenterLib.Models;
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
using System.Text.RegularExpressions;
using DevExpress.XtraEditors.ColorPick.Picker;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid;
using CarServiceCenterLib.Orm.Repositories;

namespace Session_16.Win {
    public partial class ServiceTasksForm : Form {
        private Serializer _serializer;

        public ServiceTasksForm() {
            InitializeComponent();
            _serializer = new Serializer();
        }
        private void ServiceTasksForm_Load_1(object sender, EventArgs e) {
            SetControlProperties();
        }

        private void SetControlProperties() {
            ServiceTaskRepo serviceTaskRepo = new ServiceTaskRepo();
            _serializer = new Serializer();
            bsServiceTasks.DataSource = serviceTaskRepo.GetAll();
            grdServiceTasks.DataSource = bsServiceTasks;

        }

        private void dgvServiceTasks_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }

        private void btn_Close_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btn_Close_MouseEnter(object sender, EventArgs e) {
            btn_Close.FlatAppearance.MouseOverBackColor = btn_Close.BackColor;
            btn_Close.ForeColor = Color.Blue;
            btn_Close.FlatAppearance.BorderColor = Color.Red;
            btn_Close.FlatAppearance.BorderSize = 2;
        }

        private void btn_Close_MouseLeave(object sender, EventArgs e) {
            btn_Close.ForeColor = Color.Black;
            btn_Close.FlatAppearance.BorderColor = Color.Black;
            btn_Close.FlatAppearance.BorderSize = 2;
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e) {
            ServiceTaskRepo serviceTaskRepo = new ServiceTaskRepo();
            GridView view = sender as GridView;
            Guid id = Guid.Parse(view.GetRowCellValue(view.FocusedRowHandle, colID).ToString());
            String code = view.GetRowCellValue(e.RowHandle, colCode).ToString();
            String description = view.GetRowCellValue(e.RowHandle, colDescription) as String;
            String hours = view.GetRowCellValue(e.RowHandle, colHours).ToString();
            // Code Cell
            if (code == null) {
                e.Valid = false;
                view.SetColumnError(colCode, "Insert Valid Brand");
            } else if (code == " ") {
                e.Valid = false;
                view.SetColumnError(colCode, "Fill Code cell");
            }
            // Description Cell
            if (description == null) {
                e.Valid = false;
                view.SetColumnError(colDescription, "Insert Valid Description");
            } else if (description == "") {
                e.Valid = false;
                view.SetColumnError(colDescription, "Fill Description cell");
            }
            // Hours Cell
            if (hours == null) {
                e.Valid = false;
                view.SetColumnError(colHours, "Insert Valid Hours");
            } else if (hours == "") {
                e.Valid = false;
                view.SetColumnError(colHours, "Fill Hours cell");
            } else if (!double.TryParse(hours, out _)) {
                e.Valid = false;
                view.SetColumnError(colHours, "Insert Valid Hours");
            }
            if (e.Valid) {
                view.ClearColumnErrors();
                serviceTaskRepo.Add((ServiceTask)bsServiceTasks.Current);   
            }
        }

        private void gridView1_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e) {
            ColumnView view = sender as ColumnView;
            GridColumn column = (e as EditFormValidateEditorEventArgs)?.Column ?? view.FocusedColumn;
            String cellVal = e.Value as String;
            if (column.FieldName == "Code") {
                // colCode changed
                if (cellVal == null) {
                    e.Valid = false;
                    view.SetColumnError(colCode, "Insert Valid Code");
                } else if (cellVal == " ") {
                    e.Valid = false;
                    view.SetColumnError(colCode, "Fill Code cell");
                }
                //else if (Convert.ToInt32(cellVal) == gridView1.Data  )
            } else if (column.FieldName == "Description") {
                // colDescription changed
                if (cellVal == null) {
                    e.Valid = false;
                    view.SetColumnError(colDescription, "Insert Valid Description");
                } else if (cellVal == "") {
                    e.Valid = false;
                    view.SetColumnError(colDescription, "Fill Description cell");
                }
            }
            if (column.FieldName == "Hours") {
                // colHours changed
                if (cellVal == null) {
                    e.Valid = false;
                    view.SetColumnError(colHours, "Insert Valid Hours");
                } else if (cellVal == "") {
                    e.Valid = false;
                    view.SetColumnError(colHours, "Fill Hours cell");
                } else if (!double.TryParse(cellVal, out _)) {
                    e.Valid = false;
                    view.SetColumnError(colHours, "Insert Valid Hours");
                }
            }
        }

        private void gridView1_InitNewRow(object sender, InitNewRowEventArgs e) {
            DevExpress.XtraGrid.Columns.GridColumn col = gridView1.Columns.ColumnByFieldName("Code");
            int dataRowCount = gridView1.DataRowCount;
            bool flag;
            // Traverse data rows and change the Price field values. 
            for (int j = 0; j <= dataRowCount; j++) {
                flag = true;
                for (int i = 0; i < dataRowCount; i++) {
                    object cellValue = gridView1.GetRowCellValue(i, col);
                    int newValue = Convert.ToInt32(cellValue);
                    if (j == newValue) {
                        flag = false;
                    }
                }
                if (flag) {
                    gridView1.SetRowCellValue(e.RowHandle, "Code", j);
                    return;
                }
            }
        }

        private void gridView1_RowDeleting(object sender, DevExpress.Data.RowDeletingEventArgs e) {
            GridView view = sender as GridView;
            ServiceTaskRepo serviceTaskRepo = new ServiceTaskRepo();
            Guid id = Guid.Parse(view.GetRowCellValue(view.FocusedRowHandle, colID).ToString());
            serviceTaskRepo.Delete(id);
        }

        private void gridView1_RowUpdated(object sender, RowObjectEventArgs e) {
            GridView view = sender as GridView;
            ServiceTaskRepo serviceTaskRepo = new ServiceTaskRepo();
            Guid id = Guid.Parse(view.GetRowCellValue(view.FocusedRowHandle, colID).ToString());
            serviceTaskRepo.Update(id, (ServiceTask)bsServiceTasks.Current);
        }
    }
}
