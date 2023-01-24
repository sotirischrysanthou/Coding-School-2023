namespace Session_11_Car_Service_Center {
    partial class ServiceTasksForm {
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
            this.grdServiceTasks = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelServiceTask = new DevExpress.XtraEditors.LabelControl();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHours = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bsServiceTasks = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grdServiceTasks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsServiceTasks)).BeginInit();
            this.SuspendLayout();
            // 
            // grdServiceTasks
            // 
            this.grdServiceTasks.Location = new System.Drawing.Point(21, 42);
            this.grdServiceTasks.MainView = this.gridView1;
            this.grdServiceTasks.Name = "grdServiceTasks";
            this.grdServiceTasks.Size = new System.Drawing.Size(400, 200);
            this.grdServiceTasks.TabIndex = 0;
            this.grdServiceTasks.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colCode,
            this.colDescription,
            this.colHours});
            this.gridView1.GridControl = this.grdServiceTasks;
            this.gridView1.Name = "gridView1";
            // 
            // labelServiceTask
            // 
            this.labelServiceTask.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelServiceTask.Appearance.Options.UseFont = true;
            this.labelServiceTask.Location = new System.Drawing.Point(21, 12);
            this.labelServiceTask.Name = "labelServiceTask";
            this.labelServiceTask.Size = new System.Drawing.Size(73, 24);
            this.labelServiceTask.TabIndex = 2;
            this.labelServiceTask.Text = "Services";
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.Name = "colID";
            this.colID.Visible = true;
            this.colID.VisibleIndex = 0;
            // 
            // colCode
            // 
            this.colCode.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.colCode.Caption = "Code";
            this.colCode.Name = "colCode";
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 1;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 2;
            // 
            // colHours
            // 
            this.colHours.Caption = "Hours";
            this.colHours.Name = "colHours";
            this.colHours.Visible = true;
            this.colHours.VisibleIndex = 3;
            // 
            // ServiceTasksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelServiceTask);
            this.Controls.Add(this.grdServiceTasks);
            this.Name = "ServiceTasksForm";
            this.Text = "ServiceTasksForm";
            ((System.ComponentModel.ISupportInitialize)(this.grdServiceTasks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsServiceTasks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdServiceTasks;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LabelControl labelServiceTask;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colHours;
        private BindingSource bsServiceTasks;
    }
}