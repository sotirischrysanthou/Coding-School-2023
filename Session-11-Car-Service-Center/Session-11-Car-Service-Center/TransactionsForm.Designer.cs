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
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTransactions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactionLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTransactionLines)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTransactions
            // 
            this.dgvTransactions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTransactions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransactions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TransactionDate,
            this.TransactionCustomerID,
            this.TransactionCarID,
            this.TransactionManagerID,
            this.TransactionTotalPrice});
            this.dgvTransactions.Location = new System.Drawing.Point(72, 76);
            this.dgvTransactions.Name = "dgvTransactions";
            this.dgvTransactions.RowTemplate.Height = 25;
            this.dgvTransactions.Size = new System.Drawing.Size(562, 150);
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
            this.dgvTransactionLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransactionLines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TransactionLineTransactionID,
            this.TransactionLineServiceTaskID,
            this.TransactionLineEngineerID,
            this.TransactionLineHours,
            this.TransactionLinePricePerHour,
            this.TransactionLinePrice});
            this.dgvTransactionLines.Location = new System.Drawing.Point(72, 262);
            this.dgvTransactionLines.Name = "dgvTransactionLines";
            this.dgvTransactionLines.RowTemplate.Height = 25;
            this.dgvTransactionLines.Size = new System.Drawing.Size(562, 150);
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
            // TransactionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvTransactionLines);
            this.Controls.Add(this.dgvTransactions);
            this.Name = "TransactionsForm";
            this.Text = "Transactions";
            this.Load += new System.EventHandler(this.TransactionsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTransactions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactionLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTransactionLines)).EndInit();
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
    }
}