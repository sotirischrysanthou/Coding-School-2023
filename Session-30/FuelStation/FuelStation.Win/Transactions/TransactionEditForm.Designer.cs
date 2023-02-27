namespace FuelStation.Win.Transactions {
    partial class TransactionEditForm {
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
            this.txtCardNumber = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCustomerName = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCustomerSurname = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEmployeeSurname = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEmployeeName = new DevExpress.XtraEditors.TextEdit();
            this.grdCustomers = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerSurname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCardNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdEmployees = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSurname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRole = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bsCustomers = new System.Windows.Forms.BindingSource(this.components);
            this.bsEmployees = new System.Windows.Forms.BindingSource(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCash = new System.Windows.Forms.Button();
            this.btnCreditCard = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.dateEdit = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCardNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerSurname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployeeSurname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployeeName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCustomers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCustomers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit.Properties.CalendarTimeProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCardNumber
            // 
            this.txtCardNumber.Location = new System.Drawing.Point(39, 100);
            this.txtCardNumber.Name = "txtCardNumber";
            this.txtCardNumber.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCardNumber.Properties.Appearance.Options.UseFont = true;
            this.txtCardNumber.Size = new System.Drawing.Size(126, 26);
            this.txtCardNumber.TabIndex = 0;
            this.txtCardNumber.EditValueChanged += new System.EventHandler(this.txtCardNumber_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(171, 20);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(126, 33);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Customers";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(39, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Card Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(171, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Name";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(171, 100);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCustomerName.Properties.Appearance.Options.UseFont = true;
            this.txtCustomerName.Size = new System.Drawing.Size(126, 26);
            this.txtCustomerName.TabIndex = 3;
            this.txtCustomerName.EditValueChanged += new System.EventHandler(this.txtCustomerName_EditValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(303, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "Surname";
            // 
            // txtCustomerSurname
            // 
            this.txtCustomerSurname.Location = new System.Drawing.Point(303, 100);
            this.txtCustomerSurname.Name = "txtCustomerSurname";
            this.txtCustomerSurname.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCustomerSurname.Properties.Appearance.Options.UseFont = true;
            this.txtCustomerSurname.Size = new System.Drawing.Size(126, 26);
            this.txtCustomerSurname.TabIndex = 5;
            this.txtCustomerSurname.EditValueChanged += new System.EventHandler(this.txtCustomerSurname_EditValueChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(700, 20);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(127, 33);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "Employees";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(783, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 19);
            this.label4.TabIndex = 11;
            this.label4.Text = "Surname";
            // 
            // txtEmployeeSurname
            // 
            this.txtEmployeeSurname.Location = new System.Drawing.Point(783, 100);
            this.txtEmployeeSurname.Name = "txtEmployeeSurname";
            this.txtEmployeeSurname.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtEmployeeSurname.Properties.Appearance.Options.UseFont = true;
            this.txtEmployeeSurname.Size = new System.Drawing.Size(126, 26);
            this.txtEmployeeSurname.TabIndex = 10;
            this.txtEmployeeSurname.EditValueChanged += new System.EventHandler(this.txtEmployeeSurname_EditValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(651, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 19);
            this.label5.TabIndex = 9;
            this.label5.Text = "Name";
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.Location = new System.Drawing.Point(651, 100);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtEmployeeName.Properties.Appearance.Options.UseFont = true;
            this.txtEmployeeName.Size = new System.Drawing.Size(126, 26);
            this.txtEmployeeName.TabIndex = 8;
            this.txtEmployeeName.EditValueChanged += new System.EventHandler(this.txtEmployeeName_EditValueChanged);
            // 
            // grdCustomers
            // 
            this.grdCustomers.Location = new System.Drawing.Point(30, 132);
            this.grdCustomers.MainView = this.gridView1;
            this.grdCustomers.Name = "grdCustomers";
            this.grdCustomers.Size = new System.Drawing.Size(418, 433);
            this.grdCustomers.TabIndex = 13;
            this.grdCustomers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCustomerName,
            this.colCustomerSurname,
            this.colCardNumber});
            this.gridView1.GridControl = this.grdCustomers;
            this.gridView1.Name = "gridView1";
            // 
            // colCustomerName
            // 
            this.colCustomerName.Caption = "Name";
            this.colCustomerName.FieldName = "Name";
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.OptionsColumn.AllowEdit = false;
            this.colCustomerName.Visible = true;
            this.colCustomerName.VisibleIndex = 0;
            // 
            // colCustomerSurname
            // 
            this.colCustomerSurname.Caption = "Surname";
            this.colCustomerSurname.FieldName = "Surname";
            this.colCustomerSurname.Name = "colCustomerSurname";
            this.colCustomerSurname.OptionsColumn.AllowEdit = false;
            this.colCustomerSurname.Visible = true;
            this.colCustomerSurname.VisibleIndex = 1;
            // 
            // colCardNumber
            // 
            this.colCardNumber.Caption = "Card Number";
            this.colCardNumber.FieldName = "CardNumber";
            this.colCardNumber.Name = "colCardNumber";
            this.colCardNumber.OptionsColumn.AllowEdit = false;
            this.colCardNumber.Visible = true;
            this.colCardNumber.VisibleIndex = 2;
            // 
            // grdEmployees
            // 
            this.grdEmployees.Location = new System.Drawing.Point(571, 132);
            this.grdEmployees.MainView = this.gridView2;
            this.grdEmployees.Name = "grdEmployees";
            this.grdEmployees.Size = new System.Drawing.Size(418, 433);
            this.grdEmployees.TabIndex = 14;
            this.grdEmployees.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEmployeeName,
            this.colSurname,
            this.colRole});
            this.gridView2.GridControl = this.grdEmployees;
            this.gridView2.Name = "gridView2";
            // 
            // colEmployeeName
            // 
            this.colEmployeeName.Caption = "Name";
            this.colEmployeeName.FieldName = "Name";
            this.colEmployeeName.Name = "colEmployeeName";
            this.colEmployeeName.Visible = true;
            this.colEmployeeName.VisibleIndex = 0;
            // 
            // colSurname
            // 
            this.colSurname.Caption = "Surname";
            this.colSurname.FieldName = "Surname";
            this.colSurname.Name = "colSurname";
            this.colSurname.Visible = true;
            this.colSurname.VisibleIndex = 1;
            // 
            // colRole
            // 
            this.colRole.Caption = "Role";
            this.colRole.FieldName = "EmployeeType";
            this.colRole.Name = "colRole";
            this.colRole.Visible = true;
            this.colRole.VisibleIndex = 2;
            // 
            // bsCustomers
            // 
            this.bsCustomers.CurrentChanged += new System.EventHandler(this.bsCustomers_CurrentChanged);
            // 
            // bsEmployees
            // 
            this.bsEmployees.CurrentChanged += new System.EventHandler(this.bsEmployees_CurrentChanged);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSave.FlatAppearance.BorderSize = 2;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSave.Location = new System.Drawing.Point(826, 600);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(163, 53);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCancel.FlatAppearance.BorderSize = 2;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.Location = new System.Drawing.Point(30, 600);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(163, 53);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCash
            // 
            this.btnCash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCash.BackColor = System.Drawing.Color.Transparent;
            this.btnCash.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCash.FlatAppearance.BorderSize = 2;
            this.btnCash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCash.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCash.Location = new System.Drawing.Point(1000, 277);
            this.btnCash.Margin = new System.Windows.Forms.Padding(0);
            this.btnCash.Name = "btnCash";
            this.btnCash.Size = new System.Drawing.Size(163, 114);
            this.btnCash.TabIndex = 23;
            this.btnCash.Text = "Cash";
            this.btnCash.UseVisualStyleBackColor = false;
            this.btnCash.Click += new System.EventHandler(this.btnCash_Click);
            // 
            // btnCreditCard
            // 
            this.btnCreditCard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreditCard.BackColor = System.Drawing.Color.Transparent;
            this.btnCreditCard.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCreditCard.FlatAppearance.BorderSize = 2;
            this.btnCreditCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreditCard.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCreditCard.Location = new System.Drawing.Point(1000, 432);
            this.btnCreditCard.Margin = new System.Windows.Forms.Padding(0);
            this.btnCreditCard.Name = "btnCreditCard";
            this.btnCreditCard.Size = new System.Drawing.Size(163, 114);
            this.btnCreditCard.TabIndex = 24;
            this.btnCreditCard.Text = "Credit Card";
            this.btnCreditCard.UseVisualStyleBackColor = false;
            this.btnCreditCard.Click += new System.EventHandler(this.btnCreditCard_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDate.Location = new System.Drawing.Point(1000, 132);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(38, 19);
            this.lblDate.TabIndex = 26;
            this.lblDate.Text = "Date";
            // 
            // dateEdit
            // 
            this.dateEdit.EditValue = null;
            this.dateEdit.Location = new System.Drawing.Point(1000, 154);
            this.dateEdit.Name = "dateEdit";
            this.dateEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateEdit.Properties.Appearance.Options.UseFont = true;
            this.dateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit.Size = new System.Drawing.Size(160, 26);
            this.dateEdit.TabIndex = 27;
            // 
            // TransactionEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 662);
            this.Controls.Add(this.dateEdit);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.btnCreditCard);
            this.Controls.Add(this.btnCash);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grdEmployees);
            this.Controls.Add(this.grdCustomers);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtEmployeeSurname);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtEmployeeName);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCustomerSurname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtCardNumber);
            this.Name = "TransactionEditForm";
            this.Text = "TransactionEditForm";
            this.Load += new System.EventHandler(this.TransactionEditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtCardNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerSurname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployeeSurname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployeeName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCustomers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCustomers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtCardNumber;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private Label label1;
        private Label label2;
        private DevExpress.XtraEditors.TextEdit txtCustomerName;
        private Label label3;
        private DevExpress.XtraEditors.TextEdit txtCustomerSurname;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private Label label4;
        private DevExpress.XtraEditors.TextEdit txtEmployeeSurname;
        private Label label5;
        private DevExpress.XtraEditors.TextEdit txtEmployeeName;
        private DevExpress.XtraGrid.GridControl grdCustomers;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerSurname;
        private DevExpress.XtraGrid.Columns.GridColumn colCardNumber;
        private DevExpress.XtraGrid.GridControl grdEmployees;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeName;
        private DevExpress.XtraGrid.Columns.GridColumn colSurname;
        private DevExpress.XtraGrid.Columns.GridColumn colRole;
        private BindingSource bsCustomers;
        private BindingSource bsEmployees;
        private Button btnSave;
        private Button btnCancel;
        private Button btnCash;
        private Button btnCreditCard;
        private Label lblDate;
        private DevExpress.XtraEditors.DateEdit dateEdit;
    }
}