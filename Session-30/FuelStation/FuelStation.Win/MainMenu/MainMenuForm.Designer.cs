namespace FuelStation.Win {
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
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnItems = new System.Windows.Forms.Button();
            this.btnCustomers = new System.Windows.Forms.Button();
            this.btnTransactions = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
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
            // panelMenu
            // 
            this.panelMenu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(234)))), ((int)(((byte)(218)))));
            this.panelMenu.Controls.Add(this.btnLogout);
            this.panelMenu.Controls.Add(this.btnItems);
            this.panelMenu.Controls.Add(this.btnCustomers);
            this.panelMenu.Controls.Add(this.btnTransactions);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(220, 450);
            this.panelMenu.TabIndex = 7;
            this.panelMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMenu_Paint);
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Yu Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLogout.ForeColor = System.Drawing.Color.Black;
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(0, 367);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(12, 10, 0, 0);
            this.btnLogout.Size = new System.Drawing.Size(220, 83);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            this.btnLogout.MouseEnter += new System.EventHandler(this.btnLogout_MouseEnter);
            this.btnLogout.MouseLeave += new System.EventHandler(this.btnLogout_MouseLeave);
            // 
            // btnItems
            // 
            this.btnItems.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnItems.FlatAppearance.BorderSize = 0;
            this.btnItems.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnItems.Font = new System.Drawing.Font("Yu Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnItems.ForeColor = System.Drawing.Color.Black;
            this.btnItems.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnItems.Location = new System.Drawing.Point(0, 175);
            this.btnItems.Name = "btnItems";
            this.btnItems.Padding = new System.Windows.Forms.Padding(12, 10, 0, 0);
            this.btnItems.Size = new System.Drawing.Size(220, 90);
            this.btnItems.TabIndex = 3;
            this.btnItems.Text = "Items";
            this.btnItems.UseVisualStyleBackColor = true;
            this.btnItems.Click += new System.EventHandler(this.btnItems_Click);
            this.btnItems.MouseEnter += new System.EventHandler(this.btnItems_MouseEnter);
            this.btnItems.MouseLeave += new System.EventHandler(this.btnItems_MouseLeave);
            // 
            // btnCustomers
            // 
            this.btnCustomers.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCustomers.FlatAppearance.BorderSize = 0;
            this.btnCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomers.Font = new System.Drawing.Font("Yu Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCustomers.ForeColor = System.Drawing.Color.Black;
            this.btnCustomers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomers.Location = new System.Drawing.Point(0, 271);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Padding = new System.Windows.Forms.Padding(10, 10, 30, 0);
            this.btnCustomers.Size = new System.Drawing.Size(220, 90);
            this.btnCustomers.TabIndex = 2;
            this.btnCustomers.Text = "        Customers";
            this.btnCustomers.UseVisualStyleBackColor = true;
            this.btnCustomers.Click += new System.EventHandler(this.btnCustomers_Click);
            this.btnCustomers.MouseEnter += new System.EventHandler(this.btnCustomerAndCars_MouseEnter);
            this.btnCustomers.MouseLeave += new System.EventHandler(this.btnCustomerAndCars_MouseLeave);
            // 
            // btnTransactions
            // 
            this.btnTransactions.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTransactions.FlatAppearance.BorderSize = 0;
            this.btnTransactions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransactions.Font = new System.Drawing.Font("Yu Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnTransactions.ForeColor = System.Drawing.Color.Black;
            this.btnTransactions.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTransactions.Location = new System.Drawing.Point(0, 79);
            this.btnTransactions.Name = "btnTransactions";
            this.btnTransactions.Padding = new System.Windows.Forms.Padding(12, 10, 0, 0);
            this.btnTransactions.Size = new System.Drawing.Size(220, 90);
            this.btnTransactions.TabIndex = 1;
            this.btnTransactions.Text = " Transactions";
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
            this.label3.Location = new System.Drawing.Point(80, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 26);
            this.label3.TabIndex = 1;
            this.label3.Text = "Station";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(34, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 26);
            this.label2.TabIndex = 0;
            this.label2.Text = "Fuel";
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
            this.pictureBox1.Location = new System.Drawing.Point(350, 120);
            this.pictureBox1.MinimumSize = new System.Drawing.Size(300, 200);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(327, 215);
            this.pictureBox1.TabIndex = 14;
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
        private Button btnItems;
        private Button btnCustomers;
        private Label label2;
        private Panel panelTitleBar;
        private Label label1;
        private Button btnLogout;
        private PictureBox pictureBox1;
        private Label label3;
    }
}