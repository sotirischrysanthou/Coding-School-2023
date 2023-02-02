namespace Session_16.Win {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransactionsForm));
            this.bsTransactions = new System.Windows.Forms.BindingSource(this.components);
            this.bsTransactionLines = new System.Windows.Forms.BindingSource(this.components);
            this.grdTransactionLines = new DevExpress.XtraGrid.GridControl();
            this.grvTransactionLines = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colLineID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTransactionID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colServiceTaskDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repServiceTasksDescription = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colEngineerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repEngineersName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colEngineerSurname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repEngineersSurname = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colHours = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPricePerHour = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Price = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdTransactions = new DevExpress.XtraGrid.GridControl();
            this.grvTransactions = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repCustomerName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colCustomerSurname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repCustomerSurname = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colCarBrand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repCarBrand = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colCarModel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repCarModel = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colManagerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repManagerName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colManagerSurname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repManagerSurname = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colTotalPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btn_Close = new System.Windows.Forms.Button();
            this.labelServiceTask = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelWorkHours = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.bsTransactions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTransactionLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTransactionLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTransactionLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repServiceTasksDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repEngineersName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repEngineersSurname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTransactions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTransactions)).BeginInit();
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
            this.grdTransactionLines.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdTransactionLines.Location = new System.Drawing.Point(12, 230);
            this.grdTransactionLines.MainView = this.grvTransactionLines;
            this.grdTransactionLines.Name = "grdTransactionLines";
            this.grdTransactionLines.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repServiceTasksDescription,
            this.repEngineersName,
            this.repEngineersSurname});
            this.grdTransactionLines.Size = new System.Drawing.Size(776, 171);
            this.grdTransactionLines.TabIndex = 3;
            this.grdTransactionLines.UseEmbeddedNavigator = true;
            this.grdTransactionLines.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvTransactionLines});
            // 
            // grvTransactionLines
            // 
            this.grvTransactionLines.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colLineID,
            this.colTransactionID,
            this.colServiceTaskDescription,
            this.colEngineerName,
            this.colEngineerSurname,
            this.colHours,
            this.colPricePerHour,
            this.Price});
            this.grvTransactionLines.GridControl = this.grdTransactionLines;
            this.grvTransactionLines.Name = "grvTransactionLines";
            this.grvTransactionLines.OptionsView.ShowGroupPanel = false;
            this.grvTransactionLines.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.grvTransactionLines_InitNewRow);
            this.grvTransactionLines.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvTransactionLines_CellValueChanged);
            this.grvTransactionLines.RowDeleting += new DevExpress.Data.RowDeletingEventHandler(this.gridView2_RowDeleting);
            this.grvTransactionLines.RowDeleted += new DevExpress.Data.RowDeletedEventHandler(this.grvTransactionLines_RowDeleted);
            this.grvTransactionLines.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView2_ValidateRow);
            this.grvTransactionLines.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gridView2_ValidatingEditor);
            // 
            // colLineID
            // 
            this.colLineID.Caption = "ID";
            this.colLineID.FieldName = "ID";
            this.colLineID.Name = "colLineID";
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
            // colEngineerSurname
            // 
            this.colEngineerSurname.Caption = "Engineer Surname";
            this.colEngineerSurname.ColumnEdit = this.repEngineersSurname;
            this.colEngineerSurname.FieldName = "EngineerID";
            this.colEngineerSurname.Name = "colEngineerSurname";
            this.colEngineerSurname.Visible = true;
            this.colEngineerSurname.VisibleIndex = 2;
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
            this.colHours.OptionsColumn.AllowEdit = false;
            this.colHours.Visible = true;
            this.colHours.VisibleIndex = 3;
            // 
            // colPricePerHour
            // 
            this.colPricePerHour.Caption = "Price Per Hour";
            this.colPricePerHour.FieldName = "PricePerHour";
            this.colPricePerHour.Name = "colPricePerHour";
            this.colPricePerHour.OptionsColumn.AllowEdit = false;
            this.colPricePerHour.Visible = true;
            this.colPricePerHour.VisibleIndex = 4;
            // 
            // Price
            // 
            this.Price.Caption = "Price";
            this.Price.FieldName = "Price";
            this.Price.Name = "Price";
            this.Price.OptionsColumn.AllowEdit = false;
            this.Price.Visible = true;
            this.Price.VisibleIndex = 5;
            // 
            // grdTransactions
            // 
            this.grdTransactions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdTransactions.Location = new System.Drawing.Point(12, 42);
            this.grdTransactions.MainView = this.grvTransactions;
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
            this.grvTransactions});
            // 
            // grvTransactions
            // 
            this.grvTransactions.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colDate,
            this.colCustomerName,
            this.colCustomerSurname,
            this.colCarBrand,
            this.colCarModel,
            this.colManagerName,
            this.colManagerSurname,
            this.colTotalPrice});
            this.grvTransactions.GridControl = this.grdTransactions;
            this.grvTransactions.Name = "grvTransactions";
            this.grvTransactions.OptionsView.ShowGroupPanel = false;
            this.grvTransactions.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.grvTransactions_SelectionChanged);
            this.grvTransactions.RowDeleting += new DevExpress.Data.RowDeletingEventHandler(this.grvTransactions_RowDeleting);
            this.grvTransactions.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.grvTransactions_ValidateRow);
            this.grvTransactions.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.grvTransactions_ValidatingEditor);
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
            // colCustomerName
            // 
            this.colCustomerName.Caption = "Customer Name";
            this.colCustomerName.ColumnEdit = this.repCustomerName;
            this.colCustomerName.FieldName = "CustomerID";
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.Visible = true;
            this.colCustomerName.VisibleIndex = 1;
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
            // colManagerSurname
            // 
            this.colManagerSurname.Caption = "ManagerSurname";
            this.colManagerSurname.ColumnEdit = this.repManagerSurname;
            this.colManagerSurname.FieldName = "ManagerID";
            this.colManagerSurname.Name = "colManagerSurname";
            this.colManagerSurname.Visible = true;
            this.colManagerSurname.VisibleIndex = 6;
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
            this.colTotalPrice.OptionsColumn.AllowEdit = false;
            this.colTotalPrice.Visible = true;
            this.colTotalPrice.VisibleIndex = 7;
            // 
            // btn_Close
            // 
            this.btn_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(234)))), ((int)(((byte)(218)))));
            this.btn_Close.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_Close.FlatAppearance.BorderSize = 2;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("Segoe Print", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Close.Location = new System.Drawing.Point(663, 404);
            this.btn_Close.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(125, 40);
            this.btn_Close.TabIndex = 7;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            this.btn_Close.MouseEnter += new System.EventHandler(this.btn_Close_MouseEnter);
            this.btn_Close.MouseLeave += new System.EventHandler(this.btn_Close_MouseLeave);
            // 
            // labelServiceTask
            // 
            this.labelServiceTask.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 200);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(141, 24);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "TransactionLine";
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(521, 200);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(217, 24);
            this.labelControl2.TabIndex = 10;
            this.labelControl2.Text = "Total Remaining Hours: ";
            // 
            // labelWorkHours
            // 
            this.labelWorkHours.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelWorkHours.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelWorkHours.Appearance.Options.UseFont = true;
            this.labelWorkHours.Location = new System.Drawing.Point(744, 200);
            this.labelWorkHours.Name = "labelWorkHours";
            this.labelWorkHours.Size = new System.Drawing.Size(11, 24);
            this.labelWorkHours.TabIndex = 11;
            this.labelWorkHours.Text = "0";
            // 
            // TransactionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(234)))), ((int)(((byte)(218)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelWorkHours);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelServiceTask);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.grdTransactions);
            this.Controls.Add(this.grdTransactionLines);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "TransactionsForm";
            this.Text = "Transactions";
            this.Load += new System.EventHandler(this.TransactionsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsTransactions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTransactionLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTransactionLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTransactionLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repServiceTasksDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repEngineersName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repEngineersSurname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTransactions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTransactions)).EndInit();
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
        private DevExpress.XtraGrid.Views.Grid.GridView grvTransactionLines;
        private DevExpress.XtraGrid.GridControl grdTransactions;
        private DevExpress.XtraGrid.Views.Grid.GridView grvTransactions;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colCarBrand;
        private DevExpress.XtraGrid.Columns.GridColumn colManagerName;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colServiceTaskDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colEngineerName;
        private DevExpress.XtraGrid.Columns.GridColumn colHours;
        private DevExpress.XtraGrid.Columns.GridColumn colPricePerHour;
        private DevExpress.XtraGrid.Columns.GridColumn Price;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerSurname;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repCustomerSurname;
        private DevExpress.XtraGrid.Columns.GridColumn colCarModel;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repCarModel;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repCarBrand;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repManagerName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repManagerSurname;
        private DevExpress.XtraGrid.Columns.GridColumn colManagerSurname;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repServiceTasksDescription;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repEngineersName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repEngineersSurname;
        private DevExpress.XtraGrid.Columns.GridColumn colEngineerSurname;
        private Button btn_Close;
        private DevExpress.XtraGrid.Columns.GridColumn colTransactionID;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraEditors.LabelControl labelServiceTask;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelWorkHours;
        private DevExpress.XtraGrid.Columns.GridColumn colLineID;
    }
}