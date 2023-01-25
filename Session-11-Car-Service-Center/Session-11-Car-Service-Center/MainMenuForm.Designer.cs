namespace Session_11_Car_Service_Center {
    partial class MainMenuForm {
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
            this.btnTransactions = new System.Windows.Forms.Button();
            this.btnCustomerAndCars = new System.Windows.Forms.Button();
            this.btnPopulate = new System.Windows.Forms.Button();
            this.btnServiceTasks = new System.Windows.Forms.Button();
            this.btnEmployees = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btn_MonthlyLedger = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTransactions
            // 
            this.btnTransactions.Location = new System.Drawing.Point(344, 73);
            this.btnTransactions.Name = "btnTransactions";
            this.btnTransactions.Size = new System.Drawing.Size(125, 23);
            this.btnTransactions.TabIndex = 0;
            this.btnTransactions.Text = "Transactions";
            this.btnTransactions.UseVisualStyleBackColor = true;
            this.btnTransactions.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCustomerAndCars
            // 
            this.btnCustomerAndCars.Location = new System.Drawing.Point(344, 102);
            this.btnCustomerAndCars.Name = "btnCustomerAndCars";
            this.btnCustomerAndCars.Size = new System.Drawing.Size(125, 23);
            this.btnCustomerAndCars.TabIndex = 1;
            this.btnCustomerAndCars.Text = "Customers and Cars";
            this.btnCustomerAndCars.UseVisualStyleBackColor = true;
            this.btnCustomerAndCars.Click += new System.EventHandler(this.btnCustomerAndCars_Click);
            // 
            // btnPopulate
            // 
            this.btnPopulate.Location = new System.Drawing.Point(621, 382);
            this.btnPopulate.Name = "btnPopulate";
            this.btnPopulate.Size = new System.Drawing.Size(125, 23);
            this.btnPopulate.TabIndex = 2;
            this.btnPopulate.Text = "Populate";
            this.btnPopulate.UseVisualStyleBackColor = true;
            this.btnPopulate.Click += new System.EventHandler(this.btnPopulate_Click);
            // 
            // btnServiceTasks
            // 
            this.btnServiceTasks.Location = new System.Drawing.Point(344, 131);
            this.btnServiceTasks.Name = "btnServiceTasks";
            this.btnServiceTasks.Size = new System.Drawing.Size(125, 24);
            this.btnServiceTasks.TabIndex = 2;
            this.btnServiceTasks.Text = "Service Tasks";
            this.btnServiceTasks.UseVisualStyleBackColor = true;
            this.btnServiceTasks.Click += new System.EventHandler(this.btnServiceTasks_Click);
            // 
            // btnEmployees
            // 
            this.btnEmployees.Location = new System.Drawing.Point(344, 160);
            this.btnEmployees.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEmployees.Name = "btnEmployees";
            this.btnEmployees.Size = new System.Drawing.Size(125, 24);
            this.btnEmployees.TabIndex = 3;
            this.btnEmployees.Text = "Employees";
            this.btnEmployees.UseVisualStyleBackColor = true;
            this.btnEmployees.Click += new System.EventHandler(this.btnEmployees_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(621, 328);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(125, 22);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(621, 355);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(125, 22);
            this.btnLoad.TabIndex = 5;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btn_MonthlyLedger
            // 
            this.btn_MonthlyLedger.Location = new System.Drawing.Point(344, 188);
            this.btn_MonthlyLedger.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_MonthlyLedger.Name = "btn_MonthlyLedger";
            this.btn_MonthlyLedger.Size = new System.Drawing.Size(125, 24);
            this.btn_MonthlyLedger.TabIndex = 6;
            this.btn_MonthlyLedger.Text = "MonthlyLedger";
            this.btn_MonthlyLedger.UseVisualStyleBackColor = true;
            this.btn_MonthlyLedger.Click += new System.EventHandler(this.btn_MonthlyLedger_Click);
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_MonthlyLedger);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnEmployees);
            this.Controls.Add(this.btnPopulate);
            this.Controls.Add(this.btnServiceTasks);
            this.Controls.Add(this.btnCustomerAndCars);
            this.Controls.Add(this.btnTransactions);
            this.Name = "MainMenuForm";
            this.Text = "MainMenu";
            this.Load += new System.EventHandler(this.MainMenuForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnTransactions;
        private Button btnCustomerAndCars;
        private Button btnPopulate;
        private Button btnServiceTasks;
        private Button btnEmployees;
        private Button btnSave;
        private Button btnLoad;
        private Button btn_MonthlyLedger;
    }
}