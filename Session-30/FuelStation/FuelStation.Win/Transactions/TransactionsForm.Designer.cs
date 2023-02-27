namespace FuelStation.Win.Transactions {
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
            this.colTransactionLineID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTransactionID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repItems = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItemPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNetValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiscountValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTransactionLineTotalValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdTransactions = new DevExpress.XtraGrid.GridControl();
            this.grvTransactions = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repCustomers = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colEmployee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repEmployees = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colPaymentMethod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btn_Close = new System.Windows.Forms.Button();
            this.labelServiceTask = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.customerListDtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnAddTransactionLIne = new System.Windows.Forms.Button();
            this.btnEditTransactionLine = new System.Windows.Forms.Button();
            this.btnDeleteTransactionLine = new System.Windows.Forms.Button();
            this.btnAddTransaction = new System.Windows.Forms.Button();
            this.btnEditTransaction = new System.Windows.Forms.Button();
            this.btnDeleteTransaction = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bsTransactions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTransactionLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTransactionLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTransactionLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTransactions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTransactions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCustomers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerListDtoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // grdTransactionLines
            // 
            this.grdTransactionLines.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdTransactionLines.Location = new System.Drawing.Point(12, 314);
            this.grdTransactionLines.MainView = this.grvTransactionLines;
            this.grdTransactionLines.Name = "grdTransactionLines";
            this.grdTransactionLines.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repItems});
            this.grdTransactionLines.Size = new System.Drawing.Size(1007, 272);
            this.grdTransactionLines.TabIndex = 3;
            this.grdTransactionLines.UseEmbeddedNavigator = true;
            this.grdTransactionLines.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvTransactionLines});
            // 
            // grvTransactionLines
            // 
            this.grvTransactionLines.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTransactionLineID,
            this.colTransactionID,
            this.colItem,
            this.colQuantity,
            this.colItemPrice,
            this.colNetValue,
            this.colDiscountValue,
            this.colTransactionLineTotalValue});
            this.grvTransactionLines.GridControl = this.grdTransactionLines;
            this.grvTransactionLines.Name = "grvTransactionLines";
            this.grvTransactionLines.OptionsView.ShowGroupPanel = false;
            this.grvTransactionLines.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.grvTransactionLines_InitNewRow);
            this.grvTransactionLines.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvTransactionLines_CellValueChanged);
            this.grvTransactionLines.RowDeleting += new DevExpress.Data.RowDeletingEventHandler(this.grvTransactionLines_RowDeleting);
            this.grvTransactionLines.RowDeleted += new DevExpress.Data.RowDeletedEventHandler(this.grvTransactionLines_RowDeleted);
            this.grvTransactionLines.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.grvTransactionLines_ValidateRow);
            this.grvTransactionLines.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.grvTransactionLines_ValidatingEditor);
            // 
            // colTransactionLineID
            // 
            this.colTransactionLineID.Caption = "ID";
            this.colTransactionLineID.FieldName = "ID";
            this.colTransactionLineID.Name = "colTransactionLineID";
            this.colTransactionLineID.OptionsColumn.AllowEdit = false;
            // 
            // colTransactionID
            // 
            this.colTransactionID.Caption = "TransactionID";
            this.colTransactionID.FieldName = "TransactionID";
            this.colTransactionID.Name = "colTransactionID";
            // 
            // colItem
            // 
            this.colItem.Caption = "Item";
            this.colItem.ColumnEdit = this.repItems;
            this.colItem.FieldName = "ItemId";
            this.colItem.Name = "colItem";
            this.colItem.OptionsColumn.AllowEdit = false;
            this.colItem.Visible = true;
            this.colItem.VisibleIndex = 0;
            // 
            // repItems
            // 
            this.repItems.AutoHeight = false;
            this.repItems.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repItems.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ItemType", "Item Type"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Code", "Code"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Description", "Description"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Price", "Price")});
            this.repItems.Name = "repItems";
            this.repItems.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.StartsWith;
            // 
            // colQuantity
            // 
            this.colQuantity.Caption = "Quantity";
            this.colQuantity.FieldName = "Quantity";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.OptionsColumn.AllowEdit = false;
            this.colQuantity.Visible = true;
            this.colQuantity.VisibleIndex = 1;
            // 
            // colItemPrice
            // 
            this.colItemPrice.Caption = "Item Price";
            this.colItemPrice.FieldName = "ItemPrice";
            this.colItemPrice.Name = "colItemPrice";
            this.colItemPrice.OptionsColumn.AllowEdit = false;
            this.colItemPrice.Visible = true;
            this.colItemPrice.VisibleIndex = 2;
            // 
            // colNetValue
            // 
            this.colNetValue.Caption = "Net Value";
            this.colNetValue.FieldName = "NetValue";
            this.colNetValue.Name = "colNetValue";
            this.colNetValue.OptionsColumn.AllowEdit = false;
            this.colNetValue.Visible = true;
            this.colNetValue.VisibleIndex = 3;
            // 
            // colDiscountValue
            // 
            this.colDiscountValue.Caption = "DiscountValue";
            this.colDiscountValue.FieldName = "DiscountValue";
            this.colDiscountValue.Name = "colDiscountValue";
            this.colDiscountValue.OptionsColumn.AllowEdit = false;
            this.colDiscountValue.Visible = true;
            this.colDiscountValue.VisibleIndex = 4;
            // 
            // colTransactionLineTotalValue
            // 
            this.colTransactionLineTotalValue.Caption = "Total Value";
            this.colTransactionLineTotalValue.FieldName = "TotalValue";
            this.colTransactionLineTotalValue.Name = "colTransactionLineTotalValue";
            this.colTransactionLineTotalValue.OptionsColumn.AllowEdit = false;
            this.colTransactionLineTotalValue.Visible = true;
            this.colTransactionLineTotalValue.VisibleIndex = 5;
            // 
            // grdTransactions
            // 
            this.grdTransactions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdTransactions.Location = new System.Drawing.Point(12, 31);
            this.grdTransactions.MainView = this.grvTransactions;
            this.grdTransactions.Name = "grdTransactions";
            this.grdTransactions.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repCustomers,
            this.repEmployees});
            this.grdTransactions.Size = new System.Drawing.Size(1007, 247);
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
            this.colCustomer,
            this.colEmployee,
            this.colPaymentMethod,
            this.colTotalValue});
            this.grvTransactions.GridControl = this.grdTransactions;
            this.grvTransactions.Name = "grvTransactions";
            this.grvTransactions.OptionsView.ShowGroupPanel = false;
            this.grvTransactions.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.grvTransactions_InitNewRow);
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
            // colCustomer
            // 
            this.colCustomer.Caption = "Customer Name";
            this.colCustomer.ColumnEdit = this.repCustomers;
            this.colCustomer.FieldName = "CustomerId";
            this.colCustomer.Name = "colCustomer";
            this.colCustomer.OptionsColumn.AllowEdit = false;
            this.colCustomer.Visible = true;
            this.colCustomer.VisibleIndex = 1;
            // 
            // repCustomers
            // 
            this.repCustomers.AutoHeight = false;
            this.repCustomers.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repCustomers.Name = "repCustomers";
            // 
            // colEmployee
            // 
            this.colEmployee.Caption = "Employee Name";
            this.colEmployee.ColumnEdit = this.repEmployees;
            this.colEmployee.FieldName = "EmployeeId";
            this.colEmployee.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colEmployee.Name = "colEmployee";
            this.colEmployee.OptionsColumn.AllowEdit = false;
            this.colEmployee.Visible = true;
            this.colEmployee.VisibleIndex = 2;
            // 
            // repEmployees
            // 
            this.repEmployees.AutoHeight = false;
            this.repEmployees.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repEmployees.Name = "repEmployees";
            // 
            // colPaymentMethod
            // 
            this.colPaymentMethod.Caption = "Payment Method";
            this.colPaymentMethod.FieldName = "PaymentMethod";
            this.colPaymentMethod.Name = "colPaymentMethod";
            this.colPaymentMethod.OptionsColumn.AllowEdit = false;
            this.colPaymentMethod.Visible = true;
            this.colPaymentMethod.VisibleIndex = 3;
            // 
            // colTotalValue
            // 
            this.colTotalValue.Caption = "Total Value";
            this.colTotalValue.FieldName = "TotalValue";
            this.colTotalValue.Name = "colTotalValue";
            this.colTotalValue.OptionsColumn.AllowEdit = false;
            this.colTotalValue.Visible = true;
            this.colTotalValue.VisibleIndex = 4;
            // 
            // btn_Close
            // 
            this.btn_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(234)))), ((int)(((byte)(218)))));
            this.btn_Close.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_Close.FlatAppearance.BorderSize = 2;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("Segoe Print", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Close.Location = new System.Drawing.Point(1022, 591);
            this.btn_Close.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(163, 40);
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
            this.labelServiceTask.Location = new System.Drawing.Point(12, 1);
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
            this.labelControl1.Location = new System.Drawing.Point(12, 284);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(150, 24);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "TransactionLines";
            // 
            // customerListDtoBindingSource
            // 
            this.customerListDtoBindingSource.DataSource = typeof(FuelStation.Web.Blazor.Shared.CustomerListDto);
            // 
            // btnAddTransactionLIne
            // 
            this.btnAddTransactionLIne.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddTransactionLIne.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(234)))), ((int)(((byte)(218)))));
            this.btnAddTransactionLIne.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnAddTransactionLIne.FlatAppearance.BorderSize = 2;
            this.btnAddTransactionLIne.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTransactionLIne.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddTransactionLIne.Location = new System.Drawing.Point(1022, 327);
            this.btnAddTransactionLIne.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddTransactionLIne.Name = "btnAddTransactionLIne";
            this.btnAddTransactionLIne.Size = new System.Drawing.Size(163, 78);
            this.btnAddTransactionLIne.TabIndex = 11;
            this.btnAddTransactionLIne.Text = "Add Transaction Line";
            this.btnAddTransactionLIne.UseVisualStyleBackColor = false;
            this.btnAddTransactionLIne.Click += new System.EventHandler(this.btnAddTransactionLine_Click);
            // 
            // btnEditTransactionLine
            // 
            this.btnEditTransactionLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditTransactionLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(234)))), ((int)(((byte)(218)))));
            this.btnEditTransactionLine.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnEditTransactionLine.FlatAppearance.BorderSize = 2;
            this.btnEditTransactionLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditTransactionLine.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEditTransactionLine.Location = new System.Drawing.Point(1022, 414);
            this.btnEditTransactionLine.Margin = new System.Windows.Forms.Padding(0);
            this.btnEditTransactionLine.Name = "btnEditTransactionLine";
            this.btnEditTransactionLine.Size = new System.Drawing.Size(163, 78);
            this.btnEditTransactionLine.TabIndex = 12;
            this.btnEditTransactionLine.Text = "Edit Transaction Line";
            this.btnEditTransactionLine.UseVisualStyleBackColor = false;
            this.btnEditTransactionLine.Click += new System.EventHandler(this.btnEditTransactionLine_Click);
            // 
            // btnDeleteTransactionLine
            // 
            this.btnDeleteTransactionLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteTransactionLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(234)))), ((int)(((byte)(218)))));
            this.btnDeleteTransactionLine.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnDeleteTransactionLine.FlatAppearance.BorderSize = 2;
            this.btnDeleteTransactionLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteTransactionLine.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDeleteTransactionLine.Location = new System.Drawing.Point(1022, 500);
            this.btnDeleteTransactionLine.Margin = new System.Windows.Forms.Padding(0);
            this.btnDeleteTransactionLine.Name = "btnDeleteTransactionLine";
            this.btnDeleteTransactionLine.Size = new System.Drawing.Size(163, 78);
            this.btnDeleteTransactionLine.TabIndex = 13;
            this.btnDeleteTransactionLine.Text = "Delete Transaction Line";
            this.btnDeleteTransactionLine.UseVisualStyleBackColor = false;
            this.btnDeleteTransactionLine.Click += new System.EventHandler(this.btnDeleteTransactionLine_Click);
            // 
            // btnAddTransaction
            // 
            this.btnAddTransaction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddTransaction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(234)))), ((int)(((byte)(218)))));
            this.btnAddTransaction.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnAddTransaction.FlatAppearance.BorderSize = 2;
            this.btnAddTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTransaction.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddTransaction.Location = new System.Drawing.Point(1022, 30);
            this.btnAddTransaction.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddTransaction.Name = "btnAddTransaction";
            this.btnAddTransaction.Size = new System.Drawing.Size(163, 78);
            this.btnAddTransaction.TabIndex = 14;
            this.btnAddTransaction.Text = "Add Transaction";
            this.btnAddTransaction.UseVisualStyleBackColor = false;
            this.btnAddTransaction.Click += new System.EventHandler(this.btnAddTransaction_Click);
            // 
            // btnEditTransaction
            // 
            this.btnEditTransaction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditTransaction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(234)))), ((int)(((byte)(218)))));
            this.btnEditTransaction.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnEditTransaction.FlatAppearance.BorderSize = 2;
            this.btnEditTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditTransaction.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEditTransaction.Location = new System.Drawing.Point(1022, 112);
            this.btnEditTransaction.Margin = new System.Windows.Forms.Padding(0);
            this.btnEditTransaction.Name = "btnEditTransaction";
            this.btnEditTransaction.Size = new System.Drawing.Size(163, 78);
            this.btnEditTransaction.TabIndex = 15;
            this.btnEditTransaction.Text = "Edit Transaction";
            this.btnEditTransaction.UseVisualStyleBackColor = false;
            this.btnEditTransaction.Click += new System.EventHandler(this.btnEditTransaction_Click);
            // 
            // btnDeleteTransaction
            // 
            this.btnDeleteTransaction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteTransaction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(234)))), ((int)(((byte)(218)))));
            this.btnDeleteTransaction.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnDeleteTransaction.FlatAppearance.BorderSize = 2;
            this.btnDeleteTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteTransaction.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDeleteTransaction.Location = new System.Drawing.Point(1022, 197);
            this.btnDeleteTransaction.Margin = new System.Windows.Forms.Padding(0);
            this.btnDeleteTransaction.Name = "btnDeleteTransaction";
            this.btnDeleteTransaction.Size = new System.Drawing.Size(163, 78);
            this.btnDeleteTransaction.TabIndex = 16;
            this.btnDeleteTransaction.Text = "Delete Transaction";
            this.btnDeleteTransaction.UseVisualStyleBackColor = false;
            // 
            // TransactionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(234)))), ((int)(((byte)(218)))));
            this.ClientSize = new System.Drawing.Size(1194, 637);
            this.Controls.Add(this.btnDeleteTransaction);
            this.Controls.Add(this.btnEditTransaction);
            this.Controls.Add(this.btnAddTransaction);
            this.Controls.Add(this.btnDeleteTransactionLine);
            this.Controls.Add(this.btnEditTransactionLine);
            this.Controls.Add(this.btnAddTransactionLIne);
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
            ((System.ComponentModel.ISupportInitialize)(this.repItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTransactions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTransactions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCustomers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerListDtoBindingSource)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn colCustomer;
        private Button btn_Close;
        private DevExpress.XtraGrid.Columns.GridColumn colTransactionID;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraEditors.LabelControl labelServiceTask;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn colTransactionLineID;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployee;
        private DevExpress.XtraGrid.Columns.GridColumn colItem;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentMethod;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalValue;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colItemPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colNetValue;
        private DevExpress.XtraGrid.Columns.GridColumn colDiscountValue;
        private DevExpress.XtraGrid.Columns.GridColumn colTransactionLineTotalValue;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repItems;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repCustomers;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repEmployees;
        private BindingSource customerListDtoBindingSource;
        private Button btnAddTransactionLIne;
        private Button btnEditTransactionLine;
        private Button btnDeleteTransactionLine;
        private Button btnAddTransaction;
        private Button btnEditTransaction;
        private Button btnDeleteTransaction;
    }
}