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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvTransactions = new System.Windows.Forms.DataGridView();
            this.TransactionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransactionCustomerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransactionCarID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransactionManagerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransactionTotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsTransactions = new System.Windows.Forms.BindingSource(this.components);
            this.dgvTransactionLines = new System.Windows.Forms.DataGridView();
            this.TransactionLineTransactionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransactionLineServiceTaskID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransactionLineEngineerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransactionLineHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransactionLinePricePerHour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransactionLinePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsTransactionLines = new System.Windows.Forms.BindingSource(this.components);
            this.grdTransactions = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerID = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTransactions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactionLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTransactionLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTransactions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTransactions
            // 
            this.dgvTransactions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTransactions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTransactions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransactions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TransactionDate,
            this.TransactionCustomerID,
            this.TransactionCarID,
            this.TransactionManagerID,
            this.TransactionTotalPrice});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTransactions.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvTransactions.Location = new System.Drawing.Point(72, 76);
            this.dgvTransactions.Name = "dgvTransactions";
            this.dgvTransactions.RowTemplate.Height = 25;
            this.dgvTransactions.Size = new System.Drawing.Size(271, 150);
            this.dgvTransactions.TabIndex = 0;
            // 
            // TransactionDate
            // 
            this.TransactionDate.DataPropertyName = "Date";
            this.TransactionDate.HeaderText = "Date";
            this.TransactionDate.Name = "TransactionDate";
            // 
            // TransactionCustomerID
            // 
            this.TransactionCustomerID.DataPropertyName = "CustomerID";
            this.TransactionCustomerID.HeaderText = "CustomerID";
            this.TransactionCustomerID.Name = "TransactionCustomerID";
            // 
            // TransactionCarID
            // 
            this.TransactionCarID.DataPropertyName = "CarID";
            this.TransactionCarID.HeaderText = "CarID";
            this.TransactionCarID.Name = "TransactionCarID";
            // 
            // TransactionManagerID
            // 
            this.TransactionManagerID.DataPropertyName = "ManagerID";
            this.TransactionManagerID.HeaderText = "ManagerID";
            this.TransactionManagerID.Name = "TransactionManagerID";
            // 
            // TransactionTotalPrice
            // 
            this.TransactionTotalPrice.DataPropertyName = "TotalPrice";
            this.TransactionTotalPrice.HeaderText = "TotalPrice";
            this.TransactionTotalPrice.Name = "TransactionTotalPrice";
            // 
            // dgvTransactionLines
            // 
            this.dgvTransactionLines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTransactionLines.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTransactionLines.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvTransactionLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransactionLines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TransactionLineTransactionID,
            this.TransactionLineServiceTaskID,
            this.TransactionLineEngineerID,
            this.TransactionLineHours,
            this.TransactionLinePricePerHour,
            this.TransactionLinePrice});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTransactionLines.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvTransactionLines.Location = new System.Drawing.Point(72, 262);
            this.dgvTransactionLines.Name = "dgvTransactionLines";
            this.dgvTransactionLines.RowTemplate.Height = 25;
            this.dgvTransactionLines.Size = new System.Drawing.Size(271, 150);
            this.dgvTransactionLines.TabIndex = 1;
            // 
            // TransactionLineTransactionID
            // 
            this.TransactionLineTransactionID.DataPropertyName = "TransactionID";
            this.TransactionLineTransactionID.HeaderText = "TransactionID";
            this.TransactionLineTransactionID.Name = "TransactionLineTransactionID";
            // 
            // TransactionLineServiceTaskID
            // 
            this.TransactionLineServiceTaskID.DataPropertyName = "ServiceTaskID";
            this.TransactionLineServiceTaskID.HeaderText = "ServiceTaskID";
            this.TransactionLineServiceTaskID.Name = "TransactionLineServiceTaskID";
            // 
            // TransactionLineEngineerID
            // 
            this.TransactionLineEngineerID.DataPropertyName = "EngineerID";
            this.TransactionLineEngineerID.HeaderText = "EngineerID";
            this.TransactionLineEngineerID.Name = "TransactionLineEngineerID";
            // 
            // TransactionLineHours
            // 
            this.TransactionLineHours.DataPropertyName = "Hours";
            this.TransactionLineHours.HeaderText = "Hours";
            this.TransactionLineHours.Name = "TransactionLineHours";
            // 
            // TransactionLinePricePerHour
            // 
            this.TransactionLinePricePerHour.DataPropertyName = "PricePerHour";
            this.TransactionLinePricePerHour.HeaderText = "PricePerHour";
            this.TransactionLinePricePerHour.Name = "TransactionLinePricePerHour";
            // 
            // TransactionLinePrice
            // 
            this.TransactionLinePrice.DataPropertyName = "Price";
            this.TransactionLinePrice.HeaderText = "Price";
            this.TransactionLinePrice.Name = "TransactionLinePrice";
            // 
            // grdTransactions
            // 
            this.grdTransactions.Location = new System.Drawing.Point(398, 76);
            this.grdTransactions.MainView = this.gridView1;
            this.grdTransactions.Name = "grdTransactions";
            this.grdTransactions.Size = new System.Drawing.Size(400, 200);
            this.grdTransactions.TabIndex = 2;
            this.grdTransactions.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDate,
            this.colCustomerID});
            this.gridView1.GridControl = this.grdTransactions;
            this.gridView1.Name = "gridView1";
            // 
            // colDate
            // 
            this.colDate.Caption = "Date";
            this.colDate.FieldName = "Date";
            this.colDate.Name = "colDate";
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 0;
            // 
            // colCustomerID
            // 
            this.colCustomerID.Caption = "CustomerID";
            this.colCustomerID.FieldName = "CustomerID";
            this.colCustomerID.Name = "colCustomerID";
            this.colCustomerID.Visible = true;
            this.colCustomerID.VisibleIndex = 1;
            // 
            // TransactionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grdTransactions);
            this.Controls.Add(this.dgvTransactionLines);
            this.Controls.Add(this.dgvTransactions);
            this.Name = "TransactionsForm";
            this.Text = "Transactions";
            this.Load += new System.EventHandler(this.TransactionsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTransactions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactionLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTransactionLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTransactions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dgvTransactions;
        private DataGridViewTextBoxColumn TransactionDate;
        private DataGridViewTextBoxColumn TransactionCustomerID;
        private DataGridViewTextBoxColumn TransactionCarID;
        private DataGridViewTextBoxColumn TransactionManagerID;
        private DataGridViewTextBoxColumn TransactionTotalPrice;
        private BindingSource bsTransactions;
        private DataGridView dgvTransactionLines;
        private DataGridViewTextBoxColumn TransactionLineTransactionID;
        private DataGridViewTextBoxColumn TransactionLineServiceTaskID;
        private DataGridViewTextBoxColumn TransactionLineEngineerID;
        private DataGridViewTextBoxColumn TransactionLineHours;
        private DataGridViewTextBoxColumn TransactionLinePricePerHour;
        private DataGridViewTextBoxColumn TransactionLinePrice;
        private BindingSource bsTransactionLines;
        private DevExpress.XtraGrid.GridControl grdTransactions;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerID;
    }
}