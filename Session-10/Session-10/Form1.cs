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
            



        }

        private void NewUni() {
            _uni = new University("University of Athents", 185);
            int RegistrationNumber = 1;
            _uni.Students.Add(new Student("Sotiris Chrysanthou", 25, RegistrationNumber++));
            _uni.Students.Add(new Student("Fotis Chrysoulas", 44, RegistrationNumber++));
            _uni.Students.Add(new Student("Demetris Raptodimos", 25, RegistrationNumber++));
            Refresh();


        }

        private void Refresh() {
            if (_uni != null) {
                bsStudents.DataSource = _uni.Students;
                bsCourses.DataSource = _uni.Courses;
                bsGrades.DataSource = _uni.Grades;
                bsScheduledCourse.DataSource = _uni.ScheduledCourse;
            }
        }

        private void SetControlProperties() {

            serializer = new Serializer();
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
            serializer.SerializeToFile(_uni, "University.json");
            MessageBox.Show("Save Done!!!");
        }

        private void btnLoad_Click(object sender, EventArgs e) {
            _uni = serializer.Deserialize<University>("University.json");
            Refresh();
        }

        private void btnNew_Click(object sender, EventArgs e) {
            NewUni();
        }

        private void btnRefresh_Click(object sender, EventArgs e) {
            Refresh();
        }
    }
}