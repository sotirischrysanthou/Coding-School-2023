namespace Session_16.Win {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeesForm));
            this.grdEngineers = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEngineerID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSurname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEngineersManagerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repManagerName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colEngineersManagerSurname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repManagerSurname = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colSalaryPerMonth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEngineerStartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelEngineers = new DevExpress.XtraEditors.LabelControl();
            this.grdManagers = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colManagerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colManagerSurname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colManagerSalaryPerMonth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colManagerStartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelManagers = new DevExpress.XtraEditors.LabelControl();
            this.bsEngineers = new System.Windows.Forms.BindingSource(this.components);
            this.bsManagers = new System.Windows.Forms.BindingSource(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.colStartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdEngineers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repManagerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repManagerSurname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdManagers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEngineers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsManagers)).BeginInit();
            this.SuspendLayout();
            // 
            // grdEngineers
            // 
            this.grdEngineers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdEngineers.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdEngineers.Location = new System.Drawing.Point(10, 40);
            this.grdEngineers.MainView = this.gridView1;
            this.grdEngineers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdEngineers.Name = "grdEngineers";
            this.grdEngineers.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repManagerName,
            this.repManagerSurname});
            this.grdEngineers.Size = new System.Drawing.Size(924, 136);
            this.grdEngineers.TabIndex = 0;
            this.grdEngineers.UseEmbeddedNavigator = true;
            this.grdEngineers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEngineerID,
            this.colName,
            this.colSurname,
            this.colEngineersManagerName,
            this.colEngineersManagerSurname,
            this.colSalaryPerMonth,
            this.colEngineerStartDate});
            this.gridView1.DetailHeight = 262;
            this.gridView1.GridControl = this.grdEngineers;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowDeleting += new DevExpress.Data.RowDeletingEventHandler(this.gridView1_RowDeleting);
            this.gridView1.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView1_ValidateRow);
            this.gridView1.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView1_RowUpdated);
            this.gridView1.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gridView1_ValidatingEditor);
            this.gridView1.RowCountChanged += new System.EventHandler(this.gridView1_RowCountChanged);
            // 
            // colEngineerID
            // 
            this.colEngineerID.Caption = "ID";
            this.colEngineerID.FieldName = "ID";
            this.colEngineerID.Name = "colEngineerID";
            // 
            // colName
            // 
            this.colName.Caption = "Name";
            this.colName.FieldName = "Name";
            this.colName.MinWidth = 22;
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 82;
            // 
            // colSurname
            // 
            this.colSurname.Caption = "Surname";
            this.colSurname.FieldName = "Surname";
            this.colSurname.MinWidth = 22;
            this.colSurname.Name = "colSurname";
            this.colSurname.Visible = true;
            this.colSurname.VisibleIndex = 1;
            this.colSurname.Width = 82;
            // 
            // colEngineersManagerName
            // 
            this.colEngineersManagerName.Caption = "Manager Name";
            this.colEngineersManagerName.ColumnEdit = this.repManagerName;
            this.colEngineersManagerName.FieldName = "ManagerID";
            this.colEngineersManagerName.MinWidth = 22;
            this.colEngineersManagerName.Name = "colEngineersManagerName";
            this.colEngineersManagerName.Visible = true;
            this.colEngineersManagerName.VisibleIndex = 2;
            this.colEngineersManagerName.Width = 82;
            // 
            // repManagerName
            // 
            this.repManagerName.AutoHeight = false;
            this.repManagerName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repManagerName.Name = "repManagerName";
            // 
            // colEngineersManagerSurname
            // 
            this.colEngineersManagerSurname.Caption = "Manager Surname";
            this.colEngineersManagerSurname.ColumnEdit = this.repManagerSurname;
            this.colEngineersManagerSurname.FieldName = "ManagerID";
            this.colEngineersManagerSurname.Name = "colEngineersManagerSurname";
            this.colEngineersManagerSurname.Visible = true;
            this.colEngineersManagerSurname.VisibleIndex = 3;
            // 
            // repManagerSurname
            // 
            this.repManagerSurname.AutoHeight = false;
            this.repManagerSurname.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repManagerSurname.Name = "repManagerSurname";
            // 
            // colSalaryPerMonth
            // 
            this.colSalaryPerMonth.Caption = "Salary per Month";
            this.colSalaryPerMonth.FieldName = "SalaryPerMonth";
            this.colSalaryPerMonth.MinWidth = 22;
            this.colSalaryPerMonth.Name = "colSalaryPerMonth";
            this.colSalaryPerMonth.Visible = true;
            this.colSalaryPerMonth.VisibleIndex = 4;
            this.colSalaryPerMonth.Width = 82;
            // 
            // colEngineerStartDate
            // 
            this.colEngineerStartDate.Caption = "Start Date";
            this.colEngineerStartDate.FieldName = "StartDate";
            this.colEngineerStartDate.Name = "colEngineerStartDate";
            this.colEngineerStartDate.Visible = true;
            this.colEngineerStartDate.VisibleIndex = 5;
            // 
            // labelEngineers
            // 
            this.labelEngineers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelEngineers.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelEngineers.Appearance.Options.UseFont = true;
            this.labelEngineers.Location = new System.Drawing.Point(10, 12);
            this.labelEngineers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelEngineers.Name = "labelEngineers";
            this.labelEngineers.Size = new System.Drawing.Size(87, 24);
            this.labelEngineers.TabIndex = 1;
            this.labelEngineers.Text = "Engineers";
            // 
            // grdManagers
            // 
            this.grdManagers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdManagers.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdManagers.Location = new System.Drawing.Point(9, 216);
            this.grdManagers.MainView = this.gridView2;
            this.grdManagers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdManagers.Name = "grdManagers";
            this.grdManagers.Size = new System.Drawing.Size(924, 144);
            this.grdManagers.TabIndex = 2;
            this.grdManagers.UseEmbeddedNavigator = true;
            this.grdManagers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colManagerName,
            this.colManagerSurname,
            this.colManagerSalaryPerMonth,
            this.colManagerStartDate});
            this.gridView2.DetailHeight = 262;
            this.gridView2.GridControl = this.grdManagers;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView2_InitNewRow);
            this.gridView2.RowDeleting += new DevExpress.Data.RowDeletingEventHandler(this.gridView2_RowDeleting);
            this.gridView2.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView2_ValidateRow);
            this.gridView2.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView2_RowUpdated);
            this.gridView2.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gridView2_ValidatingEditor);
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colManagerName
            // 
            this.colManagerName.Caption = "Name";
            this.colManagerName.FieldName = "Name";
            this.colManagerName.MinWidth = 22;
            this.colManagerName.Name = "colManagerName";
            this.colManagerName.Visible = true;
            this.colManagerName.VisibleIndex = 0;
            this.colManagerName.Width = 82;
            // 
            // colManagerSurname
            // 
            this.colManagerSurname.Caption = "Surname";
            this.colManagerSurname.FieldName = "Surname";
            this.colManagerSurname.MinWidth = 22;
            this.colManagerSurname.Name = "colManagerSurname";
            this.colManagerSurname.Visible = true;
            this.colManagerSurname.VisibleIndex = 1;
            this.colManagerSurname.Width = 82;
            // 
            // colManagerSalaryPerMonth
            // 
            this.colManagerSalaryPerMonth.Caption = "Salary per Month";
            this.colManagerSalaryPerMonth.FieldName = "SalaryPerMonth";
            this.colManagerSalaryPerMonth.MinWidth = 22;
            this.colManagerSalaryPerMonth.Name = "colManagerSalaryPerMonth";
            this.colManagerSalaryPerMonth.Visible = true;
            this.colManagerSalaryPerMonth.VisibleIndex = 2;
            this.colManagerSalaryPerMonth.Width = 82;
            // 
            // colManagerStartDate
            // 
            this.colManagerStartDate.Caption = "Start Date";
            this.colManagerStartDate.FieldName = "StartDate";
            this.colManagerStartDate.Name = "colManagerStartDate";
            this.colManagerStartDate.Visible = true;
            this.colManagerStartDate.VisibleIndex = 3;
            this.colManagerStartDate.Width = 66;
            // 
            // labelManagers
            // 
            this.labelManagers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelManagers.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelManagers.Appearance.Options.UseFont = true;
            this.labelManagers.Location = new System.Drawing.Point(10, 188);
            this.labelManagers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelManagers.Name = "labelManagers";
            this.labelManagers.Size = new System.Drawing.Size(86, 24);
            this.labelManagers.TabIndex = 3;
            this.labelManagers.Text = "Managers";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(234)))), ((int)(((byte)(218)))));
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSave.FlatAppearance.BorderSize = 2;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe Print", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSave.Location = new System.Drawing.Point(678, 376);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(125, 40);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.MouseEnter += new System.EventHandler(this.btnSave_MouseEnter);
            this.btnSave.MouseLeave += new System.EventHandler(this.btnSave_MouseLeave);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(234)))), ((int)(((byte)(218)))));
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnClose.FlatAppearance.BorderSize = 2;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe Print", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnClose.Location = new System.Drawing.Point(809, 376);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(125, 40);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.MouseEnter += new System.EventHandler(this.btnClose_MouseEnter);
            this.btnClose.MouseLeave += new System.EventHandler(this.btnClose_MouseLeave);
            // 
            // colStartDate
            // 
            this.colStartDate.Caption = "Start Date";
            this.colStartDate.FieldName = "StartDate";
            this.colStartDate.Name = "colStartDate";
            this.colStartDate.Visible = true;
            this.colStartDate.VisibleIndex = 4;
            this.colStartDate.Width = 66;
            // 
            // EmployeesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(234)))), ((int)(((byte)(218)))));
            this.ClientSize = new System.Drawing.Size(959, 427);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.labelManagers);
            this.Controls.Add(this.grdManagers);
            this.Controls.Add(this.labelEngineers);
            this.Controls.Add(this.grdEngineers);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(975, 466);
            this.Name = "EmployeesForm";
            this.Text = "Employees";
            this.Load += new System.EventHandler(this.EmployeesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdEngineers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repManagerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repManagerSurname)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn colEngineersManagerName;
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
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repManagerName;
        private DevExpress.XtraGrid.Columns.GridColumn colEngineersManagerSurname;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repManagerSurname;
        private DevExpress.XtraGrid.Columns.GridColumn colStartDate;
        private DevExpress.XtraGrid.Columns.GridColumn colManagerStartDate;
        private DevExpress.XtraGrid.Columns.GridColumn colEngineerStartDate;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colEngineerID;
    }
}