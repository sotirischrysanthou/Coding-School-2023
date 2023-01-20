using UniversityLib;
using SerializerLib;

namespace Session_10 {
    public partial class Form1 : Form {
        private University _uni;
        Serializer serializer;
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            SetControlProperties();
            Init();



        }

        private void Init() {
            _uni = new University("University of Athents",185);

            bsStudents.DataSource = _uni.Students;
            bsCourses.DataSource = _uni.Courses;
            bsGrades.DataSource = _uni.Grades;
            bsScheduledCourse.DataSource = _uni.ScheduledCourse;
        }

        private void SetControlProperties() {

            dgvStudents.AutoGenerateColumns = false;
            dgvCourses.AutoGenerateColumns = false;
            dgvGrades.AutoGenerateColumns = false;
            dgvScheduledCourse.AutoGenerateColumns = false;
            dgvStudents.DataSource = bsStudents;
            dgvCourses.DataSource = bsCourses;
            dgvGrades.DataSource = bsGrades;
            dgvScheduledCourse.DataSource = bsScheduledCourse;



            dgvStudents.CellContentClick += dgvStudents_CellContentClick;

        }

        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            var dgv = (DataGridView)sender;

            DataGridViewButtonColumn col = dgv.Columns[e.ColumnIndex] as DataGridViewButtonColumn;

            if (col != null && col.Name == "colShowID" && e.RowIndex >= 0) {
                Student student = dgv.CurrentRow.DataBoundItem as Student;
                MessageBox.Show($"The ID of student {student.Name} is {student.ID}");
            }
        }

        private void btnSave_Click(object sender, EventArgs e) {

        }
    }
}