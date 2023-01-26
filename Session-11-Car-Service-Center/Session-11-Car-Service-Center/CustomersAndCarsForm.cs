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
using System.Text.RegularExpressions;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;

namespace Session_11_Car_Service_Center {
    public partial class CustomersAndCarsForm : Form {
        private CarServiceCenter _carServiceCenter;
        private Serializer _serializer;

        public CustomersAndCarsForm(CarServiceCenter carServiceCenter) {
            InitializeComponent();
            _serializer = new Serializer();
            _carServiceCenter = carServiceCenter;
        }
        private void CustomersAndCarsForm_Load(object sender, EventArgs e) {
            SetControlProperties();
            _serializer = new Serializer();

        }

        private void SetControlProperties() {
            _serializer = new Serializer();
            bsService.DataSource = _carServiceCenter;
            bsCustomers.DataSource = bsService;

            bsCustomers.DataSource = _carServiceCenter.Customers;
            grdCustomers.DataSource = bsCustomers;

            bsCars.DataSource = _carServiceCenter.Cars;
            grdCars.DataSource = bsCars;

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e) {

        }

        private void bsCustomers_CurrentChanged(object sender, EventArgs e) {

        }

        private void bsCars_CurrentChanged(object sender, EventArgs e) {

        }

        private void bsService_CurrentChanged(object sender, EventArgs e) {

        }

        private void btn_Save_Click(object sender, EventArgs e) {
            _serializer.SerializeToFile(_carServiceCenter, "CarServiceCenter.json");
            DevExpress.XtraEditors.XtraMessageBox.Show("Saved!");

        }

        private void btn_Close_Click(object sender, EventArgs e) {
            this.Close();
        }

        //Customize Buttons

        private void btn_Save_MouseEnter(object sender, EventArgs e) {
            btn_Save.FlatAppearance.MouseOverBackColor = btn_Save.BackColor;
            btn_Save.ForeColor = Color.Blue;
            btn_Save.FlatAppearance.BorderColor = Color.Red;
            btn_Save.FlatAppearance.BorderSize = 2;
        }

        private void btn_Save_MouseLeave(object sender, EventArgs e) {
            btn_Save.ForeColor = Color.Black;
            btn_Save.FlatAppearance.BorderSize = 0;
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

        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e) {

        }

        private void gridView2_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e) {
            GridView view = sender as GridView;
            GridColumn colBrand = view.Columns["Brand"];
            GridColumn colModel = view.Columns["Model"];
            GridColumn colRegNum = view.Columns["CarRegistrationNumber"];
            String brand = view.GetRowCellValue(e.RowHandle, colBrand) as String;
            String model = view.GetRowCellValue(e.RowHandle, colModel) as String;
            String regNum = view.GetRowCellValue(e.RowHandle, colRegNum) as String;
            // Brand Cell
            if (brand == null) {
                e.Valid = false;
                view.SetColumnError(colBrand, "Insert Valid Brand");
            } else if (brand == " ") {
                e.Valid = false;
                view.SetColumnError(colBrand, "Fill Brand cell");
            }
            // Model Cell
            if (model == null) {
                e.Valid = false;
                view.SetColumnError(colModel, "Insert Valid Model");
            } else if (model == "") {
                e.Valid = false;
                view.SetColumnError(colModel, "Fill Model cell");
            }
            // Car Registration Number Cell
            if (regNum == null) {
                e.Valid = false;
                view.SetColumnError(colRegNum, "Insert Valid Registration number");
            } else if (regNum == "") {
                view.SetColumnError(colModel, "Fill Car Registration Number cell");
            } else if (Regex.IsMatch(regNum.Substring(0, 3), @"^[a-zA-Z]+$") && regNum[3] == ' ' && Regex.IsMatch(regNum.Substring(4, 4), @"^[1-9]+$")) {
                // Correct
            } else {
                e.Valid = false;
                view.SetColumnError(colRegNum, "Insert Valid Registration number with format for e.g [IZM 1234] ");
            }

            if (e.Valid) {
                view.ClearColumnErrors();
            }
        }

        private void gridView2_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e) {
            ColumnView view = sender as ColumnView;
            GridColumn column = (e as EditFormValidateEditorEventArgs)?.Column ?? view.FocusedColumn;
            String cellVal = e.Value as String;
            if (column.FieldName == "Brand") {
                // colBrand changed
                if (cellVal == null) {
                    e.Valid = false;
                    view.SetColumnError(colBrand, "Insert Valid Brand");
                } else if (cellVal == " ") {
                    e.Valid = false;
                    view.SetColumnError(colBrand, "Fill Brand cell");
                }
            } else if (column.FieldName == "Model") {
                // colBrand changed
                if (cellVal == null) {
                    e.Valid = false;
                    view.SetColumnError(colModel, "Insert Valid Model");
                } else if (cellVal == "") {
                    e.Valid = false;
                    view.SetColumnError(colModel, "Fill Model cell");
                }
            } else if (column.FieldName == "CarRegistrationNumber") {
                // colCarRegistrationNumber changed
                if (cellVal == null) {
                    e.Valid = false;
                    view.SetColumnError(colCarRegistrationNumber, "Insert Valid Registration number");
                } else if (cellVal == "") {
                    e.Valid = false;
                    view.SetColumnError(colCarRegistrationNumber, "Fill Car Registration Number cell");
                } else if (cellVal.Count() == 8 && Regex.IsMatch(cellVal.Substring(0, 3), @"^[a-zA-Z]+$") && cellVal[3] == ' ' && Regex.IsMatch(cellVal.Substring(4, 4), @"^[1-9]+$")) {
                    // Correct
                } else {
                    e.Valid = false;
                    view.SetColumnError(colCarRegistrationNumber, "Insert Valid Registration number with format for e.g [IZM 1234] ");
                }
            }
        }
    }
}
