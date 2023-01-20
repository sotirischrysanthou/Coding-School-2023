namespace Session_10 {
    partial class Form1 {
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
            this.dgvStudents = new System.Windows.Forms.DataGridView();
            this.StdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StdAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StdRegistrationNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShowID = new System.Windows.Forms.DataGridViewButtonColumn();
            this.bsStudents = new System.Windows.Forms.BindingSource(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvCourses = new System.Windows.Forms.DataGridView();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsCourses = new System.Windows.Forms.BindingSource(this.components);
            this.dgvScheduledCourse = new System.Windows.Forms.DataGridView();
            this.dgvGrades = new System.Windows.Forms.DataGridView();
            this.bsGrades = new System.Windows.Forms.BindingSource(this.components);
            this.bsScheduledCourse = new System.Windows.Forms.BindingSource(this.components);
            this.StudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CourseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GradesCourse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SchdlCourseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SchdlProfessorID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SchdlCalendar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsStudents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCourses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScheduledCourse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsGrades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsScheduledCourse)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStudents
            // 
            this.dgvStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StdName,
            this.StdAge,
            this.StdRegistrationNumber,
            this.colShowID});
            this.dgvStudents.Location = new System.Drawing.Point(12, 12);
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.RowTemplate.Height = 25;
            this.dgvStudents.Size = new System.Drawing.Size(614, 231);
            this.dgvStudents.TabIndex = 0;
            this.dgvStudents.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStudents_CellContentClick);
            // 
            // StdName
            // 
            this.StdName.DataPropertyName = "Name";
            this.StdName.HeaderText = "Name";
            this.StdName.Name = "StdName";
            // 
            // StdAge
            // 
            this.StdAge.DataPropertyName = "Age";
            this.StdAge.HeaderText = "Age";
            this.StdAge.Name = "StdAge";
            // 
            // StdRegistrationNumber
            // 
            this.StdRegistrationNumber.DataPropertyName = "RegistrationNumber";
            this.StdRegistrationNumber.HeaderText = "Registration Number";
            this.StdRegistrationNumber.Name = "StdRegistrationNumber";
            // 
            // colShowID
            // 
            this.colShowID.HeaderText = "ID";
            this.colShowID.Name = "colShowID";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(653, 527);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvCourses
            // 
            this.dgvCourses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCourses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCourses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Code,
            this.Subject});
            this.dgvCourses.Location = new System.Drawing.Point(643, 12);
            this.dgvCourses.Name = "dgvCourses";
            this.dgvCourses.RowTemplate.Height = 25;
            this.dgvCourses.Size = new System.Drawing.Size(616, 231);
            this.dgvCourses.TabIndex = 2;
            // 
            // Code
            // 
            this.Code.DataPropertyName = "Code";
            this.Code.HeaderText = "Code";
            this.Code.Name = "Code";
            // 
            // Subject
            // 
            this.Subject.DataPropertyName = "Subject";
            this.Subject.HeaderText = "Subject";
            this.Subject.Name = "Subject";
            // 
            // dgvScheduledCourse
            // 
            this.dgvScheduledCourse.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvScheduledCourse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvScheduledCourse.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SchdlCourseID,
            this.SchdlProfessorID,
            this.SchdlCalendar});
            this.dgvScheduledCourse.Location = new System.Drawing.Point(643, 249);
            this.dgvScheduledCourse.Name = "dgvScheduledCourse";
            this.dgvScheduledCourse.RowTemplate.Height = 25;
            this.dgvScheduledCourse.Size = new System.Drawing.Size(616, 234);
            this.dgvScheduledCourse.TabIndex = 4;
            // 
            // dgvGrades
            // 
            this.dgvGrades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGrades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StudentID,
            this.CourseID,
            this.GradesCourse});
            this.dgvGrades.Location = new System.Drawing.Point(12, 249);
            this.dgvGrades.Name = "dgvGrades";
            this.dgvGrades.RowTemplate.Height = 25;
            this.dgvGrades.Size = new System.Drawing.Size(614, 234);
            this.dgvGrades.TabIndex = 3;
            // 
            // StudentID
            // 
            this.StudentID.DataPropertyName = "StudentID";
            this.StudentID.HeaderText = "Student ID";
            this.StudentID.Name = "StudentID";
            // 
            // CourseID
            // 
            this.CourseID.DataPropertyName = "CourseID";
            this.CourseID.HeaderText = "Course ID";
            this.CourseID.Name = "CourseID";
            // 
            // GradesCourse
            // 
            this.GradesCourse.DataPropertyName = "GradesCourse";
            this.GradesCourse.HeaderText = "Grade";
            this.GradesCourse.Name = "GradesCourse";
            // 
            // SchdlCourseID
            // 
            this.SchdlCourseID.DataPropertyName = "CourseID";
            this.SchdlCourseID.HeaderText = "Course ID";
            this.SchdlCourseID.Name = "SchdlCourseID";
            // 
            // SchdlProfessorID
            // 
            this.SchdlProfessorID.DataPropertyName = "ProfessorID";
            this.SchdlProfessorID.HeaderText = "Professor ID";
            this.SchdlProfessorID.Name = "SchdlProfessorID";
            // 
            // SchdlCalendar
            // 
            this.SchdlCalendar.DataPropertyName = "Calendar";
            this.SchdlCalendar.HeaderText = "Calendar";
            this.SchdlCalendar.Name = "SchdlCalendar";
            this.SchdlCalendar.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1271, 552);
            this.Controls.Add(this.dgvScheduledCourse);
            this.Controls.Add(this.dgvGrades);
            this.Controls.Add(this.dgvCourses);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvStudents);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsStudents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCourses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScheduledCourse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsGrades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsScheduledCourse)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dgvStudents;
        private BindingSource bsStudents;
        private Button btnSave;
        private DataGridView dgvCourses;
        private DataGridViewTextBoxColumn Code;
        private DataGridViewTextBoxColumn Subject;
        private BindingSource bsCourses;
        private DataGridViewTextBoxColumn StdName;
        private DataGridViewTextBoxColumn StdAge;
        private DataGridViewTextBoxColumn StdRegistrationNumber;
        private DataGridViewButtonColumn colShowID;
        private DataGridView dgvScheduledCourse;
        private DataGridView dgvGrades;
        private BindingSource bsGrades;
        private BindingSource bsScheduledCourse;
        private DataGridViewTextBoxColumn StudentID;
        private DataGridViewTextBoxColumn CourseID;
        private DataGridViewTextBoxColumn GradesCourse;
        private DataGridViewTextBoxColumn SchdlCourseID;
        private DataGridViewTextBoxColumn SchdlProfessorID;
        private DataGridViewTextBoxColumn SchdlCalendar;
    }
}