namespace Session_16.Win {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenuForm));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btn_MonthlyLedger = new System.Windows.Forms.Button();
            this.btnEmployees = new System.Windows.Forms.Button();
            this.btnServiceTasks = new System.Windows.Forms.Button();
            this.btnCustomerAndCars = new System.Windows.Forms.Button();
            this.btnTransactions = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnPopulate = new System.Windows.Forms.Button();
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.panelTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(234)))), ((int)(((byte)(218)))));
            this.panelMenu.Controls.Add(this.btnExit);
            this.panelMenu.Controls.Add(this.btn_MonthlyLedger);
            this.panelMenu.Controls.Add(this.btnEmployees);
            this.panelMenu.Controls.Add(this.btnServiceTasks);
            this.panelMenu.Controls.Add(this.btnCustomerAndCars);
            this.panelMenu.Controls.Add(this.btnTransactions);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(220, 450);
            this.panelMenu.TabIndex = 7;
            this.panelMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMenu_Paint);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Yu Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.Image = global::Session_16.Properties.Resources.exit;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(0, 380);
            this.btnExit.Name = "btnExit";
            this.btnExit.Padding = new System.Windows.Forms.Padding(12, 10, 0, 0);
            this.btnExit.Size = new System.Drawing.Size(220, 60);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit ";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            this.btnExit.MouseEnter += new System.EventHandler(this.btnExit_MouseEnter);
            this.btnExit.MouseLeave += new System.EventHandler(this.btnExit_MouseLeave);
            // 
            // btn_MonthlyLedger
            // 
            this.btn_MonthlyLedger.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_MonthlyLedger.FlatAppearance.BorderSize = 0;
            this.btn_MonthlyLedger.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_MonthlyLedger.Font = new System.Drawing.Font("Yu Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_MonthlyLedger.ForeColor = System.Drawing.Color.Black;
            this.btn_MonthlyLedger.Image = global::Session_16.Properties.Resources.monthlyledger;
            this.btn_MonthlyLedger.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_MonthlyLedger.Location = new System.Drawing.Point(0, 320);
            this.btn_MonthlyLedger.Name = "btn_MonthlyLedger";
            this.btn_MonthlyLedger.Padding = new System.Windows.Forms.Padding(12, 10, 0, 0);
            this.btn_MonthlyLedger.Size = new System.Drawing.Size(220, 60);
            this.btn_MonthlyLedger.TabIndex = 5;
            this.btn_MonthlyLedger.Text = "MonthlyLedger";
            this.btn_MonthlyLedger.UseVisualStyleBackColor = true;
            this.btn_MonthlyLedger.Click += new System.EventHandler(this.btn_MonthlyLedger_Click_1);
            this.btn_MonthlyLedger.MouseEnter += new System.EventHandler(this.btn_MonthlyLedger_MouseEnter);
            this.btn_MonthlyLedger.MouseLeave += new System.EventHandler(this.btn_MonthlyLedger_MouseLeave);
            // 
            // btnEmployees
            // 
            this.btnEmployees.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEmployees.FlatAppearance.BorderSize = 0;
            this.btnEmployees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmployees.Font = new System.Drawing.Font("Yu Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEmployees.ForeColor = System.Drawing.Color.Black;
            this.btnEmployees.Image = global::Session_16.Properties.Resources.employee;
            this.btnEmployees.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmployees.Location = new System.Drawing.Point(0, 260);
            this.btnEmployees.Name = "btnEmployees";
            this.btnEmployees.Padding = new System.Windows.Forms.Padding(12, 10, 0, 0);
            this.btnEmployees.Size = new System.Drawing.Size(220, 60);
            this.btnEmployees.TabIndex = 4;
            this.btnEmployees.Text = "Employees";
            this.btnEmployees.UseVisualStyleBackColor = true;
            this.btnEmployees.Click += new System.EventHandler(this.btnEmployees_Click_1);
            this.btnEmployees.MouseEnter += new System.EventHandler(this.btnEmployees_MouseEnter);
            this.btnEmployees.MouseLeave += new System.EventHandler(this.btnEmployees_MouseLeave);
            // 
            // btnServiceTasks
            // 
            this.btnServiceTasks.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnServiceTasks.FlatAppearance.BorderSize = 0;
            this.btnServiceTasks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServiceTasks.Font = new System.Drawing.Font("Yu Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnServiceTasks.ForeColor = System.Drawing.Color.Black;
            this.btnServiceTasks.Image = global::Session_16.Properties.Resources.serviceTasks;
            this.btnServiceTasks.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnServiceTasks.Location = new System.Drawing.Point(0, 200);
            this.btnServiceTasks.Name = "btnServiceTasks";
            this.btnServiceTasks.Padding = new System.Windows.Forms.Padding(12, 10, 0, 0);
            this.btnServiceTasks.Size = new System.Drawing.Size(220, 60);
            this.btnServiceTasks.TabIndex = 3;
            this.btnServiceTasks.Text = "Service Tasks";
            this.btnServiceTasks.UseVisualStyleBackColor = true;
            this.btnServiceTasks.Click += new System.EventHandler(this.btnServiceTasks_Click_1);
            this.btnServiceTasks.MouseEnter += new System.EventHandler(this.btnServiceTasks_MouseEnter);
            this.btnServiceTasks.MouseLeave += new System.EventHandler(this.btnServiceTasks_MouseLeave);
            // 
            // btnCustomerAndCars
            // 
            this.btnCustomerAndCars.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCustomerAndCars.FlatAppearance.BorderSize = 0;
            this.btnCustomerAndCars.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomerAndCars.Font = new System.Drawing.Font("Yu Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCustomerAndCars.ForeColor = System.Drawing.Color.Black;
            this.btnCustomerAndCars.Image = global::Session_16.Properties.Resources.customerandcar;
            this.btnCustomerAndCars.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomerAndCars.Location = new System.Drawing.Point(0, 140);
            this.btnCustomerAndCars.Name = "btnCustomerAndCars";
            this.btnCustomerAndCars.Padding = new System.Windows.Forms.Padding(10, 10, 30, 0);
            this.btnCustomerAndCars.Size = new System.Drawing.Size(220, 60);
            this.btnCustomerAndCars.TabIndex = 2;
            this.btnCustomerAndCars.Text = "Customers / Cars";
            this.btnCustomerAndCars.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCustomerAndCars.UseVisualStyleBackColor = true;
            this.btnCustomerAndCars.Click += new System.EventHandler(this.btnCustomerAndCars_Click_1);
            this.btnCustomerAndCars.MouseEnter += new System.EventHandler(this.btnCustomerAndCars_MouseEnter);
            this.btnCustomerAndCars.MouseLeave += new System.EventHandler(this.btnCustomerAndCars_MouseLeave);
            // 
            // btnTransactions
            // 
            this.btnTransactions.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTransactions.FlatAppearance.BorderSize = 0;
            this.btnTransactions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransactions.Font = new System.Drawing.Font("Yu Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnTransactions.ForeColor = System.Drawing.Color.Black;
            this.btnTransactions.Image = global::Session_16.Properties.Resources.transaction;
            this.btnTransactions.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTransactions.Location = new System.Drawing.Point(0, 80);
            this.btnTransactions.Name = "btnTransactions";
            this.btnTransactions.Padding = new System.Windows.Forms.Padding(12, 10, 0, 0);
            this.btnTransactions.Size = new System.Drawing.Size(220, 60);
            this.btnTransactions.TabIndex = 1;
            this.btnTransactions.Text = "Transactions";
            this.btnTransactions.UseVisualStyleBackColor = true;
            this.btnTransactions.Click += new System.EventHandler(this.btnTransactions_Click);
            this.btnTransactions.MouseEnter += new System.EventHandler(this.btnTransactions_MouseEnter);
            this.btnTransactions.MouseLeave += new System.EventHandler(this.btnTransactions_MouseLeave);
            // 
            // panelLogo
            // 
            this.panelLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(79)))), ((int)(((byte)(117)))));
            this.panelLogo.Controls.Add(this.label3);
            this.panelLogo.Controls.Add(this.label2);
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(220, 80);
            this.panelLogo.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(62, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 26);
            this.label3.TabIndex = 1;
            this.label3.Text = "Center";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(37, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 26);
            this.label2.TabIndex = 0;
            this.label2.Text = "Car Service";
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.panelTitleBar.Controls.Add(this.label1);
            this.panelTitleBar.Location = new System.Drawing.Point(220, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(580, 80);
            this.panelTitleBar.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(230, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "WELCOME";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::Session_16.Properties.Resources.Logo;
            this.pictureBox1.Location = new System.Drawing.Point(350, 120);
            this.pictureBox1.MinimumSize = new System.Drawing.Size(300, 200);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(327, 215);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // btnPopulate
            // 
            this.btnPopulate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPopulate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(234)))), ((int)(((byte)(218)))));
            this.btnPopulate.FlatAppearance.BorderSize = 0;
            this.btnPopulate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPopulate.Font = new System.Drawing.Font("Segoe Print", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPopulate.Location = new System.Drawing.Point(260, 380);
            this.btnPopulate.Name = "btnPopulate";
            this.btnPopulate.Size = new System.Drawing.Size(145, 45);
            this.btnPopulate.TabIndex = 11;
            this.btnPopulate.Text = "Populate";
            this.btnPopulate.UseVisualStyleBackColor = false;
            this.btnPopulate.Click += new System.EventHandler(this.btnPopulate_Click);
            this.btnPopulate.MouseEnter += new System.EventHandler(this.btnPopulate_MouseEnter);
            this.btnPopulate.MouseLeave += new System.EventHandler(this.btnPopulate_MouseLeave);
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnPopulate);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.panelMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainMenuForm";
            this.Text = "MainMenu";
            this.Load += new System.EventHandler(this.MainMenuForm_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Panel panelMenu;
        private Button btnTransactions;
        private Panel panelLogo;
        private Button btn_MonthlyLedger;
        private Button btnEmployees;
        private Button btnServiceTasks;
        private Button btnCustomerAndCars;
        private Label label2;
        private Panel panelTitleBar;
        private Label label1;
        private Button btnExit;
        private PictureBox pictureBox1;
        private Button btnPopulate;
        private Label label3;
    }
}