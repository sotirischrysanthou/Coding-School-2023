using Session_06;

namespace Session_10 {
    public partial class Form1 : Form {
        List<Student> students;
        List<Course> courses;
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            SetControlProperties();
            Init();
            
            
            
        }

        private void Init() {
            students = new List<Student>();
            students.Add(new Student("Sotiris Chrysanthou", 25, 1));
            bsStudents.DataSource = students;

            courses = new List<Course>();
            courses.Add(new Course("A05","IP"));
            courses.Add(new Course("A06","OOP"));
            bsCourses.DataSource = courses;
        }

        private void SetControlProperties() {

            dgvStudents.AutoGenerateColumns = false;
            dgvCourses.AutoGenerateColumns = false;
            dgvStudents.DataSource = bsStudents;
            dgvCourses.DataSource = bsCourses;

            

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