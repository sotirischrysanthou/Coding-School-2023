namespace Session_11_Car_Service_Center {
    partial class TransactionsForm {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.bsTransactions = new System.Windows.Forms.BindingSource(this.components);
            this.bsTransactionLines = new System.Windows.Forms.BindingSource(this.components);
            this.grdTransactionLines = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTransactionID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colServiceTaskDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repServiceTasksDescription = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colEngineerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repEngineersName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.EngineerSurname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repEngineersSurname = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colHours = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPricePerHour = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Price = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdTransactions = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repCustomerName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colCustomerSurname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repCustomerSurname = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colCarBrand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repCarBrand = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colCarModel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repCarModel = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colManagerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repManagerName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.conManagerSurname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repManagerSurname = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colTotalPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.labelServiceTask = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.bsTransactions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTransactionLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTransactionLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repServiceTasksDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repEngineersName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repEngineersSurname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTransactions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCustomerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCustomerSurname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCarBrand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCarModel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repManagerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repManagerSurname)).BeginInit();
            this.SuspendLayout();
            // 
            // grdTransactionLines
            // 
            this.grdTransactionLines.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grdTransactionLines.Location = new System.Drawing.Point(12, 237);
            this.grdTransactionLines.MainView = this.gridView2;
            this.grdTransactionLines.Name = "grdTransactionLines";
            this.grdTransactionLines.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repServiceTasksDescription,
            this.repEngineersName,
            this.repEngineersSurname});
            this.grdTransactionLines.Size = new System.Drawing.Size(776, 171);
            this.grdTransactionLines.TabIndex = 3;
            this.grdTransactionLines.UseEmbeddedNavigator = true;
            this.grdTransactionLines.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTransactionID,
            this.colServiceTaskDescription,
            this.colEngineerName,
            this.EngineerSurname,
            this.colHours,
            this.colPricePerHour,
            this.Price});
            this.gridView2.GridControl = this.grdTransactionLines;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView2_InitNewRow);
            this.gridView2.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView2_CellValueChanged);
            this.gridView2.RowDeleting += new DevExpress.Data.RowDeletingEventHandler(this.gridView2_RowDeleting);
            // 
            // colTransactionID
            // 
            this.colTransactionID.Caption = "TransactionID";
            this.colTransactionID.FieldName = "TransactionID";
            this.colTransactionID.Name = "colTransactionID";
            // 
            // colServiceTaskDescription
            // 
            this.colServiceTaskDescription.Caption = "Sevice Task Description";
            this.colServiceTaskDescription.ColumnEdit = this.repServiceTasksDescription;
            this.colServiceTaskDescription.FieldName = "ServiceTaskID";
            this.colServiceTaskDescription.Name = "colServiceTaskDescription";
            this.colServiceTaskDescription.Visible = true;
            this.colServiceTaskDescription.VisibleIndex = 0;
            // 
            // repServiceTasksDescription
            // 
            this.repServiceTasksDescription.AutoHeight = false;
            this.repServiceTasksDescription.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repServiceTasksDescription.Name = "repServiceTasksDescription";
            // 
            // colEngineerName
            // 
            this.colEngineerName.Caption = "Engineer Name";
            this.colEngineerName.ColumnEdit = this.repEngineersName;
            this.colEngineerName.FieldName = "EngineerID";
            this.colEngineerName.Name = "colEngineerName";
            this.colEngineerName.Visible = true;
            this.colEngineerName.VisibleIndex = 1;
            // 
            // repEngineersName
            // 
            this.repEngineersName.AutoHeight = false;
            this.repEngineersName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repEngineersName.Name = "repEngineersName";
            // 
            // EngineerSurname
            // 
            this.EngineerSurname.Caption = "Engineer Surname";
            this.EngineerSurname.ColumnEdit = this.repEngineersSurname;
            this.EngineerSurname.FieldName = "EngineerID";
            this.EngineerSurname.Name = "EngineerSurname";
            this.EngineerSurname.Visible = true;
            this.EngineerSurname.VisibleIndex = 2;
            // 
            // repEngineersSurname
            // 
            this.repEngineersSurname.AutoHeight = false;
            this.repEngineersSurname.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repEngineersSurname.Name = "repEngineersSurname";
            // 
            // colHours
            // 
            this.colHours.Caption = "Hours";
            this.colHours.FieldName = "Hours";
            this.colHours.Name = "colHours";
            this.colHours.Visible = true;
            this.colHours.VisibleIndex = 3;
            // 
            // colPricePerHour
            // 
            this.colPricePerHour.Caption = "Price Per Hour";
            this.colPricePerHour.FieldName = "PricePerHour";
            this.colPricePerHour.Name = "colPricePerHour";
            this.colPricePerHour.Visible = true;
            this.colPricePerHour.VisibleIndex = 4;
            // 
            // Price
            // 
            this.Price.Caption = "Price";
            this.Price.FieldName = "Price";
            this.Price.Name = "Price";
            this.Price.Visible = true;
            this.Price.VisibleIndex = 5;
            // 
            // grdTransactions
            // 
            this.grdTransactions.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grdTransactions.Location = new System.Drawing.Point(12, 42);
            this.grdTransactions.MainView = this.gridView1;
            this.grdTransactions.Name = "grdTransactions";
            this.grdTransactions.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repCustomerName,
            this.repCustomerSurname,
            this.repCarModel,
            this.repCarBrand,
            this.repManagerName,
            this.repManagerSurname});
            this.grdTransactions.Size = new System.Drawing.Size(777, 143);
            this.grdTransactions.TabIndex = 5;
            this.grdTransactions.UseEmbeddedNavigator = true;
            this.grdTransactions.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colDate,
            this.CustomerName,
            this.colCustomerSurname,
            this.colCarBrand,
            this.colCarModel,
            this.colManagerName,
            this.conManagerSurname,
            this.colTotalPrice});
            this.gridView1.GridControl = this.grdTransactions;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colDate
            // 
            this.colDate.Caption = "Date";
            this.colDate.FieldName = "Date";
            this.colDate.Name = "colDate";
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 0;
            // 
            // CustomerName
            // 
            this.CustomerName.Caption = "Customer Name";
            this.CustomerName.ColumnEdit = this.repCustomerName;
            this.CustomerName.FieldName = "CustomerID";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.Visible = true;
            this.CustomerName.VisibleIndex = 1;
            // 
            // repCustomerName
            // 
            this.repCustomerName.AutoHeight = false;
            this.repCustomerName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repCustomerName.Name = "repCustomerName";
            // 
            // colCustomerSurname
            // 
            this.colCustomerSurname.Caption = "Customer Surname";
            this.colCustomerSurname.ColumnEdit = this.repCustomerSurname;
            this.colCustomerSurname.FieldName = "CustomerID";
            this.colCustomerSurname.Name = "colCustomerSurname";
            this.colCustomerSurname.Visible = true;
            this.colCustomerSurname.VisibleIndex = 2;
            // 
            // repCustomerSurname
            // 
            this.repCustomerSurname.AutoHeight = false;
            this.repCustomerSurname.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repCustomerSurname.Name = "repCustomerSurname";
            // 
            // colCarBrand
            // 
            this.colCarBrand.Caption = "Car Brand";
            this.colCarBrand.ColumnEdit = this.repCarBrand;
            this.colCarBrand.FieldName = "CarID";
            this.colCarBrand.Name = "colCarBrand";
            this.colCarBrand.Visible = true;
            this.colCarBrand.VisibleIndex = 3;
            // 
            // repCarBrand
            // 
            this.repCarBrand.AutoHeight = false;
            this.repCarBrand.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repCarBrand.Name = "repCarBrand";
            // 
            // colCarModel
            // 
            this.colCarModel.Caption = "Car Model";
            this.colCarModel.ColumnEdit = this.repCarModel;
            this.colCarModel.FieldName = "CarID";
            this.colCarModel.Name = "colCarModel";
            this.colCarModel.Visible = true;
            this.colCarModel.VisibleIndex = 4;
            // 
            // repCarModel
            // 
            this.repCarModel.AutoHeight = false;
            this.repCarModel.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repCarModel.Name = "repCarModel";
            // 
            // colManagerName
            // 
            this.colManagerName.Caption = "Manager Name";
            this.colManagerName.ColumnEdit = this.repManagerName;
            this.colManagerName.FieldName = "ManagerID";
            this.colManagerName.Name = "colManagerName";
            this.colManagerName.Visible = true;
            this.colManagerName.VisibleIndex = 5;
            // 
            // repManagerName
            // 
            this.repManagerName.AutoHeight = false;
            this.repManagerName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repManagerName.Name = "repManagerName";
            // 
            // conManagerSurname
            // 
            this.conManagerSurname.Caption = "ManagerSurname";
            this.conManagerSurname.ColumnEdit = this.repManagerSurname;
            this.conManagerSurname.FieldName = "ManagerID";
            this.conManagerSurname.Name = "conManagerSurname";
            this.conManagerSurname.Visible = true;
            this.conManagerSurname.VisibleIndex = 6;
            // 
            // repManagerSurname
            // 
            this.repManagerSurname.AutoHeight = false;
            this.repManagerSurname.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repManagerSurname.Name = "repManagerSurname";
            // 
            // colTotalPrice
            // 
            this.colTotalPrice.Caption = "Total Price";
            this.colTotalPrice.FieldName = "TotalPrice";
            this.colTotalPrice.Name = "colTotalPrice";
            this.colTotalPrice.Visible = true;
            this.colTotalPrice.VisibleIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSave.Location = new System.Drawing.Point(632, 415);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Close.Location = new System.Drawing.Point(714, 415);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 23);
            this.btn_Close.TabIndex = 7;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // labelServiceTask
            // 
            this.labelServiceTask.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelServiceTask.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelServiceTask.Appearance.Options.UseFont = true;
            this.labelServiceTask.Location = new System.Drawing.Point(12, 12);
            this.labelServiceTask.Name = "labelServiceTask";
            this.labelServiceTask.Size = new System.Drawing.Size(113, 24);
            this.labelServiceTask.TabIndex = 8;
            this.labelServiceTask.Text = "Transactions";
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 207);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(141, 24);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "TransactionLine";
            // 
            // TransactionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelServiceTask);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grdTransactions);
            this.Controls.Add(this.grdTransactionLines);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(816, 489);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "TransactionsForm";
            this.Text = "Transactions";
            this.Load += new System.EventHandler(this.TransactionsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsTransactions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTransactionLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTransactionLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repServiceTasksDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repEngineersName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repEngineersSurname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTransactions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCustomerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCustomerSurname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCarBrand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCarModel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repManagerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repManagerSurname)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private BindingSource bsTransactions;
        private BindingSource bsTransactionLines;
        private DevExpress.XtraGrid.GridControl grdTransactionLines;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.GridControl grdTransactions;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn CustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colCarBrand;
        private DevExpress.XtraGrid.Columns.GridColumn colManagerName;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colServiceTaskDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colEngineerName;
        private DevExpress.XtraGrid.Columns.GridColumn colHours;
        private DevExpress.XtraGrid.Columns.GridColumn colPricePerHour;
        private DevExpress.XtraGrid.Columns.GridColumn Price;
        private Button btnSave;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerSurname;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repCustomerSurname;
        private DevExpress.XtraGrid.Columns.GridColumn colCarModel;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repCarModel;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repCarBrand;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repManagerName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repManagerSurname;
        private DevExpress.XtraGrid.Columns.GridColumn conManagerSurname;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repServiceTasksDescription;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repEngineersName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repEngineersSurname;
        private DevExpress.XtraGrid.Columns.GridColumn EngineerSurname;
        private Button btn_Close;
        private DevExpress.XtraGrid.Columns.GridColumn colTransactionID;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraEditors.LabelControl labelServiceTask;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}