namespace Session_11_Car_Service_Center {
    partial class EmployeesForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.grdEngineers = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSurname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colManagerID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSalaryPerMonth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelEngineers = new DevExpress.XtraEditors.LabelControl();
            this.grdManagers = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colManagerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colManagerSurname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colManagerSalaryPerMonth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelManagers = new DevExpress.XtraEditors.LabelControl();
            this.bsEngineers = new System.Windows.Forms.BindingSource(this.components);
            this.bsManagers = new System.Windows.Forms.BindingSource(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdEngineers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdManagers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEngineers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsManagers)).BeginInit();
            this.SuspendLayout();
            // 
            // grdEngineers
            // 
            this.grdEngineers.Location = new System.Drawing.Point(12, 39);
            this.grdEngineers.MainView = this.gridView1;
            this.grdEngineers.Name = "grdEngineers";
            this.grdEngineers.Size = new System.Drawing.Size(945, 159);
            this.grdEngineers.TabIndex = 0;
            this.grdEngineers.UseEmbeddedNavigator = true;
            this.grdEngineers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colSurname,
            this.colManagerID,
            this.colSalaryPerMonth});
            this.gridView1.GridControl = this.grdEngineers;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colName
            // 
            this.colName.Caption = "Name";
            this.colName.FieldName = "Name";
            this.colName.MinWidth = 25;
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 94;
            // 
            // colSurname
            // 
            this.colSurname.Caption = "Surname";
            this.colSurname.FieldName = "Surname";
            this.colSurname.MinWidth = 25;
            this.colSurname.Name = "colSurname";
            this.colSurname.Visible = true;
            this.colSurname.VisibleIndex = 1;
            this.colSurname.Width = 94;
            // 
            // colManagerID
            // 
            this.colManagerID.Caption = "ManagerID";
            this.colManagerID.FieldName = "ManagerID";
            this.colManagerID.MinWidth = 25;
            this.colManagerID.Name = "colManagerID";
            this.colManagerID.Visible = true;
            this.colManagerID.VisibleIndex = 2;
            this.colManagerID.Width = 94;
            // 
            // colSalaryPerMonth
            // 
            this.colSalaryPerMonth.Caption = "Salary per Month";
            this.colSalaryPerMonth.FieldName = "SalaryPerMonth";
            this.colSalaryPerMonth.MinWidth = 25;
            this.colSalaryPerMonth.Name = "colSalaryPerMonth";
            this.colSalaryPerMonth.Visible = true;
            this.colSalaryPerMonth.VisibleIndex = 3;
            this.colSalaryPerMonth.Width = 94;
            // 
            // labelEngineers
            // 
            this.labelEngineers.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelEngineers.Appearance.Options.UseFont = true;
            this.labelEngineers.Location = new System.Drawing.Point(12, 3);
            this.labelEngineers.Name = "labelEngineers";
            this.labelEngineers.Size = new System.Drawing.Size(108, 30);
            this.labelEngineers.TabIndex = 1;
            this.labelEngineers.Text = "Engineers";
            // 
            // grdManagers
            // 
            this.grdManagers.Location = new System.Drawing.Point(12, 248);
            this.grdManagers.MainView = this.gridView2;
            this.grdManagers.Name = "grdManagers";
            this.grdManagers.Size = new System.Drawing.Size(945, 192);
            this.grdManagers.TabIndex = 2;
            this.grdManagers.UseEmbeddedNavigator = true;
            this.grdManagers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colManagerName,
            this.colManagerSurname,
            this.colManagerSalaryPerMonth});
            this.gridView2.GridControl = this.grdManagers;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // colManagerName
            // 
            this.colManagerName.Caption = "Name";
            this.colManagerName.FieldName = "Name";
            this.colManagerName.MinWidth = 25;
            this.colManagerName.Name = "colManagerName";
            this.colManagerName.Visible = true;
            this.colManagerName.VisibleIndex = 0;
            this.colManagerName.Width = 94;
            // 
            // colManagerSurname
            // 
            this.colManagerSurname.Caption = "Surname";
            this.colManagerSurname.FieldName = "Surname";
            this.colManagerSurname.MinWidth = 25;
            this.colManagerSurname.Name = "colManagerSurname";
            this.colManagerSurname.Visible = true;
            this.colManagerSurname.VisibleIndex = 1;
            this.colManagerSurname.Width = 94;
            // 
            // colManagerSalaryPerMonth
            // 
            this.colManagerSalaryPerMonth.Caption = "Salary per Month";
            this.colManagerSalaryPerMonth.FieldName = "SalaryPerMonth";
            this.colManagerSalaryPerMonth.MinWidth = 25;
            this.colManagerSalaryPerMonth.Name = "colManagerSalaryPerMonth";
            this.colManagerSalaryPerMonth.Visible = true;
            this.colManagerSalaryPerMonth.VisibleIndex = 2;
            this.colManagerSalaryPerMonth.Width = 94;
            // 
            // labelManagers
            // 
            this.labelManagers.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelManagers.Appearance.Options.UseFont = true;
            this.labelManagers.Location = new System.Drawing.Point(12, 212);
            this.labelManagers.Name = "labelManagers";
            this.labelManagers.Size = new System.Drawing.Size(106, 30);
            this.labelManagers.TabIndex = 3;
            this.labelManagers.Text = "Managers";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(615, 446);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(148, 40);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(786, 446);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(148, 40);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // EmployeesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 491);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.labelManagers);
            this.Controls.Add(this.grdManagers);
            this.Controls.Add(this.labelEngineers);
            this.Controls.Add(this.grdEngineers);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "EmployeesForm";
            this.Text = "Employees";
            this.Load += new System.EventHandler(this.EmployeesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdEngineers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdManagers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEngineers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsManagers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdEngineers;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colSurname;
        private DevExpress.XtraGrid.Columns.GridColumn colManagerID;
        private DevExpress.XtraGrid.Columns.GridColumn colSalaryPerMonth;
        private DevExpress.XtraEditors.LabelControl labelEngineers;
        private DevExpress.XtraGrid.GridControl grdManagers;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colManagerName;
        private DevExpress.XtraGrid.Columns.GridColumn colManagerSurname;
        private DevExpress.XtraGrid.Columns.GridColumn colManagerSalaryPerMonth;
        private DevExpress.XtraEditors.LabelControl labelManagers;
        private BindingSource bsEngineers;
        private BindingSource bsManagers;
        private Button btnSave;
        private Button btnClose;
    }
}