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
            this.SuspendLayout();
            // 
            // btnTransactions
            // 
            this.btnTransactions.Location = new System.Drawing.Point(393, 97);
            this.btnTransactions.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTransactions.Name = "btnTransactions";
            this.btnTransactions.Size = new System.Drawing.Size(143, 31);
            this.btnTransactions.TabIndex = 0;
            this.btnTransactions.Text = "Transactions";
            this.btnTransactions.UseVisualStyleBackColor = true;
            this.btnTransactions.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCustomerAndCars
            // 
            this.btnCustomerAndCars.Location = new System.Drawing.Point(393, 136);
            this.btnCustomerAndCars.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCustomerAndCars.Name = "btnCustomerAndCars";
            this.btnCustomerAndCars.Size = new System.Drawing.Size(143, 31);
            this.btnCustomerAndCars.TabIndex = 1;
            this.btnCustomerAndCars.Text = "Customers and Cars";
            this.btnCustomerAndCars.UseVisualStyleBackColor = true;
            this.btnCustomerAndCars.Click += new System.EventHandler(this.btnCustomerAndCars_Click);
            // 
            // btnPopulate
            // 
            this.btnPopulate.Location = new System.Drawing.Point(710, 509);
            this.btnPopulate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPopulate.Name = "btnPopulate";
            this.btnPopulate.Size = new System.Drawing.Size(143, 31);
            this.btnPopulate.TabIndex = 2;
            this.btnPopulate.Text = "Populate";
            this.btnPopulate.UseVisualStyleBackColor = true;
            this.btnPopulate.Click += new System.EventHandler(this.btnPopulate_Click);
            // 
            // btnServiceTasks
            // 
            this.btnServiceTasks.Location = new System.Drawing.Point(393, 175);
            this.btnServiceTasks.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnServiceTasks.Name = "btnServiceTasks";
            this.btnServiceTasks.Size = new System.Drawing.Size(143, 32);
            this.btnServiceTasks.TabIndex = 2;
            this.btnServiceTasks.Text = "Service Tasks";
            this.btnServiceTasks.UseVisualStyleBackColor = true;
            this.btnServiceTasks.Click += new System.EventHandler(this.btnServiceTasks_Click);
            // 
            // btnEmployees
            // 
            this.btnEmployees.Location = new System.Drawing.Point(393, 214);
            this.btnEmployees.Name = "btnEmployees";
            this.btnEmployees.Size = new System.Drawing.Size(143, 32);
            this.btnEmployees.TabIndex = 3;
            this.btnEmployees.Text = "Employees";
            this.btnEmployees.UseVisualStyleBackColor = true;
            this.btnEmployees.Click += new System.EventHandler(this.btnEmployees_Click);
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 600);
            this.Controls.Add(this.btnEmployees);
            this.Controls.Add(this.btnPopulate);
            this.Controls.Add(this.btnServiceTasks);
            this.Controls.Add(this.btnCustomerAndCars);
            this.Controls.Add(this.btnTransactions);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
    }
}