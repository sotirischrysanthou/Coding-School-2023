using CarServiceCenterLib.Models;
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
using DevExpress.XtraGrid.Columns;
using System.Text.RegularExpressions;
using DevExpress.XtraEditors.ColorPick.Picker;
using DevExpress.XtraGrid.Views.Base;
using CarServiceCenterLib.Orm.Repositories;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Session_16.Win {
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
            EngineerRepo engineerRepo = new EngineerRepo();
            ManagerRepo managerRepo = new ManagerRepo();
            bsEngineers.DataSource = engineerRepo.GetAll();//_carServiceCenter.Engineers;
            grdEngineers.DataSource = bsEngineers;
            bsManagers.DataSource = managerRepo.GetAll();//_carServiceCenter.Managers;
            grdManagers.DataSource = bsManagers;
            SetLookUpEdit<Manager>(repManagerName, managerRepo.GetAll().ToList(), "Name", "ID");
            SetLookUpEdit<Manager>(repManagerSurname, managerRepo.GetAll().ToList(), "Surname", "ID");
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
            btnSave.FlatAppearance.BorderColor = Color.Black;
            btnSave.FlatAppearance.BorderSize = 2;
        }

        private void btnClose_MouseEnter(object sender, EventArgs e) {
            btnClose.FlatAppearance.MouseOverBackColor = btnClose.BackColor;
            btnClose.ForeColor = Color.Blue;
            btnClose.FlatAppearance.BorderColor = Color.Red;
            btnClose.FlatAppearance.BorderSize = 2;
        }

        private void btnClose_MouseLeave(object sender, EventArgs e) {
            btnClose.ForeColor = Color.Black;
            btnClose.FlatAppearance.BorderColor = Color.Black;
            btnSave.FlatAppearance.BorderSize = 2;
        }
        //gridView1_ValidateRow Giannis
        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e) {
            EngineerRepo engineerRepo = new EngineerRepo();
            GridView view = sender as GridView;
            GridColumn colName = view.Columns["Name"];
            GridColumn colSurName = view.Columns["Surname"];
            GridColumn colEngineersManagerName = view.Columns["ManagerID"];
            GridColumn colEngineersManagerSurname = view.Columns["ManagerID"];
            GridColumn colSalaryPerMonth = view.Columns["SalaryPerMonth"];
            GridColumn colEngineerStartDate = view.Columns["StartDate"];
            Guid id = Guid.Parse(view.GetRowCellValue(e.RowHandle, colEngineerID).ToString());
            String name = view.GetRowCellValue(e.RowHandle, colName) as String;
            String surname = view.GetRowCellValue(e.RowHandle, colSurName) as String;
            String managerName = view.GetRowCellValue(e.RowHandle, colEngineersManagerName).ToString();
            String managerSurname = view.GetRowCellValue(e.RowHandle, colEngineersManagerSurname).ToString();
            String salaryPerMonth = view.GetRowCellValue(e.RowHandle, colSalaryPerMonth).ToString();
            String startDay;
            if (view.GetRowCellValue(e.RowHandle, colEngineerStartDate) != null)
                startDay = view.GetRowCellValue(e.RowHandle, colEngineerStartDate).ToString();
            else
                startDay = null;
            if (name == null) {
                e.Valid = false;
                view.SetColumnError(colName, "Insert Valid Name");
            } else if (name == "") {
                e.Valid = false;
                view.SetColumnError(colName, "Fill Name cell");
            }
            // Surname Cell
            if (surname == null) {
                e.Valid = false;
                view.SetColumnError(colSurName, "Insert Valid Surname");
            } else if (surname == "") {
                e.Valid = false;
                view.SetColumnError(colSurName, "Fill Surname cell");
            }
            // Manager Name Cell
            if (managerName == null) {
                e.Valid = false;
                view.SetColumnError(colEngineersManagerName, "Insert Valid Manager Name");
            } else if (managerName == "") {
                e.Valid = false;
                view.SetColumnError(colEngineersManagerName, "Fill Manager Name cell");
            }
            // Manager Surname Cell
            if (managerSurname == null) {
                e.Valid = false;
                view.SetColumnError(colEngineersManagerSurname, "Insert Valid Manager Surname");
            } else if (managerSurname == "") {
                e.Valid = false;
                view.SetColumnError(colEngineersManagerSurname, "Fill Manager Surname cell");
            }
            // Salary Per Month Cell
            if (salaryPerMonth == null) {
                e.Valid = false;
                view.SetColumnError(colSalaryPerMonth, "Insert Valid Salary Per Month");
            } else if (salaryPerMonth == "0") {
                e.Valid = false;
                view.SetColumnError(colSalaryPerMonth, "Fill Salary Per Month cell");
            }
            // Start Day Cell
            if (startDay == null) {
                e.Valid = false;
                view.SetColumnError(colEngineerStartDate, "Insert Valid Start Day");
            } else if (startDay == "") {
                e.Valid = false;
                view.SetColumnError(colEngineerStartDate, "Fill Start Day cell");
            }

            if (e.Valid) {
                view.ClearColumnErrors();
                engineerRepo.Add((Engineer)bsEngineers.Current);
            }
        }

        private void gridView1_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e) {
            ColumnView view = sender as ColumnView;
            GridColumn column = (e as EditFormValidateEditorEventArgs)?.Column ?? view.FocusedColumn;
            String cellVal = e.Value.ToString();
            if (column.FieldName == "Name") {
                // colName changed
                if (cellVal == null) {
                    e.Valid = false;
                    view.SetColumnError(colName, "Insert Valid Name");
                } else if (cellVal == "") {
                    e.Valid = false;
                    view.SetColumnError(colName, "Fill Name cell");
                }
            } else if (column.FieldName == "Surname") {
                // colSurname changed
                if (cellVal == null) {
                    e.Valid = false;
                    view.SetColumnError(colSurname, "Insert Valid Surname");
                } else if (cellVal == "") {
                    e.Valid = false;
                    view.SetColumnError(colSurname, "Fill Surname cell");
                }
            } else if (column.FieldName == "ManagerID") {
                if (cellVal == null) {
                    e.Valid = false;
                    view.SetColumnError(colEngineersManagerName, "Insert Valid Manager");
                    view.SetColumnError(colEngineersManagerSurname, "Insert Valid Manager");
                } else if (cellVal == "") {
                    e.Valid = false;
                    view.SetColumnError(colEngineersManagerName, "Fill Manager cell");
                    view.SetColumnError(colEngineersManagerSurname, "fill Manager cell");
                }
            }else if (column.FieldName == "SalaryPerMonth") {
                if (cellVal == null) {
                    e.Valid = false;
                    view.SetColumnError(colSalaryPerMonth, "Insert Valid Salary Per Month");
                } else if (cellVal == "0") {
                    e.Valid = false;
                    view.SetColumnError(colSalaryPerMonth, "Fill Salary Per Month cell");
                }
            } else if (column.FieldName == "StartDate") {
                if (cellVal == null) {
                    e.Valid = false;
                    view.SetColumnError(colEngineerStartDate, "Insert Valid Start Day");
                } else if (cellVal == "") {
                    e.Valid = false;
                    view.SetColumnError(colEngineerStartDate, "Fill Start Day cell");
                }
            }
        }

        private void gridView2_ValidateRow(object sender, ValidateRowEventArgs e) {
            ManagerRepo managerRepo = new ManagerRepo();
            GridView view = sender as GridView;
            GridColumn colName = view.Columns["Name"];
            GridColumn colSurName = view.Columns["Surname"];
            GridColumn colSalaryPerMonth = view.Columns["SalaryPerMonth"];
            GridColumn colEngineerStartDate = view.Columns["StartDate"];
            Guid id = Guid.Parse(view.GetRowCellValue(e.RowHandle, colID).ToString());
            String name = view.GetRowCellValue(e.RowHandle, colName) as String;
            String surname = view.GetRowCellValue(e.RowHandle, colSurName) as String;
            String salaryPerMonth = view.GetRowCellValue(e.RowHandle, colSalaryPerMonth).ToString();
            String startDay;
            if (view.GetRowCellValue(e.RowHandle, colEngineerStartDate) != null)
                startDay = view.GetRowCellValue(e.RowHandle, colEngineerStartDate).ToString();
            else
                startDay = null;
            // Name Cell
            if (name == null) {
                e.Valid = false;
                view.SetColumnError(colName, "Insert Valid Name");
            } else if (name == "") {
                e.Valid = false;
                view.SetColumnError(colName, "Fill Name cell");
            }
            // Surname Cell
            if (surname == null) {
                e.Valid = false;
                view.SetColumnError(colSurName, "Insert Valid Surname");
            } else if (surname == "") {
                e.Valid = false;
                view.SetColumnError(colSurName, "Fill Surname cell");
            }
            // Salary Per Month Cell
            if (salaryPerMonth == null) {
                e.Valid = false;
                view.SetColumnError(colSalaryPerMonth, "Insert Valid Salary Per Month");
            } else if (salaryPerMonth == "0") {
                e.Valid = false;
                view.SetColumnError(colSalaryPerMonth, "Fill Salary Per Month cell");
            }
            // Start Day Cell
            if (startDay == null) {
                e.Valid = false;
                view.SetColumnError(colEngineerStartDate, "Insert Valid Start Day");
            } else if (startDay == "") {
                e.Valid = false;
                view.SetColumnError(colEngineerStartDate, "Fill Start Day cell");
            }

            if (e.Valid) {
                view.ClearColumnErrors();
                managerRepo.Add((Manager)bsManagers.Current);
            }
        }

        private void gridView2_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e) {
            ColumnView view = sender as ColumnView;
            GridColumn column = (e as EditFormValidateEditorEventArgs)?.Column ?? view.FocusedColumn;
            String cellVal = e.Value.ToString();
            if (column.FieldName == "Name") {
                // colName changed
                if (cellVal == null) {
                    e.Valid = false;
                    view.SetColumnError(colName, "Insert Valid Name");
                } else if (cellVal == "") {
                    e.Valid = false;
                    view.SetColumnError(colName, "Fill Name cell");
                }
            } else if (column.FieldName == "Surname") {
                // colSurname changed
                if (cellVal == null) {
                    e.Valid = false;
                    view.SetColumnError(colSurname, "Insert Valid Surname");
                } else if (cellVal == "") {
                    e.Valid = false;
                    view.SetColumnError(colSurname, "Fill Surname cell");
                }
            } else if (column.FieldName == "SalaryPerMonth") {
                if (cellVal == null) {
                    e.Valid = false;
                    view.SetColumnError(colSalaryPerMonth, "Insert Valid Salary Per Month");
                } else if (cellVal == "0") {
                    e.Valid = false;
                    view.SetColumnError(colSalaryPerMonth, "Fill Salary Per Month cell");
                }
            } else if (column.FieldName == "StartDate") {
                if (cellVal == null) {
                    e.Valid = false;
                    view.SetColumnError(colEngineerStartDate, "Insert Valid Start Day");
                } else if (cellVal == "") {
                    e.Valid = false;
                    view.SetColumnError(colEngineerStartDate, "Fill Start Day cell");
                }
            }
        }

        private void gridView1_RowCountChanged(object sender, EventArgs e) {
            _carServiceCenter.UpdateWorkDays();
        }

        private Engineer FindEngineerWithID(Guid id) {
            Engineer retEngineer = null;
            foreach (Engineer engineer in _carServiceCenter.Engineers) {
                if (engineer.ID == id) {
                    retEngineer = engineer;
                }
            }
            return retEngineer;
        }

        private Manager FindManagerWithID(Guid id) {
            Manager retManager = null;
            foreach (Manager manager in _carServiceCenter.Managers) {
                if (manager.ID == id) {
                    retManager = manager;
                }
            }
            return retManager;
        }

        private void gridView1_RowDeleting(object sender, DevExpress.Data.RowDeletingEventArgs e) {
            GridView view = sender as GridView; 
            EngineerRepo engineerRepo = new EngineerRepo();
            Guid id = Guid.Parse(view.GetRowCellValue(view.FocusedRowHandle, colEngineerID).ToString());
            engineerRepo.Delete(id);
        }

        private void gridView1_RowUpdated(object sender, RowObjectEventArgs e) {
            GridView view = sender as GridView;
            EngineerRepo engineerRepo = new EngineerRepo();
            Guid id = Guid.Parse(view.GetRowCellValue(view.FocusedRowHandle, colEngineerID).ToString());
            engineerRepo.Update(id,(Engineer)bsEngineers.Current);

        }

        private void gridView2_RowDeleting(object sender, DevExpress.Data.RowDeletingEventArgs e) {
            GridView view = sender as GridView;
            ManagerRepo managerRepo = new ManagerRepo();
            Guid id = Guid.Parse(view.GetRowCellValue(view.FocusedRowHandle, colID).ToString());
            managerRepo.Delete(id);
        }

        private void gridView2_RowUpdated(object sender, RowObjectEventArgs e) {
            GridView view = sender as GridView;
            ManagerRepo managerRepo = new ManagerRepo();
            Guid id = Guid.Parse(view.GetRowCellValue(view.FocusedRowHandle, colID).ToString());
            managerRepo.Update(id, (Manager)bsManagers.Current);
        }
    }
}
