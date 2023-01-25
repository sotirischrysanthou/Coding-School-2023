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
            this.colServiceTaskID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEngineerID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHours = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPricePerHour = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Price = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdTransactions = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repCustomerName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colCarID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colManagerID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.repCustomerSurname = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colCustomerSurname = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bsTransactions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTransactionLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTransactionLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTransactions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCustomerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCustomerSurname)).BeginInit();
            this.SuspendLayout();
            // 
            // grdTransactionLines
            // 
            this.grdTransactionLines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdTransactionLines.Location = new System.Drawing.Point(12, 237);
            this.grdTransactionLines.MainView = this.gridView2;
            this.grdTransactionLines.Name = "grdTransactionLines";
            this.grdTransactionLines.Size = new System.Drawing.Size(776, 171);
            this.grdTransactionLines.TabIndex = 3;
            this.grdTransactionLines.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTransactionID,
            this.colServiceTaskID,
            this.colEngineerID,
            this.colHours,
            this.colPricePerHour,
            this.Price});
            this.gridView2.GridControl = this.grdTransactionLines;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // colTransactionID
            // 
            this.colTransactionID.Caption = "TransactionID";
            this.colTransactionID.FieldName = "TransactionID";
            this.colTransactionID.Name = "colTransactionID";
            this.colTransactionID.Visible = true;
            this.colTransactionID.VisibleIndex = 0;
            // 
            // colServiceTaskID
            // 
            this.colServiceTaskID.Caption = "Sevice Task ID";
            this.colServiceTaskID.FieldName = "ServiceTaskID";
            this.colServiceTaskID.Name = "colServiceTaskID";
            this.colServiceTaskID.Visible = true;
            this.colServiceTaskID.VisibleIndex = 1;
            // 
            // colEngineerID
            // 
            this.colEngineerID.Caption = "EngineerID";
            this.colEngineerID.FieldName = "EngineerID";
            this.colEngineerID.Name = "colEngineerID";
            this.colEngineerID.Visible = true;
            this.colEngineerID.VisibleIndex = 2;
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
            this.grdTransactions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdTransactions.Location = new System.Drawing.Point(12, 12);
            this.grdTransactions.MainView = this.gridView1;
            this.grdTransactions.Name = "grdTransactions";
            this.grdTransactions.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repCustomerName,
            this.repCustomerSurname});
            this.grdTransactions.Size = new System.Drawing.Size(776, 200);
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
            this.colCarID,
            this.colManagerID,
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
            this.colID.Visible = true;
            this.colID.VisibleIndex = 0;
            // 
            // colDate
            // 
            this.colDate.Caption = "Date";
            this.colDate.FieldName = "Date";
            this.colDate.Name = "colDate";
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 1;
            // 
            // CustomerName
            // 
            this.CustomerName.Caption = "Customer Name";
            this.CustomerName.ColumnEdit = this.repCustomerName;
            this.CustomerName.FieldName = "CustomerID";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.Visible = true;
            this.CustomerName.VisibleIndex = 2;
            // 
            // repCustomerName
            // 
            this.repCustomerName.AutoHeight = false;
            this.repCustomerName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repCustomerName.Name = "repCustomerName";
            // 
            // colCarID
            // 
            this.colCarID.Caption = "CarID";
            this.colCarID.FieldName = "CarID";
            this.colCarID.Name = "colCarID";
            this.colCarID.Visible = true;
            this.colCarID.VisibleIndex = 4;
            // 
            // colManagerID
            // 
            this.colManagerID.Caption = "ManagerID";
            this.colManagerID.FieldName = "ManagerID";
            this.colManagerID.Name = "colManagerID";
            this.colManagerID.Visible = true;
            this.colManagerID.VisibleIndex = 5;
            // 
            // colTotalPrice
            // 
            this.colTotalPrice.Caption = "Total Price";
            this.colTotalPrice.FieldName = "TotalPrice";
            this.colTotalPrice.Name = "colTotalPrice";
            this.colTotalPrice.Visible = true;
            this.colTotalPrice.VisibleIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(713, 415);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // repCustomerSurname
            // 
            this.repCustomerSurname.AutoHeight = false;
            this.repCustomerSurname.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repCustomerSurname.Name = "repCustomerSurname";
            // 
            // colCustomerSurname
            // 
            this.colCustomerSurname.Caption = "Customer Surname";
            this.colCustomerSurname.ColumnEdit = this.repCustomerSurname;
            this.colCustomerSurname.FieldName = "CustomerID";
            this.colCustomerSurname.Name = "colCustomerSurname";
            this.colCustomerSurname.Visible = true;
            this.colCustomerSurname.VisibleIndex = 3;
            // 
            // TransactionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grdTransactions);
            this.Controls.Add(this.grdTransactionLines);
            this.Name = "TransactionsForm";
            this.Text = "Transactions";
            this.Load += new System.EventHandler(this.TransactionsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsTransactions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTransactionLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTransactionLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTransactions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCustomerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCustomerSurname)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private BindingSource bsTransactions;
        private BindingSource bsTransactionLines;
        private DevExpress.XtraGrid.GridControl grdTransactionLines;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colTransactionID;
        private DevExpress.XtraGrid.GridControl grdTransactions;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn CustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colCarID;
        private DevExpress.XtraGrid.Columns.GridColumn colManagerID;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colServiceTaskID;
        private DevExpress.XtraGrid.Columns.GridColumn colEngineerID;
        private DevExpress.XtraGrid.Columns.GridColumn colHours;
        private DevExpress.XtraGrid.Columns.GridColumn colPricePerHour;
        private DevExpress.XtraGrid.Columns.GridColumn Price;
        private Button btnSave;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerSurname;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repCustomerSurname;
    }
}