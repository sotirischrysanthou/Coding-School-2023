﻿namespace Session_11_Car_Service_Center {
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
            this.btnPopulate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_MonthlyLedger = new System.Windows.Forms.Button();
            this.btnEmployees = new System.Windows.Forms.Button();
            this.btnServiceTasks = new System.Windows.Forms.Button();
            this.btnCustomerAndCars = new System.Windows.Forms.Button();
            this.btnTransactions = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.panelTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPopulate
            // 
            this.btnPopulate.Location = new System.Drawing.Point(335, 414);
            this.btnPopulate.Name = "btnPopulate";
            this.btnPopulate.Size = new System.Drawing.Size(125, 23);
            this.btnPopulate.TabIndex = 2;
            this.btnPopulate.Text = "Populate";
            this.btnPopulate.UseVisualStyleBackColor = true;
            this.btnPopulate.Click += new System.EventHandler(this.btnPopulate_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(466, 415);
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
            this.btnLoad.Location = new System.Drawing.Point(597, 414);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(125, 22);
            this.btnLoad.TabIndex = 5;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(234)))), ((int)(((byte)(218)))));
            this.panelMenu.Controls.Add(this.button1);
            this.panelMenu.Controls.Add(this.btn_MonthlyLedger);
            this.panelMenu.Controls.Add(this.btnEmployees);
            this.panelMenu.Controls.Add(this.btnServiceTasks);
            this.panelMenu.Controls.Add(this.btnCustomerAndCars);
            this.panelMenu.Controls.Add(this.btnTransactions);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(220, 450);
            this.panelMenu.TabIndex = 7;
            this.panelMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMenu_Paint);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Image = global::Session_11_Car_Service_Center.Properties.Resources.exit;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(0, 380);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(12, 10, 0, 0);
            this.button1.Size = new System.Drawing.Size(220, 60);
            this.button1.TabIndex = 6;
            this.button1.Text = "Exit ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btn_MonthlyLedger
            // 
            this.btn_MonthlyLedger.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_MonthlyLedger.FlatAppearance.BorderSize = 0;
            this.btn_MonthlyLedger.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_MonthlyLedger.ForeColor = System.Drawing.Color.Black;
            this.btn_MonthlyLedger.Image = global::Session_11_Car_Service_Center.Properties.Resources.monthlyledger;
            this.btn_MonthlyLedger.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_MonthlyLedger.Location = new System.Drawing.Point(0, 320);
            this.btn_MonthlyLedger.Name = "btn_MonthlyLedger";
            this.btn_MonthlyLedger.Padding = new System.Windows.Forms.Padding(12, 10, 0, 0);
            this.btn_MonthlyLedger.Size = new System.Drawing.Size(220, 60);
            this.btn_MonthlyLedger.TabIndex = 5;
            this.btn_MonthlyLedger.Text = "MonthlyLedger";
            this.btn_MonthlyLedger.UseVisualStyleBackColor = true;
            this.btn_MonthlyLedger.Click += new System.EventHandler(this.btn_MonthlyLedger_Click_1);
            // 
            // btnEmployees
            // 
            this.btnEmployees.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEmployees.FlatAppearance.BorderSize = 0;
            this.btnEmployees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmployees.ForeColor = System.Drawing.Color.Black;
            this.btnEmployees.Image = global::Session_11_Car_Service_Center.Properties.Resources.employee;
            this.btnEmployees.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmployees.Location = new System.Drawing.Point(0, 260);
            this.btnEmployees.Name = "btnEmployees";
            this.btnEmployees.Padding = new System.Windows.Forms.Padding(12, 10, 0, 0);
            this.btnEmployees.Size = new System.Drawing.Size(220, 60);
            this.btnEmployees.TabIndex = 4;
            this.btnEmployees.Text = "Employees";
            this.btnEmployees.UseVisualStyleBackColor = true;
            this.btnEmployees.Click += new System.EventHandler(this.btnEmployees_Click_1);
            // 
            // btnServiceTasks
            // 
            this.btnServiceTasks.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnServiceTasks.FlatAppearance.BorderSize = 0;
            this.btnServiceTasks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServiceTasks.ForeColor = System.Drawing.Color.Black;
            this.btnServiceTasks.Image = global::Session_11_Car_Service_Center.Properties.Resources.serviceTasks;
            this.btnServiceTasks.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnServiceTasks.Location = new System.Drawing.Point(0, 200);
            this.btnServiceTasks.Name = "btnServiceTasks";
            this.btnServiceTasks.Padding = new System.Windows.Forms.Padding(12, 10, 0, 0);
            this.btnServiceTasks.Size = new System.Drawing.Size(220, 60);
            this.btnServiceTasks.TabIndex = 3;
            this.btnServiceTasks.Text = "Service Tasks";
            this.btnServiceTasks.UseVisualStyleBackColor = true;
            this.btnServiceTasks.Click += new System.EventHandler(this.btnServiceTasks_Click_1);
            // 
            // btnCustomerAndCars
            // 
            this.btnCustomerAndCars.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCustomerAndCars.FlatAppearance.BorderSize = 0;
            this.btnCustomerAndCars.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomerAndCars.ForeColor = System.Drawing.Color.Black;
            this.btnCustomerAndCars.Image = global::Session_11_Car_Service_Center.Properties.Resources.customerandcar;
            this.btnCustomerAndCars.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomerAndCars.Location = new System.Drawing.Point(0, 140);
            this.btnCustomerAndCars.Name = "btnCustomerAndCars";
            this.btnCustomerAndCars.Padding = new System.Windows.Forms.Padding(12, 10, 0, 0);
            this.btnCustomerAndCars.Size = new System.Drawing.Size(220, 60);
            this.btnCustomerAndCars.TabIndex = 2;
            this.btnCustomerAndCars.Text = "Customers And Cars";
            this.btnCustomerAndCars.UseVisualStyleBackColor = true;
            this.btnCustomerAndCars.Click += new System.EventHandler(this.btnCustomerAndCars_Click_1);
            // 
            // btnTransactions
            // 
            this.btnTransactions.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTransactions.FlatAppearance.BorderSize = 0;
            this.btnTransactions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransactions.ForeColor = System.Drawing.Color.Black;
            this.btnTransactions.Image = global::Session_11_Car_Service_Center.Properties.Resources.transaction;
            this.btnTransactions.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTransactions.Location = new System.Drawing.Point(0, 80);
            this.btnTransactions.Name = "btnTransactions";
            this.btnTransactions.Padding = new System.Windows.Forms.Padding(12, 10, 0, 0);
            this.btnTransactions.Size = new System.Drawing.Size(220, 60);
            this.btnTransactions.TabIndex = 1;
            this.btnTransactions.Text = "Transaction";
            this.btnTransactions.UseVisualStyleBackColor = true;
            this.btnTransactions.Click += new System.EventHandler(this.btnTransactions_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(79)))), ((int)(((byte)(117)))));
            this.panelLogo.Controls.Add(this.label2);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(220, 80);
            this.panelLogo.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Algerian", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(28, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Car Service Center";
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.panelTitleBar.Controls.Add(this.label1);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
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
            this.label1.Location = new System.Drawing.Point(236, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "HOME";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Session_11_Car_Service_Center.Properties.Resources.Logo;
            this.pictureBox1.Location = new System.Drawing.Point(351, 149);
            this.pictureBox1.MinimumSize = new System.Drawing.Size(300, 200);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(327, 215);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnPopulate);
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
        private Button btnPopulate;
        private Button btnSave;
        private Button btnLoad;
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
        private PictureBox pictureBox1;
        private Button button1;
    }
}